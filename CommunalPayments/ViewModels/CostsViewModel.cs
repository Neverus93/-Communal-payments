using CommunalPayments.Models;
using CommunalPayments.Command;
using CommunalPayments.Helpers;
using System;

namespace CommunalPayments.ViewModels
{
    public class CostsViewModel
    {
        public event EventHandler AfterSave;

        public decimal ColdWaterPerCubeCost { get; set; }

        public decimal HotWaterPerCubeCost { get; set; }

        public decimal ElectricityPerKwt { get; set; }

        public decimal InternetCost { get; set; }

        public decimal WaterSumCost { get; set; }

        public RelayCommand SaveSettingsCommand { get; }

        public CostsViewModel()
        {
            SaveSettingsCommand = new RelayCommand(SaveSettingsClick);
        }

        private void SaveSettingsClick(object parameter)
        {
            Costs settings = new Costs(ColdWaterPerCubeCost, HotWaterPerCubeCost, ElectricityPerKwt, InternetCost, WaterSumCost);
            SerializeHelper<Costs>.Save(settings);
            var onClose = AfterSave;
            onClose?.Invoke(this, EventArgs.Empty);
        }
    }
}