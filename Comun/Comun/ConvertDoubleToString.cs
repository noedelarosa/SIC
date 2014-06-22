using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Empresa.Comun
{
    public class ConvertDoubleToString: IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double tvalue = (double)value;
            return tvalue.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string tvalue = value.ToString();
            return System.Convert.ToDouble(tvalue);
        }
    }
}
