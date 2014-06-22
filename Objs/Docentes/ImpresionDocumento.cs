using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Comun
{
    public class ImpresionDocumento
    {
        

        
        public bool ExisteDocumento(Empresa.Docente.tsolicitudfunenario item) {
            bool valuetemp = false;
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@solsf_id", item.Id);

            using (System.Data.SqlClient.SqlDataReader lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("dbo.Comun_ImpresionDocumentos_Existe_SolSeguroFunerario", System.Data.CommandType.StoredProcedure)) {
                if (lector.Read()){
                    return (Convert.ToInt32(lector[0]).Equals(1)); 
                }
            }

            return valuetemp;
        }

        public bool ExisteDocumento(Empresa.Docente.tsolicitudpj item){
            bool valuetemp = false;
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@solsf_id", item.Id);
            







            return valuetemp;
        }


        public void Insert(timpresiondocumento item) {
         SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
         
         ///Asignacion de valores por defecto
         switch (item.Documento) { 
             case  Docente.EnumDocumento.SeguroFunerario:
                 consulta.Parameters.Add("@solsf_id", item.IdSolicitudSeguroFunerario);
                 consulta.Parameters.Add("@solpj_id", 0);
                 break;
             case Docente.EnumDocumento.PensionJubilacion:
                 break;
             case Docente.EnumDocumento.PensionDiscapacidad:
                 consulta.Parameters.Add("@solsf_id", 0);
                 consulta.Parameters.Add("@solpj_id", item.IdSolcitudPesionJubilacion);
                 break;
         }

         consulta.Parameters.Add("@comdi_comentario", item.Comentario);
         consulta.Parameters.Add("@usua_id", item.IdUsuario);

         consulta.Execute.NoQuery("Comun_ImpresionDocumentos_Insert", System.Data.CommandType.StoredProcedure);
        }





    }
}
