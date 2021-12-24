using CommunalPayments.Models;
using CommunalPayments.Command;
using CommunalPayments.Helpers;
using CommunalPayments.Views;
using Prism.Mvvm;

namespace CommunalPayments.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        public string ColdWaterPerCubeCostText { get; set; }

        public string HotWaterPerCubeCostText { get; set; }

        public string ElectricityPerKwtText { get; set; }

        public string InternetCostText { get; set; }

        public string WaterSumCostText { get; set; }

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
            // парсинг происходит
            settings.ColdWaterPerCubeCost = double.Parse(ColdWaterPerCubeCostText);
            settings.HotWaterPerCubeCost = double.Parse(HotWaterPerCubeCostText);
            settings.ElectricityPerKwtCost = double.Parse(ElectricityPerKwtText);
            settings.InternetCost = double.Parse(InternetCostText);
            settings.WaterSumCost = double.Parse(WaterSumCostText);
            SerializeHelper<SettingsInfo>.Save(settings); //не создаётся файл
        }

        private void CancelChangesClick(object parameter)
        {
            SettingsView settingsViewWindow = new SettingsView();
            settingsViewWindow.Close();
            //TODO не срабатывает команда
        }

        private void TryParseFunction(string text, out double result)
        {
            if (double.TryParse(text, out result))
            {
                result = double.Parse(text);
            }
            else
            {
                result = 0;
            }
        }
    }
}