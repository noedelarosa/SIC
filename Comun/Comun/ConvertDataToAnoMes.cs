using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Empresa.Comun
{
    /// <summary>
    /// Conversión Estructura Fecha de Partes, a Año Mes
    /// </summary>
    public class ConvertDataToAnoMes:IValueConverter
    {
        /// <summary>
        /// Conversión de Estructura Fecha Partes, a Año Mes. 
        /// </summary>
        /// <param name="value">tipo: StFechasPartes</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture">Neutral</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture){
            if (value != null)
            {
                Empresa.Comun.StFechasPartes fecha = (Empresa.Comun.StFechasPartes)value;
                return fecha.Anos.ToString() + " Año(s) y " + fecha.Meses.ToString() + " Mes(ses)";
            }
            else {
                return new Empresa.Comun.StFechasPartes();
            }
            //formato de salida  --> 12 Año(s) y 4 Mes(ses)
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
