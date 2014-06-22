using System.Text;

namespace Empresa.USeguridad
{
    public class TRecurso
    {
        public int Id { get; set; }
        public string Nombre { get;set; }
        public string Codigo { get; set; }
        public string Modulo { get; set; }
        public string CModulo { get; set; }


        public TRecurso(){
            this.Id = 0;
            this.Nombre = string.Empty;
            this.Codigo = string.Empty;
            this.Modulo = string.Empty;
            this.CModulo = string.Empty;
        }

        public TRecurso(int id, string nombre){
            this.Id = id;
            this.Nombre = nombre;
            
        }
        public TRecurso(int id){
            this.Id = id;
        }
        public TRecurso(int id, string nombre,string codigo){
            this.Id = id;
            this.Nombre = nombre;
            this.Codigo = codigo;
            
        }
        public TRecurso(int id, string nombre, string codigo,string modulo, string cmodulo){
            this.Id = id;
            this.Nombre = nombre;
            this.Codigo = codigo;
            this.Modulo = modulo;
            this.CModulo = cmodulo;
            
        }
        public TRecurso(string nombre, string codigo, string modulo, string cmodulo){
            this.Nombre = nombre;
            this.Codigo = codigo;
            this.Modulo = modulo;
            this.CModulo = cmodulo;
        }

        public TRecurso(string nombre, string codigo){
            this.Nombre = nombre;
            this.Codigo = codigo;
        }

    }
}
