using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.RHH
{
    public class TDepartamento{
       public int Id { get; set; }
       public string Nombre { get; set; }
       public string Descripcion { get; set; }
       public string Abreviatura { get; set; }
       public string Email { get; set; }
       public TDepartamento(int id, string nombre, string descripcion, string email) { this.Id = id; this.Nombre = nombre; this.Descripcion = descripcion; Email = email; }
       public TDepartamento(string nombre, string descripcion) { this.Nombre = nombre; this.Descripcion = descripcion; }

       public TDepartamento(){
           this.Id = -1;
           this.Nombre = string.Empty;
           this.Descripcion = string.Empty;
       }

    }
}
