namespace Empresa
{
    namespace Comun
    {
        using System;
        public class TSuplidor
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Rnc { get; set; }
            public bool EsAutorizado { get; set; }
            
            public string Web { get; set; }
            public string Telefono { get; set; }
            public string Fax { get; set; }
            
            public TDireccion Direccion { get; set; }

            public TSuplidor()
            {
                this.Id = 0;
                this.Nombre = string.Empty;
                this.Rnc = string.Empty;
                this.EsAutorizado = false;
                this.Web = string.Empty;
                this.Fax = string.Empty;
                this.Telefono = string.Empty;
                this.Direccion = new TDireccion();
            }
            public TSuplidor(int id) { this.Id = id; }

            public TSuplidor(int id,string nombre,string rnc,bool esautorizado,string web,string fax,string telefono,TDireccion direccion) { 
                this.Id = id;
                this.Nombre = nombre;
                this.Rnc = rnc;
                this.EsAutorizado = esautorizado;
                this.Web = web;
                this.Fax = fax;
                this.Telefono = telefono;
                this.Direccion = direccion;
            }
            public TSuplidor(string nombre, string rnc, bool esautorizado, string web, string fax, string telefono,TDireccion direccion){
                this.Nombre = nombre;
                this.Rnc = rnc;
                this.EsAutorizado = esautorizado;
                this.Web = web;
                this.Fax = fax;
                this.Telefono = telefono;
                this.Direccion = direccion;
            }
            public TSuplidor(string nombre, string rnc,TDireccion direccion){
                this.Nombre = nombre;
                this.Rnc = rnc;
                this.Direccion = direccion;
            }


        }
    }
}