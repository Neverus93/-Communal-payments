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

        public CostsViewModel Costs { get; set; }
        public IndicatorsViewModel Indicators { get; set; }
        public IndicatorsViewModel PreviousIndicators { get; set; }

        public decimal ColdWaterIndicatorDifference
        {
            get => _coldWaterIndicatorDifference < 0 ? 0 : _coldWaterIndicatorDifference;
            set => SetProperty(ref _coldWaterIndicatorDifference, value);
        }
        public decimal HotWaterIndicatorDifference
        {
            get => _hotWaterIndicatorDifference < 0 ? 0 : _hotWaterIndicatorDifference;
            set => SetProperty(ref _hotWaterIndicatorDifference, value);
        }
        public decimal ElectricityIndicatorDifference
        {
            get => _electricityIndicatorDifference < 0 ? 0 : _electricityIndicatorDifference;
            set => SetProperty(ref _electricityIndicatorDifference, value);
        }
        public decimal WaterSum
        {
            get => _waterSum;
            set => SetProperty(ref _waterSum, value);
        }

        public decimal ColdWaterCostResult
        {
            get => _coldWaterCostResult;
            set => SetProperty(ref _coldWaterCostResult, value);
        }
        public decimal HotWaterCostResult
        {
            get => _hotWaterCostResult;
            set => SetProperty(ref _hotWaterCostResult, value);
        }
        public decimal ElectricityCostResult
        {
            get => _electricityCostResult;
            set => SetProperty(ref _electricityCostResult, value);
        }
        public decimal WaterSumCostResult
        {
            get => _waterSumCostResult;
            set => SetProperty(ref _waterSumCostResult, value);
        }

        public decimal OverallResult
        {
            get => _overallResult;
            set => SetProperty(ref _overallResult, value);
        }

        public CalculationViewModel(CostsViewModel costsViewModel, IndicatorsViewModel indicators, IndicatorsViewModel previousIndicators)
        {
            Indicators = indicators;
            PreviousIndicators = previousIndicators;
            Costs = costsViewModel;
            Indicators.PropertyChanged += (s, e) => UpdateCalculation();
            Costs.PropertyChanged += (s, e) => UpdateCalculation();
        }

        private void UpdateCalculation()
        {
            ColdWaterIndicatorDifference = Indicators.ColdWaterIndicator - PreviousIndicators.ColdWaterIndicator;
            HotWaterIndicatorDifference = Indicators.HotWaterIndicator - PreviousIndicators.HotWaterIndicator;
            ElectricityIndicatorDifference = Indicators.ElectricityIndicator - PreviousIndicators.ElectricityIndicator;
            WaterSum = ColdWaterIndicatorDifference + HotWaterIndicatorDifference;
            ColdWaterCostResult = ColdWaterIndicatorDifference * Costs.ColdWaterPerCube;
            HotWaterCostResult = HotWaterIndicatorDifference * Costs.HotWaterPerCube;
            ElectricityCostResult = ElectricityIndicatorDifference * Costs.ElectricityPerKwt;
            WaterSumCostResult = WaterSum * Costs.WaterSum;
            OverallResult = ColdWaterCostResult + HotWaterCostResult + ElectricityCostResult + WaterSumCostResult + Costs.Internet;
        }
    }
}
