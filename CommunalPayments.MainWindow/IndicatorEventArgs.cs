using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPayments.MainWindow
{
    class IndicatorEventArgs
    {
        public double IndicatorCost { get; }

        public IndicatorEventArgs(double indicatorCost)
        {
            IndicatorCost = indicatorCost;
        }
    }
}
