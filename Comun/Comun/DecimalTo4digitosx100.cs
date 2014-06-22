using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data; 
namespace Empresa.Comun
{
    public class DecimalTo4digitosx100: IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Double valor = (Double)value;
            return string.Format("{0:0.0000}", valor * 100.0); 

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
