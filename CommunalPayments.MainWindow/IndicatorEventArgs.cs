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
