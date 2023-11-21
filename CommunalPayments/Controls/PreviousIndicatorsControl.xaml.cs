using CommunalPayments.ViewModels.Controls;
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
            var viewModel = new PreviousIndicatorControlViewModel();
            DataContext = viewModel;
        }
    }
}
