using System;
using System.IO;
using System.Xml.Serialization;

namespace CommunalPayments.MainWindow
{
    [Serializable]
    public class DataIndicator
    {
        public double ColdWater { get; set; }
        public double HotWater { get; set; }
        public double Electricity { get; set; }

        XmlSerializer formatterData = new XmlSerializer(typeof(DataIndicator));

        public DataIndicator()
        {

        }

        public void SaveData()
        {
            DataIndicator data = new DataIndicator();

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
    }
}
