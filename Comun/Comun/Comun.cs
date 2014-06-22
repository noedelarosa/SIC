using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.NetworkInformation;
using System.ComponentModel;
using System.Management;
using System.Management.Instrumentation;




public delegate void DInicio(object arg);
public delegate void DFinalizar(object resul);

namespace Empresa.Comun
{

    public class Info
    {
        private Assembly Asm { get; set; }
        public Info(Assembly asm)
        {
            this.Asm = asm;
        }
        public string ModuloNombre
        {
            get
            {
                return ((AssemblyTitleAttribute)Asm.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title;
            }
        }

        public string GUID
        {
            get
            {
                return ((GuidAttribute)Asm.GetCustomAttributes(typeof(GuidAttribute), false)[0]).Value;
            }
        }

    }

    public interface IOperaciones<T>
    {
        void Guardar(T item);
        void Modificar(T item);
        void Limpiar();
        void Eliminar(T item);
    }

		public delegate void DConteo(int e);
    	public delegate void Saliendo();
    	public delegate void DSeleccion(object e);
    	public delegate void Aceptar(object e);
    	public delegate void AceptarDireccion(TDireccion item);
        public delegate void DFinalizar(object e);
        public delegate void DNRetur();

       /// <summary>
       /// Estructura que define por parte la fecha.
       /// </summary>
       public struct StFechasPartes {
            public int Anos;
            public int Meses;
            public int Semanas;
            public int Dias;
            public int Hora;
            public int Minutos;
            public int Segundos;
           
            public override string ToString(){
                return Anos.ToString() + " Año(s) y " +  Meses.ToString() + " Mes(es) ";
            }

            public string ToStrings(EnumFormatoTiempo formato)
            {
                switch (formato) {
                    case EnumFormatoTiempo.Fecha:
                        return Dias.ToString() + "/" + Meses.ToString() + "/" + Anos.ToString();
                    case EnumFormatoTiempo.FechaHora:
                        return Dias.ToString() + "/" + Meses.ToString() + "/" + Anos.ToString() + "  " + Hora.ToString() + ":" + Minutos.ToString() + ":" + Segundos.ToString();;
                    case EnumFormatoTiempo.Hora:
                        return Hora.ToString() + ":" + Minutos.ToString() + ":" + Segundos.ToString();
                }

                return string.Empty;
            }
        }

       public enum EnumFormatoTiempo{
           FechaHora =1,
           Fecha =2,
           Hora =3 
       }

       public enum Meses{ 
            Enero=1,
            Febrero=2,
            Marzo=3,
            Abrirl=4,
            Mayo=5,
            Junio=6,
            Julio=7,
            Agosto=8,
            Septiembre=9,
            Octubre=10,
            Noviembre=11,
            Diciembre=12
        }

        public class Servicios {



            public static string DameDireccionFisica() { 
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                if (interfaces.Count() > 0) return interfaces[1].GetPhysicalAddress().ToString();
                return string.Empty;
            }

        public static string DameIdProcesador(){	     
	        string idpro = string.Empty;
	        //string consulta = "SELECT ProcessorId FROM Win32_Processor";
            System.Management.ManagementClass mag = new ManagementClass("win32_processor");
            ManagementObjectCollection magcol = mag.GetInstances();

            foreach (ManagementObject obj in magcol) {
                
                if (idpro == string.Empty){
                    idpro = obj.Properties["processorID"].Value.ToString();
                }
                else {
                    break;
                }

            }


            return idpro;
        }

            public static string DividirCAD(List<string> arg) {
                string temp = string.Empty;
                for(int i=0; i <= arg.Count-1; i++){
                    if (!string.IsNullOrEmpty(arg[i])){
                        if (i.Equals(arg.Count - 1)){
                            temp += arg[i];
                        }
                        else {
                            temp += arg[i] + ",";
                        }
                    }
                }
                return temp;
            }

            /// <summary>
            /// Retorna la Diferencia de una fecha en una estructura divida
            /// </summary>
            /// <param name="FechaInicio"></param>
            /// <param name="FechaFinal"></param>
            /// <returns></returns>
            public static StFechasPartes FechasDifencia(DateTime FechaInicio, DateTime FechaFinal) {
                StFechasPartes tempvalue = new StFechasPartes();

                TimeSpan resul = new TimeSpan(); 
                //evitando resultados negativos
                if (FechaFinal > FechaInicio){
                    resul = FechaFinal - FechaInicio;
                }
                else {
                    resul = FechaInicio - FechaFinal;
                }


                if (resul.Ticks <= 0){
                    //RESULTADO NEGATIVO NO VALIDO.
                    return new StFechasPartes();
                }
                else{
                   DateTime retorno = DateTime.MinValue + resul;
                   tempvalue.Anos = retorno.Year - 1;

                   //Calculo para meses
                   if (retorno.Month != 0){
                       tempvalue.Meses = retorno.Month - 1;
                   }
                   else {
                       tempvalue.Meses = 0;
                   }

                   //Calculo de dias
                   if (retorno.Day != 0){
                       tempvalue.Dias = retorno.Day - 1;
                   }
                   else{
                       tempvalue.Dias = 0;
                   }
                   tempvalue.Semanas = (retorno.Day - 1) / 7;

                   //Horas 
                   if (retorno.Hour != 0){
                       tempvalue.Hora = retorno.Hour - 1;
                   }
                   else{
                       tempvalue.Hora = 0;
                   }
                    
                    
                    
                    //Minutos 
                   if (retorno.Minute != 0){
                       tempvalue.Minutos = retorno.Minute - 1;
                   }
                   else{
                       tempvalue.Minutos = 0;
                   }
                   
                   //Segundos
                   if (retorno.Second != 0){
                       tempvalue.Segundos = retorno.Second - 1;
                   }
                   else{
                       tempvalue.Segundos = 0;
                   }

                   
                }
                return tempvalue;
            }

            public static DateTime FechasDifenciaDateTime(DateTime FechaInicio, DateTime FechaFinal)
            {
                StFechasPartes tempvalue = new StFechasPartes();
                TimeSpan resul = FechaFinal - FechaInicio;
                
                if (resul.Ticks <= 0){
                    //RESULTADO NEGATIVO NO VALIDO.
                    return new DateTime();
                }
                else{

                    DateTime retorno = DateTime.MinValue + resul;
                    tempvalue.Anos = retorno.Year - 1;

                    //Calculo para meses.
                    if (retorno.Month != 0){
                        tempvalue.Meses = retorno.Month - 1;
                    }
                    else{
                        tempvalue.Meses = 0;
                    }

                    //Calculo de dias
                    if (retorno.Day != 0){
                        tempvalue.Dias = retorno.Day - 1;
                    }
                    else{
                        tempvalue.Dias = 0;
                    }
                    tempvalue.Semanas = (retorno.Day - 1) / 7;

                    return new DateTime(tempvalue.Anos, tempvalue.Meses, tempvalue.Dias);
                }

                
            }


            public static bool CedulaEsValida(string cedula)
            {
                //Almacena el resultado del calculo hecho con los numeros no intercalados de la cedula
                var numerosProcesados = new List<int>();
                //Almacena los numeros intercalados de la cedula, que son ignorados en el calculo
                var numerosIgnorados = new List<int>();
                var esValida = false;
                int num=0;

                cedula = cedula.Trim();

                if (cedula.Length != 11)
                {
                    return false;
                }
                
                //No es numero falso
                //if (Information.IsNumeric(cedula) == false)
                //{
                //    return false;
                //}
                
                long ncedula = 0;
                return long.TryParse(cedula, out ncedula);

                for (int i=9; i >= 0; i--)
                {

                    if (i % 2 == 0)
                    {
                        //Si la posicion del indice es par, ignoramos el digito de la cedula y lo almacenamos como int.
                        numerosIgnorados.Add(Convert.ToInt32(cedula[i].ToString(CultureInfo.InvariantCulture)));
                    }
                    else
                    {
                        //Se convierte el digito de la cedula analizado de char, a string, y luego a int
                        var numero = Convert.ToInt32(cedula[i].ToString(CultureInfo.InvariantCulture));

                        if ((numero * 2) > 9)
                        {
                            //Si al multiplicar el numero por dos, pasa de 9, le restamos 9, y almacenamos el resultado
                            numerosProcesados.Add((numero * 2) - 9);
                        }
                        else
                        {
                            //De lo contrario, solo multiplicamos y almacenamos el resultado. Sin restar nada
                            numerosProcesados.Add(numero * 2);
                        }
                    }
                }

                //Sumamos los numeros dentro de ambos arreglos entre si
                var sumatoriaProceso = numerosIgnorados.Sum() + numerosProcesados.Sum();

                //Creamos un contador, y lo vamos incrementando de 10 en 10, hasta que
                //sea mayor o igual que la sumatoria del proceso.
                var contador = 10;
                while (contador < sumatoriaProceso)
                {
                    contador += 10;
                }

                //Conseguimos el digito verificador, segun el calculo
                var resultadoProceso = contador - sumatoriaProceso;

                //Por ultimo, comparamos el digito verificador que conseguimos, con el digito verificador
                //que nos trajo la cedula que nos llego como parametro. Si son iguales, la cedula es valida.
                if (resultadoProceso == Convert.ToInt32(cedula[10].ToString(CultureInfo.InvariantCulture)))
                    esValida = true;

                return esValida;
            }

            public static TimeSpan FechaDiferenciaActual(DateTime fecha) {
                TimeSpan df;
                if (fecha != DateTime.MinValue){
                    df = Empresa.Comun.Server.DameTiempo() - fecha;
                    return df;
                }
                else{
                    return  new TimeSpan();
                }
            }
        }

        public static class Mensajes {
            
            public static string NoConeccion = " No Existe conección de Red, Verifique la conección de red con el servidor. ";
            public static string DocumentoGuardar = " Documento Guardado con exito. ";
            public static string Documen_No_Guardar = " No se pudo guardar el Documento, verifique. ";
            public static string Documen_FaltaRequisitos = " Falta requisito para completar la tarea, porfavor verifique todos los campos. ";
            public static string Documen_No_Seleccionado = " Falta Selección de Documento, Verifique los datos. ";
            public static string Error_Proceso = "Error en el Proceso, Intente de nuevo.";
        
        }
}
