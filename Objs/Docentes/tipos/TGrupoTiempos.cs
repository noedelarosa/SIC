using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class TGrupoTiempos: Empresa.Comun.TEstandar
    {
        /// <summary>
        /// Valor en Días
        /// </summary>
        public int Valor { get; set; }
        
        public TGrupoTiempos(){
            this.Id = 0;
            this.Valor = 0;
            this.Nombre = string.Empty;
        }

        public TGrupoTiempos(int id)
        {
            this.Id = id;
            this.Valor = 0;
            this.Nombre = string.Empty;
        }

        public TGrupoTiempos(int id, int valor, string nombre)
        {
            this.Id = id;
            this.Valor = valor;
            this.Nombre = nombre;
        }

        public TGrupoTiempos(int valor, string nombre)
        {
            this.Id = 0;
            this.Valor = valor;
            this.Nombre = nombre;
        }

    }
}
