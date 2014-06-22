using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class DocenteEnDecreto: Empresa.Docente.Docente
    {
        private Empresa.Docente.Decreto _decretos = Empresa.Docente.Decreto.GetInstnace();
        private Empresa.RHH.EstadoLaboral _estadolaboral = Empresa.RHH.EstadoLaboral.GetInstance();

        public bool Existe(TDecreto dec, tdocente doc) {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            consulta.Parameters.Add("@p_decd_cedula", doc.Cedula);
            consulta.Parameters.Add("@p_dec_id", dec.Id);

            using(System.Data.SqlClient.SqlDataReader Lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("dbo.Decretos_Docentes_Existe", System.Data.CommandType.StoredProcedure)){
                if (Lector.Read()){
                    if (Convert.ToInt32(Lector[0]) == 0) {
                        return false;
                    }else {
                        return true;
                    }
                }
                else {
                    return false;
                }
            }
        }

        public bool EsValidaIncluir(TDecreto dec, tdocente doc){
            //Si existe sera incluido
            bool val1 = this.Existe(dec, doc);
            bool val2 = doc.EsFallecido;
            return !val1 && !val2;
        }

        public DocenteEnDecreto():base(){

            


        }

        public DocenteEnDecreto(TDecreto item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@p_dec_id", item.Id);
            Empresa.Docente.tdocente _doc;
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[View_decreto_docente_dec_id]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                _doc = new tdocente();

                _doc.Cedula = fila["decd_cedula"].ToString();
                _doc.Nombres = fila["pdr_Nombres"].ToString();
                _doc.Apellidos = fila["pdr_Apellidos"].ToString();
                _doc.NombreCompleto = fila["pdr_NombreCompleto"].ToString();
                _doc.FechaNacimiento = Convert.ToDateTime(fila["pdr_FechaNac"]);
                _doc.EsMasculino = Convert.ToBoolean(fila["pdr_Sexo"]);

                TDecretoDocente __itemdec = new TDecretoDocente(item, Convert.ToDouble(fila["decd_monto"]), _estadolaboral[Convert.ToInt32(fila["taf_id"])]);
                __itemdec.Porciento = Convert.ToDouble(fila["decd_porciento"]);
                _doc.Decretos.Add(__itemdec);
                _doc.DecretoActual = __itemdec;

                _doc.HistorialPagos = new Pagos();
                _doc.HistorialPagos.Lista.Add(new TPago(Convert.ToDouble(fila["noh_sueldo"]), Convert.ToDateTime(fila["noh_fnomina"]), _estadolaboral[Convert.ToInt32(fila["taf_id"])]));

                this.Add(_doc);
            }
        }


        /// <summary>
        /// Devuelve una persona no presente en nomina pero si en decreto.
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public tdocente DamePersonaEnDecreto(string cedula) {
            tdocente __tdoc;

                SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
                Empresa.Docente.TDecretoDocente __decd;

                consulta.Parameters.Add("@decd_cedula", cedula);

                __tdoc = new tdocente();
                __tdoc.Decretos = new System.Collections.ObjectModel.ObservableCollection<Empresa.Docente.TDecretoDocente>();

                foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[View_Decretos_Docentes_datos]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
                {
                    //Para Personas no docente o no encontradas en nomina.
                    //Asignando datos personales. 
                    __tdoc.Cedula = fila["decd_cedula"].ToString();
                    __tdoc.Nombres = fila["NOMBRES"].ToString();
                    __tdoc.Apellidos = fila["APELLIDO1"].ToString();
                    __tdoc.NombreCompleto = fila["nombrecompleto"].ToString();
                    __tdoc.FechaNacimiento = Convert.ToDateTime(fila["FECHA_NAC"]);
                    __tdoc.EsMasculino = Convert.ToBoolean(fila["Sexo"]);
                    __tdoc.EsDocente = false;
                    __tdoc.Foto = fila["foto"] == DBNull.Value ? null : (byte[])fila["foto"];
                    //Asignado decretos 
                    __decd = new Empresa.Docente.TDecretoDocente();
                    __decd.Decreto = _decretos.GetItem(Convert.ToInt32(fila["dec_id"]));
                    __decd.Estado = _estadolaboral[Convert.ToInt32(fila["taf_id"])];
                    __decd.Monto = Convert.ToDouble(fila["decd_monto"]);

                    __tdoc.Decretos.Add(__decd);
                }

                //consulta.Parameters.ClerAll();

                return __tdoc;
        }

        public DocenteEnDecreto(string cedula) : base(cedula)
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            foreach (Empresa.Docente.tdocente item in this)
            {
                Empresa.Docente.TDecretoDocente __decd;    
                consulta.Parameters.Add("@decd_cedula", item.Cedula);

                item.Decretos = new System.Collections.ObjectModel.ObservableCollection<Empresa.Docente.TDecretoDocente>();
                foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[View_Decretos_Docentes]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
                {
                    __decd = new Empresa.Docente.TDecretoDocente();

                    __decd.Decreto = _decretos.GetItem(Convert.ToInt32(fila["dec_id"]));
                    __decd.Estado = _estadolaboral[Convert.ToInt32(fila["taf_id"])];
                    __decd.Monto = Convert.ToDouble(fila["decd_monto"]);

                    item.Decretos.Add(__decd);
                }
                consulta.Parameters.ClerAll();
            }

        }

        public void Agregar(Empresa.Docente.tdocente item)
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@decd_cedula", item.Cedula);
            consulta.Parameters.Add("@taf_id", item.DecretoTransito.Estado.Id);
            consulta.Parameters.Add("@dec_id", item.DecretoTransito.Decreto.Id);
            consulta.Parameters.Add("@decd_monto", item.DecretoTransito.Monto);
            consulta.Parameters.Add("@decd_porciento", item.DecretoTransito.Porciento);

            consulta.Execute.NoQuery("dbo.Decretos_Docentes_Insert", System.Data.CommandType.StoredProcedure);
        }

        public void Eliminar(Empresa.Docente.tdocente item)
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@decd_cedula", item.Cedula);
            consulta.Parameters.Add("@dec_id", item.DecretoTransito.Decreto.Id);
            consulta.Execute.NoQuery("dbo.Decretos_Docentes_Delete", System.Data.CommandType.StoredProcedure);
            this.Remove(item);
        }

        public void Update(Empresa.Docente.tdocente item) {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@decd_cedula", item.Cedula);
            consulta.Parameters.Add("@taf_id", item.DecretoTransito.Estado.Id);
            consulta.Parameters.Add("@dec_id", item.DecretoTransito.Decreto.Id);
            consulta.Parameters.Add("@decd_monto", item.DecretoTransito.Monto);
            consulta.Parameters.Add("@decd_porciento", item.DecretoTransito.Porciento);

            consulta.Execute.NoQuery("dbo.Decretos_Docentes_Update", System.Data.CommandType.StoredProcedure);
        }

    }
}
