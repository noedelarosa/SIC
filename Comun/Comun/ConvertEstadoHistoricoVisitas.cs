using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Empresa.Comun
{
    public class ConvertEstadoHistoricoVisitas: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture){
            int valor = (int)value;

            LinearGradientBrush brocha = new LinearGradientBrush();
            GradientStop color1 = new GradientStop();
            GradientStop color2 = new GradientStop();

            brocha.StartPoint.Offset(-0.041,-0.005);
            brocha.EndPoint.Offset(0.782,1.123);

            color1.Offset = 0;
            if(valor == 0){
                color1.Color = Colors.IndianRed;
            }else {
                color1.Color = Colors.LightBlue;
            }
            
            color2.Offset = 0.645;

            brocha.GradientStops.Add(color1);
            brocha.GradientStops.Add(color2);
            
            return brocha;
 
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
