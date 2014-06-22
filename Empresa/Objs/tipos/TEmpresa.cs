namespace Empresa{
    using System;
    public class TEmpresa
    {
       public int Id { get; set; }
       public string Nombre { get; set; }
       public string Rnc { get; set; }
       public string Telefono { get; set; }
       public string Telefono1 { get; set; }
       public string Fax { get; set; }
       public string Web { get; set; }
       public string Email { get; set; }
       public string Email1 { get; set; }
       public Comun.TDireccion Direccion { get; set; }
       public object Logo { get; set; }
       public string Descripcion { get; set; }
       public Empresa.RHH.tpersonal Director { get; set; } 

        public TEmpresa() {
            this.Id = 0;
            
            this.Nombre = string.Empty;
            this.Rnc = string.Empty;
            this.Telefono = string.Empty;
            this.Telefono1 = string.Empty;
            this.Fax = string.Empty;
            this.Web = string.Empty;
            this.Email1 = string.Empty;
            this.Email = string.Empty;
            this.Direccion = new Comun.TDireccion();
            this.Logo = new object();
            this.Descripcion = string.Empty;
            this.Director = new RHH.tpersonal();
        }
        public TEmpresa(int id) { 
            this.Id = id;

            this.Nombre = string.Empty;
            this.Rnc = string.Empty;
            this.Telefono = string.Empty;
            this.Telefono1 = string.Empty;
            this.Fax = string.Empty;
            this.Web = string.Empty;
            this.Email1 = string.Empty;
            this.Email = string.Empty;
            this.Direccion = new Comun.TDireccion() ;
            this.Logo = new object();
            this.Descripcion = string.Empty;
            this.Director = new RHH.tpersonal();
        
        }
        public TEmpresa(string nombre, string rnc,string telefono,string telefono1,string fax, string web, string email, string email1, Comun.TDireccion direccion, object logo,string descripcion) {
            this.Nombre = nombre;
            this.Rnc = rnc;
            this.Telefono = telefono;
            this.Telefono1 = telefono1;
            this.Fax = fax;
            this.Web = web;
            this.Email1 = email1;
            this.Email = email;
            this.Direccion = direccion;
            this.Logo = logo;
            this.Descripcion = descripcion;
            this.Director = new RHH.tpersonal();
        }
        public TEmpresa(int id,string nombre, string rnc, string telefono, string telefono1, string fax, string web, string email, string email1, Comun.TDireccion direccion, object logo, string descripcion) {
            this.Id = id;
            this.Nombre = nombre;
            this.Rnc = rnc;
            this.Telefono = telefono;
            this.Telefono1 = telefono1;
            this.Fax = fax;
            this.Web = web;
            this.Email1 = email1;
            this.Email = email;
            this.Direccion = direccion;
            this.Logo = logo;
            this.Descripcion = descripcion;
            this.Director = new RHH.tpersonal();
        }

        public TEmpresa(int id, string nombre, string rnc, string telefono, string telefono1, string fax, string web, string email, string email1, Comun.TDireccion direccion, object logo, string descripcion, Empresa.RHH.tpersonal director)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Rnc = rnc;
            this.Telefono = telefono;
            this.Telefono1 = telefono1;
            this.Fax = fax;
            this.Web = web;
            this.Email1 = email1;
            this.Email = email;
            this.Direccion = direccion;
            this.Logo = logo;
            this.Descripcion = descripcion;
            this.Director = director;
        }



    }

}
