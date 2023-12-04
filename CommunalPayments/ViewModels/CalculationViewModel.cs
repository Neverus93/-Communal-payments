using CommunalPayments.ViewModels.Controls;
using Prism.Mvvm;

namespace CommunalPayments.ViewModels
{
    public class CalculationViewModel : BindableBase
    {
        private decimal _coldWaterIndicatorDifference;
        private decimal _hotWaterIndicatorDifference;
        private decimal _electricityIndicatorDifference;
        private decimal _waterSum;
        private decimal _coldWaterCostResult;
        private decimal _hotWaterCostResult;
        private decimal _electricityCostResult;
        private decimal _waterSumCostResult;
        private decimal _overallResult;

        public IndicatorsViewModel Indicators { get; set; }
        public MainWindowViewModel MainWindow { get; set; }
        public CostsViewModel Costs { get; set; }
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
                _coldWaterIndicatorDifference = Indicators.ColdWaterIndicator - MainWindow.PreviousColdWaterIndicator;
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
                _hotWaterIndicatorDifference = Indicators.HotWaterIndicator - MainWindow.PreviousHotWaterIndicator;
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
                _electricityIndicatorDifference = Indicators.ElectricityIndicator - MainWindow.PreviousElectricityindicator;
                RaisePropertyChanged();
            }
        }
        public decimal WaterSum
        {
            get => _waterSum;
            set
            {
                _waterSum = ColdWaterIndicatorDifference + HotWaterIndicatorDifference;
                RaisePropertyChanged();
            }
        }

        public decimal ColdWaterCostResult
        {
            get => _coldWaterCostResult;
            set
            {
                _coldWaterCostResult = ColdWaterIndicatorDifference * ColdWaterPerCubeCost;
                RaisePropertyChanged();
            }
        }
        public decimal HotWaterCostResult
        {
            get => _hotWaterCostResult;
            set
            {
                _hotWaterCostResult = HotWaterIndicatorDifference * HotWaterPerCubeCost;
                RaisePropertyChanged();
            }
        }
        public decimal ElectricityCostResult
        {
            get => _electricityCostResult;
            set
            {
                _electricityCostResult = ElectricityIndicatorDifference * ElectricityPerKwtCost;
                RaisePropertyChanged();
            }
        }
        public decimal WaterSumCostResult
        {
            get => _waterSumCostResult;
            set
            {
                _waterSumCostResult = WaterSum * WaterSumCost;
                RaisePropertyChanged();
            }
        }

        public decimal OverallResult
        {
            get => _overallResult;
            set
            {
                _overallResult = ColdWaterCostResult + HotWaterCostResult + ElectricityCostResult + WaterSumCostResult;
                RaisePropertyChanged();
            }
        }

        public CalculationViewModel(CostsViewModel costsViewModel)
        {
            Costs = costsViewModel;
            ColdWaterPerCubeCost = Costs.ColdWaterPerCube;
            HotWaterPerCubeCost = Costs.HotWaterPerCube;
            ElectricityPerKwtCost = Costs.ElectricityPerKwt;
            InternetCost = Costs.Internet;
            WaterSumCost = Costs.WaterSum;
        }
    }
}
