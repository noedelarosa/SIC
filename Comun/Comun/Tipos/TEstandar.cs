using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Text.RegularExpressions;
namespace Empresa.Comun{
        
        public class TEstandar: Validacion.ReglaContenido
        {
            public int Id { set; get; }
            public string Nombre { get; set; }
            public object Mus { get; set; } // codigo de multiuso.
            public bool Habilitado { get; set; }
            public DateTime Fecha { get; set; }

            public string Descripcion { get; set; }

            public TEstandar() {
                this.Id = 0;
                this.Nombre = string.Empty;
                this.Descripcion = string.Empty;
                this.Mus = new object();
            }

            public TEstandar(string mus)
            {
                this.Id = 0;
                this.Nombre = string.Empty;
                this.Descripcion = string.Empty;
                this.Mus = mus;
            }

            public TEstandar(string nombre, string descripcion)
            {
                this.Descripcion = descripcion;
                this.Nombre = nombre;
            }
        
            public TEstandar(int id)
            {
                this.Id = id;
                this.Nombre = string.Empty;
                this.Descripcion = string.Empty;
            }
            public TEstandar(string nombre, string descripcion, int id)
            {
                this.Descripcion = descripcion;
                this.Nombre = nombre;
                this.Id = id;
            }

       
        }
    }