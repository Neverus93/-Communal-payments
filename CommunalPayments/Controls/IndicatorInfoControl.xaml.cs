using CommunalPayments.ViewModels.Controls;
using System.Windows.Controls;

namespace CommunalPayments.Controls
{
    /// <summary>
    /// Логика взаимодействия для IndicatorInfoControl.xaml
    /// </summary>
    public partial class IndicatorInfoControl : UserControl
    {
        public IndicatorInfoControl()
        {
            InitializeComponent();
            var viewModel = new IndicatorInfoControlViewModel();
            DataContext = viewModel;
        }
    }
}
