using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Empresa.RHH
{
    public class Personal : ObservableCollection<tpersonal>
    {
        public Personal(){
            //[dbo].[Per_VerTodo_Personal]
        }

        public Personal(int id){
            tpersonal personal;
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@per_id", id);

            foreach (System.Data.DataRow item in consulta.Execute.Dataset("[dbo].[Per_VerId_Personal]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                personal = new tpersonal();

               // personal.Foto = item["pdr_foto"] == DBNull.Value ? null : (byte[])item["pdr_foto"];
                personal.Nombres = item["per_nombre1"].ToString() + " " + item["per_nombre2"].ToString();
                personal.Apellidos = item["per_apellido1"].ToString() + " " + item["per_apellido2"].ToString();
                personal.EsMasculino = Convert.ToBoolean(item["per_sexo"]);
                personal.FechaNacimiento = DateTime.Parse(item["per_fecha_nac"].ToString());
                personal.Id = (int)item["per_id"];
                personal.Cedula = item["per_cedula"].ToString();
                this.Add(personal);
            }

        }

        public Personal(string cedula){
            tpersonal personal;
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@per_cedula", cedula);

            foreach (System.Data.DataRow item in consulta.Execute.Dataset("[dbo].[Per_VerCedula_Personal]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                personal = new tpersonal();
                personal.Nombres = item["per_nombre1"].ToString() + " " + item["per_nombre2"].ToString();
                personal.Apellidos = item["per_apellido1"].ToString() + " " + item["per_apellido2"].ToString();
                personal.EsMasculino = Convert.ToBoolean(item["per_sexo"]);
                personal.FechaNacimiento = DateTime.Parse(item["per_fecha_nac"].ToString());
                personal.Id = (int)item["per_id"];
                personal.Cedula = item["per_cedula"].ToString();
                this.Add(personal);
            }

        }

        public tpersonal PrimerItem() {
            if (this.Count <= 0){
                return new tpersonal();
            }
            else{
                return this[0];
            }
        }

        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
        }

    }

}