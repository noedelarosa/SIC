using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class NotificadosFallecidos
    {
        public ObservableCollection<TNotificadosFallecidos> Lista { get; set; }

        public NotificadosFallecidos()
        {
            this.Lista = new ObservableCollection<TNotificadosFallecidos>();
        }

        public ObservableCollection<TNotificadosFallecidos> CargaLista()
        {

            Empresa.Docente.TNotificadosFallecidos tnof;
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Comun_NotificacionFallecidos_View]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                tnof = new TNotificadosFallecidos();
                tnof.Id = Convert.ToInt32(fila["notf_id"]);

                tnof.Fecha = Convert.ToDateTime(fila["notf_fecha"]);
                tnof.Descripcion = fila["notf_descripcion"].ToString();

                tnof.Docente.Cedula = fila["cedula"].ToString();
                tnof.Docente.Apellidos = fila["apellido1"].ToString();
                tnof.Docente.Nombres = fila["nombres"].ToString();
                tnof.Docente.NombreCompleto = fila["nombrecompleto"].ToString();
                
                //Notificaición por defecto
                tnof.Docente.EsNotificadoFallecido = true;
                tnof.EsFallecidoMinimo = Convert.ToBoolean(fila["EsValidoMinimo"]);

                this.Lista.Add(tnof);
            }
            return this.Lista;
        }



        public int Cantidad() 
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            using(System.Data.SqlClient.SqlDataReader lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("dbo.Comun_NotificacionFallecidos_Count", System.Data.CommandType.StoredProcedure)) 
            {
                if(lector.Read()){
                    return Convert.ToInt32(lector[0]);
                }
                else {
                    return 0;
                }
            }

        }

        public void Insert(TNotificadosFallecidos item) {
          SSData.Servicios consulta;
          consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
          
          consulta.Parameters.Add("@notf_cedula", item.Docente.Cedula);
          consulta.Parameters.Add("@notf_descripcion", item.Descripcion);
          consulta.Parameters.Add("@depa_id", item.Departamento.Id);
          consulta.Parameters.Add("@notf_enviocorreo", item.CorreoEnvidado);

          consulta.Execute.NoQuery("[dbo].[Comun_NotificacionFallecidos_Insert]", System.Data.CommandType.StoredProcedure);
        }

        public void Update(tdocente item)
        {
            //


        }

        public void Delete(TNotificadosFallecidos item) 
        {
            SSData.Servicios consulta;
            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@notf_cedula", item.Docente.Cedula);
            consulta.Execute.NoQuery("[dbo].[Comun_NotificacionFallecidos_Delete]", System.Data.CommandType.StoredProcedure);      
        }


    }
}
