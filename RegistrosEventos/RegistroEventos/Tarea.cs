using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.RegistroEventos
{
    public class Tarea
    {
        public ObservableCollection<ttarea> Lista { get; set; }
        private static Tarea _tarea;
        private Tarea() {
            this.Lista = new ObservableCollection<ttarea>();
            ttarea tarea;
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Comun_SistemaTareas_view", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                tarea = new ttarea();
                tarea.Id = Convert.ToInt32(fila["tar_id"]);
                tarea.Nombre = fila["tar_nombre"].ToString();
            }
        }

        private Tarea(int id) {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            this.Lista = new ObservableCollection<ttarea>();

        }

        public static Tarea GetInstance() {
            if (_tarea == null) _tarea = new Tarea();
            return _tarea;
        }

        public ttarea GetItem(int id){ 
            foreach (ttarea item in this.Lista){
                if (item.Id.Equals(id)) return item;
            }
            return new ttarea();
        }


    }
}
