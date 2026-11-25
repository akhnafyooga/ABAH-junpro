using System.Windows;
using ABAH.Desktop.ViewModels;
using ABAH.Desktop.Views;
using Npgsql;

namespace ABAH.Desktop;

public partial class MainWindow : Window
{
    private NpgsqlDataSource? _offerDataSource;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = new DashboardViewModel();
    }

    private void OpenOffers_Click(object sender, RoutedEventArgs e)
    {
        if (_offerDataSource is null)
        {
            string? connectionString = Environment.GetEnvironmentVariable("ABAH_POSTGRES_CONNECTION");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                MessageBox.Show(this, "Set ABAH_POSTGRES_CONNECTION before starting ABAH.", "Offers");
                return;
            }

            try
            {
                _offerDataSource = NpgsqlDataSource.Create(connectionString);
            }
            catch (ArgumentException)
            {
                MessageBox.Show(this, "Check the ABAH_POSTGRES_CONNECTION format and restart ABAH.", "Offers");
                return;
            }
        }

        new OffersWindow(_offerDataSource) { Owner = this }.ShowDialog();
    }

    protected override void OnClosed(EventArgs e)
    {
        _offerDataSource?.Dispose();
        base.OnClosed(e);
    }
}
