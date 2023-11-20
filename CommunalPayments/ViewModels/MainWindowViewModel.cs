using CommunalPayments.Models;
using CommunalPayments.Views;
using CommunalPayments.Command;
using CommunalPayments.Helpers;
using Prism.Mvvm;
using System.Windows;
using System;
using CommunalPayments.ViewModels.Controls;

namespace CommunalPayments.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private decimal coldWaterIndicatorDifference;
        private decimal hotWaterIndicatorDifference;
        private decimal electricityIndicatorDifference;

        private IndicatorInfo previousIndicators = new IndicatorInfo();
        private SettingsModel settings = new SettingsModel();
        private IndicatorInfoControlViewModel indicatorInfoControlViewModel;

        public decimal PreviousColdWaterIndicator => previousIndicators.ColdWaterIndicator;
        public decimal PreviousHotWaterIndicator => previousIndicators.HotWaterIndicator;
        public decimal PreviousElectricityindicator => previousIndicators.ElectricityIndicator;

        public decimal ColdWaterPerCubeCost => settings.ColdWaterPerCubeCost;
        public decimal HotWaterPerCubeCost => settings.HotWaterPerCubeCost;
        public decimal ElectricityPerKwtCost => settings.ElectricityPerKwtCost;
        public decimal InternetCost => settings.InternetCost;
        public decimal WaterSumCost => settings.WaterSumCost;

        public IndicatorInfoControlViewModel IndicatorInfoControlViewModel { get { return indicatorInfoControlViewModel; } }

        public decimal ColdWaterIndicatorDifference
        {
            get
            {
                return coldWaterIndicatorDifference < 0 ? 0 : coldWaterIndicatorDifference;
            }
            set
            {
                coldWaterIndicatorDifference = indicatorInfoControlViewModel.CurrentColdWaterIndicator - PreviousColdWaterIndicator;
                RaisePropertyChanged();
            }
        }
        public decimal HotWaterIndicatorDifference
        {
            get
            {
                return hotWaterIndicatorDifference < 0 ? 0 : hotWaterIndicatorDifference;
            }
            set
            {
                hotWaterIndicatorDifference = indicatorInfoControlViewModel.CurrentHotWaterIndicator - PreviousHotWaterIndicator;
                RaisePropertyChanged();
            }
        }
        public decimal ElectricityIndicatorDifference
        {
            get
            {
                return electricityIndicatorDifference < 0 ? 0 : electricityIndicatorDifference;
            }
            set
            {
                electricityIndicatorDifference = indicatorInfoControlViewModel.CurrentElectricityIndicator - PreviousElectricityindicator;
                RaisePropertyChanged();
            }
        }

        public decimal WaterSum => ColdWaterIndicatorDifference + HotWaterIndicatorDifference;

        public decimal ColdWaterCostResult => ColdWaterIndicatorDifference * ColdWaterPerCubeCost;
        public decimal HotWaterCostResult => HotWaterIndicatorDifference * HotWaterPerCubeCost;
        public decimal ElectricityCostResult => ElectricityIndicatorDifference * ElectricityPerKwtCost;
        public decimal WaterSumCostResult => WaterSum * WaterSumCost;

        public decimal OverallResult => ColdWaterCostResult + HotWaterCostResult + ElectricityCostResult + WaterSumCostResult;

        public RelayCommand SaveIndicatorCommand { get; }
        public RelayCommand CallSettingsCommand { get; }
        public RelayCommand CallApplicationInfoCommand { get; }

        public MainWindowViewModel()
        {
            SerializeHelper<IndicatorInfo>.CheckDataFile(previousIndicators);

            try
            {
                previousIndicators = SerializeHelper<IndicatorInfo>.Get();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            try
            {
                settings = SerializeHelper<SettingsModel>.Get();
            }
            catch
            {
                MessageBoxResult result = MessageBox.Show("Добро пожаловать в программу для расчёта коммунальных платежей. " +
                    "Хотите задать настройки сейчас?", "Приветствие", MessageBoxButton.YesNo, MessageBoxImage.Information);

                if(result == MessageBoxResult.Yes)
                {
                    SettingsViewModel settingsViewModel = new SettingsViewModel();
                    SettingsView settingsView = new SettingsView(settingsViewModel);
                    settingsView.ShowDialog();
                }
            }

            SaveIndicatorCommand = new RelayCommand(SaveIndicatorClick);
            CallSettingsCommand = new RelayCommand(CallSettingsClick);
            CallApplicationInfoCommand = new RelayCommand(CallApplicationInfoClick);
        }

        private void SaveIndicatorClick(object parameter)
        {
            IndicatorInfo indicator = new IndicatorInfo(indicatorInfoControlViewModel.CurrentColdWaterIndicator, indicatorInfoControlViewModel.CurrentHotWaterIndicator, indicatorInfoControlViewModel.CurrentElectricityIndicator);
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
