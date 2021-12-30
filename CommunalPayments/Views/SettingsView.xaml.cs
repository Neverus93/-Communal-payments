using System.Windows;
using CommunalPayments.ViewModels;

namespace CommunalPayments.Views
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class SettingsView : Window
    {
        public SettingsView(SettingsViewModel dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
            dataContext.AfterSave += (o, e) =>
            {
                Close();
            };
        }
    }
}
