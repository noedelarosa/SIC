using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Media;
using System.Drawing;
using System.Drawing.Design;

namespace Empresa.Comun
{
    public class ConvertColorBool_YelRed : IValueConverter
    {
       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture){
           bool valor = (bool)value;
           if (valor){
               return Color.Red;
           }
           else {
               return Color.Yellow;
           }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

    }
}
