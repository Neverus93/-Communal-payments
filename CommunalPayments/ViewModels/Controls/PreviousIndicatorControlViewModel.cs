using CommunalPayments.Models;
using Prism.Mvvm;

namespace CommunalPayments.ViewModels.Controls
{
    public class PreviousIndicatorControlViewModel : BindableBase
    {
        private readonly IndicatorsModel _previousIndicators = new IndicatorsModel();

        public decimal PreviousColdWaterIndicator => _previousIndicators.ColdWater;
        public decimal PreviousHotWaterIndicator => _previousIndicators.HotWater;
        public decimal PreviousElectricityindicator => _previousIndicators.Electricity;
    }
}
