using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Comun
{
    public struct SDireccionContacto {
        public TDireccion Direccion;
        public tcontacto Contacto;
        public string Cedula;
    }

    /// <summary>
    /// Clase enlasa los ids de Direccion y Contactos con el usuario.
    /// </summary>
    public class EnlaceContacto {
        public TDireccion Direccion { get; set; }
        public tcontacto Contacto { get; set; }
        public string Cedula {get;set;}
        public List<SDireccionContacto> Lista;
        
        public EnlaceContacto(string cedula){ 
            this.Cedula = cedula;
            Contactos cont = new Contactos(false);
            Direcciones dire = new Direcciones(false);

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@docc_cedula", this.Cedula);

            using (System.Data.SqlClient.SqlDataReader lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("dbo.Comun_DocenteContatosView", System.Data.CommandType.StoredProcedure)){

                if(lector.Read()){
                    this.Direccion = dire.GetItem(Convert.ToInt32(lector[2]));
                    this.Contacto = cont.GetItem(Convert.ToInt32(lector[1]));
                }
                else{
                    this.Contacto =  new tcontacto();
                    this.Direccion = new TDireccion();
                }
            }
        }

        public EnlaceContacto(string[] cedula)
        {
            Lista = new List<SDireccionContacto>();
        }

        public bool Existe(string cedula){
            this.Cedula = cedula;
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@cedula", this.Cedula);
            
            using (System.Data.SqlClient.SqlDataReader lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("dbo.Comun_DocenteContatosExist", System.Data.CommandType.StoredProcedure)){
                if(lector.Read()) return !Convert.ToInt32(lector[0]).Equals(0);
            }

            return false;
        }

        public bool Existe(){
            //this.Cedula = cedula;
            return this.Existe(this.Cedula);
        }

        public void Insert(string cedula,TDireccion direccion, tcontacto contacto){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            Contactos cont = new Contactos(false);
            Direcciones dire = new Direcciones(false);

            //Insertando Direccion Previa
            dire.Insert(direccion);
            
            direccion = dire.UltimoInsertado;
            //Insertado Contacto
            cont.Insert(contacto);
            contacto = cont.UltimoInsertado;

            consulta.Parameters.Add("@docc_cedula", cedula);
            consulta.Parameters.Add("@cont_id", contacto.Id);
            consulta.Parameters.Add("@dire_id", direccion.Id);
            consulta.Execute.NoQuery("dbo.Comun_DocenteContatosInsert", System.Data.CommandType.StoredProcedure); 
        }

        public void Update(string cedula, TDireccion direccion, tcontacto contacto){
            Contactos cont = new Contactos(false);
            Direcciones dire = new Direcciones(false);

            dire.Update(direccion);
            cont.Update(contacto);
        }

    }
}
