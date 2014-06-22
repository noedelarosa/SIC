using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;


namespace Empresa.Comun
{
    public class EdadToColorbgConvert: IValueConverter {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture){
            bool valor = (bool)value;
            
            if (valor){
               return  new BrushConverter().ConvertFromString("#CCFFD8D8") as SolidColorBrush;
            }
            else {
                return System.Windows.Media.Brushes.White;
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture){
            

            throw new NotImplementedException();
        }
    }
}
