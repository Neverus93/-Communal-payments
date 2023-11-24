using System;

namespace CommunalPayments.Models
{
    [Serializable]
    public class IndicatorsModel
    {
        public decimal ColdWater { get; set; }
        public decimal HotWater { get; set; }
        public decimal Electricity { get; set; }

        public IndicatorsModel()
        {

        }

        public IndicatorsModel(decimal coldWater, decimal hotWater, decimal electricity)
        {
            ColdWater = coldWater;
            HotWater = hotWater;
            Electricity = electricity;
        }

        public static IndicatorsModel operator -(IndicatorsModel previous, IndicatorsModel current)
        {
            return new IndicatorsModel
            {
                ColdWater = current.ColdWater - previous.ColdWater,
                HotWater = current.HotWater - previous.HotWater,
                Electricity = current.Electricity - previous.Electricity
            };
        }
    }
}
