using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using ABAH.Desktop.Models;

namespace ABAH.Desktop.Converters;

/// <summary>
/// Mengubah <see cref="PickupStatus"/> menjadi warna badge.
/// ConverterParameter "bg" mengembalikan warna latar, selain itu warna teks.
/// </summary>
public class StatusToBrushConverter : IValueConverter
{
    private static SolidColorBrush Hex(string hex) =>
        (SolidColorBrush)new BrushConverter().ConvertFromString(hex)!;

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        bool bg = parameter as string == "bg";
        if (value is not PickupStatus status) return Brushes.Transparent;

        // (foreground, background)
        (string fg, string back) = status switch
        {
            PickupStatus.Requested => ("#8A6D00", "#FBF1D6"),
            PickupStatus.Accepted  => ("#3B82F6", "#E6F0FF"),
            PickupStatus.OnTheWay  => ("#7C5CFF", "#EFEAFF"),
            PickupStatus.Collected => ("#22885F", "#E3F4EC"),
            PickupStatus.Verified  => ("#1A6B4C", "#E3F4EC"),
            PickupStatus.Completed => ("#556666", "#EEF1F0"),
            _ => ("#556666", "#EEF1F0")
        };

        return Hex(bg ? back : fg);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
