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
    }
}
