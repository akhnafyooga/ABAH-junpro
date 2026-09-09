using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ABAH.Desktop.Converters;

/// <summary>
/// Mengubah nilai persen (0–100) menjadi <see cref="GridLength"/> berbasis Star,
/// sehingga bisa dipakai untuk mengisi lebar progress bar secara proporsional.
/// ConverterParameter "rest" mengembalikan sisa (100 - persen).
/// </summary>
public class PercentToStarConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        double pct = value is double d ? d : 0;
        bool rest = parameter as string == "rest";
        double weight = rest ? Math.Max(0, 100 - pct) : pct;
        return new GridLength(weight, GridUnitType.Star);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
