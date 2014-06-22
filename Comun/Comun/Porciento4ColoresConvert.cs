using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Empresa.Comun
{
    public class Porciento4ColoresConvert : IValueConverter 
    {
        //r:203,g:255,b:198,a:60
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double valor = (double)value;
            BrushConverter conver = new BrushConverter();

            LinearGradientBrush Linea = new LinearGradientBrush();
            GradientStop Decra1 = new GradientStop();
            GradientStop Decra2 = new GradientStop();




            //R:#  V:#
            //double valortemp = 

            if (valor <= 40.00) { 
                return conver.ConvertFromString("#FF56EC56") as SolidColorBrush; //verde
            }

            if(valor > 40.00 && valor <= 80.00){
                return conver.ConvertFromString("#FFEDF544") as SolidColorBrush; //amarillo
            }

            if (valor > 80.00 && valor <= 90.00)
            {

                //<LinearGradientBrush EndPoint="0.5,1" StartPoint="0.5,0">
                //    <GradientStop Color="#FF3BFD67" Offset="1"/>
                //    <GradientStop Color="#FFFD522C"/>
                //</LinearGradientBrush>
                
                //degradado verde/amarrillo
                Linea.StartPoint = new System.Windows.Point(0.5, 0);
                Linea.EndPoint = new System.Windows.Point(0.5, 1);

                Decra1.Offset = 1;
                Decra1.Color = (conver.ConvertFromString("#FF3BFD67") as SolidColorBrush).Color;

                Decra1.Offset = 0;
                Decra1.Color = (conver.ConvertFromString("#FFFD522C") as SolidColorBrush).Color;

                return Linea;
            }

            if (valor > 90.00)
            {
                //degradado
                return conver.ConvertFromString("#FFFF7676") as SolidColorBrush; //rojo
            }

            // #FF56EC56 verde
            // #FFEDF544 Amarrillo
            // #FF3BFD67 Verde Amerillo
            // #FFFF7676 Rojo 

            //if(valor){
            //    return conver.ConvertFromString("#CCC0FFAD") as SolidColorBrush;
            //}
            //else {
            //    return conver.ConvertFromString("#CCFFADAD") as SolidColorBrush;
            //}
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
