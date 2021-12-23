using System;

namespace CommunalPayments.Models
{
    [Serializable]
    class IndicatorInfo
    {
        public double ColdWaterIndicator { get; set; }
        public double HotWaterIndicator { get; set; }
        public double ElectricityIndicator { get; set; }

        public IndicatorInfo()
        {

        }

        public IndicatorInfo(double coldWaterIndicator, double hotWaterIndicator, double electricityIndicator)
        {
            ColdWaterIndicator = coldWaterIndicator;
            HotWaterIndicator = hotWaterIndicator;
            ElectricityIndicator = electricityIndicator;
        }
    }
}
