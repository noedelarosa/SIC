using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Empresa.Docente
{
    class OrdenGrid_Busqueda_Solicitud_PJ: System.Collections.IComparer
    {
        
        int System.Collections.IComparer.Compare(object x, object y)
        {
            Empresa.Docente.TiemposSolicitud tx = (Empresa.Docente.TiemposSolicitud)x;
            Empresa.Docente.TiemposSolicitud ty = (Empresa.Docente.TiemposSolicitud)y;

            if (tx.DiferenciaTiemposPorciento < ty.DiferenciaTiemposPorciento)
            {
                return -1;
            }
            else {
                return 1;
            }



        }
    }
}
