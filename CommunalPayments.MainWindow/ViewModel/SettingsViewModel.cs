using CommunalPayments.MainWindow.Model;
using CommunalPayments.MainWindow.Command;
using CommunalPayments.MainWindow.Interfaces;
using System.Xml.Serialization;

namespace CommunalPayments.MainWindow.ViewModel
{
    class SettingsViewModel : IDoubleParser<SettingsInfo>
    {
        public SettingsInfo SettingsInfo { get; set; }
        public RelayCommand CallSettingsCommand { get; }

        public SettingsViewModel()
        {
            CallSettingsCommand = new RelayCommand(SaveSettingsClick);
            SettingsInfo = new SettingsInfo();
        }

        private void SaveSettingsClick(object parameter)
        {
            XmlSerializer formatterCost = new XmlSerializer(typeof(SettingsInfo));


        }

        public SettingsInfo DoubleParse(params string[] parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
