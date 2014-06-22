using System;
using System.Collections.Generic;
namespace Empresa.USeguridad
{
    public class Permiso : List<TPermiso> 
    {

        

        public Permiso() {
            this.Add(new TPermiso(1, "Denegado"));
            this.Add(new TPermiso(2, "Permitido"));
        }
    }
}
