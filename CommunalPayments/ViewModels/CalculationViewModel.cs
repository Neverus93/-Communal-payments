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
        public IndicatorsViewModel PreviousIndicators { get; set; }
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
                _coldWaterIndicatorDifference = value;
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
                _hotWaterIndicatorDifference = value;
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
                _electricityIndicatorDifference = value;
                RaisePropertyChanged();
            }
        }
        public decimal WaterSum
        {
            get => _waterSum;
            set
            {
                _waterSum = value;
                RaisePropertyChanged();
            }
        }

        public decimal ColdWaterCostResult
        {
            get => _coldWaterCostResult;
            set
            {
                _coldWaterCostResult = value;
                RaisePropertyChanged();
            }
        }
        public decimal HotWaterCostResult
        {
            get => _hotWaterCostResult;
            set
            {
                _hotWaterCostResult = value;
                RaisePropertyChanged();
            }
        }
        public decimal ElectricityCostResult
        {
            get => _electricityCostResult;
            set
            {
                _electricityCostResult = value;
                RaisePropertyChanged();
            }
        }
        public decimal WaterSumCostResult
        {
            get => _waterSumCostResult;
            set
            {
                _waterSumCostResult = value;
                RaisePropertyChanged();
            }
        }

        public decimal OverallResult
        {
            get => _overallResult;
            set
            {
                _overallResult = value;
                RaisePropertyChanged();
            }
        }

        public CalculationViewModel(CostsViewModel costsViewModel, IndicatorsViewModel indicators, IndicatorsViewModel previousIndicators)
        {
            Indicators = indicators;
            PreviousIndicators = previousIndicators;
            ColdWaterPerCubeCost = costsViewModel.ColdWaterPerCube;
            HotWaterPerCubeCost = costsViewModel.HotWaterPerCube;
            ElectricityPerKwtCost = costsViewModel.ElectricityPerKwt;
            InternetCost = costsViewModel.Internet;
            WaterSumCost = costsViewModel.WaterSum;
            Indicators.PropertyChanged += (s, e) => UpdateCalculation();
        }

        private void UpdateCalculation()
        {
            ColdWaterIndicatorDifference = Indicators.ColdWaterIndicator - PreviousIndicators.ColdWaterIndicator;
            HotWaterIndicatorDifference = Indicators.HotWaterIndicator - PreviousIndicators.HotWaterIndicator;
            ElectricityIndicatorDifference = Indicators.ElectricityIndicator - PreviousIndicators.ElectricityIndicator;
            WaterSum = ColdWaterIndicatorDifference + HotWaterIndicatorDifference;
            ColdWaterCostResult = ColdWaterIndicatorDifference * ColdWaterPerCubeCost;
            HotWaterCostResult = HotWaterIndicatorDifference * HotWaterPerCubeCost;
            ElectricityCostResult = ElectricityIndicatorDifference * ElectricityPerKwtCost;
            WaterSumCostResult = WaterSum * WaterSumCost;
            OverallResult = ColdWaterCostResult + HotWaterCostResult + ElectricityCostResult + WaterSumCostResult;
        }
    }
}
