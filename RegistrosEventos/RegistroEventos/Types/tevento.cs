using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.RegistroEventos
{
    public class tevento
    {
        public DateTime Fecha { get; set; }
        public string Modulo { get; set; }
        public string Objecto { get; set; }
        public ttarea Tarea { get; set; }
        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public Empresa.Usuarios.TUsuario Usuario { get; set; }
        public string IdProcesador { get; set; }
        public string NombreComputadora { get; set; }
        
        /// <summary>
        /// Nombre de usuario del Sistema Operativo(maquina o dominio)
        /// </summary>
        public string NombreUsuario { get; set; }
        
        public tevento() {
            this.Fecha = DateTime.Now;
            this.Modulo = string.Empty;
            this.Tarea = new ttarea();
            this.Usuario = new Usuarios.TUsuario();
            this.Referencia = string.Empty;
            this.Descripcion = string.Empty;
            this.IdProcesador = string.Empty;
            this.NombreComputadora = string.Empty;
            this.NombreUsuario = string.Empty;
        }

        public tevento(string modulo, string referencia, ttarea tarea, Empresa.Usuarios.TUsuario usuario){
            this.Fecha = DateTime.Now;
            this.Modulo = modulo;
            this.Tarea = tarea;
            this.Usuario = usuario;
            this.Referencia = referencia;
            this.Descripcion = string.Empty;
            this.IdProcesador = string.Empty;
            this.NombreComputadora = string.Empty;
            this.NombreUsuario = string.Empty;
        }

        public tevento(string modulo, string referencia, ttarea tarea, Empresa.Usuarios.TUsuario usuario,string descripcion)
        {
            this.Fecha = DateTime.Now;
            this.Modulo = modulo;
            this.Tarea = tarea;
            this.Usuario = usuario;
            this.Referencia = referencia;
            this.Descripcion = descripcion;
            this.IdProcesador = string.Empty;
            this.NombreComputadora = string.Empty;
            this.NombreUsuario = string.Empty;
        }

        public tevento(string modulo, string objecto, string referencia, ttarea tarea, Empresa.Usuarios.TUsuario usuario, string idprocesador,string nombrecomputadora, string nombreusuario)
        {
            this.Fecha = DateTime.Now;
            this.Modulo = modulo;
            this.Tarea = tarea;
            this.Usuario = usuario;
            this.Referencia = referencia;
            this.Descripcion = string.Empty;
            this.IdProcesador = idprocesador;
            this.NombreComputadora = nombrecomputadora;
            this.NombreUsuario = nombreusuario;
            this.Objecto = objecto;
        }

        public tevento(string modulo, string objecto, string referencia, ttarea tarea, Empresa.Usuarios.TUsuario usuario, string idprocesador, string nombrecomputadora, string nombreusuario, string descripcion)
        {
            this.Fecha = DateTime.Now;
            this.Modulo = modulo;
            this.Tarea = tarea;
            this.Usuario = usuario;
            this.Referencia = referencia;
            this.Descripcion = descripcion;
            this.IdProcesador = idprocesador;
            this.NombreComputadora = nombrecomputadora;
            this.NombreUsuario = nombreusuario;
            this.Objecto = objecto;
        }



    }
}
