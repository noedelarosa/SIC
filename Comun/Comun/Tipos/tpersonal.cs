using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.RHH
{
    public class tpersonal: Comun.tbasepersona {

        public Empresa.Comun.tcontacto Contacto { get; set; }
        public Empresa.Comun.TDireccion Direccion { get; set; }

        public Empresa.Docente.testadolaboral EstadoLaboral { get; set; }
        public object Foto { get; set; }
        public bool EsSantoDomingo { get; set; }
        public string CedulaF {
            get {
                return !string.IsNullOrEmpty(this.Cedula) ? this.Cedula.Insert(3, "-").Insert(11, "-") : string.Empty;
            }
        }
        
        public string nombrecompleto;
        public string NombreCompleto {
            get {  
                if( this.Nombres != null && this.Apellidos !=null  ){
                    return  this.Nombres.Trim() + " " + this.Apellidos.Trim(); 
                } else {
                    return string.Empty;
                }
            }
            private set{
                //this.Apellidos;
                if(!(this.ValidContenido(this.Nombres).IsValid && this.ValidContenido(this.Apellidos).IsValid)){
                    this.AgregoError("NombreCompleto", "Falta Nombre");
                }
                else{
                    this.BorrarError("NombreCompleto");
                }
            }
        }

        public tpersonal(){
            this.Id = 0;
            this.Nombres = string.Empty;
            this.Apellidos = string.Empty;
            this.Cedula = string.Empty;
            this.EsCasado = false;
            this.FechaNacimiento = DateTime.Now;
            this.Profesion = string.Empty;
            this.EstadoLaboral = new Empresa.Docente.testadolaboral();
            this.Contacto = new Empresa.Comun.tcontacto();
            this.EsSantoDomingo = true;

            this.Direccion = new Comun.TDireccion();
            this.Contacto = new Comun.tcontacto();
        }

        public tpersonal(int id) {
            this.Id = id;
            this.Nombres = string.Empty;
            this.Apellidos = string.Empty;
            this.Cedula = string.Empty;
            this.EsCasado = false;
            this.FechaNacimiento = DateTime.Now;
            this.Profesion = string.Empty ;
            this.EstadoLaboral = new Empresa.Docente.testadolaboral();
            this.Contacto = new Empresa.Comun.tcontacto();
        }

        public tpersonal(int id, string nombres, string apellidos, string cedula, bool escasado, DateTime fechanacimiento, string profesion, Empresa.Docente.testadolaboral estadolaboral, Empresa.Comun.tcontacto contacto, bool essantodomingo)
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
            this.EsSantoDomingo = essantodomingo;
        }
        public tpersonal(string nombres, string apellidos, string cedula, bool escasado, DateTime fechanacimiento, string profesion, Empresa.Docente.testadolaboral estadolaboral, Empresa.Comun.tcontacto contacto, bool essantodomingo)
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
            this.EsSantoDomingo = essantodomingo;
        }
        

        public Empresa.Docente.TSolicitante A_Solicitante(){
            Docente.TSolicitante sol = new Docente.TSolicitante();

            sol.Id = this.Id;
            sol.Nombres = this.Nombres;
            sol.Cedula = this.Cedula;
            sol.Nss = this.Nss;
            sol.EstadoLaboral = this.EstadoLaboral;
            sol.EsMasculino = this.EsMasculino;
            sol.EsFallecido = this.EsFallecido;
            sol.FechaNacimiento = this.FechaNacimiento;
            sol.EsDiscapacitado = this.EsDiscapacitado;
            sol.EsCasado = this.EsCasado;
            sol.Contacto = this.Contacto;
            sol.Direccion = this.Direccion;
            sol.Apellidos = this.Apellidos;

            sol.Tipo = new Comun.TEstandar();
            sol.Otros = string.Empty;

            return sol;
        }



        public static implicit operator tpersonal(Empresa.Comun.tpersona arg){
        tpersonal pertemp = new tpersonal();
        pertemp.Apellidos = arg.Apellidos;
        pertemp.Cedula = arg.Cedula;
        pertemp.Contacto = arg.Contacto;
        pertemp.Direccion = arg.Direccion;
        pertemp.EsCasado = arg.EsCasado;
        pertemp.EsDiscapacitado = arg.EsDiscapacitado;
        pertemp.EsFallecido = arg.EsFallecido;
        pertemp.EsMasculino = arg.EsMasculino;
        pertemp.FechaNacimiento = arg.FechaNacimiento;
        pertemp.Id = arg.Id;
        pertemp.Nombres = arg.Nombres;
        pertemp.Nss = arg.Nss;
        pertemp.Profesion = arg.Profesion;
        return pertemp;
        }

        public Empresa.Docente.TSolicitante A_Solicitante(Empresa.Comun.TEstandar tipo, string otro)
        {
            Docente.TSolicitante sol = new Docente.TSolicitante();

            sol.Id = this.Id;
            sol.Nombres = this.Nombres;
            sol.Apellidos = this.Apellidos;
            sol.Cedula = this.Cedula;
            sol.Nss = this.Nss;
            sol.EstadoLaboral = this.EstadoLaboral;
            sol.EsMasculino = this.EsMasculino;
            sol.EsFallecido = this.EsFallecido;
            sol.FechaNacimiento = this.FechaNacimiento;
            sol.EsDiscapacitado = this.EsDiscapacitado;
            sol.EsCasado = this.EsCasado;
            sol.Contacto = this.Contacto;
            sol.Direccion = this.Direccion;
            sol.Tipo = tipo;
            sol.Otros = otro;

            return sol;
        }

    }
}

