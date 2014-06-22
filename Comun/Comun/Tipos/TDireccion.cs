using System;
using System.ComponentModel;

namespace Empresa.Comun{

        public class TDireccion: INotifyPropertyChanged {
            public int Id { get; set; }

            private TSector _sector;
            public TSector Sector {
                get { return _sector; }
                set {
                    _sector = value;
                    EnCambio("Sector");
                }
            }
           // public TMunicipio Municipio { get; set; }

            public string Referencia { get; set; }
            public bool Exite {
                get {
                    return Sector.Id.Equals(0) && Sector.Municipio.Id.Equals(0);
                }
            }
            public TDireccion() {
                this.Id = 0;
                this.Sector = new TSector();
                this.Referencia = string.Empty;
            }

            public TDireccion(int id){
                this.Id = id;
                this.Sector = new TSector();
                this.Referencia = string.Empty;
            }

            public TDireccion(int id, string referencia, TSector sector){
                this.Id = id;
                this.Referencia = referencia;
                this.Sector = sector;
            }

            public TDireccion(int id, string referencia, TMunicipio municipio){
                this.Id = id;
                this.Referencia = referencia;

                this.Sector = new TSector();
                //this.Municipio = municipio;
                this.Sector.Municipio = municipio;
            }

            public TDireccion(string referencia, TSector sector){
                this.Id = 0;
                this.Referencia = referencia;
                this.Sector = sector; 
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