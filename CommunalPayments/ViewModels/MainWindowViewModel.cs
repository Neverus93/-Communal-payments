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

        public CostsViewModel CostsViewModel { get; set; }
        public IndicatorsViewModel IndicatorDataTextControlViewModel { get; set; }
        public ManageButtonsControlViewModel ManageButtonsControlViewModel { get; set; }

        public decimal PreviousColdWaterIndicator { get; set; }
        public decimal PreviousHotWaterIndicator { get; set; }
        public decimal PreviousElectricityindicator { get; set; }

        public decimal ColdWaterPerCubeCost { get; set; }
        public decimal HotWaterPerCubeCost { get; set; }
        public decimal ElectricityPerKwtCost { get; set; }
        public decimal InternetCost { get; set; }
        public decimal WaterSumCost { get; set; }

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
            IndicatorDataTextControlViewModel = new IndicatorsViewModel();
            ManageButtonsControlViewModel = new ManageButtonsControlViewModel(IndicatorDataTextControlViewModel);
            CostsViewModel = new CostsViewModel();

            SerializeHelper<IndicatorsViewModel>.CheckDataFile(IndicatorDataTextControlViewModel);

            try
            {
                IndicatorDataTextControlViewModel = SerializeHelper<IndicatorsViewModel>.Get();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            try
            {
                CostsViewModel = SerializeHelper<CostsViewModel>.Get();
            }
            catch
            {
                MessageBoxResult result = MessageBox.Show("Добро пожаловать в программу для расчёта коммунальных платежей. " +
                    "Хотите задать настройки сейчас?", "Приветствие", MessageBoxButton.YesNo, MessageBoxImage.Information);

                if(result == MessageBoxResult.Yes)
                {
                    CostsView settingsView = new CostsView(CostsViewModel);
                    settingsView.ShowDialog();
                }
            }

            ColdWaterPerCubeCost = CostsViewModel.ColdWaterPerCube;
            HotWaterPerCubeCost = CostsViewModel.HotWaterPerCube;
            ElectricityPerKwtCost = CostsViewModel.ElectricityPerKwt;
            InternetCost = CostsViewModel.Internet;
            WaterSumCost = CostsViewModel.WaterSum;
            PreviousColdWaterIndicator = IndicatorDataTextControlViewModel.ColdWaterIndicator;
            PreviousHotWaterIndicator = IndicatorDataTextControlViewModel.HotWaterIndicator;
            PreviousElectricityindicator = IndicatorDataTextControlViewModel.ElectricityIndicator;
        }
    }
}
