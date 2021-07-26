using System;

namespace CommunalPayments.MainWindow
{
    [Serializable]
    public class DataIndicator
    {
        public double ColdWater { get; set; }
        public double HotWater { get; set; }
        public double Electricity { get; set; }

        public DataIndicator()
        {

        }

        public DataIndicator(double coldWater, double hotWater, double electricity)
        {
            ColdWater = coldWater;
            HotWater = hotWater;
            Electricity = electricity;
        }
    }
}
