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
        private readonly IndicatorInfoControlViewModel _indicatorInfoControlViewModel;

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
            IndicatorInfo indicator = new IndicatorInfo(_indicatorInfoControlViewModel.CurrentColdWaterIndicator,
                                                        _indicatorInfoControlViewModel.CurrentHotWaterIndicator,
                                                        _indicatorInfoControlViewModel.CurrentElectricityIndicator);
            SerializeHelper<IndicatorInfo>.Save(indicator);
            MessageBox.Show("Данные успешно сохранены!");
        }

        private void CallSettingsClick(object parameter)
        {
            var viewModel = new SettingsViewModel();
            SettingsView settingsViewWindow = new SettingsView(viewModel);
            settingsViewWindow.ShowDialog();
        }

        private void CallApplicationInfoClick(object parameter)
        {
            ApplicationInfo applicationInfo = new ApplicationInfo();
            applicationInfo.ShowDialog();
        }
    }
}
