using CommunalPayments.Models;
using CommunalPayments.Views;
using CommunalPayments.Command;
using CommunalPayments.Helpers;
using Prism.Mvvm;

namespace CommunalPayments.ViewModels
{
    class CommunalPaymentsViewModel : BindableBase
    {
        private decimal coldWaterIndicator;
        private decimal hotWaterindicator;
        private decimal electricityindicator;

        public decimal ColdWaterIndicator
        {
            get
            {
                return coldWaterIndicator;
            }
            set
            {
                coldWaterIndicator = value;
                RaisePropertyChanged();
            }
        }
        public decimal HotWaterIndicator
        {
            get
            {
                return hotWaterindicator;
            }
            set
            {
                hotWaterindicator = value;
                RaisePropertyChanged();
            }
        }
        public decimal ElectricityIndicator
        {
            get
            {
                return electricityindicator;
            }
            set
            {
                electricityindicator = value;
                RaisePropertyChanged();
            }
        }
        public RelayCommand SaveIndicatorCommand { get; }
        public RelayCommand CallSettingsCommand { get; }
        public RelayCommand CallApplicationInfoCommand { get; }

        public CommunalPaymentsViewModel()
        {
            //TODO получить настойки для калькуляции
            //TODO получить данные из файла показателей для заполнения полей и калькуляции
            SaveIndicatorCommand = new RelayCommand(SaveIndicatorClick);
            CallSettingsCommand = new RelayCommand(CallSettingsClick);
            CallApplicationInfoCommand = new RelayCommand(CallApplicationInfoClick);
        }

        private void SaveIndicatorClick(object parameter)
        {
            IndicatorInfo indicator = new IndicatorInfo();
            SerializeHelper<IndicatorInfo>.Save(indicator);
        }

        private void CallSettingsClick(object parameter)
        {
            var viewModel = new SettingsViewModel();
            SettingsView settingsViewWindow = new SettingsView(viewModel);
            settingsViewWindow.ShowDialog();
        }

        private void CallApplicationInfoClick(object parameter)
        {
            //TODO как вызвать окно из ViewModel, когда ты нуб в MVVM
        }
    }
}
