using CommunalPayments.Command;
using CommunalPayments.Helpers;
using Prism.Mvvm;
using System;
using System.Xml.Serialization;

namespace CommunalPayments.ViewModels
{
    [Serializable]
    public class CostsViewModel : BindableBase
    {
        private decimal _coldWaterPerCube;
        private decimal _hotWaterPerCube;
        private decimal _electricityPerKwt;
        private decimal _internet;
        private decimal _waterSum;

        public event Action AfterSave;
        public decimal ColdWaterPerCube
        {
            get => _coldWaterPerCube;
            set => SetProperty(ref _coldWaterPerCube, value);
        }
        public decimal HotWaterPerCube
        {
            get => _hotWaterPerCube;
            set => SetProperty(ref _hotWaterPerCube, value);
        }
        public decimal ElectricityPerKwt
        {
            get => _electricityPerKwt;
            set => SetProperty(ref _electricityPerKwt, value);
        }
        public decimal Internet
        {
            get => _internet;
            set => SetProperty(ref _internet, value);
        }
        public decimal WaterSum
        {
            get => _waterSum;
            set => SetProperty(ref _waterSum, value);
        }

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
            SerializeHelper<CostsViewModel>.Save(this);
            AfterSave?.Invoke();
        }
    }
}