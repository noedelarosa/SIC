using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel; 

namespace Empresa.RHH{
    public class Persona : ObservableCollection<tpersonal>
    {

        public Persona() { 
        
        }

        public Persona(string cedula){
            tpersonal personal;
            cedula = cedula.Replace("-", string.Empty);

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@pdr_cedula", cedula);
            foreach (System.Data.DataRow item in consulta.Execute.Dataset("[dbo].[View_ViewPadron2010]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){    
                if(item["pdr_cedula"] != null){
                    personal = new tpersonal();
                    personal.Foto = item["pdr_foto"] == DBNull.Value ? null : (byte[])item["pdr_foto"];
                    personal.Nombres = item["pdr_nombres"].ToString();
                    personal.Apellidos = item["pdr_apellido1"].ToString() + " " + item["pdr_apellido2"].ToString();
                    personal.EsMasculino = Convert.ToBoolean(item["pdr_sexo"]);
                    personal.FechaNacimiento = (DateTime)item["pdr_FechaNac"];
                    personal.Cedula = item["pdr_cedula"].ToString();
                    this.Add(personal);

                }
            }
        }

       public Persona(int id){



        }

    }
}
