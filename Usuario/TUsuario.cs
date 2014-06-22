namespace Empresa.Usuarios
{
    using System.Text;
    using System.ComponentModel;
    using System.Collections.Generic; 
    public class TUsuario: Empresa.Comun.Validacion.ReglaContenido {
        public int Id { get; set; }
        public Empresa.RHH.tpersonal Personal { get; set; }
        private string _Nombre;

        public bool EsTemporal { get; set; }

        public string Nombre{
            get{ 
                return _Nombre; 
            }
            set{
                _Nombre = value;
                if(!this.ValidContenido(_Nombre, System.Globalization.CultureInfo.InstalledUICulture).IsValid){
                    this.AgregoError("Nombre", "Error, Falta Nombre de usuario");
                }
                else {   
                    this.BorrarError("Nombre");
                }
            }
         }
        public List<USeguridad.TGrupo> Grupos { get; set; }
        public string PClave { get; set; }

        private string _clave;
        public string Clave  {
            get {
                return _clave;
            }
            set {
                _clave = value;

                if (!this.ValidContenido(_clave, System.Globalization.CultureInfo.InstalledUICulture).IsValid){
                    this.AgregoError("Clave", "Error, Falta Clave de usuario");
                }
                else{
                    this.BorrarError("Clave");
                }
            }
        }
        public bool Habilitado { get; set; }

        private USeguridad.Miembro _Miembro;
        public USeguridad.Miembro Miembro
        {
            get {
                    return _Miembro;
            }
            set {
                _Miembro = value;
            }
        }

        

        public TUsuario()
        {
            this.Id = 0;
            this.Miembro = new USeguridad.Miembro();
            this.Grupos = Miembro.Grupos;
            this.Nombre = string.Empty;
            this.PClave = string.Empty;
            this.Clave = string.Empty;
            this.Habilitado = true;

        }

        public TUsuario(int id)
        {
            this.Id = id;
            this.Miembro = new USeguridad.Miembro();
            this.Grupos = Miembro.Grupos;
            this.Nombre = string.Empty;
            this.PClave = string.Empty;
            this.Clave = string.Empty;
            this.Habilitado = true;

        }

        public TUsuario(int id, string nombre,string pclave, string clave,bool habilitado){
            this.Id = id;         
            this.Nombre = nombre;
            this.PClave = pclave;
            this.Clave = clave;
            this.Habilitado = habilitado;
            Miembro = new USeguridad.Miembro(id);
            this.Grupos = Miembro.Grupos; 
            //this.Miembro
         }

        public TUsuario(string nombre, string pclave, string clave, bool habilitado){
            this.Nombre = nombre;
            this.PClave = pclave;
            this.Clave = clave;
            this.Habilitado = habilitado;
            this.Miembro = new USeguridad.Miembro();
            this.Grupos = Miembro.Grupos;
        }

        public TUsuario(string nombre, string pclave, string clave, bool habilitado, bool estemporal){
            this.Nombre = nombre;
            this.PClave = pclave;
            this.Clave = clave;
            this.Habilitado = habilitado;
            this.Miembro = new USeguridad.Miembro();
            this.Grupos = Miembro.Grupos;
            this.EsTemporal = estemporal;
        }


        
    }
}
