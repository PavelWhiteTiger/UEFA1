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
    class ConverterToWin : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value as GameT).Winner == 1)
                return (value as GameT).TeamT.Team;
            if ((value as GameT).Winner == 2)
                return (value as GameT).TeamT1.Team;
            if ((value as GameT).Winner == 0)
                return "Ничья!";
            throw new NotImplementedException();
        }
       

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
