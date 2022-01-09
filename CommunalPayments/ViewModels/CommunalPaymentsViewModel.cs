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
        private decimal currentColdWaterIndicator;
        private decimal currentHotWaterindicator;
        private decimal currentElectricityindicator;

        private readonly IndicatorInfo previousIndicators = new IndicatorInfo();
        private readonly SettingsInfo settings = new SettingsInfo();

        public decimal PreviousColdWaterIndicator => previousIndicators.ColdWaterIndicator;
        public decimal PreviousHotWaterIndicator => previousIndicators.HotWaterIndicator;
        public decimal PreviousElectricityindicator => previousIndicators.ElectricityIndicator;

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

        public decimal ColdWaterPerCubeCost => settings.ColdWaterPerCubeCost;
        public decimal HotWaterPerCubeCost => settings.HotWaterPerCubeCost;
        public decimal ElectricityPerKwtCost => settings.ElectricityPerKwtCost;
        public decimal InternetCost => settings.InternetCost;


        //TODO
        public decimal ColdWaterIndicatorDifference => CurrentColdWaterIndicator - PreviousColdWaterIndicator;

        //TODO
        public decimal ColdWaterCostResult => ColdWaterIndicatorDifference * ColdWaterPerCubeCost;

        public RelayCommand SaveIndicatorCommand { get; }
        public RelayCommand CallSettingsCommand { get; }
        public RelayCommand CallApplicationInfoCommand { get; }

        public CommunalPaymentsViewModel()
        {
            previousIndicators = SerializeHelper<IndicatorInfo>.Get();
            SerializeHelper<IndicatorInfo>.CheckDataFile(previousIndicators);
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
