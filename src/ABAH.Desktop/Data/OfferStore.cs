using ABAH.Desktop.Models;
using Npgsql;

namespace ABAH.Desktop.Data;

internal sealed class OfferStore(NpgsqlDataSource dataSource)
{
    public async Task<List<WasteListing>> LoadListingsAsync()
    {
        await using var command = dataSource.CreateCommand("""
            SELECT listing_id, material_type, estimated_weight_kg
            FROM waste_listings ORDER BY material_type, listing_id
            """);
        await using var reader = await command.ExecuteReaderAsync();
        var listings = new List<WasteListing>();
        while (await reader.ReadAsync())
            listings.Add(new WasteListing(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2)));

        return listings;
    }

    public async Task<List<CollectorChoice>> LoadCollectorsAsync()
    {
        await using var command = dataSource.CreateCommand("""
            SELECT collector_id, name FROM collectors ORDER BY name, collector_id
            """);
        await using var reader = await command.ExecuteReaderAsync();
        var collectors = new List<CollectorChoice>();
        while (await reader.ReadAsync())
            collectors.Add(new CollectorChoice(reader.GetInt32(0), reader.GetString(1)));

        return collectors;
    }

    public async Task<int> SaveAsync(WasteListing.Offer offer)
    {
        await using var command = dataSource.CreateCommand("""
            INSERT INTO offers (listing_id, collector_id, proposed_price, pickup_fee, pickup_schedule, status)
            VALUES ($1, $2, $3, $4, $5, $6)
            RETURNING offer_id
            """);
        command.Parameters.Add(new NpgsqlParameter<int> { TypedValue = offer.ListingId });
        command.Parameters.Add(new NpgsqlParameter<int> { TypedValue = offer.CollectorId });
        command.Parameters.Add(new NpgsqlParameter<decimal> { TypedValue = offer.ProposedPrice });
        command.Parameters.Add(new NpgsqlParameter<decimal> { TypedValue = offer.PickupFee });
        command.Parameters.Add(new NpgsqlParameter<DateTimeOffset> { TypedValue = offer.PickupSchedule });
        command.Parameters.Add(new NpgsqlParameter<string> { TypedValue = offer.Status });

        return (int)(await command.ExecuteScalarAsync())!;
    }

    public async Task<List<SavedOffer>> LoadRecentAsync()
    {
        await using var command = dataSource.CreateCommand("""
            SELECT o.offer_id, l.material_type, c.name, o.proposed_price, o.pickup_fee, o.pickup_schedule, o.status
            FROM offers o
            JOIN waste_listings l ON l.listing_id = o.listing_id
            JOIN collectors c ON c.collector_id = o.collector_id
            ORDER BY o.offer_id DESC LIMIT 25
            """);
        await using var reader = await command.ExecuteReaderAsync();
        var offers = new List<SavedOffer>();
        while (await reader.ReadAsync())
        {
            offers.Add(new SavedOffer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                reader.GetDecimal(3), reader.GetDecimal(4),
                reader.GetFieldValue<DateTimeOffset>(5).ToLocalTime().DateTime, reader.GetString(6)));
        }

        return offers;
    }
}

internal sealed record CollectorChoice(int Id, string Name);
internal sealed record SavedOffer(int Id, string Material, string Collector, decimal Price,
    decimal Fee, DateTime PickupTime, string Status);
