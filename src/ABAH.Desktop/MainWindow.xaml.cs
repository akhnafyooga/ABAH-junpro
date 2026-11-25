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
    private bool _loadingRoles;
    private sealed record DemoRole(int Id, string Name);


    public MainWindow()
    {
        InitializeComponent();
        Loaded += async (_, _) =>
        {
            await LoadRolesAsync();
            await ShowPageAsync();
        };
    }

    private async Task LoadRolesAsync()
    {
        _loadingRoles = true;
        var roles = new List<DemoRole> { new(0, "Producer") };
        try
        {
            foreach (DataRowView row in await QueryAsync("SELECT collector_id, name FROM collectors ORDER BY name"))
                roles.Add(new DemoRole((int)row[0], (string)row[1]));
        }
        catch (Exception ex) when (Handled(ex))
        {
            RoleSelector.ToolTip = Error(ex);
        }
        finally
        {
            RoleSelector.ItemsSource = roles;
            RoleSelector.SelectedValue = _collector;
            RoleSelector.IsEnabled = roles.Count > 1;
            if (RoleSelector.IsEnabled) RoleSelector.ToolTip = null;
            _loadingRoles = false;
        }
    }

    private async void RoleSelector_Changed(object sender, SelectionChangedEventArgs e)
    {
        if (_loadingRoles || RoleSelector.SelectedValue is not int id || id == _collector) return;
        _collector = id;
        await ShowPageAsync();
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
        Title = $"ABAH — {PageTitle.Text}";
        var panel = new StackPanel { Margin = new Thickness(28) };
        PageHost.Content = new ScrollViewer { Content = panel, VerticalScrollBarVisibility = ScrollBarVisibility.Auto };
        var feedback = Label(panel, "");
        Label(panel, page switch
        {
            1 => "See what is ready to collect and how much material has been recovered.",
            2 => _collector == 0 ? "Share material that a local collector can pick up." : "Choose material and propose a pickup.",
            3 => "Review the pickup time and estimated proceeds before accepting.",
            4 => "Check the pickup area and mark material collected when it changes hands.",
            5 => "Use a scale photo and measured weight to confirm what was collected.",
            6 => "Check final amounts and acknowledge payments made outside ABAH.",
            7 => "Track verified material from completed pickups.",
            _ => "Choose which side of the local demo to try."
        });
        var controls = new StackPanel();
        panel.Children.Add(controls);
        AddButton(controls, "Refresh", async () => { if (!RoleSelector.IsEnabled) await LoadRolesAsync(); await ShowPageAsync(); });
        var grid = new ListBox
        {
            Background = System.Windows.Media.Brushes.White, BorderThickness = new Thickness(0),
            SelectionMode = SelectionMode.Single, MaxHeight = 330,
            Margin = new Thickness(0, 12, 0, 12)
        };

        var actions = new List<(Button Button, string[] States)>();
        void Action(string title, Func<Task> work, params string[] states)
        {
            var button = AddButton(controls, title, async () =>
            {
                controls.IsEnabled = false;
                RoleSelector.IsEnabled = false;
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
                finally
                {
                    controls.IsEnabled = true;
                    RoleSelector.IsEnabled = RoleSelector.Items.Count > 1;
                }
            });
            if (title != "Publish listing") actions.Add((button, states));
        }

        DataRowView? Selected() => (grid.SelectedItem as ListBoxItem)?.Tag as DataRowView;
        void UpdateActions()
        {
            var row = Selected();
            foreach (var (button, states) in actions)
                button.IsEnabled = row != null && (states.Length == 0 || states.Contains(row["Status"].ToString()));
        }
        grid.SelectionChanged += (_, _) => UpdateActions();

        int Id() => Selected() is DataRowView row
            ? Convert.ToInt32(row[0]) : throw new InvalidOperationException("Select a row first.");
        int Collector() => _collector > 0 ? _collector :
            throw new InvalidOperationException("Choose a demo collector from the top-right role selector.");
        DataView records;
        try
        {
            if (page == 8)
            {
                Label(controls, "Use the Demo role selector at the top right to switch between Producer and Collector.");
                feedback.Text = _collector == 0 ? "Current role: Producer" : $"Current role: Collector #{_collector}";
                return;
            }
            controls.Children.Add(grid);
            if (page is 1 or 7)
            {
                records = await QueryAsync(page == 1 ? """
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
                records = await QueryAsync("""
                    SELECT listing_id AS "ID", material_type AS "Material", estimated_weight_kg AS "Estimated kg",
                    mode AS "Mode", pickup_area AS "Area" FROM waste_listings WHERE NOT reserved ORDER BY listing_id DESC
                    """);
                if (_collector == 0)
                {
                    var material = Field(controls, "Material");
                    var kg = Field(controls, "Estimated kg");
                    var area = Field(controls, "Pickup area (city or district)");
                    AddAreaLookup(controls, area);
                    var address = Field(controls, "Alamat detail / pickup instructions (optional)");
                    Label(controls, "Use a public meeting point or landmark for this demo.");
                    var mode = new ComboBox { ItemsSource = new[] { "Trade", "Donation" }, SelectedIndex = 0 };
                    controls.Children.Add(mode);
                    Action("Publish listing", () => SaveAsync("""
                        INSERT INTO waste_listings(material_type,estimated_weight_kg,pickup_area,mode,pickup_instructions)
                        VALUES (@p0,@p1,@p2,@p3,@p4)
                        """, Required(material), Number(kg, positive: true), Required(area), (string)mode.SelectedItem, address.Text.Trim()));
                }
                else
                {
                    var rate = Field(controls, "Trade rate (Rp/kg)", "0");
                    var fee = Field(controls, "Pickup fee (Rp)", "0");
                    var schedule = Field(controls, "Pickup time (WIB, yyyy-MM-dd HH:mm)",
                        DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7)).AddDays(1).ToString("yyyy-MM-dd HH:mm"));
                    Action("Submit offer for selected listing", () =>
                    {
                        if (Selected() is not DataRowView listing)
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
                records = await QueryAsync($"""
                    SELECT o.id AS "ID", l.material_type AS "Material", l.mode AS "Mode",
                    c.name AS "Collector", o.scheduled_at AT TIME ZONE 'Asia/Jakarta' AS "Pickup (WIB)",
                    o.status AS "Status", o.rate AS "Rp/kg", o.fee AS "Fee",
                    round(l.estimated_weight_kg * o.rate - o.fee, 2) AS "Estimated net",
                    o.actual_kg AS "Measured kg",
                    round(o.actual_kg * o.rate - o.fee, 2) AS "Measured net",
                    o.correction AS "Correction reason", o.payment_reference AS "Payment reference", l.pickup_area AS "Area",
                    CASE WHEN @p1 AND o.status <> 'Pending' THEN l.pickup_instructions END AS "Pickup instructions"
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
                        """, Id(), Collector()), "Scheduled");
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
                    }, "Collected", "Correction");
                }
                if (page is 5 or 6)
                {
                    var viewPhoto = AddButton(controls, "View scale photo", async () =>
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
                    actions.Add((viewPhoto, ["Review", "Correction", "Verified", "Recorded", "Completed"]));
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
                        """, Id(), Required(reason)), "Review");
                }
                if (page == 6 && _collector != 0)
                {
                    var reference = Field(controls, "External payment reference");
                    Action("Record payment", () => SaveAsync("""
                        UPDATE workflow_offers SET status='Recorded',payment_reference=@p2
                        WHERE id=@p0 AND collector_id=@p1 AND status='Verified'
                        """, Id(), Collector(), Required(reference)), "Verified");
                }
                if (page == 6 && _collector == 0)
                    Action("Acknowledge receipt", () => SaveAsync("""
                        UPDATE workflow_offers SET status='Completed',completed_at=now()
                        WHERE id=@p0 AND status='Recorded'
                        """, Id()));
            }
            if (page == 1)
            {
                controls.Children.Remove(grid);
                var metrics = new WrapPanel { Margin = new Thickness(0, 18, 0, 10) };
                controls.Children.Add(metrics);
                var summary = records[0];
                foreach (DataColumn column in summary.Row.Table.Columns)
                {
                    var content = new StackPanel();
                    var value = Label(content, summary[column.ColumnName].ToString() ?? "0");
                    value.FontSize = 30;
                    value.FontWeight = FontWeights.Bold;
                    Label(content, column.ColumnName);
                    var card = Card(content);
                    card.MinWidth = 156;
                    card.Margin = new Thickness(0, 0, 12, 12);
                    metrics.Children.Add(card);
                }
                AddButton(controls, _collector == 0 ? "Publish recyclable material" : "Find material to collect",
                    () => GoToAsync(2));
                return;
            }

            foreach (DataRowView row in records)
            {
                var content = new StackPanel();
                var title = Label(content, row["Material"].ToString() ?? "");
                title.FontSize = 17;
                title.FontWeight = FontWeights.SemiBold;
                string[] details = page switch
                {
                    2 => ["Mode", "Estimated kg", "Area"],
                    3 => ["Status", "Collector", "Pickup (WIB)", "Rp/kg", "Fee", "Estimated net"],
                    4 => ["Status", "Collector", "Pickup (WIB)", "Area", "Pickup instructions"],
                    5 => ["Status", "Measured kg", "Measured net", "Correction reason"],
                    6 => ["Status", "Measured kg", "Measured net", "Payment reference"],
                    _ => ["Completed pickups", "Completed kg"]
                };
                Label(content, string.Join("   ·   ", details.Where(key => row[key] != DBNull.Value
                    && !string.IsNullOrWhiteSpace(row[key].ToString())).Select(key => $"{key}: {row[key]}")));
                grid.Items.Add(new ListBoxItem { Tag = row, Content = content, Padding = new Thickness(14, 6, 14, 6),
                    HorizontalContentAlignment = HorizontalAlignment.Stretch });
            }

            UpdateActions();
            if (records.Count == 0)
            {
                grid.Visibility = Visibility.Collapsed;
                string empty = page switch
                {
                    2 => "No material is available for pickup. New listings will appear here.",
                    3 => "No offers to review. Collector proposals will appear here.",
                    4 => "No active pickups. Accept an offer to schedule collection.",
                    5 => "No weight checks yet. Mark a pickup collected to start verification.",
                    6 => "No transactions yet. Confirm a measured weight to continue.",
                    _ => "No completed collections yet. Verified weight appears after completion."
                };
                controls.Children.Insert(1, Card(new TextBlock { Text = empty, TextWrapping = TextWrapping.Wrap }));
            }
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

    private Button AddButton(Panel parent, string title, Func<Task> action)
    {
        var button = new Button { Content = title, HorizontalAlignment = HorizontalAlignment.Left,
            Margin = new Thickness(0, 8, 0, 0), Style = (Style)FindResource("PrimaryButton") };
        button.Click += async (_, _) => await action();
        parent.Children.Add(button);
        return button;
    }

    private Task GoToAsync(int page)
    {
        _page = page;
        ListingsNavigation.IsChecked = page == 2;
        return ShowPageAsync();
    }

    private Border Card(UIElement content) => new()
    {
        Child = content,
        Background = (System.Windows.Media.Brush)FindResource("CardBrush"),
        BorderBrush = (System.Windows.Media.Brush)FindResource("LineBrush"),
        BorderThickness = new Thickness(1),
        CornerRadius = new CornerRadius(14),
        Padding = new Thickness(18)
    };

    protected override void OnClosed(EventArgs e)
    {
        _database?.Dispose();
        base.OnClosed(e);
    }
}
