using System.Windows;
using CommunalPayments.ViewModels;

namespace CommunalPayments.Views
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class CostsView : Window
    {
        public CostsView(CostsViewModel dataContext)
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
