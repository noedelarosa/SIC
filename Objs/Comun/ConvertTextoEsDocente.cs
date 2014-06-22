using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
 

namespace Empresa.Comun
{
    public class ConvertTextoEsDocente: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture){
            bool valor = (bool)value;
            
            if (valor){
                return "Fallecido";
            }
            else{
                return "No Docente";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }



    }
}
