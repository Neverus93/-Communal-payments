using System;

namespace CommunalPayments.MainWindow.Model
{
    [Serializable]
    class IndicatorInfo
    {
        public double ColdWaterIndicator { get; set; }
        public double HotWaterIndicator { get; set; }
        public double ElectricityIndicator { get; set; }

    }
}
