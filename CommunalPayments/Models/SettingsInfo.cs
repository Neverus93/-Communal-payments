using System;

namespace CommunalPayments.MainWindow.Model
{
    [Serializable]
    public class SettingsInfo
    {
        public double ColdWaterPerCubeCost { get; set; }
        public double HotWaterPerCubeCost { get; set; }
        public double ElectricityPerKwtCost { get; set; }
        public double InternetCost { get; set; }
        public double WaterSumCost { get; set; }

        public SettingsInfo()
        {

        }

        public SettingsInfo(double coldWaterPerCubeCost, double hotWaterPerCubeCost, 
            double electricityPerKwtCost, double internetCost, double waterSumCost)
        {
            ColdWaterPerCubeCost = coldWaterPerCubeCost;
            HotWaterPerCubeCost = hotWaterPerCubeCost;
            ElectricityPerKwtCost = electricityPerKwtCost;
            InternetCost = internetCost;
            WaterSumCost = waterSumCost;
        }
    }
}
