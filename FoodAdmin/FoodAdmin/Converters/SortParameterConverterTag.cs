using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using FoodAdmin.Models;

namespace FoodAdmin.Converters
{
    public class SortParameterConverterTag : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var list = values[1] as IEnumerable<Tag>;
            if (list == null || values[0] == null)
            {
                return new List<Tag>();
            }
            return list.Where(x => x.Name.IndexOf(values[0].ToString(), StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}