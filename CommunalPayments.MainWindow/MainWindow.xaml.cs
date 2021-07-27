using System.IO;
using System.Windows;
using System.Xml.Serialization;

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
                settings.SaveSettings(0, 0, 0, 0);
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
            double hotWater;
            if(double.TryParse(HotWaterInput.Text, out hotWater))
            {
                hotWater = double.Parse(HotWaterInput.Text);
            }
            else
            {
                hotWater = 0;
            }
            CurrentHot.Content = HotWaterInput.Text;
            CalculateHot.Content = $"{hotWater - data.HotWater} x {settings.HotWaterCostPerCube}₽ = {(hotWater - data.HotWater) * settings.HotWaterCostPerCube}₽";
        }

        private void ColdWaterInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            double coldWater;
            if (double.TryParse(ColdWaterInput.Text, out coldWater))
            {
                coldWater = double.Parse(ColdWaterInput.Text);
            }
            else
            {
                coldWater = 0;
            }
            CurrentCold.Content = ColdWaterInput.Text;
            CalculateCold.Content = $"{coldWater - data.ColdWater} x {settings.ColdWaterCostPerCube}₽ = {(coldWater - data.ColdWater) * settings.ColdWaterCostPerCube}₽";
        }

        private void ElectricityInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            double electricity;
            if (double.TryParse(ElectricityInput.Text, out electricity))
            {
                electricity = double.Parse(ElectricityInput.Text);
            }
            else
            {
                electricity = 0;
            }
            CurrentElecricity.Content = ElectricityInput.Text;
            CalculateElecricity.Content = $"{electricity - data.Electricity} x {settings.ElectricityCostPerKwt}₽ = {(electricity - data.Electricity) * settings.ElectricityCostPerKwt}₽";
        }

        private void SettingsCalling_Click(object sender, RoutedEventArgs e)
        {
            CostSettings costSettings = new CostSettings();
            costSettings.Show();
        }
    }
}
