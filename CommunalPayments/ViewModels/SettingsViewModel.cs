using CommunalPayments.MainWindow.Model;
using CommunalPayments.MainWindow.Command;
using CommunalPayments.Helpers;

namespace CommunalPayments.ViewModels
{
    class SettingsViewModel
    {
        public string ColdWaterPerCubeCostText { get; set; }
        public string HotWaterPerCubeCostText { get; set; }
        public string ElectricityPerKwtText { get; set; }

        public RelayCommand SaveSettingsCommand { get; }
        public RelayCommand CancelChangesCommand { get; }

        public SettingsViewModel()
        {
            SaveSettingsCommand = new RelayCommand(SaveSettingsClick);
            CancelChangesCommand = new RelayCommand(CancelChangesClick);
        }

        private void SaveSettingsClick(object parameter)
        {
            SettingsInfo settings = new SettingsInfo();
            //TODO парсинг данных для сериализации
            SerializeHelper<SettingsInfo>.Save(settings);
        }

        private void CancelChangesClick(object parameter)
        {
            //TODO Как закрыть окно, если ты нуб в MVVM
        }
    }
}
