using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Citas
{
    public class TMotivoVisitas: Empresa.Comun.Validacion.ReglaContenido
    {
        public int Id { get; set; }
        private string _nombre;
        public string Nombre {
            get {
                return this._nombre;
            }
            set { 
                _nombre = value;
                if (string.IsNullOrEmpty(_nombre)){
                    this.AgregoError("Nombre", "Falta Nombre");
                }
                else {
                    this.BorrarError("Nombre");
                }
            }
        }

        public double Tiempo { get; set; }
        public Empresa.RHH.TDepartamento Departamento { get; set; }

        public TMotivoVisitas(){
            this.Id = 0;
            this.Nombre = string.Empty;
            this.Tiempo = 0;
            this.Departamento = new RHH.TDepartamento();
        }

        public TMotivoVisitas(int id){
            this.Id = id;
            this.Nombre = string.Empty;
            this.Tiempo = 0;
            this.Departamento = new RHH.TDepartamento();
        }



    }
}
