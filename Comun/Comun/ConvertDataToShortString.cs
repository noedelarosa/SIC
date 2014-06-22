using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Empresa.Comun
{
    /// <summary>
    /// Conversion a Mes-Año desde un formato Fecha
    /// </summary>
    public class ConvertDataToShortString:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime valuetemp = (DateTime)value;
            return valuetemp.ToString("MMMM") + "-" + valuetemp.ToString("yyyy"); 
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
