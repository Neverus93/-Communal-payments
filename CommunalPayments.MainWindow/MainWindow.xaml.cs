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
        XmlSerializer formatter = new XmlSerializer(typeof(DataIndicator));
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

            using (FileStream fs = new FileStream("DataIndicator.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, data);
            }
        }

        public void GetData(out DataIndicator data)
        {
            using (FileStream fs = new FileStream("DataIndicator.xml", FileMode.OpenOrCreate))
            {
                data = (DataIndicator)formatter.Deserialize(fs);
            }
        }
    }
}
