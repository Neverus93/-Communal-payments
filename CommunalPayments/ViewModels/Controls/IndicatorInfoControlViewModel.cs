using Prism.Mvvm;

namespace CommunalPayments.ViewModels.Controls
{
    public class IndicatorInfoControlViewModel : BindableBase
    {
        private decimal _currentColdWaterIndicator;
        private decimal _currentHotWaterindicator;
        private decimal _currentElectricityindicator;

        public decimal CurrentColdWaterIndicator
        {
            get
            {
                return _currentColdWaterIndicator;
            }
            set
            {
                _currentColdWaterIndicator = value;
                RaisePropertyChanged();
            }
        }
        public decimal CurrentHotWaterIndicator
        {
            get
            {
                return _currentHotWaterindicator;
            }
            set
            {
                _currentHotWaterindicator = value;
                RaisePropertyChanged();
            }
        }
        public decimal CurrentElectricityIndicator
        {
            get
            {
                return _currentElectricityindicator;
            }
            set
            {
                _currentElectricityindicator = value;
                RaisePropertyChanged();
            }
        }

        public IndicatorInfoControlViewModel()
        {
            
        }

        public IndicatorInfoControlViewModel(decimal cold, decimal hot, decimal elecricity)
        {
            CurrentColdWaterIndicator = cold;
            CurrentHotWaterIndicator = hot;
            CurrentElectricityIndicator = elecricity;
        }
    }
}
