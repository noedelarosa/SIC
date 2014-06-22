using System;
namespace Empresa.USeguridad
{
    public class TBoleto{
        public TPermiso  Permiso { get; set; }
        public TAccion Accion { get; set; }
        public TBoleto(){
            Permiso = new TPermiso();
            Accion = new TAccion(); 
        }

        public TBoleto(TPermiso permiso, TAccion accion){      
            this.Permiso = permiso;
            this.Accion = accion;
        }
    }
}
