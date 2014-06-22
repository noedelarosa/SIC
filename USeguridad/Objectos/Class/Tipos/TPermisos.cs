using System;
namespace Empresa.USeguridad
{
    public class TPermisos
    {
        public TRecurso Recurso  { get; set; }
        public Permiso Permiso { get; set; }
        
        public TPermisos(TRecurso recurso, Permiso permiso) {
            this.Recurso = recurso;
            this.Permiso = permiso;
        }
    }
}
