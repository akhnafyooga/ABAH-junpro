using System.Collections.ObjectModel;
using System.Windows.Media;
using ABAH.Desktop.Models;

namespace ABAH.Desktop.ViewModels;

/// <summary>
/// ViewModel untuk Climate Impact Dashboard (fitur #8 pada README).
/// Untuk sementara data masih dummy — nanti diganti dengan query ke PostgreSQL
/// melalui layer service/ORM di modul backend.
/// </summary>
public class DashboardViewModel : ObservableObject
{
    public string UserName { get; } = "Akmal Rafli";
    public string UserRole { get; } = "Waste Producer";
    public string Greeting { get; } = "Ringkasan aktivitas sirkular sampahmu.";

    public ObservableCollection<StatCard> Stats { get; } = new();
    public ObservableCollection<MaterialBreakdown> Materials { get; } = new();
    public ObservableCollection<PickupItem> RecentPickups { get; } = new();
    public ObservableCollection<TransactionItem> RecentTransactions { get; } = new();

    // Data chart bulanan (berat kg per bulan)
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
            Icon = "♻", Label = "Sampah Diselamatkan", Value = "1.284 kg",
            Delta = "+12,5%", IsUp = true,
            AccentBrush = Hex("#22885F"), AccentBackground = Hex("#E3F4EC")
        });
        Stats.Add(new StatCard
        {
            Icon = "📦", Label = "Listing Aktif", Value = "18",
            Delta = "+3", IsUp = true,
            AccentBrush = Hex("#3B82F6"), AccentBackground = Hex("#E6F0FF")
        });
        Stats.Add(new StatCard
        {
            Icon = "🚛", Label = "Pickup Bulan Ini", Value = "42",
            Delta = "+8,2%", IsUp = true,
            AccentBrush = Hex("#7C5CFF"), AccentBackground = Hex("#EFEAFF")
        });
        Stats.Add(new StatCard
        {
            Icon = "💰", Label = "Total Pendapatan", Value = "Rp 3,4jt",
            Delta = "-2,1%", IsUp = false,
            AccentBrush = Hex("#E8A13A"), AccentBackground = Hex("#FBF1D6")
        });

        // ---- Material breakdown ----
        Materials.Add(new MaterialBreakdown { Name = "Kardus & Kertas", ValueText = "480 kg", Percent = 38, BarBrush = Hex("#E8A13A") });
        Materials.Add(new MaterialBreakdown { Name = "Botol PET",       ValueText = "320 kg", Percent = 25, BarBrush = Hex("#3B82F6") });
        Materials.Add(new MaterialBreakdown { Name = "Kaleng Logam",    ValueText = "210 kg", Percent = 16, BarBrush = Hex("#7C5CFF") });
        Materials.Add(new MaterialBreakdown { Name = "Kaca",            ValueText = "160 kg", Percent = 13, BarBrush = Hex("#2EA373") });
        Materials.Add(new MaterialBreakdown { Name = "Minyak Jelantah", ValueText = "114 kg", Percent = 8,  BarBrush = Hex("#EF5A78") });

        // ---- Monthly chart ----
        var monthly = new (string, double)[]
        {
            ("Apr", 140), ("Mei", 180), ("Jun", 165),
            ("Jul", 220), ("Agu", 260), ("Sep", 239)
        };
        double max = 260;
        foreach (var (m, v) in monthly)
            MonthlyWaste.Add(new MonthlyBar { Month = m, Value = v, BarHeight = v / max * 180 });

        // ---- Recent pickups ----
        RecentPickups.Add(new PickupItem { Material = "Botol PET", Estimate = "12 kg est.", Collector = "Bank Sampah Melati", Weight = "11,4 kg", Status = PickupStatus.Verified });
        RecentPickups.Add(new PickupItem { Material = "Kardus", Estimate = "30 kg est.", Collector = "CV Daur Ulang Jaya", Weight = "28,0 kg", Status = PickupStatus.OnTheWay });
        RecentPickups.Add(new PickupItem { Material = "Minyak Jelantah", Estimate = "8 L est.", Collector = "Komunitas Hijau", Weight = "—", Status = PickupStatus.Accepted });
        RecentPickups.Add(new PickupItem { Material = "Kaleng Logam", Estimate = "15 kg est.", Collector = "Pengepul Barokah", Weight = "—", Status = PickupStatus.Requested });
        RecentPickups.Add(new PickupItem { Material = "Kaca", Estimate = "20 kg est.", Collector = "Bank Sampah Melati", Weight = "19,2 kg", Status = PickupStatus.Completed });

        // ---- Recent transactions ----
        RecentTransactions.Add(new TransactionItem { Title = "Penjualan Kaca", Counterparty = "Bank Sampah Melati", Amount = "+ Rp 38.400", Date = "9 Sep 2026", IsIncome = true });
        RecentTransactions.Add(new TransactionItem { Title = "Penjualan Botol PET", Counterparty = "Bank Sampah Melati", Amount = "+ Rp 22.800", Date = "7 Sep 2026", IsIncome = true });
        RecentTransactions.Add(new TransactionItem { Title = "Biaya Pickup", Counterparty = "CV Daur Ulang Jaya", Amount = "- Rp 10.000", Date = "5 Sep 2026", IsIncome = false });
    }
}

/// <summary>Satu batang pada grafik bulanan.</summary>
public class MonthlyBar
{
    public string Month { get; set; } = "";
    public double Value { get; set; }
    public double BarHeight { get; set; }
}
