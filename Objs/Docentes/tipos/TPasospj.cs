using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class TPasospj: Empresa.Comun.TEstandar {
        public TGrupoTiempos GrupoTiempo{get;set;}

        public int Orden { get; set; }
        public TPasospj() {

            this.Id = 0;
            this.Nombre = string.Empty;
            this.Descripcion = string.Empty;
            this.GrupoTiempo = new TGrupoTiempos();
        }
        
        public TPasospj(int id) {
            this.Id = id;
            this.Nombre = string.Empty;
            this.Descripcion = string.Empty;
        }

        public TPasospj(int id, string nombre, int orden){
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = string.Empty;
            this.Orden = orden;
        }

        public TPasospj(int id, string nombre, int orden,TGrupoTiempos grupotipo)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = string.Empty;
            this.Orden = orden;
            this.GrupoTiempo = grupotipo;
        } 

    }
}
