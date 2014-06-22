using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.RegistroEventos
{
    public class ttarea: Empresa.Comun.TEstandar
    {
        public ttarea() {
            this.Id = 0;
            this.Nombre = string.Empty;
            this.Descripcion = string.Empty;
        }

        public ttarea(int id)
        {
            this.Id = id;
            this.Nombre = string.Empty;
            this.Descripcion = string.Empty;
        }

        public ttarea(EnumIdentificadorTarea idtarea)
        {
            this.Id = Convert.ToInt32(idtarea);
            this.Nombre = string.Empty;
            this.Descripcion = string.Empty;
        }

        public ttarea(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = string.Empty;
        }

    }
}
