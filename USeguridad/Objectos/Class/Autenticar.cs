using System;
using System.Collections.Generic;
namespace Empresa.USeguridad
{
    public class Autenticar {
        private SSData.Servicios consulta;
        private bool _IsAutenticado=false;
        public bool IsAutenticado { get { return _IsAutenticado; } }
        public TUsuario _Usuario;
        public TUsuario Usuario {
            get { return _Usuario; }
        }

        public Autenticar(string nombre, string clave){        
            Seguridad.Seguridades.Encriptacion encrip = new Seguridad.Seguridades.Encriptacion();
            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@usua_nombre", nombre);
            System.Data.SqlClient.SqlDataReader lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("[inventario].[dbo].[Com_ViewUsuarioAutenticado]", System.Data.CommandType.StoredProcedure);
            
            if (lector.Read()){
                _IsAutenticado = encrip.DesEncriptar(lector[0]).Equals(clave);
                this._Usuario = new Usuario(nombre, true).FirstItem(); 
            }else{
                _IsAutenticado = false;
                lector.Close();
                lector.Dispose(); 
            }

        }
    }
}
