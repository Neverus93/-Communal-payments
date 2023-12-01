using CommunalPayments.ViewModels;
using System.Windows.Controls;

namespace CommunalPayments.Controls
{
    /// <summary>
    /// Логика взаимодействия для PreviousIndicatorsControl.xaml
    /// </summary>
    public partial class PreviousIndicatorsControl : UserControl
    {
        public PreviousIndicatorsControl()
        {
            InitializeComponent();
            var viewModel = new MainWindowViewModel();
            DataContext = viewModel;
        }
    }
}
