using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ABAH.Desktop.Converters;

/// <summary>
/// true (pemasukan) -> hijau, false (pengeluaran) -> merah.
/// </summary>
public class IncomeToBrushConverter : IValueConverter
{
    private static readonly SolidColorBrush Income = (SolidColorBrush)new BrushConverter().ConvertFromString("#22885F")!;
    private static readonly SolidColorBrush Expense = (SolidColorBrush)new BrushConverter().ConvertFromString("#EF5A78")!;

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is true ? Income : Expense;

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
