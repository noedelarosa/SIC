using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Empresa.Comun
{
    public static class ConverToDates : Object
    {
        /// <summary>
        /// Convierte la Fecha en formato Ejempl. 01 de Mayo del 2010
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static string FormatoA(DateTime fecha)
        {
            return fecha.Day.ToString() + " de " + new System.Globalization.CultureInfo("Es-DO").TextInfo.ToTitleCase(String.Format("{0:MMMM}", fecha).ToString()) + " del " + fecha.Year.ToString();
        }

        /// <summary>
        /// Convierte la Fecha en formato Ejempl. 01 del mes de Mayo del año 2010
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static string FormatoB(DateTime fecha)
        {
            return fecha.Day.ToString() + " del mes de " + new System.Globalization.CultureInfo("Es-DO").TextInfo.ToTitleCase(String.Format("{0:MMMM}", fecha).ToString()) + " del año " + fecha.Year.ToString();
        }

        /// <summary>
        /// Convierte la fecha que inician con el Numero 1 en formato Ejempl. al UN(01) dia del mes de Mayo del 2010
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static string FormatoC(DateTime fecha)
        {
            if (fecha.Day == decimal.One)
            {
                return " al UN (" + fecha.Day.ToString() + ") día del mes de " + new System.Globalization.CultureInfo("Es-DO").TextInfo.ToTitleCase(String.Format("{0:MMMM}", fecha).ToString()) + " del año " + fecha.Year.ToString();
            }
            else
            {
                Empresa.Comun.ConvertNaL c = new Empresa.Comun.ConvertNaL();
                return " a los " + c.UnidadDecena(fecha.Day, false, false) + " (" + fecha.Day + ") días del mes de " + new System.Globalization.CultureInfo("Es-DO").TextInfo.ToTitleCase(String.Format("{0:MMMM}", fecha).ToString()) + " del año " + fecha.Year.ToString();
            }
        }

    }
}
