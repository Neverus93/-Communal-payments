using System;
using System.IO;
using System.Xml.Serialization;

namespace CommunalPayments.MainWindow
{
    [Serializable]
    public class SettingsCost
    {
        public double ColdWaterCostPerCube { get; set; } = 0;
        public double HotWaterCostPerCube { get; set; } = 0;
        public double ElectricityCostPerKwt { get; set; } = 0;
        public double InternetCost { get; set; } = 0;

        XmlSerializer formatterCost = new XmlSerializer(typeof(SettingsCost));

        public SettingsCost()
        {

        }

        public SettingsCost(double coldWaterCost, double hotWaterCost, double electricityCost, double internetCost)
        {
            ColdWaterCostPerCube = coldWaterCost;
            HotWaterCostPerCube = hotWaterCost;
            ElectricityCostPerKwt = electricityCost;
            InternetCost = internetCost;
        }

        public void SaveSettings(double coldCost, double hotCost, double electricityCost, double internetCost)
        {
            SettingsCost settings = new SettingsCost(coldCost, hotCost, electricityCost, internetCost);

            using (FileStream fs = new FileStream("Settings.xml", FileMode.OpenOrCreate))
            {
                formatterCost.Serialize(fs, settings);
            }
        }
    }
}
