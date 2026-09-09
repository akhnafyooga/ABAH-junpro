using System.Collections.ObjectModel;
using System.Windows.Media;
using ABAH.Desktop.Models;

namespace ABAH.Desktop.ViewModels;

/// <summary>
/// ViewModel for the Climate Impact Dashboard (feature #8 in the README).
/// Sample data is used for now — it will later be replaced with a PostgreSQL query
/// through the backend service/ORM layer.
/// </summary>
public class DashboardViewModel : ObservableObject
{
    public string UserName { get; } = "Akmal Rafli";
    public string UserRole { get; } = "Waste Producer";
    public string Greeting { get; } = "Your circular waste activity at a glance.";

    public ObservableCollection<StatCard> Stats { get; } = new();
    public ObservableCollection<MaterialBreakdown> Materials { get; } = new();
    public ObservableCollection<PickupItem> RecentPickups { get; } = new();
    public ObservableCollection<TransactionItem> RecentTransactions { get; } = new();

    // Monthly chart data (weight in kg per month)
    public ObservableCollection<MonthlyBar> MonthlyWaste { get; } = new();

    public DashboardViewModel()
    {
        LoadSampleData();
    }

    private static SolidColorBrush Hex(string hex) =>
        (SolidColorBrush)new BrushConverter().ConvertFromString(hex)!;

    private void LoadSampleData()
    {
        // ---- Stat cards ----
        Stats.Add(new StatCard
        {
            Icon = "♻", Label = "Waste Diverted", Value = "1,284 kg",
            Delta = "+12.5%", IsUp = true,
            AccentBrush = Hex("#22885F"), AccentBackground = Hex("#E3F4EC")
        });
        Stats.Add(new StatCard
        {
            Icon = "📦", Label = "Active Listings", Value = "18",
            Delta = "+3", IsUp = true,
            AccentBrush = Hex("#3B82F6"), AccentBackground = Hex("#E6F0FF")
        });
        Stats.Add(new StatCard
        {
            Icon = "🚛", Label = "Pickups This Month", Value = "42",
            Delta = "+8.2%", IsUp = true,
            AccentBrush = Hex("#7C5CFF"), AccentBackground = Hex("#EFEAFF")
        });
        Stats.Add(new StatCard
        {
            Icon = "💰", Label = "Total Earnings", Value = "Rp 3.4M",
            Delta = "-2.1%", IsUp = false,
            AccentBrush = Hex("#E8A13A"), AccentBackground = Hex("#FBF1D6")
        });

        // ---- Material breakdown ----
        Materials.Add(new MaterialBreakdown { Name = "Cardboard & Paper", ValueText = "480 kg", Percent = 38, BarBrush = Hex("#E8A13A") });
        Materials.Add(new MaterialBreakdown { Name = "PET Bottles",       ValueText = "320 kg", Percent = 25, BarBrush = Hex("#3B82F6") });
        Materials.Add(new MaterialBreakdown { Name = "Metal Cans",        ValueText = "210 kg", Percent = 16, BarBrush = Hex("#7C5CFF") });
        Materials.Add(new MaterialBreakdown { Name = "Glass",              ValueText = "160 kg", Percent = 13, BarBrush = Hex("#2EA373") });
        Materials.Add(new MaterialBreakdown { Name = "Used Cooking Oil",   ValueText = "114 kg", Percent = 8,  BarBrush = Hex("#EF5A78") });

        // ---- Monthly chart ----
        var monthly = new (string, double)[]
        {
            ("Apr", 140), ("May", 180), ("Jun", 165),
            ("Jul", 220), ("Aug", 260), ("Sep", 239)
        };
        double max = 260;
        foreach (var (m, v) in monthly)
            MonthlyWaste.Add(new MonthlyBar { Month = m, Value = v, BarHeight = v / max * 180 });

        // ---- Recent pickups ----
        RecentPickups.Add(new PickupItem { Material = "PET Bottles", Estimate = "12 kg est.", Collector = "Melati Waste Bank", Weight = "11.4 kg", Status = PickupStatus.Verified });
        RecentPickups.Add(new PickupItem { Material = "Cardboard", Estimate = "30 kg est.", Collector = "CV Daur Ulang Jaya", Weight = "28.0 kg", Status = PickupStatus.OnTheWay });
        RecentPickups.Add(new PickupItem { Material = "Used Cooking Oil", Estimate = "8 L est.", Collector = "Komunitas Hijau", Weight = "—", Status = PickupStatus.Accepted });
        RecentPickups.Add(new PickupItem { Material = "Metal Cans", Estimate = "15 kg est.", Collector = "Barokah Scrap Dealer", Weight = "—", Status = PickupStatus.Requested });
        RecentPickups.Add(new PickupItem { Material = "Glass", Estimate = "20 kg est.", Collector = "Melati Waste Bank", Weight = "19.2 kg", Status = PickupStatus.Completed });

        // ---- Recent transactions ----
        RecentTransactions.Add(new TransactionItem { Title = "Glass sale", Counterparty = "Melati Waste Bank", Amount = "+ Rp 38,400", Date = "Sep 9, 2026", IsIncome = true });
        RecentTransactions.Add(new TransactionItem { Title = "PET bottle sale", Counterparty = "Melati Waste Bank", Amount = "+ Rp 22,800", Date = "Sep 7, 2026", IsIncome = true });
        RecentTransactions.Add(new TransactionItem { Title = "Pickup fee", Counterparty = "CV Daur Ulang Jaya", Amount = "- Rp 10,000", Date = "Sep 5, 2026", IsIncome = false });
    }
}

/// <summary>One bar on the monthly chart.</summary>
public class MonthlyBar
{
    public string Month { get; set; } = "";
    public double Value { get; set; }
    public double BarHeight { get; set; }
}
