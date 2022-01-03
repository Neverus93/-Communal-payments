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

        private IndicatorInfo previousIndicators = new IndicatorInfo();
        private SettingsInfo settings = new SettingsInfo();

        public decimal PreviousColdWaterIndicator
        {
            get
            {
                return previousColdWaterIndicator;
            }
            set
            {
                previousColdWaterIndicator = previousIndicators.ColdWaterIndicator;
                RaisePropertyChanged();
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
                previousHotWaterIndicator = previousIndicators.HotWaterIndicator;
                RaisePropertyChanged();
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
                previousElectricityindicator = previousIndicators.ElectricityIndicator;
                RaisePropertyChanged();
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
            //Каждый раз создаётся файл с нулями, хотя изначально файл существует, необходимо доработать условие в методе CheckDataFile
            //Неправильно цепляются значения к свойствам, вследствие чего неправильное отображение на форме
            SerializeHelper<IndicatorInfo>.CheckDataFile(previousIndicators);
            previousIndicators = SerializeHelper<IndicatorInfo>.Get();
            //Необходимо добавить привязки к настройкам
            settings = SerializeHelper<SettingsInfo>.Get();
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
