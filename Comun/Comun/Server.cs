using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Comun
{
    public static class Server
    {
        public static DateTime DameTiempo()
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            return (DateTime)consulta.Execute.Dataset("dbo.Com_View_DameTiempo", System.Data.CommandType.StoredProcedure).Tables[0].Rows[0].ItemArray[0];
        }

        public static string DameTiempoFormatoC {
            get{
                return ConverToDates.FormatoC(DameTiempo());
            } 
        }

        public static string DameTiempoFormatoB
        {
            get
            {
                return ConverToDates.FormatoB(DameTiempo());
            }
        }

    }
}
