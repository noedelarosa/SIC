using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.RHH
{
    public class TNotario: tpersonal {
        public  string Colegio { get; set; }
        public string Numero { get; set; }
  
        public TNotario() {
            this.Id = 0;
            this.Nombres = string.Empty;
            this.Apellidos = string.Empty;
            this.Cedula = string.Empty;
            this.EsCasado = false;
            this.FechaNacimiento = DateTime.Now;
            this.Profesion = string.Empty;
            this.EstadoLaboral = new testadolaboral();
            this.Contacto = new ContraPrestamos.tcontacto();
            this.Colegio = string.Empty;
            this.Numero = string.Empty;
        }

        public TNotario(int id) {
            this.Id = id;
            this.Nombres = string.Empty;
            this.Apellidos = string.Empty;
            this.Cedula = string.Empty;
            this.EsCasado = false;
            this.FechaNacimiento = DateTime.Now;
            this.Profesion = string.Empty ;
            this.EstadoLaboral = new testadolaboral();
            this.Contacto = new ContraPrestamos.tcontacto();
            this.Colegio = string.Empty;
            this.Numero = string.Empty;
        }

        public TNotario(int id, string nombres, string apellidos, string cedula, bool escasado, DateTime fechanacimiento, string profesion, testadolaboral estadolaboral, ContraPrestamos.tcontacto contacto, string colegio, string numero)
        {
            this.Id = id;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Cedula = cedula;
            this.EsCasado = escasado;
            this.FechaNacimiento = fechanacimiento;
            this.Profesion = profesion;
            this.EstadoLaboral = estadolaboral;
            this.Contacto = contacto;
            this.Colegio = colegio;
            this.Numero = numero;

        }
        public TNotario(string nombres, string apellidos, string cedula, bool escasado, DateTime fechanacimiento, string profesion, testadolaboral estadolaboral, ContraPrestamos.tcontacto contacto,string colegio, string numero)
        {
            this.Id = 0;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Cedula = cedula;
            this.EsCasado = escasado;
            this.FechaNacimiento = fechanacimiento;
            this.Profesion = profesion;
            this.EstadoLaboral = estadolaboral;
            this.Contacto = contacto;
            this.Colegio = colegio;
            this.Numero = numero;
        }


    }
}

