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

        public string CalculateCost(double currentIndicator, double previousIndicator, double costIndicator)
        {
            double differenceBetweenCurrentAndPrevious = currentIndicator - previousIndicator;
            if(currentIndicator < previousIndicator)
            {
                differenceBetweenCurrentAndPrevious = 0;
            }
            string calculateCost = $"{differenceBetweenCurrentAndPrevious} x {costIndicator}₽ = {differenceBetweenCurrentAndPrevious * costIndicator}₽";
            return calculateCost;
        }
    }
}
