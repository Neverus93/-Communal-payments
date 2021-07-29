using System;
using System.IO;
using System.Xml.Serialization;

namespace CommunalPayments.MainWindow
{
    [Serializable]
    public class DataIndicator
    {
        public double ColdWater { get; set; } = 0;
        public double HotWater { get; set; } = 0;
        public double Electricity { get; set; } = 0;

        XmlSerializer formatterData = new XmlSerializer(typeof(DataIndicator));

        public DataIndicator()
        {

        }

        public DataIndicator(double coldWater, double hotWater, double electricity)
        {
            ColdWater = coldWater;
            HotWater = hotWater;
            Electricity = electricity;
        }

        public void SaveData(double cold, double hot, double electro)
        {
            DataIndicator data = new DataIndicator(cold, hot, electro);

            using (FileStream fs = new FileStream("DataIndicator.xml", FileMode.OpenOrCreate))
            {
                formatterData.Serialize(fs, data);
            }
        }

        public void GetData(out DataIndicator data)
        {
            using (FileStream fs = new FileStream("DataIndicator.xml", FileMode.OpenOrCreate))
            {
                data = (DataIndicator)formatterData.Deserialize(fs);
            }
        }

        public string CalculateHot(double currentHotWater, double previousHotWater, double hotWaterCostPerCube)
        {
            return $"{currentHotWater - previousHotWater} x {hotWaterCostPerCube}₽ = {(currentHotWater - previousHotWater) * hotWaterCostPerCube}₽";
        }

        public void CalculateCold()
        {

        }

        public void CalculateElectricity()
        {

        }
    }
}
