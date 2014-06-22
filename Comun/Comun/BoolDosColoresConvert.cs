using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Empresa.Comun
{
    public class BoolDosColoresConvert: IValueConverter 
    {
        //r:203,g:255,b:198,a:60
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool valor = (bool)value;
            BrushConverter conver = new BrushConverter();
            //R:#  V:#
            if (valor){
                return conver.ConvertFromString("#CCC0FFAD") as SolidColorBrush;
            }
            else {
                return conver.ConvertFromString("#CCFFADAD") as SolidColorBrush;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
