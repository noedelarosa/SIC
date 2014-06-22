using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace Empresa.Comun
{
     public class ConvertFiltroMunicipio:DependencyObject, IValueConverter {
         public static DependencyProperty DepenParametrosConversion = DependencyProperty.Register("ParametrosConversion", typeof(object), typeof(ConvertFiltroMunicipio));
         public object ParametrosConversion {
             get {
                 return GetValue(DepenParametrosConversion);
             }
             set {
                 SetValue(DepenParametrosConversion, value);
             }
         }
         
         public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture){

             return value;
         }

         public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             return value;
         }
     }
}
