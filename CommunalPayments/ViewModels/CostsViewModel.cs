using CommunalPayments.Command;
using CommunalPayments.Helpers;
using System;
using System.Xml.Serialization;

namespace CommunalPayments.ViewModels
{
    [Serializable]
    public class CostsViewModel
    {
        public event EventHandler AfterSave;
        public decimal ColdWaterPerCube { get; set; }
        public decimal HotWaterPerCube { get; set; }
        public decimal ElectricityPerKwt { get; set; }
        public decimal Internet { get; set; }
        public decimal WaterSum { get; set; }

        [XmlIgnore]
        public RelayCommand SaveSettingsCommand { get; }

        public CostsViewModel()
        {
            SaveSettingsCommand = new RelayCommand(SaveSettingsClick);
        }

        public CostsViewModel(decimal cold, decimal hot, decimal electricity, decimal internet, decimal waterSum) : this()
        {
            ColdWaterPerCube = cold;
            HotWaterPerCube = hot;
            ElectricityPerKwt = electricity;
            Internet = internet;
            WaterSum = waterSum;
        }

        private void SaveSettingsClick(object parameter)
        {
            var costsViewModel = new CostsViewModel(ColdWaterPerCube,HotWaterPerCube, ElectricityPerKwt, Internet, WaterSum);
            SerializeHelper<CostsViewModel>.Save(costsViewModel);
            var onClose = AfterSave;
            onClose?.Invoke(this, EventArgs.Empty);
        }
    }
}