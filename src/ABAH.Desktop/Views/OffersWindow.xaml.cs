using System.Globalization;
using System.Windows;
using ABAH.Desktop.Data;
using ABAH.Desktop.Models;
using Npgsql;

namespace ABAH.Desktop.Views;

public partial class OffersWindow : Window
{
    private readonly OfferStore _store;

    internal OffersWindow(NpgsqlDataSource dataSource)
    {
        InitializeComponent();
        _store = new OfferStore(dataSource);
        PickupDate.SelectedDate = DateTime.Today.AddDays(1);
        Loaded += LoadOffers;
    }

    private async void LoadOffers(object sender, RoutedEventArgs e)
    {
        Loaded -= LoadOffers;
        Feedback.Text = "Loading offers from PostgreSQL...";
        try
        {
            var listings = await _store.LoadListingsAsync();
            var collectors = await _store.LoadCollectorsAsync();
            RecentOffers.ItemsSource = await _store.LoadRecentAsync();
            Listings.ItemsSource = listings;
            Collectors.ItemsSource = collectors;
            Collectors.SelectedIndex = collectors.Count == 1 ? 0 : -1;

            OfferFields.IsEnabled = listings.Count > 0 && collectors.Count > 0;
            Feedback.Text = OfferFields.IsEnabled
                ? "Select a listing to make an offer."
                : "No listings or collectors are available. Load the demo seed data and reopen Offers.";
        }
        catch (NpgsqlException)
        {
            Feedback.Text = "Could not load offers. Check the PostgreSQL connection and schema, then reopen Offers.";
        }
    }

    private async void SubmitOffer_Click(object sender, RoutedEventArgs e)
    {
        if (Listings.SelectedItem is not WasteListing listing || Collectors.SelectedItem is not CollectorChoice collector)
        {
            Feedback.Text = "Select a waste listing and a collector.";
            return;
        }

        const NumberStyles moneyStyles = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign
            | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite;
        if (!decimal.TryParse(Price.Text, moneyStyles, CultureInfo.CurrentCulture, out decimal price)
            || !decimal.TryParse(Fee.Text, moneyStyles, CultureInfo.CurrentCulture, out decimal fee))
        {
            Feedback.Text = "Enter numeric amounts without grouping separators for the price and pickup fee.";
            return;
        }

        if (PickupDate.SelectedDate is not DateTime date
            || !TimeOnly.TryParseExact(PickupTime.Text.Trim(), "HH:mm", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out TimeOnly time))
        {
            Feedback.Text = "Choose a pickup date and enter the local time in HH:mm format.";
            return;
        }

        DateTime localPickup = date.Date + time.ToTimeSpan();
        if (TimeZoneInfo.Local.IsInvalidTime(localPickup) || TimeZoneInfo.Local.IsAmbiguousTime(localPickup))
        {
            Feedback.Text = "Choose a pickup time outside the local clock change.";
            return;
        }

        WasteListing.Offer offer;
        try
        {
            offer = listing.CreateOffer(collector.Id, price, fee, new DateTimeOffset(localPickup));
        }
        catch (ArgumentException exception)
        {
            Feedback.Text = exception.Message;
            return;
        }

        OfferFields.IsEnabled = false;
        Feedback.Text = "Saving offer...";
        int? savedId = null;
        try
        {
            savedId = await _store.SaveAsync(offer);
            Price.Clear();
            Fee.Text = "0";
            RecentOffers.ItemsSource = await _store.LoadRecentAsync();
            Feedback.Text = $"Offer #{savedId} saved as {offer.Status}.";
        }
        catch (PostgresException exception) when (exception.SqlState == PostgresErrorCodes.ForeignKeyViolation)
        {
            Feedback.Text = "The listing or collector is no longer available. Reopen Offers to reload.";
        }
        catch (NpgsqlException)
        {
            Feedback.Text = savedId.HasValue
                ? $"Offer #{savedId} was saved. Reopen Offers to refresh the list."
                : "Could not confirm the save. Reopen Offers and check the recent list before submitting again.";
        }
        finally
        {
            OfferFields.IsEnabled = true;
        }
    }
}
