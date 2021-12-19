using CommunalPayments.MainWindow.Model;
using CommunalPayments.MainWindow.Command;
using CommunalPayments.MainWindow.Interfaces;
using System.Xml.Serialization;
using System.IO;

namespace CommunalPayments.MainWindow.ViewModel
{
    class SettingsViewModel : IDoubleParser<SettingsInfo>
    {
        public SettingsInfo SettingsInfo { get; set; }
        public RelayCommand CallSettingsCommand { get; }

        XmlSerializer formatterCost = new XmlSerializer(typeof(SettingsInfo));

        public SettingsViewModel()
        {
            CallSettingsCommand = new RelayCommand(SaveSettingsClick);
            SettingsInfo = new SettingsInfo();
        }

        private void SaveSettingsClick(object parameter)
        {
        }

        public SettingsInfo DoubleParse(params string[] parameters)
        {
            throw new System.NotImplementedException();
        }

        private void SaveSettings(SettingsCost settings)
        {
            using (FileStream fs = new FileStream("Settings.xml", FileMode.OpenOrCreate))
            {
                formatterCost.Serialize(fs, settings);
            }
        }

        private SettingsCost GetSettings()
        {
            using (FileStream fs = new FileStream("Settings.xml", FileMode.OpenOrCreate))
            {
                SettingsCost dataCost = (SettingsCost)formatterCost.Deserialize(fs);
                return dataCost;
            }
        }
    }
}
