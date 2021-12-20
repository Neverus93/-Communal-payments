using CommunalPayments.MainWindow.Model;
using System.ComponentModel;

namespace CommunalPayments.MainWindow.ViewModel
{
    class CommunalPaymentsViewModel : INotifyPropertyChanged
    {
        private IndicatorInfo[] indicators;
        public IndicatorInfo[] Indicators { get; private set; }
        public CommunalPaymentsViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
