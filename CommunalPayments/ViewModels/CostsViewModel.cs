using CommunalPayments.Models;
using CommunalPayments.Command;
using CommunalPayments.Helpers;
using System;

namespace CommunalPayments.ViewModels
{
    public class CostsViewModel
    {
        public event EventHandler AfterSave;

        public Costs Costs { get; set; }

        public RelayCommand SaveSettingsCommand { get; }

        public CostsViewModel()
        {
            Costs = new Costs();
            SaveSettingsCommand = new RelayCommand(SaveSettingsClick);
        }

        private void SaveSettingsClick(object parameter)
        {
            Costs = new Costs(Costs.ColdWaterPerCube,Costs.HotWaterPerCube, Costs.ElectricityPerKwt, Costs.Internet, Costs.WaterSum);
            SerializeHelper<Costs>.Save(Costs);
            var onClose = AfterSave;
            onClose?.Invoke(this, EventArgs.Empty);
        }
    }
}