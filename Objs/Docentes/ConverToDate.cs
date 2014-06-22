using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public static class ConverToDate: Object{

       public static string  FormatoA(DateTime fecha){
           return fecha.Day.ToString() + " de " + String.Format("{0:MMMM}", fecha).ToString() + " del " + fecha.Year.ToString();
       }
       public static string  FormatoB(DateTime fecha){
           return fecha.Day.ToString() + " del mes de " + String.Format("{0:MMMM}", fecha).ToString() + " del año " + fecha.Year.ToString();
       }
       public static string FormatoC(DateTime fecha){
           if(fecha.Day == decimal.One){
               return " al UN (" + fecha.Day.ToString() + ") día del mes de " + String.Format("{0:MMMM}", fecha).ToString() + " del año " + fecha.Year.ToString(); 
           }
           else{
               Empresa.Comun.ConvertNaL c = new Empresa.Comun.ConvertNaL();
               return " a los " + c.UnidadDecena(fecha.Day,false,false) + " (" + fecha.Day + ") días del mes de " + String.Format("{0:MMMM}", fecha).ToString() + " del año " + fecha.Year.ToString();
           }
       }

    }

