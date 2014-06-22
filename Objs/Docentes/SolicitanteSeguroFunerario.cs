using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class SolicitanteSeguroFunerario {
        public TSolicitante Solicitante { get; set; }

        public SolicitanteSeguroFunerario() {
            this.Solicitante = new TSolicitante();
        }

        public SolicitanteSeguroFunerario(string cedula){
            //SeguroFunerario_Solicitante_View
            this.Solicitante = new TSolicitante();
        }

        public SolicitanteSeguroFunerario(tsolicitudfunenario solicitud){
            this.Solicitante = new TSolicitante();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@solsf_id", solicitud.Id);
            Empresa.Comun.Parentesco parn = new Comun.Parentesco();

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.SeguroFunerario_Solicitante_View", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                
                this.Solicitante.Nombres = fila["nombres"].ToString();
                this.Solicitante.Apellidos = fila["apellidos"].ToString();
                this.Solicitante.Cedula = fila["cedula"].ToString();
                this.Solicitante.Parentesco = parn.GetItem(Convert.ToInt32(fila["parn_id"]));
            

                this.Solicitante.DireccionAsignada = new Comun.DireccionAsignada(Solicitante.Cedula, 3).GetLast();
                this.Solicitante.Contacto = new Comun.ContactoAsignado(Solicitante.Cedula).GetLast();
            }

        }

        public void Insert(tsolicitudfunenario solicitud){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@solsf_id", solicitud.Id);
            consulta.Parameters.Add("@solisf_cedula", solicitud.Solicitante.Cedula);
            consulta.Parameters.Add("@parn_id", solicitud.Solicitante.Parentesco.Id);

            consulta.Execute.NoQuery("dbo.SeguroFunerario_Solicitante_Insert", System.Data.CommandType.StoredProcedure);

            Empresa.Comun.DireccionAsignada dires = new Comun.DireccionAsignada(solicitud.Solicitante.Cedula, 3);
            Empresa.Comun.ContactoAsignado cont = new Comun.ContactoAsignado(solicitud.Solicitante.Cedula);
            
            //Ingresando Dirección.
            if(dires.GetLast().Existe){
                //update 
                dires.Update(solicitud.Solicitante.Cedula, solicitud.Solicitante.DireccionAsignada, 3);
            }
            else {
                //insert
                dires.Insert(solicitud.Solicitante.Cedula, solicitud.Solicitante.DireccionAsignada,3);
            }

            //Ingresando Contactos
            if(cont.GetLast().Existe){
                //Update
                cont.Update(solicitud.Solicitante.Contacto);
            }
            else{
                //Insert
                cont.Insert(solicitud.Solicitante.Cedula, solicitud.Solicitante.Contacto);
            }

        }

        public void Update(tsolicitudfunenario solicitud){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@solsf_id", solicitud.Id);
            consulta.Parameters.Add("@solisf_cedula", solicitud.Solicitante.Cedula);
            consulta.Parameters.Add("@parn_id", solicitud.Solicitante.Parentesco.Id);
            consulta.Execute.NoQuery("dbo.SeguroFunerario_Solicitante_Update", System.Data.CommandType.StoredProcedure);

            Empresa.Comun.DireccionAsignada dires = new Comun.DireccionAsignada(solicitud.Solicitante.Cedula, 3);
            Empresa.Comun.ContactoAsignado cont = new Comun.ContactoAsignado(solicitud.Solicitante.Cedula);

            //Ingresando Dirección.
            if (dires.GetLast().Existe)
            {
                //update 
                dires.Update(solicitud.Solicitante.Cedula, solicitud.Solicitante.DireccionAsignada, 3);
            }
            else
            {
                //insert
                dires.Insert(solicitud.Solicitante.Cedula, solicitud.Solicitante.DireccionAsignada, 3);
            }

            //Ingresando Contactos
            if (cont.GetLast().Existe){
                //Update
                cont.Update(solicitud.Solicitante.Contacto);
            }
            else{
                //Insert
                cont.Insert(solicitud.Solicitante.Cedula, solicitud.Solicitante.Contacto);
            }
        
        }

    }
}
