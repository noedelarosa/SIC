using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.RegistroEventos
{
    /// <summary>
    /// Identificador de tarea, sincronizado con los ids de la base de Datos.Tabla: Comun.SistemaTerea
    /// </summary>
    public enum EnumIdentificadorTarea
    {
        	AccesoModulo=1,
	        VistaReporte=2,
	        AbriendoSessionUsuario=3,
	        CerrandoSessionUsuario=4,
	        AccesoDivicion=5,
	        Cerrandodivición=6,
            IntentoFallidoAbrirSeccion=7,
            ConsultaInformacion=8,
            ModificacionRegistro=9,
            InsercionRegistro=10,
            ModificancionEstadoRegistro=11,
            InsercionEstadoRegistro=12,
            ImpresionReporte=13,
            InsercionNota=14,
            VistaDatos=15,
            RegistroNotificacionFallecido = 16
    }
}
