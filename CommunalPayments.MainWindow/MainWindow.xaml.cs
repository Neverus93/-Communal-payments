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
            PreviousCold.Content = data.ColdWater;
            PreviousHot.Content = data.HotWater;
            PreviousElecricity.Content = data.Electricity;
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
            CurrentHot.Content = HotWaterInput.Text;
        }

        private void ColdWaterInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CurrentCold.Content = ColdWaterInput.Text;
        }

        private void ElectricityInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CurrentElecricity.Content = ElectricityInput.Text;
        }

        private void SettingsCalling_Click(object sender, RoutedEventArgs e)
        {
            CostSettings costSettings = new CostSettings();
            costSettings.Show();
        }
    }
}
