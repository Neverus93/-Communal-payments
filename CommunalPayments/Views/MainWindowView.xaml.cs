using System.Reflection;
using System.Windows;
using CommunalPayments.ViewModels;
using CommunalPayments.Helpers;
namespace CommunalPayments.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
            var viewModel = new MainWindowViewModel();
            DataContext = viewModel;
        }

        private void MainWindowView_OnLoaded(object sender, RoutedEventArgs e)
        {
            AppendVersionToTitle();
        }

        private void AppendVersionToTitle()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Title += $" {version.ToString(RuntimeHelper.DebugMode ? 4 : 3)}";
        }
    }
}
