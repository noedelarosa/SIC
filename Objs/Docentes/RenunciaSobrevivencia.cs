using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class RenunciaSobrevivencia
    {
        public Empresa.Docente.trenunciasobrevivencia Renuncia { get; set; }
        public RenunciaSobrevivencia(string cedula) {
            this.Renuncia = new trenunciasobrevivencia();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@Sop_Cedula", cedula); 
            //consulta.Parameters.Add("@Sop_Cedula", cedula);
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.View_Minerd_Exclusiones_Soportes_Cedula", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                this.Renuncia.Fecha = fila["exc_fecha"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["exc_fecha"];
                this.Renuncia.Id = Convert.ToInt32(fila["exc_id"]);
                this.Renuncia.Foto = fila["sop_soporte"] == DBNull.Value ? null : (byte[])fila["sop_soporte"];
            }
        }
    }
}
