using CommunalPayments.ViewModels.Controls;
using System.Windows.Controls;

namespace CommunalPayments.Controls
{
    /// <summary>
    /// Логика взаимодействия для CurrentIndicatorsControl.xaml
    /// </summary>
    public partial class CurrentIndicatorsControl : UserControl
    {
        public CurrentIndicatorsControl()
        {
            InitializeComponent();
            var viewModel = new IndicatorsDataTextControlViewModel();
            DataContext = viewModel;
        }
    }
}
