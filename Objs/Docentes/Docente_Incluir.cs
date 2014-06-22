using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class DocenteIncluir: DocenteEnDecreto
    {


        public DocenteIncluir(string cedula) :base (cedula){ 

        }
        public DocenteIncluir(): base(){ 

        }

        public void Agregar(tdocente item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@perin_cedula", item.Cedula);
            consulta.Parameters.Add("@perin_sueldobruto", item.HistorialPagos.Primero.MontoBruto);
            consulta.Parameters.Add("@perin_fecha", item.HistorialPagos.Primero.Fecha);
            consulta.Parameters.Add("@perin_tservicio", 0);
            consulta.Parameters.Add("@sup_id", item.TrabajoLabora.Id);

            consulta.Execute.NoQuery("[dbo].[Comun_Personalincluido_Insert]", System.Data.CommandType.StoredProcedure);
        }

        public void Quitar(tdocente item){



        }

    }
}
