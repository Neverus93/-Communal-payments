using CommunalPayments.Models;
using CommunalPayments.Command;
using CommunalPayments.Helpers;
using System;

namespace CommunalPayments.ViewModels
{
    public class SettingsViewModel
    {
        public event EventHandler AfterSave;
        public decimal ColdWaterPerCubeCost { get; set; }

        public decimal HotWaterPerCubeCost { get; set; }

        public decimal ElectricityPerKwt { get; set; }

        public decimal InternetCost { get; set; }

        public decimal WaterSumCost { get; set; }

        public RelayCommand SaveSettingsCommand { get; }

        public SettingsViewModel()
        {
            SaveSettingsCommand = new RelayCommand(SaveSettingsClick);
        }

        private void SaveSettingsClick(object parameter)
        {
            SettingsInfo settings = new SettingsInfo(ColdWaterPerCubeCost, HotWaterPerCubeCost, ElectricityPerKwt, InternetCost, WaterSumCost);
            SerializeHelper<SettingsInfo>.Save(settings);
            var onClose = AfterSave;
            onClose?.Invoke(this, EventArgs.Empty);
        }
    }
}