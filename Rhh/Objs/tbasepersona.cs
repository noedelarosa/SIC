    using System;
namespace Empresa.Comun
{
    public class tbasepersona :Validacion.ReglaContenido {

        public int Id { get; set; }
        public string Nss { get; set; }
        public bool EsFallecido { get; set; }
        public bool EsDiscapacitado {get;set;}

        string _Nombres;
        public string Nombres {
            get{
                return _Nombres;
            }
           set{
              
               if (!this.ValidContenido(value).IsValid){
                   this.AgregoError("Nombres", "Falta Nombres");
               }
               else{
                   this.BorrarError("Nombres");
                   _Nombres = value;
               }

            }
        }

        private string _apellidos;
        public string Apellidos{
            get {
                return _apellidos; 
            }
              set{
               if (!this.ValidContenido(value).IsValid){
                   this.AgregoError("Apellidos", "Falta Apellidos");
               }
               else{
                   this.BorrarError("Apellidos");
                   _apellidos = value;
               }

            }
        }

        private string _cedula;
        public string Cedula { 
            get{
                return _cedula;
            }
            set{

                if (!this.ValidContenido(value).IsValid)
                {
                    this.AgregoError("Cedula", "Falta Cedula");
                }
                else
                {
                    this.BorrarError("Cedula");
                    _cedula = value;
                }
            
            }
        }

        public bool EsMasculino { get; set; }

        public string EsMasculinof{
            get{
                //no existe la cedula, no imprimi sexo.
                if (!string.IsNullOrEmpty(this.Cedula)){
                    if (this.EsMasculino) return "Masculino";
                    return "Femenino";
                }
                else {
                    return string.Empty;
                }
            }
        }

        public int Edad { 
            get;
            private set;
        }
        public DateTime FechaNacimiento { get; set; }
        public bool EsCasado    {get; set;}
        public object Etiqueta  {get; set;}
        public string Profesion {get; set;}

        public tbasepersona(){
            this.Id = 0;
            
            this.Nombres = string.Empty;
            this.Apellidos = string.Empty;
            this.Cedula = string.Empty;
            this.Edad = 0;
            this.EsCasado = true;
            this.Etiqueta = new object();
            this.EsMasculino = true;
            this.FechaNacimiento = DateTime.Now;
            this.Nss = string.Empty;
            this.EsFallecido = false;
            this.EsDiscapacitado = false;
        }
        public tbasepersona(int id){
            this.Id = id;

            this.Nombres = string.Empty;
            this.Apellidos = string.Empty;
            this.Cedula = string.Empty;
            this.Edad = 0;
            this.EsCasado = true;
            this.Etiqueta = new object();
            this.FechaNacimiento = DateTime.Now;
            this.Nss = string.Empty;
            this.EsFallecido = false;
        }

        public tbasepersona(int id, string nombre, string apellidos, string cedula, int edad, bool escadado, bool esmasculino){
            this.Id = id;

            this.Nombres = nombre;
            this.Apellidos = apellidos;
            this.Cedula = cedula;
            this.Edad = edad;
            this.EsCasado = escadado;
            this.EsMasculino = true;
            this.Etiqueta = new object();
            this.EsFallecido = false;
        }


        public tbasepersona(int id, string nombres, string apellidos, string cedula, DateTime fechanacimiento, bool escadado, bool esmasculino, bool esdiscapacitado){
            this.Id = id;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Cedula = cedula;
            this.EsCasado = escadado;
            this.EsMasculino = true;
            this.Etiqueta = new object();
            this.EsFallecido = false;
            this.EsDiscapacitado = esdiscapacitado;
        }

        public tbasepersona(int id, string nombre, string apellidos, string cedula, int edad, bool escadado, object etiqueda, bool esmasculino){
            this.Id = id;
            
            this.Nombres = nombre;
            this.Apellidos = apellidos;
            this.Cedula = cedula;
            this.Edad = edad;
            this.EsCasado = escadado;
            this.Etiqueta = etiqueda;
            this.EsMasculino = esmasculino;
            this.Nss = string.Empty;
            this.EsFallecido = false;
        }

        public tbasepersona(int id, string nombre, string apellidos, string cedula, int edad, bool escadado, object etiqueda, bool esmasculino,string nss){
            this.Id = id;
            this.Nombres = nombre;
            this.Apellidos = apellidos;
            this.Cedula = cedula;
            this.Edad = edad;
            this.EsCasado = escadado;
            this.Etiqueta = etiqueda;
            this.EsMasculino = esmasculino;
            this.Nss = nss;
            this.EsFallecido = false;
        }

        public tbasepersona(string nombre, string apellidos, string cedula, int edad, bool escadado,bool esmasculino,string nss){
            this.Id = 0;

            this.Nombres = nombre;
            this.Apellidos = apellidos;
            this.Cedula = cedula;
            this.Edad = edad;
            this.EsCasado = escadado;
            this.Etiqueta = new object();
            this.EsMasculino = esmasculino;
            this.Nss = string.Empty;
            this.EsFallecido = false;
        }
        public tbasepersona(string nombre, string apellidos, string cedula, int edad, bool escadado, object etiqueda,bool esmasculino,string nss)
        {
            this.Id = 0;

            this.Nombres = nombre;
            this.Apellidos = apellidos;
            this.Cedula = cedula;
            this.Edad = edad;
            this.EsCasado = escadado;
            this.Etiqueta = etiqueda;
            this.EsMasculino = esmasculino;
        }

        public tbasepersona(string nombre, string apellidos, string cedula, int edad, bool escadado, object etiqueda, bool esmasculino)
        {
            this.Id = 0;

            this.Nombres = nombre;
            this.Apellidos = apellidos;
            this.Cedula = cedula;
            this.Edad = edad;
            this.EsCasado = escadado;
            this.Etiqueta = etiqueda;
            this.EsMasculino = esmasculino;
            this.EsFallecido = false;
        }
    }

}