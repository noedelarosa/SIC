using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class TFamiliares: Empresa.Comun.tbasepersona {
        
        private Empresa.Comun.TParentesco _Parentesco;
        public Empresa.Comun.TParentesco Parentesco {
            get {
                return _Parentesco;
            }
            set {
                _Parentesco = value;

                if(_Parentesco == null){
                    this.AgregoError("Parentesco", "Falta Parentesco");
                }
                else {
                    if (_Parentesco.Id.Equals(0)){
                        this.AgregoError("Parentesco", "Falta Parentesco");
                    }
                    else { 
                    //Valido 
                        this.BorrarError("Parentesco");
                    }
                }
            }
        }
        public Empresa.Comun.TEstandar Tipo { get; set; }
        public string TipoCalculo { get; set; }

        public bool EsBeneficiario { get; set; }
        public double MontoPension { get; set; }
        public Double Scala { get; set; }
        
        public TDecreto Decreto {get; set;}
        public Empresa.Comun.TSuplidor Aseguradora { get; set; }

        public Empresa.RHH.tpersona Tutor { get; set; }
        public Empresa.Docente.tdocente Docente { get; set; }
        public bool PresenteDocumentos { get; set; }
        
        public bool HijosPosee {get; set;}
        public Empresa.Comun.TEstandar EstadoBeneficio {get;set;}

        private bool Regla_EstadoBeneficio(){
            bool resul=false;
            DateTime trfecha = Empresa.Comun.Server.DameTiempo();
            
            //Regla 1. Si Esta Excluido, no es Beneficiario.
            if(this.EstadoBeneficio.Id.Equals(2)) return true;
            
            //Regla 2. Casado, Posee Hijos Excluido Si.
            if(this.EsCasado == true || this.HijosPosee == true) resul = true;

            if(Parentesco.Id.Equals(2) || Parentesco.Id.Equals(3) || Parentesco.Id.Equals(4)){
                //Padre, Madre, Esposo.

                    if (this.FechaFinalPJ == DateTime.MinValue || this.FechaFinalPJ == DateTime.MaxValue){
                        return false;
                    }
                    else {

                         if(this.FechaFinalPJ.Year == trfecha.Year){
                           if(this.FechaFinalPJ.Month <= trfecha.Month){
                                resul = true;
                            }
                            else{
                                //resul = false;
                            }
                        }
                        else if (this.FechaFinalPJ.Year < trfecha.Year){
                            resul = true;
                        }
                        else{
                            //resul = false;
                        }

                    }

             }else{
                    
                    if (this.FechaFinalPJ.Year == trfecha.Year){
                        if (this.FechaFinalPJ.Month <= trfecha.Month){
                            resul = true;
                        }
                        else{
                            //resul = false;
                        }
                    }
                    else if (this.FechaFinalPJ.Year < trfecha.Year){
                        resul = true;
                    }
                    else{
                        //resul = false;
                    }
                    
                    if (this.EsMayor == true && this.PresenteDocumentos == false){
                        resul = true;
                    }
                
                }
                
            return resul;
        }
        
        public bool CompruebEstadoBeneficio {
            get {
                return this.Regla_EstadoBeneficio();
            }
        }

        private string _nombrecompleto;
        public string NombreCompleto
        {
            get{
                return _nombrecompleto;
            }
            set{
                if (!this.ValidContenido(value).IsValid){
                    this.AgregoError("NombreCompleto", "Falta Nombre");
                }
                else{
                    this.BorrarError("NombreCompleto");
                    _nombrecompleto = value;
                }
            }
        }
        
        public DateTime FechaInicioPJ {get; set;}
        public DateTime FechaFinalPJ {get; set;}
        public DateTime FechaFinalRetroActivo {get; set;}
        
        public Empresa.Comun.StFechasPartes EdadFallecimientoDocentePartida {get; set;}
        public int EdadFallecimientoDocente {get; set;}

        public string EdadFallecimientoDocentePartida_FormatoA{
            get{
                Empresa.Comun.ConvertDataToAnoMes conver = new Comun.ConvertDataToAnoMes();
                return (string)conver.Convert(this.EdadFallecimientoDocentePartida, this.GetType(), null, System.Globalization.CultureInfo.CurrentCulture);
            }
        }

        public Empresa.Comun.StFechasPartes EdadPartida{get;set;}
        public string EdadPartida_FormatoA {
            get{
                Empresa.Comun.ConvertDataToAnoMes conver = new Comun.ConvertDataToAnoMes();
                return (string)conver.Convert(this.EdadPartida, this.GetType(), null, System.Globalization.CultureInfo.CurrentCulture);
            }
        }

        private DateTime _FechaNacimiento;
        public DateTime FechaNacimiento {

            get {
                return _FechaNacimiento;
            }
            
            set {
                _FechaNacimiento = value;
                if (_FechaNacimiento == null){
                    this.AgregoError("FechaNacimiento", "Falta Fecha de Nacimiento");
                }
                else{

                    if (_FechaNacimiento == DateTime.MinValue){
                        this.AgregoError("FechaNacimiento", "Falta Fecha de Nacimiento");
                    }
                    else{
                        this.BorrarError("FechaNacimiento");
                    }

                }
            }
        
        }
        
        public bool EsMayor{
            get{
                return this.Edad >= 18;
            }
        }

        public int TiempoPensionAnos  { get; set; }
        public int TiempoPensionMeses { get; set; }

        public string TiempoEnPension {
            get{
                if (FechaFinalPJ.Equals(DateTime.MaxValue)){
                    return "n/d";
                }
                else {
                    return this.TiempoPensionAnos.ToString() + " Años y " + this.TiempoPensionMeses.ToString() + " Mes(es)";
                }
            }
        }

        public TFamiliares(){
            this.Id = 0;
            this.Tipo = new Comun.TEstandar(3);
            this.Nombres = string.Empty;
            this.FechaNacimiento = DateTime.MinValue;
            this.Cedula = string.Empty;
            this.Apellidos = string.Empty;
            this.EsDiscapacitado = false;
            this.Parentesco = new Comun.TParentesco();
            this.EsBeneficiario = false;
            this.MontoPension = 0;
            this.Tutor = new RHH.tpersona();
            this.PresenteDocumentos = false;
        }

        public void CalculoInterno() {
           Empresa.Comun.StFechasPartes ftrabjo =  Empresa.Comun.Servicios.FechasDifencia(this.FechaNacimiento, Empresa.Comun.Server.DameTiempo());
           this.EdadPartida = ftrabjo;
           this.Edad = ftrabjo.Anos;
        }

        public TFamiliares(int id, string nombres, string apellidos, DateTime fechanacimiento, string cedula, bool esdiscapacitado, Empresa.Comun.TParentesco parentesco, bool esbeneficiario){
            this.Id = id;
            this.Nombres = nombres;
            this.FechaNacimiento = fechanacimiento;
            this.Cedula = cedula;
            this.Apellidos = apellidos;
            this.EsDiscapacitado = esdiscapacitado;
            this.Parentesco = parentesco;
            this.MontoPension = 0;
            this.EsBeneficiario =  esbeneficiario;
            this.Tutor = new RHH.tpersona();
            this.Docente = new tdocente();
            this.PresenteDocumentos = false;
            this.Tipo = new Comun.TEstandar(3);

            this.NombreCompleto = this.Nombres + " " + this.Apellidos == null ? string.Empty : this.Apellidos;
        }

        public TFamiliares(string nombres, string apellidos, DateTime fechanacimiento, string cedula, bool esdiscapacitado, Empresa.Comun.TParentesco parentesco, bool esbeneficiario){
            this.Id = 0;
            this.Nombres = nombres;
            this.FechaNacimiento = fechanacimiento;
            //this.Edad = EstablerEdadActual(this.FechaNacimiento);
            this.Cedula = cedula;
            this.Apellidos = apellidos;
            this.EsDiscapacitado = esdiscapacitado;
            this.Parentesco = parentesco;
            this.EsBeneficiario = esbeneficiario;
            this.MontoPension = 0;
            this.Tutor = new RHH.tpersona();
            this.PresenteDocumentos = false;
            this.Tipo = new Comun.TEstandar(3);
            this.NombreCompleto = this.Nombres + " " + this.Apellidos == null ? string.Empty : this.Apellidos;
        }

        public TFamiliares(string nombres, string apellidos, DateTime fechanacimiento, string cedula, bool esdiscapacitado, Empresa.Comun.TParentesco parentesco, bool esbeneficiario, bool esmasculino){
            this.Id = 0;
            this.Nombres = nombres;
            this.FechaNacimiento = fechanacimiento;
            //this.Edad = EstablerEdadActual(this.FechaNacimiento);
            this.Cedula = cedula;
            this.EsDiscapacitado = esdiscapacitado;
            this.Parentesco = parentesco;
            this.EsBeneficiario = esbeneficiario;
            this.EsMasculino = esmasculino;
            this.MontoPension = 0;
            this.Apellidos = nombres;
            this.Tutor = new RHH.tpersona();
            this.PresenteDocumentos = false;
            this.Tipo = new Comun.TEstandar(3);
            this.NombreCompleto = this.Nombres + " " + this.Apellidos == null ? string.Empty : this.Apellidos;
        }

        public static implicit operator TFamiliares(Empresa.RHH.tpersonal arg){
            TFamiliares argstemp = new TFamiliares();

            argstemp.Id = arg.Id;
            argstemp.Nombres = arg.Nombres;
            argstemp.Apellidos = arg.Apellidos;
            argstemp.Cedula = arg.Cedula;
            argstemp.FechaNacimiento = arg.FechaNacimiento;
            argstemp.Edad = arg.Edad;
            argstemp.EsMasculino = arg.EsMasculino;
            argstemp.EsCasado = argstemp.EsCasado;
            argstemp.EsFallecido = argstemp.EsFallecido;
            argstemp.Nss = arg.Nss;
            argstemp.Profesion = argstemp.Profesion;
            argstemp.EsDiscapacitado = arg.EsDiscapacitado;
            argstemp.Tipo = new Comun.TEstandar(3);
            

            return argstemp;
        }

    }
}
