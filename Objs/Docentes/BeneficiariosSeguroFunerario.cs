using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class BeneficiariosSeguroFunerario{
        public ObservableCollection<tpersonaRelacionada> Lista { get; set; }

        public BeneficiariosSeguroFunerario(){
            this.Lista = new ObservableCollection<tpersonaRelacionada>();
        }

        public bool Existe(tpersonaRelacionada item){
            foreach(tpersonaRelacionada itemp in this.Lista){
                return itemp.Persona.Cedula.Equals(item.Persona.Cedula);
            }

            return false;
        }

        public BeneficiariosSeguroFunerario(tsolicitudfunenario item){
            this.Lista = new ObservableCollection<tpersonaRelacionada>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@solsf_id", item.Id);
            Comun.Parentesco paren = new Comun.Parentesco();

            tpersonaRelacionada per;
            foreach(System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[SeguroFunerario_Beneficiarios_View]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                per = new tpersonaRelacionada();

                per.Persona = new RHH.tpersonal(fila["bensf_cedula"].ToString());
                per.Persona.Nombres = fila["NOMBRES"].ToString();
                per.Persona.Apellidos = fila["apellidos"].ToString();
                per.Persona.FechaNacimiento = Convert.ToDateTime(fila["FECHA_NAC"]);
                per.Parentesco =  paren.GetItem(Convert.ToInt32(fila["parn_id"]));
                per.Persona.Foto = fila["foto"] == DBNull.Value ? null : (byte[])fila["foto"];

                per.EsNuevo = false;

                per.Persona.DireccionAsignada = new Comun.DireccionAsignada(per.Persona.Cedula, 3).GetLast();
                per.Persona.Contacto = new Comun.ContactoAsignado(per.Persona.Cedula).GetLast();

                this.Lista.Add(per);
                
            }
        }

        public void Insert(tsolicitudfunenario item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            Comun.DireccionAsignada dire = new Comun.DireccionAsignada();
            Comun.ContactoAsignado cont = new Comun.ContactoAsignado();
            
            foreach (tpersonaRelacionada itemper in item.Beneficiarios){
                
                if (itemper.EsNuevo){
                    consulta.Parameters.Add("@bensf_cedula", itemper.Persona.Cedula);
                    consulta.Parameters.Add("@parn_id", itemper.Parentesco.Id);
                    consulta.Parameters.Add("@bensf_monto", 0);
                    consulta.Parameters.Add("@solsf_id", item.Id);
                    consulta.Execute.NoQuery("dbo.SeguroFunerario_Beneficiarios_Insert", System.Data.CommandType.StoredProcedure);
                    consulta.Parameters.ClerAll();

                    dire.Insert(itemper.Persona.Cedula, itemper.Persona.DireccionAsignada, 3);
                    cont.Insert(itemper.Persona.Cedula, itemper.Persona.Contacto);
                }

            }
            
        }

        public void Update(tsolicitudfunenario item)
        {



        }


        public void Insert(tpersonaRelacionada item, int id) {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            Comun.DireccionAsignada dire = new Comun.DireccionAsignada();
            Comun.ContactoAsignado cont = new Comun.ContactoAsignado();

            if(item.EsNuevo){
                consulta.Parameters.Add("@bensf_cedula", item.Persona.Cedula);
                consulta.Parameters.Add("@parn_id", item.Parentesco.Id);
                consulta.Parameters.Add("@bensf_monto", 0);
                consulta.Parameters.Add("@solsf_id", id);
                consulta.Execute.NoQuery("dbo.SeguroFunerario_Beneficiarios_Insert", System.Data.CommandType.StoredProcedure);
                //consulta.Parameters.ClerAll();
                //Agregando contactos y Direccion
                dire.Insert(item.Persona.Cedula, item.Persona.DireccionAsignada, 3);
                cont.Insert(item.Persona.Cedula, item.Persona.Contacto);
            }
        
        }

        public void Update(tpersonaRelacionada item, int id)
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            Comun.DireccionAsignada dire = new Comun.DireccionAsignada();
            Comun.ContactoAsignado cont = new Comun.ContactoAsignado();

            if (!item.EsNuevo){

                consulta.Parameters.Add("@bensf_cedula", item.Persona.Cedula);
                consulta.Parameters.Add("@solsf_id", id);
                consulta.Parameters.Add("@parn_id", item.Parentesco.Id);
                consulta.Execute.NoQuery("dbo.SeguroFunerario_Beneficiarios_Update", System.Data.CommandType.StoredProcedure);
                
                //Actualizando contactos y Direccion
                if (item.Persona.DireccionAsignada.Provincia.Id.Equals(0)){
                    dire.Insert(item.Persona.Cedula, item.Persona.DireccionAsignada, 3);
                }
                else {
                    dire.Update(item.Persona.Cedula, item.Persona.DireccionAsignada, 3);
                }

                if (item.Persona.Contacto.Id.Equals(0)){
                    cont.Insert(item.Persona.Cedula,item.Persona.Contacto);
                }
                else {
                    cont.Update(item.Persona.Contacto);
                }
            }
        }

        public void Delete(tpersonaRelacionada item, int id)
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@bensf_cedula", item.Persona.Cedula);
            consulta.Parameters.Add("@solsf_id", id);
            consulta.Execute.NoQuery("dbo.SeguroFunerario_Beneficiarios_Delete", System.Data.CommandType.StoredProcedure);
        }


     



    }
}
