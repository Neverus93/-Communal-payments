using System;
using System.ComponentModel;

namespace CommunalPayments.MainWindow.Model
{
    [Serializable]
    class IndicatorInfo : INotifyPropertyChanged
    {
        private double coldWaterIndicator;
        private double hotWaterIndicator;
        private double electricityIndicator;

        public double ColdWaterIndicator
        {
            get
            {
                return coldWaterIndicator;
            }
            set
            {
                coldWaterIndicator = value;
                OnPropertyChanged("ColdWaterIndicator");
            }
        }
        public double HotWaterIndicator
        {
            get
            {
                return hotWaterIndicator;
            }
            set
            {
                hotWaterIndicator = value;
                OnPropertyChanged("HotWaterindicator");
            }
        }
        public double ElectricityIndicator
        {
            get
            {
                return electricityIndicator;
            }
            set
            {
                electricityIndicator = value;
                OnPropertyChanged("ElectricityIndicator");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
