using System;
using System.Collections.Generic;

namespace Empresa.USeguridad
{
    public class TRol{

        public int Id {get; set;}
        public string Nombre {get; set;}
        public string Descripcion {get;set;}
        public bool Habilitado {get; set;}

        private Autorizacion _Autorizaciones;
        
        public Autorizacion Autorizaciones{
            get {
                _Autorizaciones = new Autorizacion(this.Id);
                return _Autorizaciones;
            }
            set{
                _Autorizaciones = value;
            }
        }
        
        public TRol(){
            this.Id = 0;
            this.Nombre = string.Empty;
            this.Descripcion = string.Empty;
            this.Habilitado = false;
            this.Autorizaciones = new Autorizacion();
        }

        public TRol(string nombre, string descripcion,bool habilitado){
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Habilitado = habilitado;
        }

        public TRol(string nombre, string descripcion, bool habilitado, Autorizacion recurso)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Habilitado = habilitado;
            this.Autorizaciones = recurso;
        }

        public TRol(int id, string nombre,string descripcion, bool habilitado) {
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Habilitado = habilitado;
            
            this.Autorizaciones = new Autorizacion(this.Id);
        }
    }
}
