using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Empresa.Comun
{
    public class ConvertNoDefinidoNegativo: IValueConverter
    {



        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double tvalue = System.Convert.ToDouble(value);
            if (tvalue < 0) return "n/d";
            return tvalue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
