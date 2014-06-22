using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;


namespace Empresa.Citas
{
    public class Indicadores{
        public ObservableCollection<Empresa.Citas.tindicadores> Lista { get; set; }

        public static Indicadores _indicadores;
       
        private Indicadores() {
            Empresa.Citas.tindicadores item;

            this.Lista = new ObservableCollection<Empresa.Citas.tindicadores>();
            this.Lista.CollectionChanged += OnChangedList;

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Citas_Indicador_View", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                
                item = new Empresa.Citas.tindicadores();

                item.Id = Convert.ToInt32(fila["citi_id"]);
                item.Valoracion =  Convert.ToInt32(fila["citi_valoracion"]);
                item.Nombre = fila["citi_nombre"].ToString();
                item.Habilitado = Convert.ToBoolean(fila["citi_eshabilitado"]);

                this.Lista.Add(item);
            }
        }

        public void OnChangedList(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
            var r = e;
            
        }

        public static Indicadores GetInstance() {
            if (_indicadores == null) _indicadores = new Indicadores();
            return _indicadores;
        }

        public Empresa.Citas.tindicadores GetItem()
        {
            return new Empresa.Citas.tindicadores();
        }

        public void Insert(Empresa.Citas.tindicadores item)
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            //consulta.Parameters.Add("@citi_Id", item.Id);
            consulta.Parameters.Add("@citi_nombre", item.Nombre);
            consulta.Parameters.Add("@citi_valoracion", item.Valoracion);
            consulta.Parameters.Add("@citi_eshabilitado",item.Habilitado);
            
            consulta.Execute.NoQuery("dbo.Citas_Indicador_Insert",System.Data.CommandType.StoredProcedure);
        }

        public Indicadores Recarga() {
            _indicadores = null;
            return GetInstance();
        }

        public void Update(Empresa.Comun.TEstandar item){
            //Citas_Indicador_Update



        }

    }
}
