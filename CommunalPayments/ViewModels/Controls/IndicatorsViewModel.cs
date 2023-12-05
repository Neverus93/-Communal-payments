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
            get => _coldWater;
            set => SetProperty(ref _coldWater, value);
        }
        public decimal HotWaterIndicator
        {
            get => _hotWater;
            set => SetProperty(ref _hotWater, value);
        }
        public decimal ElectricityIndicator
        {
            get => _electricity;
            set => SetProperty(ref _electricity, value);
        }

        public IndicatorsViewModel()
        {
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
