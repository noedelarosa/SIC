using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Comun
{
    public class Contactos: ObservableCollection<tcontacto> {
        //Comun_ContactosInsert
        public bool InDb = false;
        public tcontacto UltimoInsertado { get; set; }

        public Contactos(int id){

        }

        public Contactos(bool indb){
            this.InDb = indb;
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            tcontacto con;
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Comun_DocenteContatosViewTodos]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                con = new tcontacto();
                con.Id = Convert.ToInt32(fila["cont_Id"]);
                con.TelefonoA = fila["cont_telefonoa"].ToString();
                con.TelefonoB = fila["cont_telefonob"].ToString();
                con.EmailA = fila["cont_Emaila"].ToString();
                con.EmailB = fila["cont_Emailb"].ToString();
                con.FaxA = fila["cont_faxa"].ToString();
                con.FaxB = fila["cont_faxb"].ToString();
                con.ExtensionA = fila["cont_extensiona"].ToString();
                con.ExtensionB = fila["cont_extensionb"].ToString();
                con.MovilA = fila["cont_movila"].ToString();
                con.MovilB = fila["cont_movilb"].ToString();
                con.WebA = fila["cont_weba"].ToString();
                con.WebB = fila["cont_webb"].ToString();
                this.Add(con); 
            }
        }

        public Contactos(int id,bool indb){
            this.InDb = indb;
        }

        public tcontacto GetItem(int id){
            foreach (tcontacto item in this) {
                if (item.Id.Equals(id)) return item;
            }
            return new tcontacto();
        }

        private int _Add(tcontacto item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@cont_telefonoa", item.TelefonoA);
            consulta.Parameters.Add("@cont_telefonob", item.TelefonoB);
            consulta.Parameters.Add("@cont_emaila", item.EmailA);
            consulta.Parameters.Add("@cont_emailb", item.EmailB);
            consulta.Parameters.Add("@cont_faxa", item.FaxA);
            consulta.Parameters.Add("@cont_faxb", item.FaxB);
            consulta.Parameters.Add("@cont_extensiona", item.ExtensionA);
            consulta.Parameters.Add("@cont_extensionb", item.ExtensionB);
            consulta.Parameters.Add("@cont_codigopostal", item.CodigoPostal);
            consulta.Parameters.Add("@cont_movila", item.MovilA);
            consulta.Parameters.Add("@cont_movilb", item.MovilB);
            consulta.Parameters.Add("@cont_weba", item.WebA);
            consulta.Parameters.Add("@cont_webb", item.WebB);
            
            using (System.Data.SqlClient.SqlDataReader lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("dbo.Comun_ContactosInsert", System.Data.CommandType.StoredProcedure)) { 
                if (lector.Read()) return Convert.ToInt32 (lector[0]);
            }

            return 0;
        }

        private void _Remove(tcontacto item){



        }

        private void _Update(tcontacto item){



        }

        public void Update(tcontacto item){

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@cont_id", item.Id);
            consulta.Parameters.Add("@cont_telefonoa", item.TelefonoA);
            consulta.Parameters.Add("@cont_telefonob", item.TelefonoB);
            consulta.Parameters.Add("@cont_emaila", item.EmailA);
            consulta.Parameters.Add("@cont_emailb", item.EmailB);
            consulta.Parameters.Add("@cont_faxa", item.FaxA);
            consulta.Parameters.Add("@cont_faxb", item.FaxB);
            consulta.Parameters.Add("@cont_extensiona", item.ExtensionA);
            consulta.Parameters.Add("@cont_extensionb", item.ExtensionB);
            consulta.Parameters.Add("@cont_codigopostal", item.CodigoPostal);
            consulta.Parameters.Add("@cont_movila", item.MovilA);
            consulta.Parameters.Add("@cont_movilb", item.MovilB);
            consulta.Parameters.Add("@cont_weba", item.WebA);
            consulta.Parameters.Add("@cont_webb", item.WebB);

            consulta.Execute.NoQuery("dbo.Comun_ContactoUpdate", System.Data.CommandType.StoredProcedure);
        }

        public void Insert(tcontacto item) {
            bool tempindb = this.InDb;
            this.InDb = true;
            this.Add(item);
            this.InDb = tempindb;
        }

        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e){
            switch (e.Action){
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    
                    if (InDb){
                        ((tcontacto)e.NewItems[0]).Id  = _Add((tcontacto)e.NewItems[0]);
                        this.UltimoInsertado = ((tcontacto)e.NewItems[0]);
                    }
                    base.OnCollectionChanged(e);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:

                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:

                    break;
            }

        }

    }
}
