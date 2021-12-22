using CommunalPayments.MainWindow.Model;
using CommunalPayments.MainWindow.Command;
using CommunalPayments.Helpers;
using System.ComponentModel;

namespace CommunalPayments.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private string coldWaterPerCubeCostText;
        private string hotWaterPerCubeCostText;
        private string electricityPerKwttext;
        private string internetCostText;
        private string waterSumCostText;
        public string ColdWaterPerCubeCostText
        {
            get
            {
                return coldWaterPerCubeCostText;
            }
            set
            {
                coldWaterPerCubeCostText = value;
                OnPropertyChanged("ColdWaterPerCubeCostText");
            }
        }
        public string HotWaterPerCubeCostText
        {
            get
            {
                return hotWaterPerCubeCostText;
            }
            set
            {
                hotWaterPerCubeCostText = value;
                OnPropertyChanged("HotWaterPerCubeCostText");
            }
        }
        public string ElectricityPerKwtText
        {
            get
            {
                return electricityPerKwttext;
            }
            set
            {
                electricityPerKwttext = value;
                OnPropertyChanged("ElectricityPerKwtText");
            }
        }
        public string InternetCostText
        {
            get
            {
                return internetCostText;
            }
            set
            {
                internetCostText = value;
                OnPropertyChanged("InternetCostText");
            }
        }
        public string WaterSumCostText
        {
            get
            {
                return waterSumCostText;
            }
            set
            {
                waterSumCostText = value;
                OnPropertyChanged("WaterSumCostText");
            }
        }

        public RelayCommand SaveSettingsCommand { get; }
        public RelayCommand CancelChangesCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public SettingsViewModel()
        {
            SaveSettingsCommand = new RelayCommand(SaveSettingsClick);
            CancelChangesCommand = new RelayCommand(CancelChangesClick);
        }

        private void SaveSettingsClick(object parameter)
        {
            SettingsInfo settings = new SettingsInfo();
            settings.ColdWaterPerCubeCost = double.Parse(ColdWaterPerCubeCostText);
            settings.HotWaterPerCubeCost = double.Parse(HotWaterPerCubeCostText);
            settings.ElectricityPerKwtCost = double.Parse(ElectricityPerKwtText);
            settings.InternetCost = double.Parse(InternetCostText);
            settings.WaterSumCost = double.Parse(WaterSumCostText);
            SerializeHelper<SettingsInfo>.Save(settings);
        }

        private void CancelChangesClick(object parameter)
        {
            //TODO Как закрыть окно, если ты нуб в MVVM
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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