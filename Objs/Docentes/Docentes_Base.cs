using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class DocentesBase : ObservableCollection<tdocente>
    {

        public Int32 TotalDocentes
        {
            get
            {
                return this.Count;
            }
        }

        public Int32 TotalFamiliares
        {
            get
            {
                Int32 t = 0;
                foreach (tdocente item in this) { t += item.Familiares.Count; }
                return t;
            }
        }

        public DocentesBase()
        {

        }

        public DocentesBase(List<string> arg)
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            tdocente docente;

            string temp = string.Empty;
            string sced = Empresa.Comun.Servicios.DividirCAD(arg);
            Empresa.Comun.Direcciones dire = new Empresa.Comun.Direcciones(false);

            consulta.Parameters.Add("@cedula", sced);
            System.Data.DataSet ds = consulta.Execute.Dataset("[dbo].[ViewCed_ViewDecretosPadron_V1]", System.Data.CommandType.StoredProcedure);

            foreach (System.Data.DataRow fila in ds.Tables[0].Rows){

                docente = new tdocente();
                docente.Nombres = fila["pdr_nombres"].ToString();
                docente.Apellidos = fila["pdr_apellido1"].ToString() + fila["pdr_apellido2"].ToString();
                docente.NombreCompleto = fila["pdr_NombreCompleto"].ToString();
                docente.Cedula = fila["pdr_cedula"].ToString();
                docente.EsMasculino = Convert.ToBoolean(fila["pdr_sexo"]);
                docente.EsFallecido = Convert.ToBoolean(fila["pdr_esfallecido"]);
                docente.FechaFallecido = fila["pdr_ffallecido"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["pdr_ffallecido"];
                docente.FechaIngresoEducacion = fila["pdr_fingreso"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["pdr_fingreso"];
                docente.FechaNacimiento = (DateTime)fila["pdr_FechaNac"];
                
                this.Add(docente);
            }

            DateTime fechaactual = Empresa.Comun.Server.DameTiempo();
            foreach (tdocente item in this)
            {
                if (item.FechaNacimiento != DateTime.MinValue)
                {
                    
                    if (!item.EsFallecido){
                        item.Edad = Empresa.Comun.Servicios.FechasDifencia(item.FechaNacimiento, fechaactual).Anos;
                    }
                    else{
                        item.Edad = Empresa.Comun.Servicios.FechasDifencia(item.FechaNacimiento, item.FechaFallecido).Anos;
                    }

                }
            }

        }
    }
}