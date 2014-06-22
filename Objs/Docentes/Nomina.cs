using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.Docente
{
    public class Nomina
    {
        public ObservableCollection<TNomina> Lista { get; set; }
        
        public Nomina() {
            Lista = new ObservableCollection<TNomina>();
        }

        /// <summary>
        /// Devuelve los fallecidos y notificados de la ultima nomina encontrada
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<TNotificadosFallecidos> DameNotificadosFallecidos() {
            ObservableCollection<TNotificadosFallecidos> __list = new ObservableCollection<TNotificadosFallecidos>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            TNotificadosFallecidos __tnoti;
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Comun_View_FallecidosNotificados_UltimaNomina]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                __tnoti = new TNotificadosFallecidos();

                __tnoti.Docente.Cedula = fila["docf_cedula"].ToString();
                __tnoti.Docente.Apellidos = fila["noh_apellido1"].ToString();
                __tnoti.Docente.Nombres = fila["noh_nombres"].ToString();
                __tnoti.Docente.EsMasculino = Convert.ToBoolean(fila["noh_sexo"]);
                __tnoti.Docente.HistorialPagos.Lista.Add(new TPago(Convert.ToDouble(fila["noh_sueldo"]),Convert.ToDateTime(fila[""]), new RHH.testadolaboral())); 
                __tnoti.Docente.EsNotificadoFallecido = Convert.ToBoolean(fila["EsNotificado"]);
                __list.Add(__tnoti);
                //__tnoti.EsFallecidoMinimo 
            }
            return __list;
        }

        public ObservableCollection<tcuentanomina> DameListadoCantidadNomina(DateTime FechaInicio, DateTime FechaFinal, Empresa.RHH.testadolaboral estado) {
            ObservableCollection<tcuentanomina> __lista = new ObservableCollection<tcuentanomina>();

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Comun_View_ConteoFecha_Nomina]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            { 
            
  
                
            }
            //noh_fnomina
            //cantidad




            return __lista;
        }

        private void Construir(int ano, int mes, Empresa.RHH.testadolaboral estado)
        {
            tdocente docent;
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@ano", ano);
            consulta.Parameters.Add("@mes", mes);
            consulta.Parameters.Add("@tar_id", estado.Id);

            TNomina nom;
            nom = new TNomina();

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[View_NominaHistorico_AMT]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                docent = new tdocente();

                docent.Nombres = fila["Noh_Nombres"].ToString();
                docent.Apellidos = fila["Noh_Apellidos"].ToString();
                docent.EsMasculino = Convert.ToBoolean(fila["Noh_Sexo"]);
                docent.Cedula = fila["Noh_Cedula"].ToString();

                docent.HistorialPagos = new Pagos();
                DateTime FechaNom = Convert.ToDateTime(fila["Noh_FNomina"]);
                docent.HistorialPagos.Lista.Add(new TPago(Convert.ToDouble(fila["Noh_Sueldo"]), FechaNom, estado));

                nom.Docentes.Add(docent);
                nom.Fecha = FechaNom;
                nom.Tipo = estado;
            }
            this.Lista.Add(nom);
        }

        public Nomina(int ano,int mes, Empresa.RHH.testadolaboral estado){
            Lista = new ObservableCollection<TNomina>();
            this.Construir(ano, mes, estado);  
        }

        /// <summary>
        /// Ultimas.
        /// </summary>
        /// <param name="indice"></param>
        public Nomina(byte indice, Empresa.RHH.testadolaboral estado)
        {
           int cont =0;
           Lista = new ObservableCollection<TNomina>();
           
           while (cont != indice){
               cont += 1;
               DateTime tfecha = Empresa.Comun.Server.DameTiempo().AddMonths(((-1) * Math.Abs(cont)));
               this.Construir(tfecha.Year, tfecha.Month,estado);  
           }

        }

        public Nomina(int ano, Empresa.RHH.testadolaboral estado) {
            Lista = new ObservableCollection<TNomina>();
            DateTime FechaActual = Empresa.Comun.Server.DameTiempo(); 
            
            for(int i = 1; i <= 12; i++) 
            {
                if (ano <= FechaActual.Year && i < FechaActual.Month)
                {
                    this.Construir(ano, i, estado);
                }
            }

        }

        /// <summary>
        /// Indica la Cantidad y Fecha de Ultima Nomina encontrada en el sistema.
        /// </summary>
        public tcuentanomina UltimaNomina {
            get {
                SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
                using (System.Data.SqlClient.SqlDataReader lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("dbo.Comun_View_Ultima_Nomina_CantidadFecha", System.Data.CommandType.StoredProcedure))
                {
                    if (lector.Read()){
                        return new tcuentanomina(Convert.ToInt32(lector["cantidad"]), Convert.ToDateTime(lector["noh_fnomina"]));
                    }
                    else {
                        return new tcuentanomina();
                    }
                }
            }
        }

        /// <summary>
        /// Indica la Cantidad y Fecha de Primero Nomina encontrada en el sistema
        /// </summary>
        public tcuentanomina PrimeraNomina
        {
            get
            {
                SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
                using (System.Data.SqlClient.SqlDataReader lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("dbo.Comun_View_Primera_Nomina_CantidadFecha", System.Data.CommandType.StoredProcedure))
                {
                    if (lector.Read()){
                        return new tcuentanomina(Convert.ToInt32(lector["cantidad"]), Convert.ToDateTime(lector["noh_fnomina"]));
                    }
                    else{
                        return new tcuentanomina();
                    }
                }

            }
        }


    }
}
