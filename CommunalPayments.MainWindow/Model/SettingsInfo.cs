using System;

namespace CommunalPayments.MainWindow.Model
{
    [Serializable]
    class SettingsInfo
    {
        public double ColdWaterPerCubeCost { get; set; }
        public double HotWaterPerCubeCost { get; set; }
        public double ElectricityPerKwtCost { get; set; }
        public double InternetCost { get; set; }
        public double WaterSumCost { get; set; }
    }
}
