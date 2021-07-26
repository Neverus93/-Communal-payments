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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveCalling_Click(object sender, RoutedEventArgs e)
        {
            double coldWater = double.Parse(ColdWaterInput.Text);
            double hotWater = double.Parse(HotWaterInput.Text);
            double electricity = double.Parse(ElectricityInput.Text);

            SaveData(coldWater, hotWater, electricity);
        }

        public void SaveData(double cold, double hot, double electro)
        {
            DataIndicator data = new DataIndicator(cold, hot, electro);
            XmlSerializer formatter = new XmlSerializer(typeof(DataIndicator));

            using (FileStream fs = new FileStream("DataIndicator.xml", FileMode.Append, FileAccess.Write))
            {
                formatter.Serialize(fs, data);
            }
        }
    }
}
