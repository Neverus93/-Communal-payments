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
        double currentElectricity;

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
            SaveCalling.IsEnabled = false;
        }

        private void SaveCalling_Click(object sender, RoutedEventArgs e)
        {
            double coldWater = double.Parse(ColdWaterInput.Text);
            double hotWater = double.Parse(HotWaterInput.Text);
            double electricity = double.Parse(ElectricityInput.Text);
            data.SaveData(coldWater, hotWater, electricity);
            MessageBox.Show("Данные успешно сохранены в базу данных!");
        }

        private void HotWaterInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if(HotWaterInput.Text.Length != 0 && ColdWaterInput.Text.Length != 0 && ElectricityInput.Text.Length != 0)
            {
                SaveCalling.IsEnabled = true;
            }
            else
            {
                SaveCalling.IsEnabled = false;
            }
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
            if(HotWaterInput.Text.Length != 0 && ColdWaterInput.Text.Length != 0 && ElectricityInput.Text.Length != 0)
            {
                SaveCalling.IsEnabled = true;
            }
            else
            {
                SaveCalling.IsEnabled = false;
            }
            double previousColdWater = data.ColdWater;
            double coldWaterCostPerCube = settings.ColdWaterCostPerCube;
            double previousSummator = data.HotWater + data.ColdWater;

            double waterSummatorCost = settings.WaterSumCost;
            TryParseFunction(ColdWaterInput.Text, out currentColdWater);
            double currentSummator = currentHotWater + currentColdWater;
            CurrentCold.Content = ColdWaterInput.Text;

            CalculateCold.Content = DataIndicator.CalculateCost(currentColdWater, previousColdWater, coldWaterCostPerCube, out resultCold);
            CalculateWaterSummator.Content = DataIndicator.CalculateCost(currentSummator, previousSummator, waterSummatorCost, out resultSummator);
            CalculateScore.Content = DataIndicator.OverallCalculate(resultCold, resultHot, resultElectricity, resultSummator, settings.InternetCost);
        }

        private void ElectricityInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if(HotWaterInput.Text.Length != 0 && ColdWaterInput.Text.Length != 0 && ElectricityInput.Text.Length != 0)
            {
                SaveCalling.IsEnabled = true;
            }
            else
            {
                SaveCalling.IsEnabled = false;
            }
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

            if (costSettings.ShowDialog() == true)
            {
                settings.GetSettings(out settings);
                double previousHotWater = data.HotWater;
                double previousColdWater = data.ColdWater;
                double previousElectricity = data.Electricity;

                double hotWaterCostPerCube = settings.HotWaterCostPerCube;
                double coldWaterCostPerCube = settings.ColdWaterCostPerCube;
                double electricityCostPerKwt = settings.ElectricityCostPerKwt;

                double previousSummator = data.HotWater + data.ColdWater;
                double currentSummator = currentHotWater + currentColdWater;
                double waterSummatorCost = settings.WaterSumCost;

                CalculateInternet.Content = settings.InternetCost;
                CalculateCold.Content = DataIndicator.CalculateCost(currentColdWater, previousColdWater, coldWaterCostPerCube, out resultCold);
                CalculateHot.Content = DataIndicator.CalculateCost(currentHotWater, previousHotWater, hotWaterCostPerCube, out resultHot);
                CalculateElecricity.Content = DataIndicator.CalculateCost(currentElectricity, previousElectricity, electricityCostPerKwt, out resultElectricity);
                CalculateWaterSummator.Content = DataIndicator.CalculateCost(currentSummator, previousSummator, waterSummatorCost, out resultSummator);
                CalculateScore.Content = DataIndicator.OverallCalculate(resultCold, resultHot, resultElectricity, resultSummator, settings.InternetCost);
            }
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
