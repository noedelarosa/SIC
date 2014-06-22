using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class tdocentes: tdocente{

        public tdocentes() {
            this.Tipo = new Comun.TEstandar(1); // tipo inicial 1;
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
            this.DecretoActual = new TDecretoDocente();

            this.Nss = string.Empty;
            this.SueldoBrutoActual = 0;
            this.FechaFallecido = DateTime.MinValue;
            this.FechaIngresoEducacion = DateTime.MinValue;
            this.Familiares = new Familiares();
            this.EstadoLaboral = new RHH.testadolaboral();
            this.Contacto = new Empresa.Comun.tcontacto();
            this.Direccion = new Comun.TDireccion();
            this.PagosDetalle = new PagoDetalle();
            this.HistorialPagos = new Pagos();
        }

        public tdocentes(int id, string nombres, string apellidos, string nombrec, string cedula, bool escasado, bool esmasculino, DateTime fechanacimiento, string profesion, RHH.testadolaboral estadolaboral, Empresa.Comun.tcontacto contacto, string decreto, DateTime fechadecreto, byte[] foto, string estadopr, string nss, double sueldobaseactual, bool esfallecido, DateTime fechafallecido, DateTime fechaingresoeducacion, DateTime decretofechapago, Pagos historicopagos)
        {
            //this.Tipo = new Comun.TEstandar(1); // tipo inicial 1;
            this.Id = id;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Cedula = cedula;
            this.EstadoLaboral = estadolaboral;
            this.HistorialPagos = historicopagos;
            this.Familiares = new Familiares();
            this.EsCasado = escasado;
            this.FechaNacimiento = fechanacimiento;
            this.Profesion = profesion;
            this.Contacto = contacto;
            this.EsMasculino = esmasculino;
            this.NombreCompleto = nombrec;
            this.Foto = foto;
            this.EstadoPR = estadopr;
            this.Nss = nss;
            this.SueldoBrutoActual = sueldobaseactual;
            this.EsFallecido = esfallecido;
            this.FechaFallecido = fechafallecido;
            this.FechaIngresoEducacion = fechaingresoeducacion;

            this.Direccion = new Comun.TDireccion();
        }

    }
}
