using CommunalPayments.Models;
using Prism.Mvvm;

namespace CommunalPayments.ViewModels.Controls
{
    public class PreviousIndicatorControlViewModel : BindableBase
    {
        private IndicatorInfo previousIndicators = new IndicatorInfo();

        public decimal PreviousColdWaterIndicator => previousIndicators.ColdWaterIndicator;
        public decimal PreviousHotWaterIndicator => previousIndicators.HotWaterIndicator;
        public decimal PreviousElectricityindicator => previousIndicators.ElectricityIndicator;
    }
}
