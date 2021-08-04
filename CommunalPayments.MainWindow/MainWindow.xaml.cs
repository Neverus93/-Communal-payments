using System.IO;
using System.Windows;

namespace CommunalPayments.MainWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    //delegate double IndicatorHandler(double cold, double hot, double electricity, double summator, double internet);
    //delegate SettingsCost SettingsHandler();
    public partial class MainWindow : Window
    {
        #region TODO events
        //event IndicatorHandler ColdWaterIndicatorChanged;
        //event IndicatorHandler HotWaterIndicatorChanged;
        //event IndicatorHandler ElectricityIndicatorChanged;
        //event IndicatorHandler WaterSummatorChanged;
        //event IndicatorHandler InternetCostChanged;

        //event SettingsHandler SettingsShanged;
        #endregion

        DataIndicator data = new DataIndicator();
        SettingsCost settings = new SettingsCost();

        //IndicatorHandler indicatorHandler = new IndicatorHandler(DataIndicator.OverallCalculate);
        double currentColdWater;
        double currentHotWater;

        double resultSummator;
        double resultCold;
        double resultHot;
        double resultElectricity;

        private readonly string indicatorPath = "DataIndicator.xml";
        private readonly string settingsPath = "Settings.xml";
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(indicatorPath))
            {
                data.GetData(out data);
            }
            else
            {
                data.SaveData(0, 0, 0);
            }

            if (!File.Exists(settingsPath))
            {
                settings.SaveSettings(0, 0, 0, 0, 0);
            }
            else
            {
                settings.GetSettings(out settings);
            }
            PreviousCold.Content = data.ColdWater;
            PreviousHot.Content = data.HotWater;
            PreviousElecricity.Content = data.Electricity;
            CalculateInternet.Content = settings.InternetCost;
        }

        private void SaveCalling_Click(object sender, RoutedEventArgs e)
        {
            double coldWater = double.Parse(ColdWaterInput.Text);
            double hotWater = double.Parse(HotWaterInput.Text);
            double electricity = double.Parse(ElectricityInput.Text);
            data.SaveData(coldWater, hotWater, electricity);
        }

        private void HotWaterInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            double previousHotWater = data.HotWater;
            double hotWaterCostPerCube = settings.HotWaterCostPerCube;
            double previousSummator = data.HotWater + data.ColdWater;

            double waterSummatorCost = settings.WaterSumCost;
            TryParseFunction(HotWaterInput.Text, out currentHotWater);
            double currentSummator = currentHotWater + currentColdWater;
            CurrentHot.Content = HotWaterInput.Text;

            CalculateHot.Content = DataIndicator.CalculateCost(currentHotWater, previousHotWater, hotWaterCostPerCube, out resultHot);
            CalculateWaterSummator.Content = DataIndicator.CalculateCost(currentSummator, previousSummator, waterSummatorCost, out resultSummator);
            CalculateScore.Content = DataIndicator.OverallCalculate(resultCold, resultHot, resultElectricity, resultSummator, settings.InternetCost);
        }

        private void ColdWaterInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            double previousColdWater = data.ColdWater;
            double coldWaterCostPerCube = settings.ColdWaterCostPerCube;
            double previousSum = data.HotWater + data.ColdWater;

            double waterSumCost = settings.WaterSumCost;
            TryParseFunction(ColdWaterInput.Text, out currentColdWater);
            double currentSum = currentHotWater + currentColdWater;
            CurrentCold.Content = ColdWaterInput.Text;

            CalculateCold.Content = DataIndicator.CalculateCost(currentColdWater, previousColdWater, coldWaterCostPerCube, out resultCold);
            CalculateWaterSummator.Content = DataIndicator.CalculateCost(currentSum, previousSum, waterSumCost, out resultSummator);
            CalculateScore.Content = DataIndicator.OverallCalculate(resultCold, resultHot, resultElectricity, resultSummator, settings.InternetCost);
        }

        private void ElectricityInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            double currentElectricity;
            double previousElectricity = data.Electricity;
            double electricityCostPerKwt = settings.ElectricityCostPerKwt;

            TryParseFunction(ElectricityInput.Text, out currentElectricity);
            CurrentElecricity.Content = ElectricityInput.Text;

            CalculateElecricity.Content = DataIndicator.CalculateCost(currentElectricity, previousElectricity, electricityCostPerKwt, out resultElectricity);
            CalculateScore.Content = DataIndicator.OverallCalculate(resultCold, resultHot, resultElectricity, resultSummator, settings.InternetCost);
        }

        private void SettingsCalling_Click(object sender, RoutedEventArgs e)
        {
            CostSettings costSettings = new CostSettings();
            costSettings.Show();
        }

        private void TryParseFunction(string text, out double result)
        {
            if (double.TryParse(text, out result))
            {
                result = double.Parse(text);
            }
            else
            {
                result = 0;
            }
        }
    }
}
