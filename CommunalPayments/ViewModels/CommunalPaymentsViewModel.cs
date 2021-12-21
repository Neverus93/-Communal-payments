using CommunalPayments.MainWindow.Model;
using System.ComponentModel;

namespace CommunalPayments.ViewModels
{
    class CommunalPaymentsViewModel : INotifyPropertyChanged
    {
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
