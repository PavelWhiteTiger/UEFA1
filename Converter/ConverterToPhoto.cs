using Microsoft.Win32;
using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using UEFA.Model;

namespace UEFA.Converter
{
    class ConverterToPhoto : IValueConverter

    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value as GameT).Winner == 1)
                return Converter.ConvertToPhonoOrNull.Convert((value as GameT).TeamT.Photo);
            if ((value as GameT).Winner == 2)
                return Converter.ConvertToPhonoOrNull.Convert((value as GameT).TeamT1.Photo);
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
