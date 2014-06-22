namespace Empresa.USeguridad
{
    using System.Text;
    using System.ComponentModel;
    using System.Collections.Generic; 
    public class TUsuario: Empresa.Comun.Validacion.ReglaContenido {

        public int Id { get; set; }
        public Empresa.Comun.tbasepersona Personal { get; set; }
        private string _Nombre;
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
        public List<TGrupo> Grupos { get; set; }
        public string PClave { get; set; }

        private string _clave;
        public string Clave  {
            get {
                return _clave;
            }
            set {
                _clave = value;

                if (!this.ValidContenido(_clave, System.Globalization.CultureInfo.InstalledUICulture).IsValid)
                {
                    this.AgregoError("Clave", "Error, Falta Clave de usuario");
                }
                else
                {
                    this.BorrarError("Clave");
                }
            }
        }
        public bool Habilitado { get; set; }
        
        private Miembro _Miembro;
        public Miembro Miembro
        {
            get  { 
                    return _Miembro;
            }
            set {
                _Miembro = value;
            }
        }

        public TUsuario(){
            this.Id = 0;
            this.Miembro = new Miembro();
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
            Miembro = new Miembro(id);
            this.Grupos = Miembro.Grupos; 
            //this.Miembro
         }

        public TUsuario(string nombre, string pclave, string clave, bool habilitado)
        {
            this.Nombre = nombre;
            this.PClave = pclave;
            this.Clave = clave;
            this.Habilitado = habilitado;
            this.Miembro = new Miembro();
            this.Grupos = Miembro.Grupos;
        }


        
    }
}
