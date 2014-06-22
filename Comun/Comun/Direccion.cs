using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.Comun
{
    public class Direccion{
        public ObservableCollection<TDireccion> Direcciones { get; set; }
		
		public Direccion(){
            this.Direcciones = new ObservableCollection<TDireccion>();
        }
		
        public Direccion(string cedula){
            this.Direcciones = new ObservableCollection<TDireccion>();
            Comun.Sector sec = Comun.Sector.GetInstance();
            Comun.Municipio mun = Comun.Municipio.GetInstance();

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@docc_cedula", cedula);

            foreach(System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Comun_DocenteContatosView]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                //[dbo].[Comun_DocenteContatosViewCompleto]
            }
        }

        public Direccion(TDireccion item){
            this.Direcciones = new ObservableCollection<TDireccion>();

        }


        public void Insert(TDireccion item){
            //
            //


            

        }

        public void Update(TDireccion item){



        }

        public void Delete(TDireccion item){


        }

        public TDireccion GetItem(string cedula) {
            TDireccion resultado = new TDireccion();






            return resultado;
        }



    }
}
