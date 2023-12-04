using System;
using Prism.Mvvm;

namespace CommunalPayments.ViewModels.Controls
{
    [Serializable]
    public class IndicatorsViewModel : BindableBase
    {
        private decimal _coldWater;
        private decimal _hotWater;
        private decimal _electricity;

        public decimal ColdWaterIndicator
        {
            get
            {
                return _coldWater;
            }
            set
            {
                _coldWater = value;
                RaisePropertyChanged();
            }
        }
        public decimal HotWaterIndicator
        {
            get
            {
                return _hotWater;
            }
            set
            {
                _hotWater = value;
                RaisePropertyChanged();
            }
        }
        public decimal ElectricityIndicator
        {
            get
            {
                return _electricity;
            }
            set
            {
                _electricity = value;
                RaisePropertyChanged();
            }
        }

        public IndicatorsViewModel()
        {
        }

        public IndicatorsViewModel(decimal cold, decimal hot, decimal electricity)
        {
            ColdWaterIndicator = cold;
            HotWaterIndicator = hot;
            ElectricityIndicator = electricity;
        }

        public static IndicatorsViewModel operator -(IndicatorsViewModel previous, IndicatorsViewModel current)
        {
            return new IndicatorsViewModel
            {
                ColdWaterIndicator = current.ColdWaterIndicator - previous.ColdWaterIndicator,
                HotWaterIndicator = current.HotWaterIndicator - previous.HotWaterIndicator,
                ElectricityIndicator = current.ElectricityIndicator - previous.ElectricityIndicator
            };
        }
    }
}
