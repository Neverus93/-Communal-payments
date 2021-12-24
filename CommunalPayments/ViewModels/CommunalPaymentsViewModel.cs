using CommunalPayments.Models;
using CommunalPayments.Views;
using CommunalPayments.Command;
using CommunalPayments.Helpers;
using Prism.Mvvm;

namespace CommunalPayments.ViewModels
{
    class CommunalPaymentsViewModel : BindableBase
    {
        private string coldWaterIndicatorText;
        private string hotWaterindicatorText;
        private string electricityindicatorText;
        public string ColdWaterIndicatorText
        {
            get
            {
                return coldWaterIndicatorText;
            }
            set
            {
                coldWaterIndicatorText = value;
                //OnPropertyChanged("ColdWaterIndicatorText");
            }
        }
        public string HotWaterIndicatorText
        {
            get
            {
                return hotWaterindicatorText;
            }
            set
            {
                hotWaterindicatorText = value;
                //OnPropertyChanged("HotWaterIndicatorText");
            }
        }
        public string ElectricityIndicatorText
        {
            get
            {
                return electricityindicatorText;
            }
            set
            {
                electricityindicatorText = value;
                //OnPropertyChanged("ElectricityIndicatorText");
            }
        }
        public RelayCommand SaveIndicatorCommand { get; }
        public RelayCommand CallSettingsCommand { get; }
        public RelayCommand CallApplicationInfoCommand { get; }
        public CommunalPaymentsViewModel()
        {
            SaveIndicatorCommand = new RelayCommand(SaveIndicatorClick);
            CallSettingsCommand = new RelayCommand(CallSettingsClick);
            CallApplicationInfoCommand = new RelayCommand(CallApplicationInfoClick);
        }
        private void SaveIndicatorClick(object parameter)
        {
            IndicatorInfo indicator = new IndicatorInfo();
            //TODO парсинг данных с формы
            SerializeHelper<IndicatorInfo>.Save(indicator);
        }
        private void CallSettingsClick(object parameter)
        {
            SettingsView settingsViewWindow = new SettingsView();
            settingsViewWindow.Show();
        }
        private void CallApplicationInfoClick(object parameter)
        {
            //TODO как вызвать окно из ViewModel, когда ты нуб в MVVM
        }

        private string coldWaterPerCubeCostText;

        public string ColdWaterPerCubeCostText { get => coldWaterPerCubeCostText; set => SetProperty(ref coldWaterPerCubeCostText, value); }

        private string hotWaterPerCubeCostText;

        public string HotWaterPerCubeCostText { get => hotWaterPerCubeCostText; set => SetProperty(ref hotWaterPerCubeCostText, value); }

        private string electricityPerKwtText;

        public string ElectricityPerKwtText { get => electricityPerKwtText; set => SetProperty(ref electricityPerKwtText, value); }

        private string waterSumCostText;

        public string WaterSumCostText { get => waterSumCostText; set => SetProperty(ref waterSumCostText, value); }

        private string internetCostText;

        public string InternetCostText { get => internetCostText; set => SetProperty(ref internetCostText, value); }
    }
}
