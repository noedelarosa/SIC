using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Comun
{
    public class comparacion_tiempo_distinto_sf : IComparer
    {
        public int Compare(object x, object y)
        {
            try
            {
                int __x = ((Empresa.Docente.TiempoSolicitudSeguroFunerario)x).DiferenciaTiempos;
                int __y = ((Empresa.Docente.TiempoSolicitudSeguroFunerario)y).DiferenciaTiempos;

                if (__x < __y) {
                    return -1;
                }
                else if (__x > __y)
                {
                    return 1;
                }
                else {
                    return __x.CompareTo(__x);
                }
            }
            catch {
                return 0;
            }
        }

    }
}
