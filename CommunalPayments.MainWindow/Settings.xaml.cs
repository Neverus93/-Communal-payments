using System.Windows;

namespace CommunalPayments.MainWindow
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class CostSettings : Window
    {
        SettingsCost settings = new SettingsCost();
        public CostSettings()
        {
            InitializeComponent();
        }

        private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            double coldWaterCost = double.Parse(ColdWaterCostPerCube.Text);
            double hotWaterCost = double.Parse(HotWaterCostPerCube.Text);
            double electricityCost = double.Parse(ElectricityCostPerKwt.Text);
            double internetCost = double.Parse(InternetCost.Text);
            double waterSumCost = double.Parse(WaterSumCost.Text);

            settings.SaveSettings(coldWaterCost, hotWaterCost, electricityCost, internetCost, waterSumCost);
            DialogResult = true;
        }
    }
}
