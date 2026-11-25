using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;

namespace ABAH.Desktop;

public partial class MainWindow
{
    private static readonly HttpClient Geocoder = new() { Timeout = TimeSpan.FromSeconds(8) };

    private sealed record Place(string Name, string? Admin1, string? Admin2, double Latitude, double Longitude)
    {
        public string Label => string.Join(", ", new[] { Name, Admin2, Admin1 }
            .Where(part => !string.IsNullOrWhiteSpace(part)).Distinct(StringComparer.OrdinalIgnoreCase));
    }

    private sealed record PlacesResponse([property: JsonPropertyName("results")] Place[]? Results);

    private void AddAreaLookup(Panel parent, TextBox area)
    {
        var choices = new ComboBox { DisplayMemberPath = "Label", Width = 450, MinHeight = 38, MaxDropDownHeight = 320,
            Padding = new Thickness(10, 6, 10, 6), Margin = new Thickness(0, 8, 0, 0),
            HorizontalAlignment = HorizontalAlignment.Left, Visibility = Visibility.Collapsed };
        var note = Label(parent, "Search by public place name only. You can also enter the pickup area manually.");
        Button? search = null;
        search = AddButton(parent, "Find pickup area", async () =>
        {
            var query = area.Text.Trim();
            choices.ItemsSource = null;
            choices.Visibility = Visibility.Collapsed;
            if (query.Length is < 3 or > 80)
            {
                note.Text = "Enter a city or district name of 3–80 characters.";
                return;
            }

            search!.IsEnabled = false;
            note.Text = "Searching Indonesian places…";
            try
            {
                var uri = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(query)}&count=8&language=en&countryCode=ID";
                var response = await Geocoder.GetFromJsonAsync<PlacesResponse>(uri);
                if (!string.Equals(area.Text.Trim(), query, StringComparison.Ordinal))
                {
                    note.Text = "Area changed. Search again or keep your manual entry.";
                    return;
                }

                var matches = response?.Results ?? [];
                choices.ItemsSource = matches;
                choices.Visibility = matches.Length > 0 ? Visibility.Visible : Visibility.Collapsed;
                if (matches.Length == 0)
                {
                    note.Text = "No matching Indonesian places. Try a nearby city or enter the area manually.";
                    return;
                }

                choices.SelectedIndex = 0;
                note.Text = "Top match selected. Check the area or choose another match below.";
            }
            catch (Exception ex) when (ex is HttpRequestException or OperationCanceledException or JsonException)
            {
                note.Text = "Location lookup is unavailable. You can still enter the pickup area manually.";
            }
            finally { search!.IsEnabled = true; }
        });
        var map = AddButton(parent, "Preview selected area on map", () =>
        {
            if (choices.SelectedItem is Place place)
            {
                var url = FormattableString.Invariant(
                    $"https://www.openstreetmap.org/?mlat={place.Latitude}&mlon={place.Longitude}#map=13/{place.Latitude}/{place.Longitude}");
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    note.Text = "Could not open the default browser. The pickup area can still be saved.";
                }
            }
            return Task.CompletedTask;
        });
        map.Visibility = Visibility.Collapsed;
        choices.SelectionChanged += (_, _) =>
        {
            map.Visibility = choices.SelectedItem is Place ? Visibility.Visible : Visibility.Collapsed;
            if (choices.SelectedItem is Place place)
            {
                area.Text = place.Label;
                note.Text = "Area selected. Check the name and publish when ready.";
            }
        };
        parent.Children.Insert(parent.Children.IndexOf(map), choices);
        Label(parent, "Place search: Open-Meteo / GeoNames. Map preview: © OpenStreetMap contributors.");
    }
}
