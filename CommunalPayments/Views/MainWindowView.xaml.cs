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
            DataContext = new MainWindowViewModel();
            //Сделать обновление данных после изменения настроек - событие AfterSave
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
