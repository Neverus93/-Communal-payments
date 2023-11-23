using CommunalPayments.ViewModels.Controls;
using System.Windows.Controls;

namespace CommunalPayments.Controls
{
    /// <summary>
    /// Логика взаимодействия для CalculateScoreControl.xaml
    /// </summary>
    public partial class CalculateScoreControl : UserControl
    {
        public CalculateScoreControl()
        {
            InitializeComponent();
            var viewModel = new CalculateScoreControlViewModel();
            DataContext = viewModel;
        }
    }
}
