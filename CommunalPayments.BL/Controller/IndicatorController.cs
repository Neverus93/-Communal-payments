using CommunalPayments.BL.Model;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace CommunalPayments.BL.Controller
{
    class IndicatorController
    {
        public DataIndicator Indicator { get; }

        public IndicatorController(DataIndicator lastDataIndicators)
        {
            Indicator = lastDataIndicators;
        }

        private void SetNewData()
        {

        }

        private void SaveData()
        {
            var formatter = new XmlSerializer(typeof(DataIndicator));

            using(var fs = new FileStream("DataIndicators.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Indicator);
            }
        }

        private List<DataIndicator> GetDataIndicators()
        {
            var formatter = new XmlSerializer(typeof(DataIndicator));

            using(var fs = new FileStream("DataIndicators.xml", FileMode.OpenOrCreate))
            {
                if(fs.Length > 0 && formatter.Deserialize(fs) is List<DataIndicator> dataIndicators)
                {
                    return dataIndicators;
                }
                else
                {
                    return new List<DataIndicator>();
                }
            }
        }
    }
}
