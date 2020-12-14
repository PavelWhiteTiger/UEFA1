using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using UEFA.Model;

namespace UEFA.Converter
{
    class ConvertToPhonoOrNull : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null)
            return value;
            return @"../../Images/What.png";
        }
        public static object Convert(object value)
        {
            if (value != null)
                return value;
            return @"../../Images/What.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
