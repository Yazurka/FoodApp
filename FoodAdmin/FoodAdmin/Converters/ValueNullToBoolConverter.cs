using System;
using System.Globalization;
using System.Windows.Data;

namespace FoodAdmin.Converters
{
    public class ValueNullToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(true) ? value : null;
        }
    }
}