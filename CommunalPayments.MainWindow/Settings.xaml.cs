using System.Windows;
using CommunalPayments.MainWindow.ViewModel;

namespace CommunalPayments.MainWindow
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class CostSettings : Window
    {
        public CostSettings()
        {
            InitializeComponent();
            DataContext = new SettingsViewModel();
        }

        private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            //settings.ColdWaterCostPerCube = double.Parse(ColdWaterCostPerCube.Text);
            //settings.HotWaterCostPerCube = double.Parse(HotWaterCostPerCube.Text);
            //settings.ElectricityCostPerKwt = double.Parse(ElectricityCostPerKwt.Text);
            //settings.InternetCost = double.Parse(InternetCost.Text);
            //settings.WaterSumCost = double.Parse(WaterSumCost.Text);

            //settings.SaveSettings(settings);
            //DialogResult = true;
        }
    }
}
