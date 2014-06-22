using System;
using System.Collections;
using System.Collections.Generic;
namespace Empresa.USeguridad
{
    public class TAccion
    {
        public int Id{get;set;}
        public string Nombre {get; set;}
        
        public TAccion(int id, string nombre){
            this.Id = id;
            this.Nombre = nombre;
        }

        public TAccion(int id){
            this.Id = id;
            this.Nombre = string.Empty;
        }
        
        public TAccion(){
            Id = 0;
            this.Nombre = string.Empty;
        }

    }

    public class Accion: List<TAccion>{
        public Accion() {
            this.Add(new TAccion(1, "Acceso"));
            this.Add(new TAccion(2, "Lectura"));
            this.Add(new TAccion(3, "Escritura"));
            this.Add(new TAccion(4, "Modificacion"));
        } 
    }

}
