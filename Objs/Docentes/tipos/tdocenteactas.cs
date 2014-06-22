using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class tdocenteactas: tdocente {
        public Empresa.Comun.TProvincia Provincia { get; set; }
        public tdocenteactas(){
            this.Id = 0;
            this.Nombres = string.Empty;
            this.Apellidos = string.Empty;
            this.Cedula = string.Empty;
            this.EsCasado = false;
            this.FechaNacimiento = DateTime.Now;
            this.Profesion = string.Empty;
            this.EsMasculino = true;
            this.NombreCompleto = string.Empty;
            this.Decretos = new System.Collections.ObjectModel.ObservableCollection<TDecretoDocente>();
            //this.DecretoActual = new TDecretoDocente();
            this.Nss = string.Empty;
            this.SueldoBrutoActual = 0;
            this.FechaFallecido = DateTime.MinValue;
            this.FechaIngresoEducacion = DateTime.MinValue;
            this.Provincia = new Comun.TProvincia();
        }
    }
}
