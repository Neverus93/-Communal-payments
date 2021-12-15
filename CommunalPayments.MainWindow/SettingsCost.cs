using System;
using System.IO;
using System.Xml.Serialization;

namespace CommunalPayments.MainWindow
{
    [Serializable]
    public class SettingsCost
    {
        public double ColdWaterCostPerCube { get; set; }
        public double HotWaterCostPerCube { get; set; }
        public double ElectricityCostPerKwt { get; set; }
        public double InternetCost { get; set; }
        public double WaterSumCost { get; set; }

        XmlSerializer formatterCost = new XmlSerializer(typeof(SettingsCost));

        public SettingsCost()
        {

        }

        public void SaveSettings(SettingsCost settings)
        {
            using (FileStream fs = new FileStream("Settings.xml", FileMode.OpenOrCreate))
            {
                formatterCost.Serialize(fs, settings);
            }
        }

        public SettingsCost GetSettings()
        {
            using (FileStream fs = new FileStream("Settings.xml", FileMode.OpenOrCreate))
            {
                SettingsCost dataCost = (SettingsCost)formatterCost.Deserialize(fs);
                return dataCost;
            }
        }
    }
}
