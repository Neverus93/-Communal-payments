using CommunalPayments.Views;
using CommunalPayments.Helpers;
using Prism.Mvvm;
using System.Windows;
using System;
using CommunalPayments.ViewModels.Controls;

namespace CommunalPayments.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public CostsViewModel Costs { get; set; }
        public IndicatorsViewModel CurrentIndicators { get; set; }
        public ManageButtonsControlViewModel ButtonsManager { get; set; }
        public IndicatorsViewModel PreviousIndicators { get; set; }
        public CalculationViewModel Calculation { get; set; }

        public MainWindowViewModel()
        {
            CurrentIndicators = new IndicatorsViewModel();
            Costs = new CostsViewModel();

            SerializeHelper<IndicatorsViewModel>.CheckDataFile(CurrentIndicators);

            try
            {
                PreviousIndicators = SerializeHelper<IndicatorsViewModel>.Get();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            try
            {
                Costs = SerializeHelper<CostsViewModel>.Get();
            }
            catch
            {
                MessageBoxResult result = MessageBox.Show("Добро пожаловать в программу для расчёта коммунальных платежей. " +
                    "Хотите задать настройки сейчас?", "Приветствие", MessageBoxButton.YesNo, MessageBoxImage.Information);

                if(result == MessageBoxResult.Yes)
                {
                    CostsView settingsView = new CostsView(Costs);
                    settingsView.ShowDialog();
                }
            }

            Calculation = new CalculationViewModel(Costs, CurrentIndicators, PreviousIndicators);
            ButtonsManager = new ManageButtonsControlViewModel(CurrentIndicators, Costs);
        }
    }
}
