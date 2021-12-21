using CommunalPayments.MainWindow.Model;
using CommunalPayments.MainWindow.Command;
using CommunalPayments.MainWindow.Interfaces;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;

namespace CommunalPayments.ViewModels
{
    class SettingsViewModel : IDoubleParser<SettingsInfo>, INotifyPropertyChanged
    {
        public SettingsInfo SettingsInfo { get; set; }
        public RelayCommand CallSettingsCommand { get; }

        XmlSerializer formatterCost = new XmlSerializer(typeof(SettingsInfo));

        public event PropertyChangedEventHandler PropertyChanged;

        public SettingsViewModel()
        {
            CallSettingsCommand = new RelayCommand(SaveSettingsClick);
            SettingsInfo = GetSettings();
        }

        private void SaveSettingsClick(object parameter)
        {
        }

        public SettingsInfo DoubleParse(params string[] parameters)
        {
            throw new System.NotImplementedException();
        }

        private void SaveSettings(SettingsInfo settings)
        {
            using (FileStream fs = new FileStream("Settings.xml", FileMode.OpenOrCreate))
            {
                formatterCost.Serialize(fs, settings);
            }
        }

        private SettingsInfo GetSettings()
        {
            using (FileStream fs = new FileStream("Settings.xml", FileMode.OpenOrCreate))
            {
                SettingsInfo dataCost = (SettingsInfo)formatterCost.Deserialize(fs);
                return dataCost;
            }
        }
    }
}
