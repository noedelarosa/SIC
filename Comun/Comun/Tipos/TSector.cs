using System;
using System.ComponentModel;

namespace Empresa.Comun
{
        
        public class TSector{

            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Codigo { get; set; }
            private TMunicipio _municipio;
            public TMunicipio Municipio {
                get { 
                    return _municipio; 
                }
                set {
                    _municipio = value;
                    this.EnCambio("Municipio"); 
                } 
            }
            
            public TSector(){
                this.Id = 0;
                this.Nombre = string.Empty;
                this.Codigo = string.Empty;
                this.Municipio = new TMunicipio();
            }

            public TSector(int id) {
                this.Id = id;
                this.Nombre = string.Empty;
                this.Codigo = string.Empty;
                this.Municipio = new TMunicipio();
            }

            public TSector(TMunicipio municipio) {
                this.Municipio = municipio;
                this.Id = 0;
                this.Nombre = string.Empty;
                this.Codigo = string.Empty;

            }

            public TSector(string codigo) { 
                this.Codigo = codigo;
                this.Id = 0;
                this.Nombre = string.Empty;
                this.Codigo = string.Empty;
                this.Municipio = new TMunicipio();
            }
            
            public TSector(int id, string nombre, TMunicipio municipio, string codigo) {
                this.Nombre = nombre;
                this.Municipio = municipio; 
                this.Id = id; 
                this.Codigo = codigo; 
            }

            public TSector(string nombre, TMunicipio municipio, string codigo) {
                this.Id = 0;
                this.Nombre = nombre; 
                this.Municipio = municipio; 
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