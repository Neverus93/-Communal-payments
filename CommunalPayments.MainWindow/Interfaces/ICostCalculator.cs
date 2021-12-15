namespace CommunalPayments.MainWindow.Interfaces
{
    interface ICostCalculator
    {
        string CalculateCost(double currentIndicator, double previousIndicator, double costIndicator, out double resultCost);
        double OverallCalculate(double cold, double hot, double electricity, double summator, double internet);
    }
}
