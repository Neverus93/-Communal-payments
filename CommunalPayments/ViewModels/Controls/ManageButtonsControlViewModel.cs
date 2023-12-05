using CommunalPayments.Command;
using CommunalPayments.Helpers;
using CommunalPayments.Views;
using Prism.Mvvm;
using System;
using System.Windows;
using System.Windows.Documents;

namespace CommunalPayments.ViewModels.Controls
{
    public class ManageButtonsControlViewModel : BindableBase
    {
        public CostsViewModel Costs { get; set; }
        public IndicatorsViewModel Indicators { get; set; }
        public IndicatorsViewModel PreviousIndicators { get; set; }
        public RelayCommand SaveIndicatorCommand { get; }
        public RelayCommand CallSettingsCommand { get; }
        public RelayCommand CallApplicationInfoCommand { get; }

        public ManageButtonsControlViewModel(IndicatorsViewModel indicators, IndicatorsViewModel previousIndicators, CostsViewModel costs)
        {
            Costs = costs; 
            Indicators = indicators;
            PreviousIndicators = previousIndicators;
            SaveIndicatorCommand = new RelayCommand(SaveIndicatorClick);
            CallSettingsCommand = new RelayCommand(CallSettingsClick);
            CallApplicationInfoCommand = new RelayCommand(CallApplicationInfoClick);
        }

        private void SaveIndicatorClick(object parameter)
        {
            if(Indicators.ColdWaterIndicator < PreviousIndicators.ColdWaterIndicator ||
                Indicators.HotWaterIndicator < PreviousIndicators.HotWaterIndicator ||
                Indicators.ElectricityIndicator < PreviousIndicators.ElectricityIndicator)
            {
                MessageBox.Show("Текущие значения не должны быть меньше предыдущих!");
                return;
            }

            SerializeHelper<IndicatorsViewModel>.Save(Indicators);
            MessageBox.Show("Данные успешно сохранены!");
        }

        private void CallSettingsClick(object parameter)
        {
            var costs = new CostsViewModel();
            costs.AfterSave += () =>
            {
                Costs.ColdWaterPerCube = costs.ColdWaterPerCube;
                Costs.HotWaterPerCube = costs.HotWaterPerCube;
                Costs.ElectricityPerKwt = costs.ElectricityPerKwt;
                Costs.Internet = costs.Internet;
                Costs.WaterSum = costs.WaterSum;
            };
            CostsView settingsViewWindow = new CostsView(costs);
            settingsViewWindow.ShowDialog();
        }

        private void CallApplicationInfoClick(object parameter)
        {
            ApplicationInfo applicationInfo = new ApplicationInfo();
            applicationInfo.ShowDialog();
        }
    }
}
