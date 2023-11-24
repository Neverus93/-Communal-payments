using System;

namespace CommunalPayments.Models
{
    [Serializable]
    public class CostsModel
    {
        public decimal ColdWaterPerCube { get; set; }
        public decimal HotWaterPerCube { get; set; }
        public decimal ElectricityPerKwt { get; set; }
        public decimal Internet { get; set; }
        public decimal WaterSum { get; set; }

        public CostsModel()
        {

        }

        public CostsModel(decimal coldWaterPerCube, decimal hotWaterPerCube,
            decimal electricityPerKwt, decimal internet, decimal waterSum)
        {
            ColdWaterPerCube = coldWaterPerCube;
            HotWaterPerCube = hotWaterPerCube;
            ElectricityPerKwt = electricityPerKwt;
            Internet = internet;
            WaterSum = waterSum;
        }
    }
}
