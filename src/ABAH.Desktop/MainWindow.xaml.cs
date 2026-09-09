using System.Windows;
using ABAH.Desktop.ViewModels;

namespace ABAH.Desktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new DashboardViewModel();
    }
}
