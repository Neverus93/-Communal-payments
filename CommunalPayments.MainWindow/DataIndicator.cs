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

        public static string CalculateCost(double currentIndicator, double previousIndicator, double costIndicator, out double resultCost)
        {
            double differenceBetweenCurrentAndPrevious = currentIndicator - previousIndicator;
            if(currentIndicator < previousIndicator)
            {
                differenceBetweenCurrentAndPrevious = 0;
            }
            resultCost = differenceBetweenCurrentAndPrevious * costIndicator;
            string calculateCost = $"{differenceBetweenCurrentAndPrevious} x {costIndicator}₽ = {differenceBetweenCurrentAndPrevious * costIndicator}₽";
            return calculateCost;
        }

        public static double OverallCalculate(double cold, double hot, double electricity, double summator, double internet)
        {
            double result = cold + hot + electricity + summator + internet;
            return result;
        }
    }
}
