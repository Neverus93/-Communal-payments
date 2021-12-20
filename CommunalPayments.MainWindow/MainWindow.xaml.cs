using System.IO;
using System.Windows;
using CommunalPayments.MainWindow.ViewModel;

namespace CommunalPayments.MainWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CommunalPaymentsViewModel();
        }
    //    DataIndicator data = new DataIndicator();
    //    //SettingsCost settings = new SettingsCost();

    //    double currentColdWater;
    //    double currentHotWater;
    //    double currentElectricity;

    //    double resultSummator;
    //    double resultCold;
    //    double resultHot;
    //    double resultElectricity;

    //    private readonly string indicatorPath = "DataIndicator.xml";
    //    private readonly string settingsPath = "Settings.xml";
    //    public MainWindow()
    //    {
    //        InitializeComponent();
    //        if (File.Exists(indicatorPath))
    //        {
    //            data = data.GetData();
    //        }
    //        else
    //        {
    //            data.SaveData(data);
    //        }

    //        //if (!File.Exists(settingsPath))
    //        //{
    //        //    settings.SaveSettings(settings);
    //        //}
    //        //else
    //        //{
    //        //    settings = settings.GetSettings();
    //        //}
    //        PreviousCold.Content = data.ColdWater;
    //        PreviousHot.Content = data.HotWater;
    //        PreviousElecricity.Content = data.Electricity;
    //        //CalculateInternet.Content = settings.InternetCost;
    //        SaveCalling.IsEnabled = false;
    //    }

    //    private void SaveCalling_Click(object sender, RoutedEventArgs e)
    //    {
    //        data.ColdWater = double.Parse(ColdWaterInput.Text);
    //        data.HotWater = double.Parse(HotWaterInput.Text);
    //        data.Electricity = double.Parse(ElectricityInput.Text);
    //        data.SaveData(data);
    //        MessageBox.Show("Данные успешно сохранены в базу данных!");
    //    }

    //    private void HotWaterInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    //    {
    //        if(HotWaterInput.Text.Length != 0 && ColdWaterInput.Text.Length != 0 && ElectricityInput.Text.Length != 0)
    //        {
    //            SaveCalling.IsEnabled = true;
    //        }
    //        else
    //        {
    //            SaveCalling.IsEnabled = false;
    //        }
    //        double previousHotWater = data.HotWater;
    //        //double hotWaterCostPerCube = settings.HotWaterCostPerCube;
    //        double previousSummator = data.HotWater + data.ColdWater;

    //        //double waterSummatorCost = settings.WaterSumCost;
    //        TryParseFunction(HotWaterInput.Text, out currentHotWater);
    //        double currentSummator = currentHotWater + currentColdWater;
    //        CurrentHot.Content = HotWaterInput.Text;

    //        CalculateHot.Content = Calculator.CalculateCost(currentHotWater, previousHotWater, hotWaterCostPerCube, out resultHot);
    //        CalculateWaterSummator.Content = Calculator.CalculateCost(currentSummator, previousSummator, waterSummatorCost, out resultSummator);
    //        CalculateScore.Content = Calculator.OverallCalculate(resultCold, resultHot, resultElectricity, resultSummator, settings.InternetCost);
    //    }

    //    private void ColdWaterInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    //    {
    //        if(HotWaterInput.Text.Length != 0 && ColdWaterInput.Text.Length != 0 && ElectricityInput.Text.Length != 0)
    //        {
    //            SaveCalling.IsEnabled = true;
    //        }
    //        else
    //        {
    //            SaveCalling.IsEnabled = false;
    //        }
    //        double previousColdWater = data.ColdWater;
    //        double coldWaterCostPerCube = settings.ColdWaterCostPerCube;
    //        double previousSummator = data.HotWater + data.ColdWater;

    //        double waterSummatorCost = settings.WaterSumCost;
    //        TryParseFunction(ColdWaterInput.Text, out currentColdWater);
    //        double currentSummator = currentHotWater + currentColdWater;
    //        CurrentCold.Content = ColdWaterInput.Text;

    //        CalculateCold.Content = Calculator.CalculateCost(currentColdWater, previousColdWater, coldWaterCostPerCube, out resultCold);
    //        CalculateWaterSummator.Content = Calculator.CalculateCost(currentSummator, previousSummator, waterSummatorCost, out resultSummator);
    //        CalculateScore.Content = Calculator.OverallCalculate(resultCold, resultHot, resultElectricity, resultSummator, settings.InternetCost);
    //    }

    //    private void ElectricityInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    //    {
    //        if(HotWaterInput.Text.Length != 0 && ColdWaterInput.Text.Length != 0 && ElectricityInput.Text.Length != 0)
    //        {
    //            SaveCalling.IsEnabled = true;
    //        }
    //        else
    //        {
    //            SaveCalling.IsEnabled = false;
    //        }
    //        double previousElectricity = data.Electricity;
    //        double electricityCostPerKwt = settings.ElectricityCostPerKwt;

    //        TryParseFunction(ElectricityInput.Text, out currentElectricity);
    //        CurrentElecricity.Content = ElectricityInput.Text;

    //        CalculateElecricity.Content = Calculator.CalculateCost(currentElectricity, previousElectricity, electricityCostPerKwt, out resultElectricity);
    //        CalculateScore.Content = Calculator.OverallCalculate(resultCold, resultHot, resultElectricity, resultSummator, settings.InternetCost);
    //    }

    //    private void SettingsCalling_Click(object sender, RoutedEventArgs e)
    //    {
    //        CostSettings costSettings = new CostSettings();

    //        if (costSettings.ShowDialog() == true)
    //        {
    //            settings = settings.GetSettings();
    //            double previousHotWater = data.HotWater;
    //            double previousColdWater = data.ColdWater;
    //            double previousElectricity = data.Electricity;

    //            double hotWaterCostPerCube = settings.HotWaterCostPerCube;
    //            double coldWaterCostPerCube = settings.ColdWaterCostPerCube;
    //            double electricityCostPerKwt = settings.ElectricityCostPerKwt;

    //            double previousSummator = data.HotWater + data.ColdWater;
    //            double currentSummator = currentHotWater + currentColdWater;
    //            double waterSummatorCost = settings.WaterSumCost;

    //            CalculateInternet.Content = settings.InternetCost;
    //            CalculateCold.Content = Calculator.CalculateCost(currentColdWater, previousColdWater, coldWaterCostPerCube, out resultCold);
    //            CalculateHot.Content = Calculator.CalculateCost(currentHotWater, previousHotWater, hotWaterCostPerCube, out resultHot);
    //            CalculateElecricity.Content = Calculator.CalculateCost(currentElectricity, previousElectricity, electricityCostPerKwt, out resultElectricity);
    //            CalculateWaterSummator.Content = Calculator.CalculateCost(currentSummator, previousSummator, waterSummatorCost, out resultSummator);
    //            CalculateScore.Content = Calculator.OverallCalculate(resultCold, resultHot, resultElectricity, resultSummator, settings.InternetCost);
    //        }
    //    }

    //    private void TryParseFunction(string text, out double result)
    //    {
    //        if (double.TryParse(text, out result))
    //        {
    //            result = double.Parse(text);
    //        }
    //        else
    //        {
    //            result = 0;
    //        }
    //    }
    }
}
