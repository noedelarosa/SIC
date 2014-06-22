using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
namespace Empresa.Comun
{
    public class ConvertDateNoDefinido:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime valor = (DateTime)value;

            if (valor.Equals(DateTime.MinValue) || valor.Equals(DateTime.MaxValue)){
                return "n/d";
            }
            else {
                return valor.ToString("dd/MM/yyyy");
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
