using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace CommunalPayments.Views
{
    /// <summary>
    /// Логика взаимодействия для ApplicationInfo.xaml
    /// </summary>
    public partial class ApplicationInfo : Window
    {
        public ApplicationInfo()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/SergeyRomanov93/-Communal-payments");
        }
    }
}
