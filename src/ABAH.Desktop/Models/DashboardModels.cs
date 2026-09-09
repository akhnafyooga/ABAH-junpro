using System.Windows.Media;

namespace ABAH.Desktop.Models;

/// <summary>Kartu statistik ringkas di bagian atas dashboard.</summary>
public class StatCard
{
    public string Icon { get; set; } = "";
    public string Label { get; set; } = "";
    public string Value { get; set; } = "";
    public string Delta { get; set; } = "";
    public bool IsUp { get; set; } = true;
    public Brush AccentBrush { get; set; } = Brushes.Gray;
    public Brush AccentBackground { get; set; } = Brushes.LightGray;

    public string DeltaGlyph => IsUp ? "▲" : "▼"; // ▲ / ▼
}

/// <summary>Baris rincian material (fitur #8 Climate Impact Dashboard).</summary>
public class MaterialBreakdown
{
    public string Name { get; set; } = "";
    public string ValueText { get; set; } = "";
    public double Percent { get; set; }
    public Brush BarBrush { get; set; } = Brushes.Green;

    public string PercentText => $"{Percent:0}%";
}

/// <summary>Item penjemputan terbaru pada tabel dashboard.</summary>
public class PickupItem
{
    public string Material { get; set; } = "";
    public string Estimate { get; set; } = "";
    public string Collector { get; set; } = "";
    public string Weight { get; set; } = "";
    public PickupStatus Status { get; set; }

    public string StatusLabel => Status switch
    {
        PickupStatus.Requested => "Menunggu",
        PickupStatus.Accepted  => "Diterima",
        PickupStatus.OnTheWay  => "Dalam perjalanan",
        PickupStatus.Collected => "Terkumpul",
        PickupStatus.Verified  => "Terverifikasi",
        PickupStatus.Completed => "Selesai",
        _ => Status.ToString()
    };
}

/// <summary>Riwayat transaksi terbaru (fitur #7 Transaction &amp; Financial Tracking).</summary>
public class TransactionItem
{
    public string Title { get; set; } = "";
    public string Counterparty { get; set; } = "";
    public string Amount { get; set; } = "";
    public string Date { get; set; } = "";
    public bool IsIncome { get; set; } = true;
}
