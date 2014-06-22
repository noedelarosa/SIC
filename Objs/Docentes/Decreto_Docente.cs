using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class DecretoDocente{

        public TDecreto Decreto { get; set; }
        public ObservableCollection<tdocente> Docentes { get; set; }
        
        private Empresa.Docente.Decreto _decretos = Empresa.Docente.Decreto.GetInstnace();

        private Empresa.RHH.EstadoLaboral _estadolaboral = Empresa.RHH.EstadoLaboral.GetInstance();

        public DecretoDocente(){

            this.Decreto = new TDecreto();
            this.Docentes = new ObservableCollection<tdocente>();

        }

        public DecretoDocente(Empresa.Docente.TDecreto item){
            //Buscando Todos los Docentes con este decreto.
            this.Decreto = item;
            this.Docentes = new ObservableCollection<tdocente>();

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            //Buscando Docentes
            consulta.Parameters.Add("@Dec_Decreto", item.Numero);
            tdocente doc;
            
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Minerd_Decretos_ViewDecreto]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                doc = new tdocente();

                doc.Apellidos = fila["pdr_apellidos"].ToString();
                doc.Nombres = fila["NOMBRES"].ToString();
                doc.NombreCompleto = doc.Nombres + " " + doc.Apellidos;
                doc.EsMasculino = Convert.ToBoolean(fila["SEXO"]);
                doc.FechaNacimiento = fila["FECHA_NAC"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["FECHA_NAC"];
                doc.Cedula = fila["dec_cedula"].ToString();

                doc.Foto = fila["foto"] == DBNull.Value ? null : (byte[])fila["foto"];
                doc.Decretos.Add(new TDecretoDocente(_decretos.GetItem(fila["dec_decreto"].ToString()), Convert.ToDouble(fila["dec_montoprt"]), _estadolaboral[Convert.ToInt32(fila["dec_tipo"])]));
                this.Docentes.Add(doc);
            }

        }

        /// <summary>
        /// Inicializando con un Docente.
        /// </summary>
        /// <param name="item"></param>
        /// 
        
        public DecretoDocente(Empresa.Docente.tdocente item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            //this.Decreto = new TDecreto();
            //this.Docentes = new ObservableCollection<tdocente>();
            //tdocente doc;
            //consulta.Parameters.Add("@cedula", item.Cedula);
            
            //foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Minerd_Decretos_ViewDecretoCedula]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            //{
            //    doc = new tdocente();
            //    //doc.Apellidos = fila["pdr_apellidos"].ToString();
            //    //doc.Nombres = fila["NOMBRES"].ToString();
            //    //doc.EsMasculino = Convert.ToBoolean(fila["SEXO"]);
            //    //doc.FechaNacimiento = (DateTime)fila["FECHA_NAC"];
            //    doc.Cedula = fila["dec_cedula"].ToString();
            //    doc.Decretos.Add(new TDecretoDocente(_decretos.GetItem(fila["dec_decreto"].ToString()), Convert.ToDouble(fila["dec_montoprt"]),_estadolaboral[Convert.ToInt32(fila["dec_tipo"])]));
            //    this.Docentes.Add(doc);
            //}

        }

        /// <summary>
        /// Incializando con Lista de Docentes
        /// </summary>
        /// <param name="items"></param>
        public DecretoDocente(ObservableCollection<tdocente> items)
        {
            this.Docentes = new ObservableCollection<tdocente>();
            string argmenes =string.Empty;
            
            List<string> ListaCedulas = new List<string>();
            foreach (tdocente item in items) {
                ListaCedulas.Add(item.Cedula);
            }

            argmenes = Empresa.Comun.Servicios.DividirCAD(ListaCedulas);

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            //Buscando Docentes
            consulta.Parameters.Add("@args", argmenes);
            tdocente docente;

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Minerd_Decretos_ViewDecretoCedulas]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                docente = new tdocente();
                docente.Cedula = fila["dec_cedula"].ToString();
                docente.Decretos.Add(new TDecretoDocente(_decretos.GetItem(fila["dec_decreto"].ToString()), Convert.ToDouble(fila["dec_montoprt"]), _estadolaboral[Convert.ToInt32(fila["dec_tipo"])]));
                this.Docentes.Add(docente);
            }

            DateTime fechaactual = Empresa.Comun.Server.DameTiempo();

            foreach(tdocente item in this.Docentes){
                if (item.FechaNacimiento != DateTime.MinValue){
                    if (!item.EsFallecido){
                        item.Edad = Empresa.Comun.Servicios.FechasDifencia(item.FechaNacimiento, fechaactual).Anos;
                    }
                    else{
                        item.Edad = Empresa.Comun.Servicios.FechasDifencia(item.FechaNacimiento, item.FechaFallecido).Anos;
                    }
                }
            }
        }

        //private ObservableCollection<tdocente> _docentes;
        //public ObservableCollection<tdocente> Docentes {
        //    get {
        //            _docentes = this.llenandoDocente(this.Decreto.Numero);
        //            return _docentes;
        //    }
        //}

        public bool Existe(tdocente item){
            //if (_decreto == null) _docentes = this.llenandoDocente(this._decreto.Numero);
            foreach(tdocente itemd in this.Docentes){
                    if (itemd.Cedula.Equals(item.Cedula)) return true;
            }
            return false;
        }

        public bool EsDuplica(tdocente item, Empresa.RHH.testadolaboral estadolaboral){
            foreach (tdocente itemd in this.Docentes){
                
                if(itemd.Cedula.Equals(item.Cedula)){
                    foreach (TDecretoDocente decs in item.Decretos){ 
                       
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Retorna Verdadero si se puede incluir.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Regla(tdocente item, Empresa.RHH.testadolaboral estado) {
            if (item.EsFallecido) return false;
            return !(this.Existe(item) && estado.Id.Equals(item.EstadoLaboral.Id));
        }

        public void Agregar(Empresa.Docente.tdocente item){
                SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
                //Primera Validación, Existe en este Decreto

                consulta.Parameters.Add("@dec_cedula", item.Cedula);
                consulta.Parameters.Add("@Dec_Decreto", item.DecretoTransito.Decreto.Numero);
                consulta.Parameters.Add("@Dec_Tipo", item.DecretoTransito.Estado.Abreviatura);
                consulta.Parameters.Add("@Dec_MontoPrt", item.DecretoTransito.Monto);
                consulta.Parameters.Add("@Dec_UltimoSueldo", 0);
                consulta.Parameters.Add("@Dec_OtroDecreto", string.Empty);
                consulta.Execute.NoQuery("dbo.Minerd_Decretos_Insert", System.Data.CommandType.StoredProcedure);

        }

        public void Eliminar(Empresa.Docente.tdocente item){
            //Minerd_Decretos_Insert
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            consulta.Parameters.Add("@cedula", item.Cedula);
            consulta.Parameters.Add("@decreto", item.DecretoTransito.Decreto.Numero);
            consulta.Execute.NoQuery("dbo.Minerd_Decretos_Delete_item", System.Data.CommandType.StoredProcedure);

            Docentes.Remove(item);
        }


    }


}
