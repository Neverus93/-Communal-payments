namespace CommunalPayments.MainWindow
{
    public static class Calculator
    {
        public static string CalculateCost(double currentIndicator, double previousIndicator, double costIndicator, out double resultCost)
        {
            double differenceBetweenCurrentAndPrevious = currentIndicator - previousIndicator;
            if (currentIndicator < previousIndicator)
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
