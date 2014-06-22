using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Empresa.Docente{
    public class trequisitos: Empresa.Comun.TEstandar {
                
        public trequisitos() {
            this.Nombre = string.Empty;
            this.Id = 0;
            this.Descripcion = string.Empty;
        }
        public trequisitos(int id){
            this.Nombre = string.Empty;
            this.Id = id;
            this.Descripcion = string.Empty;
        }
        public trequisitos(int id,string nombre, string descripcion){
            this.Nombre = nombre;
            this.Id = id;
            this.Descripcion = descripcion;
        }

        public trequisitos(string nombre, string descripcion){
            this.Nombre = nombre;
            this.Id = 0;
            this.Descripcion = descripcion;
        }   
    }
}
