using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPayments.BL.Model
{
    [Serializable]
    class DataIndicator
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
