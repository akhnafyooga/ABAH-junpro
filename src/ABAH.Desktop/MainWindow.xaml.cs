using System.Data;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ABAH.Desktop.Views;
using Microsoft.Win32;
using Npgsql;

namespace ABAH.Desktop;

public partial class MainWindow : Window
{
    private NpgsqlDataSource? _database;
    private int _page = 1;
    private int _collector;


    public MainWindow()
    {
        InitializeComponent();
        Loaded += async (_, _) => await ShowPageAsync();
    }

    private async void Navigate_Click(object sender, RoutedEventArgs e)
    {
        _page = int.Parse((string)((RadioButton)sender).Tag, CultureInfo.InvariantCulture);
        if (_page == 9)
        {
            Close();
            return;
        }
        await ShowPageAsync();
    }

    private NpgsqlDataSource Database()
    {
        var connection = Environment.GetEnvironmentVariable("ABAH_POSTGRES_CONNECTION");
        if (string.IsNullOrWhiteSpace(connection))
            throw new InvalidOperationException("Set ABAH_POSTGRES_CONNECTION and restart ABAH. See the README.");
        return _database ??= NpgsqlDataSource.Create(connection);
    }

    private async Task<DataView> QueryAsync(string sql, params object[] values)
    {
        await using var command = Command(sql, values);
        await using var reader = await command.ExecuteReaderAsync();
        var table = new DataTable();
        table.Load(reader);
        return table.DefaultView;
    }

    private NpgsqlCommand Command(string sql, object[] values)
    {
        var command = Database().CreateCommand(sql);
        for (int i = 0; i < values.Length; i++)
            command.Parameters.AddWithValue($"p{i}", values[i]);
        return command;
    }

    private async Task SaveAsync(string sql, params object[] values)
    {
        await using var cmd = Command(sql, values);
        if (await cmd.ExecuteNonQueryAsync() == 0)
            throw new InvalidOperationException("This action is unavailable. Refresh and check the latest state.");
    }

    private async Task ShowPageAsync()
    {
        string[] names = ["Dashboard", "Waste Listings", "Offers", "Pickups", "Verification", "Transactions", "Impact", "Settings"];
        int page = _page;
        PageTitle.Text = names[page - 1];
        var panel = new StackPanel { Margin = new Thickness(28) };
        PageHost.Content = new ScrollViewer { Content = panel, VerticalScrollBarVisibility = ScrollBarVisibility.Auto };
        var feedback = Label(panel, "");
        var controls = new StackPanel();
        panel.Children.Add(controls);
        AddButton(controls, "Refresh", ShowPageAsync);
        var grid = new DataGrid
        {
            IsReadOnly = true, AutoGenerateColumns = true, CanUserAddRows = false,
            SelectionMode = DataGridSelectionMode.Single, MinHeight = 140, MaxHeight = 330,
            Margin = new Thickness(0, 12, 0, 12)
        };

        void Action(string title, Func<Task> work)
        {
            AddButton(controls, title, async () =>
            {
                controls.IsEnabled = false;
                feedback.Text = "Saving...";
                try
                {
                    await work();
                    if (_page == page)
                    {
                        await ShowPageAsync();
                        if (PageHost.Content is ScrollViewer { Content: StackPanel current }
                            && current.Children[0] is TextBlock message && string.IsNullOrEmpty(message.Text))
                            message.Text = "Saved.";
                    }
                }
                catch (Exception ex) when (Handled(ex)) { feedback.Text = Error(ex); }
                finally { controls.IsEnabled = true; }
            });
        }

        int Id() => grid.SelectedItem is DataRowView row
            ? Convert.ToInt32(row[0]) : throw new InvalidOperationException("Select a row first.");
        int Collector() => _collector > 0 ? _collector :
            throw new InvalidOperationException("Choose a demo collector in Settings first.");
        try
        {
            if (page == 8)
            {
                Label(controls, "Local demo session. Choose Producer or a seeded Collector. This does not authenticate an account.");
                AddButton(controls, "Use Producer", () => { _collector = 0; return ShowPageAsync(); });
                foreach (DataRowView row in await QueryAsync("SELECT collector_id, name FROM collectors ORDER BY name"))
                {
                    int id = Convert.ToInt32(row[0]);
                    AddButton(controls, $"Use Collector: {row[1]}", () => { _collector = id; return ShowPageAsync(); });
                }
                feedback.Text = _collector == 0 ? "Current role: Producer" : $"Current role: Collector #{_collector}";
                return;
            }
            controls.Children.Add(grid);
            if (page is 1 or 7)
            {
                grid.ItemsSource = await QueryAsync(page == 1 ? """
                    SELECT (SELECT count(*) FROM waste_listings WHERE NOT reserved) AS "Available listings",
                    count(*) FILTER (WHERE status='Pending') AS "Pending offers",
                    count(*) FILTER (WHERE status NOT IN ('Pending','Completed')) AS "Active pickups",
                    coalesce(sum(actual_kg) FILTER (WHERE status='Completed'), 0) AS "Completed kg"
                    FROM workflow_offers
                    """ : """
                    SELECT l.material_type AS "Material", count(*) AS "Completed pickups", sum(o.actual_kg) AS "Completed kg"
                    FROM workflow_offers o JOIN waste_listings l ON l.listing_id=o.listing_id
                    WHERE o.status='Completed' GROUP BY l.material_type ORDER BY l.material_type
                    """);
            }
            else if (page == 2)
            {
                grid.ItemsSource = await QueryAsync("""
                    SELECT listing_id AS "ID", material_type AS "Material", estimated_weight_kg AS "Estimated kg",
                    mode AS "Mode", pickup_area AS "Area" FROM waste_listings WHERE NOT reserved ORDER BY listing_id DESC
                    """);
                if (_collector == 0)
                {
                    var material = Field(controls, "Material");
                    var kg = Field(controls, "Estimated kg");
                    var area = Field(controls, "Pickup area");
                    var mode = new ComboBox { ItemsSource = new[] { "Trade", "Donation" }, SelectedIndex = 0 };
                    controls.Children.Add(mode);
                    Action("Publish listing", () => SaveAsync("""
                        INSERT INTO waste_listings(material_type,estimated_weight_kg,pickup_area,mode)
                        VALUES (@p0,@p1,@p2,@p3)
                        """, Required(material), Number(kg, positive: true), Required(area), (string)mode.SelectedItem));
                }
                else
                {
                    var rate = Field(controls, "Trade rate (Rp/kg)", "0");
                    var fee = Field(controls, "Pickup fee (Rp)", "0");
                    var schedule = Field(controls, "Pickup time (WIB, yyyy-MM-dd HH:mm)",
                        DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7)).AddDays(1).ToString("yyyy-MM-dd HH:mm"));
                    Action("Submit offer for selected listing", () =>
                    {
                        if (grid.SelectedItem is not DataRowView listing)
                            throw new InvalidOperationException("Select a listing first.");
                        bool donation = (string)listing[3] == "Donation";
                        var price = donation ? 0 : Number(rate, positive: true);
                        var pickupFee = donation ? 0 : Number(fee);
                        if (!DateTime.TryParseExact(schedule.Text.Trim(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out var date))
                            throw new InvalidOperationException("Enter a pickup time in yyyy-MM-dd HH:mm format.");
                        var utc = new DateTimeOffset(date, TimeSpan.FromHours(7)).UtcDateTime;
                        if (utc <= DateTime.UtcNow)
                            throw new InvalidOperationException("Choose a future pickup time.");
                        return SaveAsync("""
                            INSERT INTO workflow_offers(listing_id,collector_id,rate,fee,scheduled_at)
                            SELECT listing_id,@p1,@p2,@p3,@p4 FROM waste_listings
                            WHERE listing_id=@p0 AND NOT reserved AND @p3 <= estimated_weight_kg * @p2
                            """, Id(), Collector(), price, pickupFee, utc);
                    });
                }
            }
            else
            {
                string filter = page switch
                {
                    3 => "o.status='Pending' AND NOT l.reserved",
                    4 => "o.status NOT IN ('Pending','Completed')",
                    5 => "o.status IN ('Collected','Review','Correction')",
                    _ => "o.status IN ('Verified','Recorded','Completed')"
                };
                grid.ItemsSource = await QueryAsync($"""
                    SELECT o.id AS "ID", l.material_type AS "Material", l.mode AS "Mode",
                    c.name AS "Collector", o.scheduled_at AT TIME ZONE 'Asia/Jakarta' AS "Pickup (WIB)",
                    o.status AS "Status", o.rate AS "Rp/kg", o.fee AS "Fee",
                    round(l.estimated_weight_kg * o.rate - o.fee, 2) AS "Estimated net",
                    o.actual_kg AS "Measured kg",
                    round(o.actual_kg * o.rate - o.fee, 2) AS "Measured net",
                    o.correction AS "Correction reason", o.payment_reference AS "Payment reference"
                    FROM workflow_offers o JOIN waste_listings l ON l.listing_id=o.listing_id
                    JOIN collectors c ON c.collector_id=o.collector_id
                    WHERE ({filter}) AND (@p0=0 OR o.collector_id=@p0) ORDER BY o.id DESC
                    """, _collector);
                if (page == 3 && _collector == 0)
                    Action("Accept offer", () => SaveAsync("""
                        WITH reserved_listing AS (
                            UPDATE waste_listings l SET reserved=true FROM workflow_offers o
                            WHERE o.id=@p0 AND o.listing_id=l.listing_id AND NOT l.reserved
                              AND o.status='Pending' AND o.scheduled_at > now()
                            RETURNING l.listing_id
                        )
                        UPDATE workflow_offers o SET status='Scheduled' FROM reserved_listing r
                        WHERE o.id=@p0 AND o.listing_id=r.listing_id
                        """, Id()));
                if (page == 4 && _collector != 0)
                    Action("Mark collected", () => SaveAsync("""
                        UPDATE workflow_offers SET status='Collected'
                        WHERE id=@p0 AND collector_id=@p1 AND status='Scheduled'
                        """, Id(), Collector()));
                if (page == 5 && _collector != 0)
                {
                    var weight = Field(controls, "Actual measured kg");
                    var photo = Label(controls, "No scale photo selected.");
                    string? evidencePath = null;
                    AddButton(controls, "Choose scale photo", () =>
                    {
                        var dialog = new OpenFileDialog { Filter = "Images|*.jpg;*.jpeg;*.png" };
                        if (dialog.ShowDialog(this) == true)
                        {
                            evidencePath = dialog.FileName;
                            photo.Text = Path.GetFileName(dialog.FileName);
                        }
                        return Task.CompletedTask;
                    });
                    Action("Submit measured weight", async () =>
                    {
                        int id = Id();
                        decimal kg = Number(weight, positive: true);
                        var path = evidencePath ?? throw new InvalidOperationException("Choose a scale photo.");
                        await using var file = File.OpenRead(path);
                        if (file.Length is < 8 or > 5_000_000)
                            throw new InvalidOperationException("Choose a JPEG or PNG under 5 MB.");
                        var image = new byte[(int)file.Length];
                        await file.ReadExactlyAsync(image);
                        if (!(image[0] == 255 && image[1] == 216)
                            && !image.AsSpan(0, 8).SequenceEqual(new byte[] {137,80,78,71,13,10,26,10}))
                            throw new InvalidOperationException("Choose a valid JPEG or PNG.");
                        await SaveAsync("""
                            UPDATE workflow_offers SET status='Review',actual_kg=@p2,evidence=@p3
                            WHERE id=@p0 AND collector_id=@p1 AND status IN ('Collected','Correction')
                              AND @p2 * rate >= fee
                            """, id, Collector(), kg, image);
                    });
                }
                if (page is 5 or 6)
                {
                    AddButton(controls, "View scale photo", async () =>
                    {
                        try
                        {
                            await using var cmd = Command("""
                                SELECT evidence FROM workflow_offers WHERE id=@p0 AND (@p1=0 OR collector_id=@p1)
                                """, [Id(), _collector]);
                            if (await cmd.ExecuteScalarAsync() is not byte[] bytes)
                                throw new InvalidOperationException("No photo is available yet.");
                            using var stream = new MemoryStream(bytes);
                            var bitmap = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                            new Window { Owner = this, Title = "Scale evidence", Width = 620, Height = 500,
                                Content = new Image { Source = bitmap } }.ShowDialog();
                        }
                        catch (Exception ex) when (Handled(ex) || ex is NotSupportedException)
                        { feedback.Text = Error(ex); }
                    });
                }
                if (page == 5 && _collector == 0)
                {
                    Action("Confirm weight", () => SaveAsync("""
                        UPDATE workflow_offers o SET
                            status=CASE WHEN l.mode='Donation' THEN 'Completed' ELSE 'Verified' END,
                            completed_at=CASE WHEN l.mode='Donation' THEN now() END
                        FROM waste_listings l
                        WHERE o.id=@p0 AND l.listing_id=o.listing_id AND o.status='Review'
                        """, Id()));
                    var reason = Field(controls, "Correction reason");
                    Action("Request correction", () => SaveAsync("""
                        UPDATE workflow_offers SET status='Correction',correction=@p1
                        WHERE id=@p0 AND status='Review'
                        """, Id(), Required(reason)));
                }
                if (page == 6 && _collector != 0)
                {
                    var reference = Field(controls, "External payment reference");
                    Action("Record payment", () => SaveAsync("""
                        UPDATE workflow_offers SET status='Recorded',payment_reference=@p2
                        WHERE id=@p0 AND collector_id=@p1 AND status='Verified'
                        """, Id(), Collector(), Required(reference)));
                }
                if (page == 6 && _collector == 0)
                    Action("Acknowledge receipt", () => SaveAsync("""
                        UPDATE workflow_offers SET status='Completed',completed_at=now()
                        WHERE id=@p0 AND status='Recorded'
                        """, Id()));
            }
            feedback.Text = $"{(_collector == 0 ? "Producer" : $"Collector #{_collector}")} demo session · "
                + (grid.Items.Count == 0 ? "No records yet." : "Select a row to act on it.");
        }
        catch (Exception ex) when (Handled(ex)) { feedback.Text = Error(ex); }
    }

    private static bool Handled(Exception ex) =>
        ex is NpgsqlException or ArgumentException or InvalidOperationException or IOException;

    private static string Error(Exception ex) => ex is PostgresException { SqlState: "42P01" or "42703" }
        ? "Apply database scripts 001, 002 and 003 in order, then refresh."
        : ex is NpgsqlException ? "Database operation could not be confirmed. Check PostgreSQL and refresh before retrying."
        : ex.Message;

    private static string Required(TextBox field) => string.IsNullOrWhiteSpace(field.Text)
        ? throw new InvalidOperationException($"Enter {field.Tag}.") : field.Text.Trim();

    private static decimal Number(TextBox field, bool positive = false)
    {
        if (!decimal.TryParse(field.Text.Trim(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var value)
            || value > 99_999_999 || value != decimal.Round(value, 2) || (positive && value == 0))
            throw new InvalidOperationException($"Enter a valid {field.Tag} with up to two decimal places. Use a dot for decimals.");
        return value;
    }

    private static TextBlock Label(Panel parent, string text)
    {
        var label = new TextBlock { Text = text, TextWrapping = TextWrapping.Wrap, Margin = new Thickness(0, 6, 0, 6) };
        parent.Children.Add(label);
        return label;
    }

    private static TextBox Field(Panel parent, string label, string value = "")
    {
        Label(parent, label);
        var field = new TextBox { Text = value, Tag = label, MaxLength = 200, MinHeight = 28,
            Width = 340, HorizontalAlignment = HorizontalAlignment.Left };
        parent.Children.Add(field);
        return field;
    }

    private void AddButton(Panel parent, string title, Func<Task> action)
    {
        var button = new Button { Content = title, HorizontalAlignment = HorizontalAlignment.Left,
            Margin = new Thickness(0, 8, 0, 0), Style = (Style)FindResource("PrimaryButton") };
        button.Click += async (_, _) => await action();
        parent.Children.Add(button);
    }

    protected override void OnClosed(EventArgs e)
    {
        _database?.Dispose();
        base.OnClosed(e);
    }
}
