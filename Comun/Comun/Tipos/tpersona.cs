using System;
namespace Empresa.Comun
{
    public class tpersona:tbasepersona {
        public TDireccion Direccion { get; set; }
        public tcontacto  Contacto  { get; set; }


        public static implicit operator tpersona(Empresa.RHH.tpersonal arg) {
            tpersona temper = new tpersona();

            temper.Apellidos = arg.Apellidos;
            temper.Cedula = arg.Cedula;
            temper.Contacto = arg.Contacto;
            temper.Direccion = arg.Direccion;
            temper.EsCasado = arg.EsCasado;
            temper.EsDiscapacitado = arg.EsDiscapacitado;
            temper.EsFallecido = arg.EsFallecido;
            temper.EsMasculino = arg.EsMasculino;
            temper.FechaNacimiento = arg.FechaNacimiento;
            temper.Id = arg.Id;
            temper.Nombres = arg.Nombres;
            temper.Nss = arg.Nss;
            temper.Profesion = arg.Profesion;
            
            return temper;
        }

    }
}
