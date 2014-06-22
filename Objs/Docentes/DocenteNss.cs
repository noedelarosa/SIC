using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class DocenteNss:Docente
    {

        public DocenteNss(string nss){
            //
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@cag_nss", nss);
            tdocente docente;

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Afiliados_View_nss]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                //(int)fila["dec_id"], fila["pdr_nombres"].ToString(), fila["pdr_apellido1"].ToString() + fila["pdr_apellido2"].ToString(), fila["pdr_NombreCompleto"].ToString(), fila["pdr_cedula"].ToString(), false, Convert.ToBoolean(fila["pdr_sexo"]), (DateTime)fila["pdr_FechaNac"], "ninguna", EstadoLaboral.GetInstance()[(int)fila["dec_tipo"]], new Empresa.Comun.tcontacto(), fila["dec_decreto"].ToString(), fila["dec_fecha"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["dec_fecha"], fila["pdr_foto"] == DBNull.Value ? null : (byte[])fila["pdr_foto"], fila["EstadoPr"].ToString(), fila["pdr_nss"].ToString(), Convert.ToDouble(fila["Dec_UltimoSueldo"]), Convert.ToBoolean(fila["pdr_esfallecido"]), fila["pdr_ffallecido"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["pdr_ffallecido"], fila["pdr_fingreso"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["pdr_fingreso"], fila["dec_fpago"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["dec_fpago"]
                docente = new tdocente( fila["cag_nombres"].ToString(), string.Empty,string.Empty,fila["cag_cedula"].ToString(), false, false, DateTime.Now, string.Empty, new RHH.testadolaboral(), new Comun.tcontacto() );
                this.Add(docente);
            }



        } 
    }
}
