using CommunalPayments.Models;
using Prism.Mvvm;

namespace CommunalPayments.ViewModels.Controls
{
    public class PreviousIndicatorControlViewModel : BindableBase
    {
        private readonly IndicatorInfo _previousIndicators = new IndicatorInfo();

        public decimal PreviousColdWaterIndicator => _previousIndicators.ColdWaterIndicator;
        public decimal PreviousHotWaterIndicator => _previousIndicators.HotWaterIndicator;
        public decimal PreviousElectricityindicator => _previousIndicators.ElectricityIndicator;
    }
}
