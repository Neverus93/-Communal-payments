using System;
using System.Globalization;
using System.Windows.Data;

namespace CommunalPayments.Converters
{
    internal class DecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!decimal.TryParse(value.ToString(), out decimal d))
            {
                d = 0;
            }
            return d;
        }
    }
}
