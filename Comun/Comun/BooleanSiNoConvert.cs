using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Empresa.Comun
{
    public class BooleanSiNoConvert: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                bool valor = (bool)value;
                if (valor)
                {
                    return "Si";
                }
                else
                {
                    return "No";
                }
            }
            else {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string valor = value.ToString();
            if (valor == "Si"){
                return true;
            }

            if (valor == "No"){
                return false;
            }

            return false;
        }
    }
}
