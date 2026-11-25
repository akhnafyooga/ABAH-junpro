namespace ABAH.Desktop.Models;

public sealed record WasteListing(int Id, string MaterialType, decimal EstimatedWeightKg)
{
    public Offer CreateOffer(int collectorId, decimal price, decimal pickupFee, DateTimeOffset pickupSchedule)
    {
        if (collectorId <= 0)
            throw new ArgumentException("Select a collector.");

        if (price <= 0 || price > 9999999999.99m || decimal.Round(price, 2) != price)
            throw new ArgumentException("Enter a positive proposed price with up to two decimal places.");

        if (pickupFee < 0 || pickupFee > price || decimal.Round(pickupFee, 2) != pickupFee)
            throw new ArgumentException("Enter a pickup fee between zero and the proposed price, with up to two decimal places.");

        if (pickupSchedule <= DateTimeOffset.UtcNow)
            throw new ArgumentException("Choose a pickup time in the future.");

        return new Offer(Id, collectorId, price, pickupFee, pickupSchedule.ToUniversalTime());
    }

    public sealed class Offer
    {
        internal Offer(int listingId, int collectorId, decimal price, decimal pickupFee, DateTimeOffset pickupSchedule)
        {
            ListingId = listingId;
            CollectorId = collectorId;
            ProposedPrice = price;
            PickupFee = pickupFee;
            PickupSchedule = pickupSchedule;
        }

        public int ListingId { get; }
        public int CollectorId { get; }
        public decimal ProposedPrice { get; }
        public decimal PickupFee { get; }
        public DateTimeOffset PickupSchedule { get; }
        public string Status => "Pending";
    }
}
