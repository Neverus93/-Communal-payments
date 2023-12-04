using CommunalPayments.Command;
using CommunalPayments.Helpers;
using CommunalPayments.Views;
using Prism.Mvvm;
using System.Windows;

namespace CommunalPayments.ViewModels.Controls
{
    public class ManageButtonsControlViewModel : BindableBase
    {
        public IndicatorsViewModel IndicatorDataTextControlViewModel { get; set; }
        public RelayCommand SaveIndicatorCommand { get; }
        public RelayCommand CallSettingsCommand { get; }
        public RelayCommand CallApplicationInfoCommand { get; }

        public ManageButtonsControlViewModel(IndicatorsViewModel indicatorDataTextControlViewModel)
        {
            IndicatorDataTextControlViewModel = indicatorDataTextControlViewModel;
            SaveIndicatorCommand = new RelayCommand(SaveIndicatorClick);
            CallSettingsCommand = new RelayCommand(CallSettingsClick);
            CallApplicationInfoCommand = new RelayCommand(CallApplicationInfoClick);
        }

        private void SaveIndicatorClick(object parameter)
        {
            SerializeHelper<IndicatorsViewModel>.Save(IndicatorDataTextControlViewModel);
            MessageBox.Show("Данные успешно сохранены!");
        }

        private void CallSettingsClick(object parameter)
        {
            var viewModel = new CostsViewModel();
            CostsView settingsViewWindow = new CostsView(viewModel);
            settingsViewWindow.ShowDialog();
        }

        private void CallApplicationInfoClick(object parameter)
        {
            ApplicationInfo applicationInfo = new ApplicationInfo();
            applicationInfo.ShowDialog();
        }
    }
}
