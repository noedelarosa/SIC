using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Empresa.Comun
{
    /// <summary>
    /// Conversion desde Formato Fecha a Año Mes.
    /// </summary>
    public class ConvertMesNombreAno:IValueConverter{

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture){
            
            if (value != null){
                DateTime tvalue = (DateTime)value;
                return tvalue.ToString("MMMM") + " - " + tvalue.Year.ToString();
            }
            else {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
