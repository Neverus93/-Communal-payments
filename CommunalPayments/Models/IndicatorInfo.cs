using System;

namespace CommunalPayments.Models
{
    [Serializable]
    public class IndicatorInfo
    {
        public decimal ColdWaterIndicator { get; set; }
        public decimal HotWaterIndicator { get; set; }
        public decimal ElectricityIndicator { get; set; }

        public IndicatorInfo()
        {

        }

        public IndicatorInfo(decimal coldWaterIndicator, decimal hotWaterIndicator, decimal electricityIndicator)
        {
            ColdWaterIndicator = coldWaterIndicator;
            HotWaterIndicator = hotWaterIndicator;
            ElectricityIndicator = electricityIndicator;
        }

        public static IndicatorInfo operator -(IndicatorInfo previousindicators, IndicatorInfo currentIndicators)
        {
            return new IndicatorInfo
            {
                ColdWaterIndicator = currentIndicators.ColdWaterIndicator - previousindicators.ColdWaterIndicator,
                HotWaterIndicator = currentIndicators.HotWaterIndicator - previousindicators.HotWaterIndicator,
                ElectricityIndicator = currentIndicators.ElectricityIndicator - previousindicators.ElectricityIndicator
            };
        }
    }
}
