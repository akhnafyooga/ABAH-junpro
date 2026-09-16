using System;
using System.Collections.Generic;

namespace WasteManagementApp
{
    public enum UserRole
    {
        WasteProducer,
        Collector,
        Processor,
        CommunityPartner
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string LocationCoords { get; set; } = string.Empty;
        public List<UserRole> Roles { get; set; } = new List<UserRole>();

        public void RateUser(int rating)
        {
            Console.WriteLine($"User {Name} received a rating of {rating}/5.");
        }
    }

    public class WasteListing
    {
        public int ListingId { get; set; }
        public int ProducerId { get; set; } // Link to User
        public string MaterialType { get; set; } = string.Empty;
        public float EstimatedWeightKg { get; set; }
        public string Condition { get; set; } = string.Empty;
        public string Photos { get; set; } = string.Empty;
        public string PickupLocation { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Offer CreateOffer(int collectorId, decimal price, decimal fee, DateTime schedule)
        {
            return new Offer
            {
                ListingId = this.ListingId,
                CollectorId = collectorId,
                ProposedPrice = price,
                PickupFee = fee,
                PickupSchedule = schedule,
                Status = "Pending"
            };
        }
    }

    public class Offer
    {
        public int OfferId { get; set; }
        public int ListingId { get; set; }
        public int CollectorId { get; set; }
        public decimal ProposedPrice { get; set; }
        public decimal PickupFee { get; set; }
        public DateTime PickupSchedule { get; set; }
        public string Status { get; set; } = "Pending";
    }

    public class WeightVerification
    {
        public int VerificationId { get; set; }
        public int ListingId { get; set; }
        public float EstimatedWeightKg { get; set; }
        public float ActualWeightKg { get; set; }
        public string PhotoEvidence { get; set; } = string.Empty;
        public string ScaleId { get; set; } = string.Empty;
    }

    public class Transaction
    {
        public int TransactionId { get; set; }
        public int OfferId { get; set; }
        public float FinalWeightKg { get; set; }
        public decimal TotalPayment { get; set; }
        public string TransactionStatus { get; set; } = "Pending";
        public string PaymentMethod { get; set; } = string.Empty;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Waste Management System initialized ---\n");

            User producer = new User
            {
                Id = 1,
                Name = "John Doe",
                Email = "john@example.com",
                Roles = new List<UserRole> { UserRole.WasteProducer }
            };

            WasteListing listing = new WasteListing
            {
                ListingId = 101,
                ProducerId = producer.Id,
                MaterialType = "Plastic (PET)",
                EstimatedWeightKg = 15.5f,
                PickupLocation = "123 Green St."
            };

            Offer offer = listing.CreateOffer(
                collectorId: 2, 
                price: 50.00m, 
                fee: 5.00m, 
                schedule: DateTime.Now.AddDays(1)
            );

            WeightVerification verification = new WeightVerification
            {
                VerificationId = 501,
                ListingId = listing.ListingId,
                EstimatedWeightKg = listing.EstimatedWeightKg,
                ActualWeightKg = 16.0f,
                ScaleId = "SCALE-09"
            };

            Transaction tx = new Transaction
            {
                TransactionId = 9001,
                OfferId = offer.OfferId,
                FinalWeightKg = verification.ActualWeightKg,
                TotalPayment = offer.ProposedPrice - offer.PickupFee,
                TransactionStatus = "Completed",
                PaymentMethod = "E-Wallet"
            };

            Console.WriteLine($"Transaction #{tx.TransactionId} {tx.TransactionStatus}. Total Paid: ${tx.TotalPayment} for {tx.FinalWeightKg} kg.");
        }
    }
}
