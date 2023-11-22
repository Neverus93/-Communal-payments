using CommunalPayments.Models;
using CommunalPayments.Views;
using CommunalPayments.Helpers;
using Prism.Mvvm;
using System.Windows;
using System;
using CommunalPayments.ViewModels.Controls;

namespace CommunalPayments.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private decimal _coldWaterIndicatorDifference;
        private decimal _hotWaterIndicatorDifference;
        private decimal _electricityIndicatorDifference;

        private readonly IndicatorInfo _previousIndicators = new IndicatorInfo();
        private readonly SettingsModel _settings = new SettingsModel();
        private readonly IndicatorInfoControlViewModel _indicatorInfoControlViewModel;

        public decimal PreviousColdWaterIndicator => _previousIndicators.ColdWaterIndicator;
        public decimal PreviousHotWaterIndicator => _previousIndicators.HotWaterIndicator;
        public decimal PreviousElectricityindicator => _previousIndicators.ElectricityIndicator;

        public decimal ColdWaterPerCubeCost => _settings.ColdWaterPerCubeCost;
        public decimal HotWaterPerCubeCost => _settings.HotWaterPerCubeCost;
        public decimal ElectricityPerKwtCost => _settings.ElectricityPerKwtCost;
        public decimal InternetCost => _settings.InternetCost;
        public decimal WaterSumCost => _settings.WaterSumCost;

        public IndicatorInfoControlViewModel IndicatorInfoControlViewModel { get; } = new IndicatorInfoControlViewModel();
        public ManageButtonsControlViewModel ManageButtonsControlViewModel { get; } = new ManageButtonsControlViewModel();

        public decimal ColdWaterIndicatorDifference
        {
            get
            {
                return _coldWaterIndicatorDifference < 0 ? 0 : _coldWaterIndicatorDifference;
            }
            set
            {
                _coldWaterIndicatorDifference = _indicatorInfoControlViewModel.CurrentColdWaterIndicator - PreviousColdWaterIndicator;
                RaisePropertyChanged();
            }
        }
        public decimal HotWaterIndicatorDifference
        {
            get
            {
                return _hotWaterIndicatorDifference < 0 ? 0 : _hotWaterIndicatorDifference;
            }
            set
            {
                _hotWaterIndicatorDifference = _indicatorInfoControlViewModel.CurrentHotWaterIndicator - PreviousHotWaterIndicator;
                RaisePropertyChanged();
            }
        }
        public decimal ElectricityIndicatorDifference
        {
            get
            {
                return _electricityIndicatorDifference < 0 ? 0 : _electricityIndicatorDifference;
            }
            set
            {
                _electricityIndicatorDifference = _indicatorInfoControlViewModel.CurrentElectricityIndicator - PreviousElectricityindicator;
                RaisePropertyChanged();
            }
        }

        public decimal WaterSum => ColdWaterIndicatorDifference + HotWaterIndicatorDifference;

        public decimal ColdWaterCostResult => ColdWaterIndicatorDifference * ColdWaterPerCubeCost;
        public decimal HotWaterCostResult => HotWaterIndicatorDifference * HotWaterPerCubeCost;
        public decimal ElectricityCostResult => ElectricityIndicatorDifference * ElectricityPerKwtCost;
        public decimal WaterSumCostResult => WaterSum * WaterSumCost;

        public decimal OverallResult => ColdWaterCostResult + HotWaterCostResult + ElectricityCostResult + WaterSumCostResult;

        public MainWindowViewModel()
        {
            SerializeHelper<IndicatorInfo>.CheckDataFile(_previousIndicators);

            try
            {
                _previousIndicators = SerializeHelper<IndicatorInfo>.Get();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            try
            {
                _settings = SerializeHelper<SettingsModel>.Get();
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
        }
    }
}
