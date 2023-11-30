using CommunalPayments.Command;
using CommunalPayments.Helpers;
using CommunalPayments.Models;
using CommunalPayments.Views;
using Prism.Mvvm;
using System.Windows;

namespace CommunalPayments.ViewModels.Controls
{
    public class ManageButtonsControlViewModel : BindableBase
    {
        private IndicatorsModel _indicator;

        public IndicatorDataTextControlViewModel IndicatorDataTextControlViewModel { get; set; } = 
            new IndicatorDataTextControlViewModel();
        public RelayCommand SaveIndicatorCommand { get; }
        public RelayCommand CallSettingsCommand { get; }
        public RelayCommand CallApplicationInfoCommand { get; }

        public ManageButtonsControlViewModel()
        {
            SaveIndicatorCommand = new RelayCommand(SaveIndicatorClick);
            CallSettingsCommand = new RelayCommand(CallSettingsClick);
            CallApplicationInfoCommand = new RelayCommand(CallApplicationInfoClick);
        }

        private void SaveIndicatorClick(object parameter)
        {
            _indicator = new IndicatorsModel(IndicatorDataTextControlViewModel.CurrentColdWaterIndicator,
                                                        IndicatorDataTextControlViewModel.CurrentHotWaterIndicator,
                                                        IndicatorDataTextControlViewModel.CurrentElectricityIndicator);
            SerializeHelper<IndicatorsModel>.Save(_indicator);
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
