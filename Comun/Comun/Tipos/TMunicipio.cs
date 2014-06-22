using System;
using System.ComponentModel;

namespace Empresa.Comun
{
        
        public class TMunicipio
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Codigo { get; set; }

            private TProvincia _provincia;
            public TProvincia Provincia {
                get {
                    return _provincia;
                }
                set {
                    _provincia = value;
                    this.EnCambio("Provincia");
                }
            }

            public TMunicipio() {
                this.Id = 0;
                this.Nombre = string.Empty;
                this.Codigo = string.Empty;
                this.Provincia = new TProvincia();
            }

            public TMunicipio(int id) { 
                this.Id = id;
                this.Nombre = string.Empty;
                this.Codigo = string.Empty;
                this.Provincia = new TProvincia();
            }

            public TMunicipio(TProvincia provincia) { 
                this.Provincia = provincia;
                this.Id = 0;
                this.Nombre = string.Empty;
                this.Codigo = string.Empty;
            }

            public TMunicipio(string codigo) { 
                this.Codigo = codigo;
                this.Id = 0;
                this.Nombre = string.Empty;
                this.Provincia = new TProvincia();
            }

            public TMunicipio(string nombre, TProvincia provincia, string codigo) { 
                this.Nombre = nombre; 
                this.Provincia = provincia;
                this.Codigo = codigo;
                this.Id = 0;
            }

            public TMunicipio(int id, string nombre, TProvincia provincia, string codigo) { 
                this.Id = id; 
                this.Nombre = nombre; 
                this.Provincia = provincia; 
                this.Codigo = codigo; 
            }

            public event PropertyChangedEventHandler PropertyChanged;

            public void EnCambio(string nombre)
            {
                PropertyChangedEventHandler manejador = PropertyChanged;
                if (manejador != null)
                {
                    manejador(this, new PropertyChangedEventArgs(nombre));
                }
            }

        }
    }
