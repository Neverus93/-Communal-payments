using CommunalPayments.Models;
using CommunalPayments.Command;
using CommunalPayments.Helpers;
using CommunalPayments.Views;
using System.Windows;

namespace CommunalPayments.ViewModels
{
    public class SettingsViewModel
    {
        public string ColdWaterPerCubeCostText { get; set; }

        public string HotWaterPerCubeCostText { get; set; }

        public string ElectricityPerKwtText { get; set; }

        public string InternetCostText { get; set; }

        public string WaterSumCostText { get; set; }

        public RelayCommand SaveSettingsCommand { get; }

        public SettingsViewModel()
        {
            SaveSettingsCommand = new RelayCommand(SaveSettingsClick);
        }

        private void SaveSettingsClick(object parameter)
        {
            //TODO Реворкнуть покрасивее
            double cold;
            double hot;
            double electricity;
            double internet;
            double waterSum;
            TryParseFunction(ColdWaterPerCubeCostText, out cold);
            TryParseFunction(HotWaterPerCubeCostText, out hot);
            TryParseFunction(ElectricityPerKwtText, out electricity);
            TryParseFunction(InternetCostText, out internet);
            TryParseFunction(WaterSumCostText, out waterSum);
            SettingsInfo settings = new SettingsInfo(cold, hot, electricity, internet, waterSum);

            //TODO Переделать generic + сделать закрытие окна настроек после сохранения
            SerializeHelper<SettingsInfo>.Save(settings);
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