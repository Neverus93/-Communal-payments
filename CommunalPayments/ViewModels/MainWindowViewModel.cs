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

        private readonly Costs _settings = new Costs();

        public IndicatorsDataTextControlViewModel IndicatorDataTextControlViewModel { get; }
        public ManageButtonsControlViewModel ManageButtonsControlViewModel { get; }

        public decimal PreviousColdWaterIndicator => IndicatorDataTextControlViewModel.ColdWaterIndicator;
        public decimal PreviousHotWaterIndicator => IndicatorDataTextControlViewModel.HotWaterIndicator;
        public decimal PreviousElectricityindicator => IndicatorDataTextControlViewModel.ElectricityIndicator;

        public decimal ColdWaterPerCubeCost => _settings.ColdWaterPerCube;
        public decimal HotWaterPerCubeCost => _settings.HotWaterPerCube;
        public decimal ElectricityPerKwtCost => _settings.ElectricityPerKwt;
        public decimal InternetCost => _settings.Internet;
        public decimal WaterSumCost => _settings.WaterSum;

        public decimal ColdWaterIndicatorDifference
        {
            get
            {
                return _coldWaterIndicatorDifference < 0 ? 0 : _coldWaterIndicatorDifference;
            }
            set
            {
                _coldWaterIndicatorDifference = IndicatorDataTextControlViewModel.ColdWaterIndicator - PreviousColdWaterIndicator;
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
                _hotWaterIndicatorDifference = IndicatorDataTextControlViewModel.HotWaterIndicator - PreviousHotWaterIndicator;
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
                _electricityIndicatorDifference = IndicatorDataTextControlViewModel.ElectricityIndicator - PreviousElectricityindicator;
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
            IndicatorDataTextControlViewModel = new IndicatorsDataTextControlViewModel();
            ManageButtonsControlViewModel = new ManageButtonsControlViewModel(IndicatorDataTextControlViewModel);

            SerializeHelper<IndicatorsDataTextControlViewModel>.CheckDataFile(IndicatorDataTextControlViewModel);

            try
            {
                IndicatorDataTextControlViewModel = SerializeHelper<IndicatorsDataTextControlViewModel>.Get();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            try
            {
                _settings = SerializeHelper<Costs>.Get();
            }
            catch
            {
                MessageBoxResult result = MessageBox.Show("Добро пожаловать в программу для расчёта коммунальных платежей. " +
                    "Хотите задать настройки сейчас?", "Приветствие", MessageBoxButton.YesNo, MessageBoxImage.Information);

                if(result == MessageBoxResult.Yes)
                {
                    CostsViewModel settingsViewModel = new CostsViewModel();
                    CostsView settingsView = new CostsView(settingsViewModel);
                    settingsView.ShowDialog();
                }
            }
        }
    }
}
