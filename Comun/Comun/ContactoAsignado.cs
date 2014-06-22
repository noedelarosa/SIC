using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Comun
{
    public class ContactoAsignado
    {
        public ObservableCollection<tcontacto> Lista { get; set; }

        public ContactoAsignado() {
            this.Lista = new ObservableCollection<tcontacto>();
        
        }

        public ContactoAsignado(int id)
        {
            this.Lista = new ObservableCollection<tcontacto>();

        }

        public ContactoAsignado(string cedula)
        {
            this.Lista = new ObservableCollection<tcontacto>();

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            tcontacto conta;

            consulta.Parameters.Add("@cont_cedula", cedula);
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.[Comun_Contactos_ViewCedula]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                conta = new tcontacto();

                conta.Id = Convert.ToInt32(fila["cont_id"]);
                conta.TelefonoA = fila["cont_telefonoa"].ToString();
                conta.TelefonoB = fila["cont_telefonob"].ToString();
                conta.EmailA = fila["cont_emaila"].ToString();
                conta.EmailB = fila["cont_emailb"].ToString();
                conta.FaxA = fila["cont_faxa"].ToString();
                conta.FaxB = fila["cont_faxb"].ToString();
                conta.ExtensionA = fila["cont_extensiona"].ToString();
                conta.ExtensionB = fila["cont_extensionb"].ToString();
                conta.CodigoPostal = fila["cont_codigopostal"].ToString();
                conta.MovilA = fila["cont_movila"].ToString();
                conta.MovilB = fila["cont_movilb"].ToString();
                conta.WebA = fila["cont_weba"].ToString();
                conta.WebB = fila["cont_webb"].ToString();
                this.Lista.Add(conta);
            }
        }


        public tcontacto GetLast()
        {
            if (this.Lista.Count > 0){
                return Lista[Lista.Count - 1];
            }
            else{
                return new tcontacto();
            }
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

        public void Insert(string cedula,tcontacto item) {
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
            consulta.Parameters.Add("@cont_cedula", cedula);

            consulta.Execute.NoQuery("dbo.Comun_ContactosInsert", System.Data.CommandType.StoredProcedure);
        }
    }
}
