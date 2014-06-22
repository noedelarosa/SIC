namespace Empresa.USeguridad
{

    using System;
    using System.Collections.Generic;
    public class TGrupo: Empresa.Comun.Validacion.ReglaContenido
    {
        public int Id { get; set; }
        string _Nombre;
        public string Nombre {
            get { return _Nombre; }
            set {
                if (!ValidContenido(value, System.Globalization.CultureInfo.InstalledUICulture).IsValid)
                {
                    AgregoError("Nombre", "Falta Nombre");
                }
                else
                {
                    BorrarError("Nombre");
                    _Nombre = value;
                }
            }
        }
        public bool Habilitado { get;set; }
        
        private Roles _Roles;
        public string Descripcion { get; set; }
        
        //public List<TRoles> Role{
        //    get{
        //        return _Roles.ToList();
        //    }
        //    set{
        //        _Roles[0].Roles = value[0].Roles;
        //        _Roles[0].IDGrupo = value[0].Id;
        //    }
        //}

        public Roles Role{
            get {
                if (_Roles == null) _Roles = new Roles(this);
                _Roles.Grupo = this;
                return _Roles;
            }
            set{
                _Roles = value;
            }
        }

   
        public TGrupo() {
            Id = 0;
            Nombre = string.Empty;
            Habilitado = false;
            _Roles = new Roles();
            this.Descripcion = string.Empty;
        }

        public TGrupo(int id, string nombre, bool habilitado) {
            
            this.Id = id;
            this.Nombre = nombre;
            this.Habilitado = habilitado;
            this.Descripcion = string.Empty;
            //_Roles = new Roles(this.Id);
        }
        public TGrupo(string nombre, bool habilitado){ 
            this.Nombre = nombre;
            this.Habilitado = habilitado;
            this.Descripcion = string.Empty;
        }
        public TGrupo(string nombre, bool habilitado, Roles role)
        {
            this.Nombre = nombre;
            this.Habilitado = habilitado;
            this.Role = role;
            this.Descripcion = string.Empty;
        }

        public TGrupo(Roles role) {
            role.Grupo = this;
            this.Role = role;
            this.Descripcion = string.Empty;
        }
    }
}
