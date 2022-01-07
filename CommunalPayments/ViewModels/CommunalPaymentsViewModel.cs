using CommunalPayments.Models;
using CommunalPayments.Views;
using CommunalPayments.Command;
using CommunalPayments.Helpers;
using Prism.Mvvm;
using System.Windows;

namespace CommunalPayments.ViewModels
{
    public class CommunalPaymentsViewModel : BindableBase
    {
        private decimal previousColdWaterIndicator;
        private decimal previousHotWaterIndicator;
        private decimal previousElectricityindicator;

        private decimal currentColdWaterIndicator;
        private decimal currentHotWaterindicator;
        private decimal currentElectricityindicator;

        public decimal PreviousColdWaterIndicator
        {
            get
            {
                return previousColdWaterIndicator;
            }
            set
            {
                previousColdWaterIndicator = value;
            }
        }
        public decimal PreviousHotWaterIndicator
        {
            get
            {
                return previousHotWaterIndicator;
            }
            set
            {
                previousHotWaterIndicator = value;
            }
        }
        public decimal PreviousElectricityindicator
        {
            get
            {
                return previousElectricityindicator;
            }
            set
            {
                previousElectricityindicator = value;
            }
        }

        public decimal CurrentColdWaterIndicator
        {
            get
            {
                return currentColdWaterIndicator;
            }
            set
            {
                currentColdWaterIndicator = value;
                RaisePropertyChanged();
            }
        }
        public decimal CurrentHotWaterIndicator
        {
            get
            {
                return currentHotWaterindicator;
            }
            set
            {
                currentHotWaterindicator = value;
                RaisePropertyChanged();
            }
        }
        public decimal CurrentElectricityIndicator
        {
            get
            {
                return currentElectricityindicator;
            }
            set
            {
                currentElectricityindicator = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand SaveIndicatorCommand { get; }
        public RelayCommand CallSettingsCommand { get; }
        public RelayCommand CallApplicationInfoCommand { get; }

        public CommunalPaymentsViewModel()
        {
            SettingsInfo settings = new SettingsInfo();
            IndicatorInfo previousIndicators = new IndicatorInfo();

            SerializeHelper<IndicatorInfo>.CheckDataFile(previousIndicators);
            previousIndicators = SerializeHelper<IndicatorInfo>.Get();
            try
            {
                settings = SerializeHelper<SettingsInfo>.Get();
            }
            catch
            {
                MessageBoxResult result = MessageBox.Show("Добро пожаловать в программу для расчёта коммунальных платежей. Хотите задать настройки сейчас?", "Приветствие", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if(result == MessageBoxResult.Yes)
                {
                    SettingsViewModel settingsViewModel = new SettingsViewModel();
                    SettingsView settingsView = new SettingsView(settingsViewModel);
                    settingsView.ShowDialog();
                }
                else
                {
                    return;
                }
            }
            SaveIndicatorCommand = new RelayCommand(SaveIndicatorClick);
            CallSettingsCommand = new RelayCommand(CallSettingsClick);
            CallApplicationInfoCommand = new RelayCommand(CallApplicationInfoClick);
        }

        private void SaveIndicatorClick(object parameter)
        {
            IndicatorInfo indicator = new IndicatorInfo(CurrentColdWaterIndicator, CurrentHotWaterIndicator, CurrentElectricityIndicator);
            SerializeHelper<IndicatorInfo>.Save(indicator);
            MessageBox.Show("Данные успешно сохранены!");
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
