using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.Citas
{

    public class PersonalPreAsignado
    {
        public ObservableCollection<Empresa.RHH.tpersonal> Lista { get; set; }
        private static PersonalPreAsignado _personalpresignado;


        private PersonalPreAsignado(){
            this.Lista = new ObservableCollection<RHH.tpersonal>();
            RHH.Departamento deps = RHH.Departamento.GetInstance();
            RHH.tpersonal item;

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Citas_PersonalPreAsignado_View", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                item = new RHH.tpersonal();

                item.Cedula = fila["perp_cedula"].ToString();
                item.Id = Convert.ToInt32(fila["perp_id"]);
                item.Apellidos = fila["prc_apellidos"].ToString();
                item.Nombres = fila["prc_nombre"].ToString();
                item.Departamento = deps.Source(Convert.ToInt32(fila["dep_id"]))[0];

                this.Lista.Add(item);
            }
        }

        public static PersonalPreAsignado GetInstance() {
            if (_personalpresignado == null) _personalpresignado = new PersonalPreAsignado();
            return _personalpresignado;
        }

        public Empresa.RHH.tpersonal GetItem(string cedula){
            foreach (Empresa.RHH.tpersonal item in this.Lista) { 
            if(item.Cedula.Equals(cedula)) return item;
            }
            return new RHH.tpersonal();
        }

        public Empresa.RHH.tpersonal GetItem(int id){

            return new RHH.tpersonal();
        }


    }
}
