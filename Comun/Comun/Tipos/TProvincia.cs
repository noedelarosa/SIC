namespace Empresa
{
    namespace Comun
    {
       using System;
       public class TProvincia
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Codigo { get; set; }
           
           public TProvincia() {
                this.Id = 0;
                this.Nombre = string.Empty;
                this.Codigo = string.Empty;
            }

            public TProvincia(int id) { 
                this.Id = id;
                this.Nombre = string.Empty;
                this.Codigo = string.Empty;
            }

            public TProvincia(string codigo) { 
                this.Id = 0;
                this.Nombre = string.Empty;
                this.Codigo = codigo;
            }

            public TProvincia(int id, string nombre, string codigo) {
                this.Id = id; 
                this.Nombre = nombre; 
                this.Codigo = codigo; 
            }
        }
    }
}