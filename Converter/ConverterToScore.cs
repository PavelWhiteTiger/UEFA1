using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;
using UEFA.Model;

namespace UEFA.Converter
{
    static class ConverterToScore
    {


        public static int Convert(string value)
        {
            string[] values = value.Split(':');
            if (int.Parse(values[0].ToString()) > int.Parse(values[1].ToString()))
            {
                return 1;
            }
            if (int.Parse(values[0].ToString()) < int.Parse(values[1].ToString()))
            {
                return 2;
            }
            if (int.Parse(values[0].ToString()) == int.Parse(values[1].ToString()))
            {
                return 0;
            }
            throw new NotImplementedException();
        }



    }
}
