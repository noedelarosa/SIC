using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class tlistadopensionadosenbeneficio
    {
        public int Id                                     {get;set;}
        public ObservableCollection<tdocente> Docente     {get;set;}
        public DateTime FechaCorte                        {get;set;}
        public string Descripcion                         {get;set;}
        public DateTime Fecha                             {get;set;}

        public tlistadopensionadosenbeneficio() {
            this.Id = 0;
            this.Docente = new ObservableCollection<tdocente>();
            this.Fecha = DateTime.Now;
            this.FechaCorte = DateTime.Now;
            this.Descripcion = string.Empty;
        } 
    }
}
