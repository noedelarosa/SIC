using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Empresa.RHH
{
    public class tpersonal: Empresa.Comun.tbasepersona {

        public Empresa.Comun.tcontacto Contacto { get; set; }
        public Empresa.Comun.TDireccion Direccion { get; set; }
        public Empresa.Comun.TDireccionAsignada DireccionAsignada { get; set; }

        public Empresa.RHH.TDepartamento Departamento { get; set; }
        public Empresa.RHH.testadolaboral EstadoLaboral { get; set; }
        
        public byte[] Foto { get; set; }
        BitmapSource _AImagen;
        public BitmapSource AImagen{
            get{
                _AImagen = WorkImage.ToImage(Foto, TypeImagen.JPG);
                return _AImagen;
            }
            //set { Foto = WorkImage.GetArray(_AImagen); }
        }

        public bool EsSantoDomingo { get; set; }
        public string CedulaF 
        {
            get {
                if(!string.IsNullOrEmpty(this.Cedula)){
                    if (this.Cedula.Length < 11){
                        return this.Cedula;
                    }
                    else{
                        if (this.Cedula.Length == 0)
                        {
                            return this.Cedula;
                        }
                        else
                        {
                            return !string.IsNullOrEmpty(this.Cedula) ? this.Cedula.Insert(3, "-").Insert(11, "-") : string.Empty;
                        }
                    }
                }
                else {
                    return this.Cedula;
                }
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
            this.EstadoLaboral = new Empresa.RHH.testadolaboral();
            this.Contacto = new Empresa.Comun.tcontacto();
            this.EsSantoDomingo = true;
            this.DireccionAsignada = new Comun.TDireccionAsignada();
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
            this.DireccionAsignada = new Comun.TDireccionAsignada();
            this.EstadoLaboral = new Empresa.RHH.testadolaboral();
            this.Contacto = new Empresa.Comun.tcontacto();
        }

        public tpersonal(string cedula)
        {
            this.Id = 0;
            this.Nombres = string.Empty;
            this.Apellidos = string.Empty;
            this.Cedula = cedula;
            this.EsCasado = false;
            this.FechaNacimiento = DateTime.Now;
            this.Profesion = string.Empty;
            this.EstadoLaboral = new Empresa.RHH.testadolaboral();
            this.Contacto = new Empresa.Comun.tcontacto();
            this.DireccionAsignada = new Comun.TDireccionAsignada();
        }

        public tpersonal(int id, string nombres, string apellidos, string cedula, bool escasado, DateTime fechanacimiento, string profesion, Empresa.RHH.testadolaboral estadolaboral, Empresa.Comun.tcontacto contacto, bool essantodomingo)
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
            this.DireccionAsignada = new Comun.TDireccionAsignada();
        }
        public tpersonal(string nombres, string apellidos, string cedula, bool escasado, DateTime fechanacimiento, string profesion, Empresa.RHH.testadolaboral estadolaboral, Empresa.Comun.tcontacto contacto, bool essantodomingo)
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
        

        //public Empresa.Docente.TSolicitante A_Solicitante(){
        //    Docente.TSolicitante sol = new Docente.TSolicitante();
        //    sol.Id = this.Id;
        //    sol.Nombres = this.Nombres;
        //    sol.Cedula = this.Cedula;
        //    sol.Nss = this.Nss;
        //    sol.EstadoLaboral = this.EstadoLaboral;
        //    sol.EsMasculino = this.EsMasculino;
        //    sol.EsFallecido = this.EsFallecido;
        //    sol.FechaNacimiento = this.FechaNacimiento;
        //    sol.EsDiscapacitado = this.EsDiscapacitado;
        //    sol.EsCasado = this.EsCasado;
        //    sol.Contacto = this.Contacto;
        //    sol.Direccion = this.Direccion;
        //    sol.Apellidos = this.Apellidos;
        //    sol.Tipo = new Comun.TEstandar();
        //    sol.Otros = string.Empty;
        //    return sol;
        //}



        public static implicit operator tpersonal(Empresa.RHH.tpersona arg){
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

        //public Empresa.Docente.TSolicitante A_Solicitante(Empresa.Comun.TEstandar tipo, string otro){
        //    Docente.TSolicitante sol = new Docente.TSolicitante();
        //    sol.Id = this.Id;
        //    sol.Nombres = this.Nombres;
        //    sol.Apellidos = this.Apellidos;
        //    sol.Cedula = this.Cedula;
        //    sol.Nss = this.Nss;
        //    sol.EstadoLaboral = this.EstadoLaboral;
        //    sol.EsMasculino = this.EsMasculino;
        //    sol.EsFallecido = this.EsFallecido;
        //    sol.FechaNacimiento = this.FechaNacimiento;
        //    sol.EsDiscapacitado = this.EsDiscapacitado;
        //    sol.EsCasado = this.EsCasado;
        //    sol.Contacto = this.Contacto;
        //    sol.Direccion = this.Direccion;
        //    sol.Tipo = tipo;
        //    sol.Otros = otro;
        //    return sol;
        //}

    }
}

