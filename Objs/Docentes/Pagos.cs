using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{

    public class Pagos
    {
       public System.Collections.ObjectModel.ObservableCollection<TPago> Lista { get; set; }      
       
       public Pagos() {
            this.Lista = new ObservableCollection<TPago>();
        }

       public TPago Ultimo {

           get {
               
               if (this.Lista.Count > 0){
                   var resul = from x in this.Lista where x.Fecha.Equals((from y in this.Lista select y.Fecha).Max()) select x;
                    return resul.ToList<TPago>()[0];
                }
                else {
                    return new TPago();
                }

            }
            
            set { 
            
            }
        }

       public TPago Primero
        {
            get{
                if(this.Lista.Count > 0){
                    var resul = from x in this.Lista where x.Fecha.Equals((from y in this.Lista select y.Fecha).Min()) select x;
                    return resul.ToList<TPago>()[0];
                }
                else{
                    return new TPago();
                }
            }
            set { 
            
            }
        }

       public Pagos(string cedula){
            this.Lista = new ObservableCollection<TPago>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@cedula", cedula);
            
            foreach(System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Legal_HistoricoSueldosView]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                this.Lista.Add(new TPago(Convert.ToInt32(fila["Noh_id"]), Convert.ToDouble(fila["Noh_Sueldo"]), fila["Noh_FNomina"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["Noh_FNomina"], new RHH.testadolaboral()));
            }
        }

       public Pagos(string cedula, DateTime fecha) { 
       

       
       }

       private void Constructor(List<string> cedulas) {
           this.Lista = new ObservableCollection<TPago>();
           string arg = Empresa.Comun.Servicios.DividirCAD(cedulas);

           SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
           consulta.Parameters.Add("@cedula", arg);

           System.Data.SqlClient.SqlDataReader Lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("[dbo].[Legal_HistoricoSueldosViewCs]", System.Data.CommandType.StoredProcedure);
               while(Lector.Read()) {
                   this.Lista.Add(new TPago(Convert.ToInt32(Lector["Noh_id"]), Lector["Noh_Cedula"].ToString(), Convert.ToDouble(Lector["Noh_Sueldo"]), Lector["Noh_FNomina"] == DBNull.Value ? DateTime.MinValue : (DateTime)Lector["Noh_FNomina"], new RHH.testadolaboral()));
               }        
       }

       public Pagos(List<string> cedulas){
            this.Constructor(cedulas);
       }

       public Pagos(ObservableCollection<tdocente> docente){
            List<string> cedulas = new List<string>();
            
            foreach (tdocente item in docente){
                if (!string.IsNullOrEmpty(item.Cedula)){
                    cedulas.Add(item.Cedula);
                }
            }

            this.Constructor(cedulas); 
        }

        /// <summary>
        /// Promedio de ultimos meses establecidos
        /// </summary>
       public double PromedioM { get; set; }
       /// <summary>
       /// Promedio desde un fecha de inicio
       /// </summary>
        public double PromedioMI { get; set; }

       public double PromedioUltimo(int meses) {
           double promedio = 0;
           double suma = 0;
           int conteo = 0;
           int finconteo =  ((-1 + this.Lista.Count)) - meses;
           int i = (this.Lista.Count - 1);

               while (i > finconteo){
                   suma += this.Lista[i].MontoBruto;
                   conteo += 1;
                   i -= 1;
                   if (i == 0) break;
               }

           promedio = suma / conteo;
           
           //Promedio Establecido
           this.PromedioM = promedio;
           return promedio;
       }

       public double PromedioUltimo(int meses, DateTime inicio){
           double promedio = 0;
           double suma = 0;
           int conteo = 0;

           int finconteo = ((-1 + this.Lista.Count)) - meses;
           int i = (this.Lista.Count - 1);

           //igualando fechas, para fines de comparación
           DateTime fecha_inicio = new DateTime(inicio.Year, inicio.Month, 1);
           DateTime fecha_lista;
          
           while (i > 0){
               //igualando fechas, para fines de comparación
               fecha_lista = new DateTime(this.Lista[i].Fecha.Year,this.Lista[i].Fecha.Month,1);
               if(fecha_lista <= fecha_inicio){
                   
                   if(conteo == 12){
                       break;
                   }
                   else {
                       suma += this.Lista[i].MontoBruto;
                       conteo += 1;
                   }

               }
               i -= 1;
           }

           promedio = suma / conteo;
           this.PromedioMI = promedio;

           if (double.IsNaN(promedio)){
               return 0;
           }
           else{
               return promedio;
           }
               
       }


       public List<TPago> DamePromedioEntre(DateTime finicio, DateTime ffinal) {
           List<TPago> __lis_t = new List<TPago>();

           int conteo = 0;

           //int finconteo = ((-1 + this.Lista.Count)) - meses;
           int i = (this.Lista.Count - 1);
           DateTime fecha_inicio = new DateTime(finicio.Year, finicio.Month, 1);
           DateTime fecha_final = new DateTime(ffinal.Year, ffinal.Month, 1);

           DateTime fecha_lista_i;

           while (i > 0)
           {
               //igualando fechas, para fines de comparación
               fecha_lista_i = new DateTime(this.Lista[i].Fecha.Year, this.Lista[i].Fecha.Month, 1);

               if (fecha_lista_i >= fecha_inicio && fecha_lista_i <= fecha_final)
               {
                   //if (conteo == 12){
                   //    break;
                   //}
                   //else{
                       __lis_t.Add(this.Lista[i]); 
                   //}
               }

               i -= 1;
           }

           return __lis_t;
       }

    }
}
