using CommunalPayments.Models;
using Prism.Mvvm;

namespace CommunalPayments.ViewModels.Controls
{
    public class IndicatorDataTextControlViewModel : BindableBase
    {
        private decimal _coldIndicator;
        private decimal _hotIndicator;
        private decimal _electricityIndicator;

        public IndicatorsModel Indicators { get; set; } = new IndicatorsModel();

        public decimal CurrentColdWaterIndicator
        {
            get
            {
                return _coldIndicator;
            }
            set
            {
                _coldIndicator = value;
                RaisePropertyChanged("CurrentColdWaterIndicator");
            }
        }
        public decimal CurrentHotWaterIndicator
        {
            get
            {
                return _hotIndicator;
            }
            set
            {
                _hotIndicator = value;
                RaisePropertyChanged("CurrentHotWaterIndicator");
            }
        }
        public decimal CurrentElectricityIndicator
        {
            get
            {
                return _electricityIndicator;
            }
            set
            {
                _electricityIndicator = value;
                RaisePropertyChanged("CurrentElectricityIndicator");
            }
        }

        public IndicatorDataTextControlViewModel()
        {
        }
    }
}
