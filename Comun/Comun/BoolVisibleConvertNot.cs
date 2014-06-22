using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace Empresa.Comun
{
    public class BoolVisibleConvertNot: IValueConverter {
        Visibility Visibilidad;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool valor = (bool)value;
            if (!valor)
            {
                Visibilidad = Visibility.Visible;
            }
            else
            {
                Visibilidad = Visibility.Hidden;
            }
            return Visibilidad;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture){
            Visibilidad = (Visibility)value;
            if (this.Visibilidad == Visibility.Collapsed || this.Visibilidad == Visibility.Hidden){
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
