﻿using System.IO;
using System.Windows;

namespace CommunalPayments.MainWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataIndicator data = new DataIndicator();
        SettingsCost settings = new SettingsCost();
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
            double currentHotWater;
            double previousHotWater = data.HotWater;
            double hotWaterCostPerCube = settings.HotWaterCostPerCube;
            TryParseFunction(HotWaterInput.Text, out currentHotWater);
            CurrentHot.Content = HotWaterInput.Text;
            CalculateHot.Content = data.CalculateCost(currentHotWater, previousHotWater, hotWaterCostPerCube);
        }

        private void ColdWaterInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            double currentColdWater;
            double previousColdWater = data.ColdWater;
            double coldWaterCostPerCube = settings.ColdWaterCostPerCube;
            TryParseFunction(ColdWaterInput.Text, out currentColdWater);
            CurrentCold.Content = ColdWaterInput.Text;
            CalculateCold.Content = data.CalculateCost(currentColdWater, previousColdWater, coldWaterCostPerCube);
        }

        private void ElectricityInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            double currentElectricity;
            double previousElectricity = data.Electricity;
            double electricityCostPerKwt = settings.ElectricityCostPerKwt;
            TryParseFunction(ElectricityInput.Text, out currentElectricity);
            CurrentElecricity.Content = ElectricityInput.Text;
            CalculateElecricity.Content = data.CalculateCost(currentElectricity, previousElectricity, electricityCostPerKwt);
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
