using System.Windows;
using CommunalPayments.ViewModels;

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
    }
}
