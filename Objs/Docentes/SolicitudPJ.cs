using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    /// ********************************************************************************************************* ////
    /// INABIMA(TIC)
    /// Noe De La Rosa
    /// 30/10/2013
    /// Sistema Integrado de Consultas
    /// Nombre obj: Solicitud de Pensión y Jubilación	     
    /// Version:	1.0
    /// Depende:    tsolicitudpj, System.Collections.ObjectModel
    /// Padre:      tdocente    
    /// ********************************************************************************************************* ////
    /// <summary>
    /// Objectivo:  administrar las solicitudes de Pension o Jubilacion del los docente.    
    /// </summary>
    public class SolicitudPJ {

        public bool ExisteProceso
        {
            get {
                if (this.Lista.Count > 0){
                    foreach (tsolicitudpj item in this.Lista){
                        if(item.EstadoActual.Estado.Id.Equals(1) || item.EstadoActual.Estado.Id.Equals(4)) return true;
                    }
                }
                return false;
            }
        }

        public tsolicitudpj Actual{get;set;}
        
        private void setActual() {
            if (ExisteProceso){
                foreach (tsolicitudpj item in this.Lista){
                    if (item.EstadoActual.Estado.Id.Equals(1)) this.Actual = item;
                }
            }
            //this. new tsolicitudpj();
        }

        public ObservableCollection<tsolicitudpj> Lista { get; set; }
        
        public bool Insert(Empresa.Docente.tsolicitudpj item, string cedula){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            Empresa.Docente.EstadosSolicitudPJ _estadosasigandos = new EstadosSolicitudPJ();

            if (item.IsValid()) //Validación
            {
                //se le cambia el estado por defecto.
                //item.EstadoActual.Estado = Empresa.Docente.EstadoPJ.GetInstance().GetItem(1);
                //item.EstadoActual.Estado.Descripcion = "Estado Asigando de forma Auto, Recepción.";

                //Estableciendo fecha de entrada del estado.
                item.EstadoActual.Fecha = Empresa.Comun.Server.DameTiempo();

                consulta.Parameters.Add("@solpj_fechaentrada", item.Fecha);
                consulta.Parameters.Add("@sup_id", item.Aseguradora.Id);
                consulta.Parameters.Add("@oris_id", item.OrigenSiniestro.Id);
                consulta.Parameters.Add("@sin_id", item.TipoSiniestro.Id);
                consulta.Parameters.Add("@solpj_fsiniestro", item.FechaSiniestro);
                consulta.Parameters.Add("@solpj_detalle", item.Detalles);
                consulta.Parameters.Add("@solpj_pdiscapcidad", item.PorcientoDiscapacidad);
                consulta.Parameters.Add("@solpjt_id", item.OrigenBeneficio.Id);
                
                if(item.FechaConcrecion == DateTime.MinValue){
                    consulta.Parameters.Add("@solpj_fconcrecion",  DBNull.Value);
                }else{
                    consulta.Parameters.Add("@solpj_fconcrecion", item.FechaConcrecion);
                }

                consulta.Parameters.Add("@solpj_cedula", cedula);
                //Guardando solicitud.
                //Recuperando Id de Solicitud.
                using (System.Data.SqlClient.SqlDataReader lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("dbo.Pensiones_SolicitudPJInsert", System.Data.CommandType.StoredProcedure)){
                    if(lector.Read()){
                        item.Id = Convert.ToInt32(lector[0]);
                        item.NoExpediente = lector[1].ToString();
                    }
                    else {
                        item.Id = 0;
                        item.NoExpediente = string.Empty;
                    }
                }

                //Insertando Estado.
                _estadosasigandos.Insert(item);

                //Insertando Pasos;
                if(item.Pasos.Lista.Count > 0){
                    item.Pasos.Insert(item);
                }

                //guardando requisitos
                RequisitosAsignados reqa = new RequisitosAsignados();
                reqa.Insert(item);
                //guardando solicitante.

                if (item.Solicitante.IsValid()){
                    Empresa.Docente.Solicitante soli = new Solicitante();
                    soli.Insert(item,cedula);
                }

                //se agrega a las list actual.
                this.Lista.Add(item);
                //se establece el item actual.
                this.setActual();
                //retorna verdadero si toda la operacion fue exitosa.
                return true;
            }//validación
            else {
                //retorna verdadero si la operacion fallo.
                return false;
            }
        }

        public bool Update(Empresa.Docente.tdocente item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            //Update Solicitud

            if(item.IsValid()){
                consulta.Parameters.Add("@solpj_id", item.SolicitudPJ.Actual.Id);
                consulta.Parameters.Add("@solpj_fechaentrada", item.SolicitudPJ.Actual.Fecha);
                consulta.Parameters.Add("@sup_id", item.SolicitudPJ.Actual.Aseguradora.Id);
                
                //consulta.Parameters.Add("@esolpj_id", item.SolicitudPJ.Actual.Estado.Id); //Estado modificado

                consulta.Parameters.Add("@oris_id", item.SolicitudPJ.Actual.OrigenSiniestro.Id);
                consulta.Parameters.Add("@sin_id", item.SolicitudPJ.Actual.TipoSiniestro.Id);
                consulta.Parameters.Add("@solpj_porcentaje", item.SolicitudPJ.Actual.PorcientoAplicado);
                consulta.Parameters.Add("@solpj_detalle", item.SolicitudPJ.Actual.Detalles);
                consulta.Parameters.Add("@solpj_fsiniestro", item.SolicitudPJ.Actual.FechaSiniestro);
                consulta.Parameters.Add("@solpjt_id", item.SolicitudPJ.Actual.OrigenBeneficio.Id);

                if(item.SolicitudPJ.Actual.FechaConcrecion == DateTime.MinValue){
                    consulta.Parameters.Add("@solpj_fconcrecion", DBNull.Value);
                }
                else {
                    consulta.Parameters.Add("@solpj_fconcrecion", item.SolicitudPJ.Actual.FechaConcrecion);
                }
                consulta.Execute.NoQuery("dbo.Pensiones_SolicitudPJUpdate", System.Data.CommandType.StoredProcedure);

                //Actualizando items
                this.setActual();

                //Empresa.Comun.tdireccioncontacto cont = new Comun.tdireccioncontacto(item.Cedula);
                //Realizando el Update, de los contactos.
                //cont.Update(item.Cedula, item.Direccion, item.Contacto);

                //Actualizando Solicitud.
                item.SolicitudPJ.Actual.Pasos.Update(item.SolicitudPJ.Actual);
                

                Solicitante solic = new Solicitante();
                if (item.SolicitudPJ.Actual.Solicitante.Exite){

                    if (item.SolicitudPJ.Actual.Solicitante.IsValid()){
                        solic.Update(item);
                    }
                }
                else {

                    if (item.SolicitudPJ.Actual.Solicitante.IsValid()){
                        solic.Insert(item);
                    }
                
                }
                return true;
            }
            else {
                return false;
            }
            //RequisitosAsignados reqa = new RequisitosAsignados();
            //reqa.Update(item.SolicitudPJ.Actual);
           
        }

        public bool Update(Empresa.Docente.tsolicitudpj item, string ceduladocente)
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            //Update Solicitud

            if (item.IsValid()){

                consulta.Parameters.Add("@solpj_id", item.Id);
                consulta.Parameters.Add("@solpj_fechaentrada", item.Fecha);
                consulta.Parameters.Add("@sup_id", item.Aseguradora.Id);
                consulta.Parameters.Add("@oris_id", item.OrigenSiniestro.Id);
                consulta.Parameters.Add("@sin_id", item.TipoSiniestro.Id);
                consulta.Parameters.Add("@solpj_pdiscapcidad", item.PorcientoDiscapacidad);
                consulta.Parameters.Add("@solpj_detalle", item.Detalles);
                consulta.Parameters.Add("@solpj_fsiniestro", item.FechaSiniestro);
                consulta.Parameters.Add("@solpjt_id", item.OrigenBeneficio.Id);

                if (item.FechaConcrecion == DateTime.MinValue){
                    consulta.Parameters.Add("@solpj_fconcrecion", DBNull.Value);
                }
                else{
                    consulta.Parameters.Add("@solpj_fconcrecion", item.FechaConcrecion);
                }
                consulta.Execute.NoQuery("[dbo].[Pensiones_SolicitudPJUpdate]", System.Data.CommandType.StoredProcedure);

                //Actualizando items
                this.setActual();

                //Empresa.Comun.tdireccioncontacto cont = new Comun.tdireccioncontacto(item.Cedula);
                //Realizando el Update, de los contactos.
                //cont.Update(item.Cedula, item.Direccion, item.Contacto);

                //Actualizando Solicitud.
                item.Pasos.Update(item);

                //guardando requisitos
                RequisitosAsignados reqa = new RequisitosAsignados();
                reqa.Insert(item); 

                //reqa.Update(

                Solicitante solic = new Solicitante();
                if (item.Solicitante.Exite){

                    if (item.Solicitante.IsValid()){
                        solic.Update(item);
                    }
                }
                else{
                    if (item.Solicitante.IsValid()){
                        solic.Insert(item ,ceduladocente);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
            //RequisitosAsignados reqa = new RequisitosAsignados();
            //reqa.Update(item.SolicitudPJ.Actual);
            
        }

        public SolicitudPJ(){
            this.Lista = new ObservableCollection<tsolicitudpj>();
            this.Actual = new tsolicitudpj();
        }

        private void Contructor(tdocente docente) {

            this.Lista = new ObservableCollection<tsolicitudpj>();
            this.Actual = new tsolicitudpj();

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@cedula", docente.Cedula);
            tsolicitudpj tsol;
            //variables de recuperación
            EstadoPJ Estados = EstadoPJ.GetInstance();

            TipoSiniestros tsiniestro = new TipoSiniestros();
            OrigenSiniestro origens = new OrigenSiniestro();

            foreach(System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Pensiones_SolicitudPJViewC", System.Data.CommandType.StoredProcedure).Tables[0].Rows){

                tsol = new tsolicitudpj();
                tsol.Docente = docente;

                tsol.Id = Convert.ToInt32(fila["solpj_id"]);

                tsol.TipoSiniestro = tsiniestro.GetItem(Convert.ToInt32(fila["sin_id"])); // tipo de siniestro.
                tsol.OrigenSiniestro = origens.GetItem(Convert.ToInt32(fila["oris_id"])); // origen de siniestro.

                tsol.Fecha = Convert.ToDateTime(fila["solpj_fecha"]);
                tsol.FechaEntrada = Convert.ToDateTime(fila["solpj_fechaentrada"]);

                tsol.Aseguradora = new Comun.Suplidor(Convert.ToInt32(fila["sup_id"]))[0];

                //Recuperando el ultimo estado de la solicitud.
                tsol.EstadoActual.Estado = Estados.GetItem(Convert.ToInt32(fila["esolpj_id"]));
                tsol.EstadoActual.Fecha = Convert.ToDateTime(fila["aesolpj_fecha"]);
                tsol.EstadoActual.Descripcion = fila["aesolpj_detalle"].ToString();


                tsol.FechaSiniestro = Convert.ToDateTime(fila["solpj_fsiniestro"]);
                tsol.NoExpediente = fila["solpj_noexpedientes"].ToString();

                //tsol.PorcientoAplicado = Convert.ToDouble(fila["solpj_porcentaje"]);
                tsol.Detalles = fila["solpj_detalle"].ToString();

                tsol.FechaConcrecion = fila["solpj_fconcrecion"] == DBNull.Value ? DateTime.MinValue: Convert.ToDateTime(fila["solpj_fconcrecion"]);
                tsol.PorcientoDiscapacidad = Convert.ToDouble(fila["solpj_pdiscapcidad"]);
  
                tsol.Pasos = new PasospjAsignados(tsol.Id);
                tsol.Requisitos = new Empresa.Docente.RequisitosAsignados(tsol.Id).Lista;

                //Busqueda Solicitante, por medio de la cedula de Docente.
                Empresa.Docente.Solicitante soli = new Empresa.Docente.Solicitante(docente.Cedula);
                tsol.Solicitante = soli.GetFirtItem();
                tsol.Tiempos = new TiemposSolicitud(tsol);

                tsol.OrigenBeneficio = OrigenBeneficio.GetInstance().GetItem(Convert.ToInt32(fila["solpjt_id"]));

                //Recuperando Estados. 
                tsol.Estados = new EstadosSolicitudPJ(tsol);
                tsol._calculando_Monto();
                tsol._calculando_MontoRetroactivo(); 
                
                this.Lista.Add(tsol);
            }

            this.setActual();
        }

        public SolicitudPJ(tdocente docente){
            this.Contructor(docente);
        }
        
        public SolicitudPJ(DateTime iniciofecha, DateTime finfecha, testadopj estadoactual){

            this.Lista = new ObservableCollection<tsolicitudpj>();
            this.Actual = new tsolicitudpj();

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            //consulta.Parameters.Add("@cedula", docente.Cedula);
            tsolicitudpj tsol;
            //variables de recuperación
            EstadoPJ _estados = EstadoPJ.GetInstance();
            //TipoSiniestros tsiniestro = new TipoSiniestros();
            //OrigenSiniestro origens = new OrigenSiniestro();

            consulta.Parameters.Add("@finicio", iniciofecha);
            consulta.Parameters.Add("@ffinal", finfecha);

            consulta.Parameters.Add("@esolpj_id", estadoactual.Id==0? string.Empty:estadoactual.Id.ToString());

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Pensiones_SolicitudPJView_FechaEstado]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                tsol = new tsolicitudpj(Convert.ToInt32(fila["solpj_id"]));

                tsol.Docente = new tdocente(fila["cedula"].ToString());
                tsol.Docente.Nombres = fila["NOMBRES"].ToString();
                tsol.Docente.Apellidos = fila["apellidos"].ToString();

                //tsol.Docente.Foto = 
                //tsol.Id = Convert.ToInt32(fila["solpj_id"]);

               // tsol.TipoSiniestro = tsiniestro.GetItem(Convert.ToInt32(fila["sin_id"])); // tipo de siniestro.
               // tsol.OrigenSiniestro = origens.GetItem(Convert.ToInt32(fila["oris_id"])); // origen de siniestro.

                tsol.Fecha = Convert.ToDateTime(fila["solpj_fecha"]);
                tsol.FechaEntrada = Convert.ToDateTime(fila["solpj_fechaentrada"]);
                //tsol.Aseguradora = new Comun.Suplidor(Convert.ToInt32(fila["sup_id"]))[0];
                //Recuperando el ultimo estado de la solicitud.

                tsol.EstadoActual = new testadossolicitudpj();
                tsol.EstadoActual.Estado = _estados.GetItem(Convert.ToInt32(fila["esolpj_id"]));
                tsol.EstadoActual.Fecha = Convert.ToDateTime(fila["aesolpj_fecha"]);
                tsol.EstadoActual.Descripcion = fila["aesolpj_detalle"].ToString();

                tsol.FechaSiniestro = Convert.ToDateTime(fila["solpj_fsiniestro"]);
                tsol.NoExpediente = fila["solpj_noexpedientes"].ToString();

                //tsol.PorcientoAplicado = Convert.ToDouble(fila["solpj_porcentaje"]);
                tsol.Detalles = fila["solpj_detalle"].ToString();

                tsol.FechaConcrecion = fila["solpj_fconcrecion"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(fila["solpj_fconcrecion"]); 
                tsol.PorcientoDiscapacidad = Convert.ToDouble(fila["solpj_pdiscapcidad"]);
               
                //tsol.Pasos = new PasospjAsignados(); 

                //tsol.Requisitos = new Empresa.Docente.RequisitosAsignados(tsol.Id).Lista;

                //Busqueda Solicitante, por medio de la cedula de Docente.
                //Empresa.Docente.Solicitante soli = new Empresa.Docente.Solicitante(tsol.Docente.Cedula);
                //tsol.Solicitante = soli.GetFirtItem();
                
                //Calculo de tiempos.
                //tsol.Tiempos = new TiemposSolicitud(tsol);

                //Recuperando Estados. 
                //tsol.Estados = new EstadosSolicitudPJ(tsol);
                //tsol._calculando_Monto();
                this.Lista.Add(tsol);
                //this.setActual(); 
            }

            PasospjAsignados pasos = new PasospjAsignados(this.Lista);
          
            foreach(tsolicitudpj item in this.Lista){
                foreach(TPasospjAsignados itempas in pasos.Lista) {
                    if (itempas.Solicitud.Id.Equals(item.Id))
                    {
                        item.Pasos = new PasospjAsignados();
                        item.Pasos.Lista.Add(itempas);
                    }
                }
                item.Tiempos = new TiemposSolicitud(item);
            }
        }

        public SolicitudPJ(testadopj estado) 
        {
            this.Lista = new ObservableCollection<tsolicitudpj>();
            this.Actual = new tsolicitudpj();

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            //consulta.Parameters.Add("@cedula", docente.Cedula);
            tsolicitudpj tsol;
            //variables de recuperación
            EstadoPJ _estados = EstadoPJ.GetInstance();

            consulta.Parameters.Add("@p_esolpj_id", estado.Id == 0 ? string.Empty : estado.Id.ToString());
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Pensiones_SolicitudPJView_Estado]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                tsol = new tsolicitudpj(Convert.ToInt32(fila["solpj_id"]));

                tsol.Docente = new tdocente(fila["cedula"].ToString());
                tsol.Docente.Nombres = fila["NOMBRES"].ToString();
                tsol.Docente.Apellidos = fila["apellidos"].ToString();
                
                tsol.Fecha = Convert.ToDateTime(fila["solpj_fecha"]);
                tsol.FechaEntrada = Convert.ToDateTime(fila["solpj_fechaentrada"]);
                //Recuperando el ultimo estado de la solicitud.

                tsol.EstadoActual = new testadossolicitudpj();
                tsol.EstadoActual.Estado = _estados.GetItem(Convert.ToInt32(fila["esolpj_id"]));
                tsol.EstadoActual.Fecha = Convert.ToDateTime(fila["aesolpj_fecha"]);
                tsol.EstadoActual.Descripcion = fila["aesolpj_detalle"].ToString();

                tsol.FechaSiniestro = Convert.ToDateTime(fila["solpj_fsiniestro"]);
                tsol.NoExpediente = fila["solpj_noexpedientes"].ToString();

                tsol.Detalles = fila["solpj_detalle"].ToString();

                tsol.FechaConcrecion = fila["solpj_fconcrecion"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(fila["solpj_fconcrecion"]);
                tsol.PorcientoDiscapacidad = Convert.ToDouble(fila["solpj_pdiscapcidad"]);

                
                this.Lista.Add(tsol);
            }

            PasospjAsignados pasos = new PasospjAsignados(this.Lista);

            foreach (tsolicitudpj item in this.Lista)
            {
                foreach (TPasospjAsignados itempas in pasos.Lista)
                {
                    if (itempas.Solicitud.Id.Equals(item.Id))
                    {
                        item.Pasos = new PasospjAsignados();
                        item.Pasos.Lista.Add(itempas);
                    }
                }
                item.Tiempos = new TiemposSolicitud(item);
            }

        }

        public SolicitudPJ(string cedula, string noexpediente) 
        {
            this.Lista = new ObservableCollection<tsolicitudpj>();
            this.Actual = new tsolicitudpj();

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            //consulta.Parameters.Add("@cedula", docente.Cedula);
            tsolicitudpj tsol;
            //variables de recuperación
            EstadoPJ _estados = EstadoPJ.GetInstance();

            consulta.Parameters.Add("@p_cedula", cedula);
            consulta.Parameters.Add("@p_noexpediente", noexpediente);

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Pensiones_SolicitudPJView_CedulaNoExpediente]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                tsol = new tsolicitudpj(Convert.ToInt32(fila["solpj_id"]));

                tsol.Docente = new tdocente(fila["cedula"].ToString());
                tsol.Docente.Nombres = fila["NOMBRES"].ToString();
                tsol.Docente.Apellidos = fila["apellidos"].ToString();

                tsol.Fecha = Convert.ToDateTime(fila["solpj_fecha"]);
                tsol.FechaEntrada = Convert.ToDateTime(fila["solpj_fechaentrada"]);
                //Recuperando el ultimo estado de la solicitud.

                tsol.EstadoActual = new testadossolicitudpj();
                tsol.EstadoActual.Estado = _estados.GetItem(Convert.ToInt32(fila["esolpj_id"]));
                tsol.EstadoActual.Fecha = Convert.ToDateTime(fila["aesolpj_fecha"]);
                tsol.EstadoActual.Descripcion = fila["aesolpj_detalle"].ToString();

                tsol.FechaSiniestro = Convert.ToDateTime(fila["solpj_fsiniestro"]);
                tsol.NoExpediente = fila["solpj_noexpedientes"].ToString();

                tsol.Detalles = fila["solpj_detalle"].ToString();

                tsol.FechaConcrecion = fila["solpj_fconcrecion"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(fila["solpj_fconcrecion"]);
                tsol.PorcientoDiscapacidad = Convert.ToDouble(fila["solpj_pdiscapcidad"]);

                this.Lista.Add(tsol);
            }

            PasospjAsignados pasos = new PasospjAsignados(this.Lista);

            foreach (tsolicitudpj item in this.Lista)
            {
                foreach (TPasospjAsignados itempas in pasos.Lista)
                {
                    if (itempas.Solicitud.Id.Equals(item.Id))
                    {
                        item.Pasos = new PasospjAsignados();
                        item.Pasos.Lista.Add(itempas);
                    }
                }
                item.Tiempos = new TiemposSolicitud(item);
            }
        }

        public SolicitudPJ(testadopj estado, string cedula, string noexpediente)
        { 
            this.Lista = new ObservableCollection<tsolicitudpj>();
            this.Actual = new tsolicitudpj();

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            //consulta.Parameters.Add("@cedula", docente.Cedula);
            tsolicitudpj tsol;
            //variables de recuperación
            EstadoPJ _estados = EstadoPJ.GetInstance();

            consulta.Parameters.Add("@p_cedula", cedula);
            consulta.Parameters.Add("@p_noexpediente", noexpediente);
            consulta.Parameters.Add("@p_esolpj_id", estado.Id == 0 ? string.Empty : estado.Id.ToString());

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Pensiones_SolicitudPJView_EstadoCedulaNoExpediente]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                tsol = new tsolicitudpj(Convert.ToInt32(fila["solpj_id"]));

                tsol.Docente = new tdocente(fila["cedula"].ToString());
                tsol.Docente.Nombres = fila["NOMBRES"].ToString();
                tsol.Docente.Apellidos = fila["apellidos"].ToString();

                tsol.Fecha = Convert.ToDateTime(fila["solpj_fecha"]);
                tsol.FechaEntrada = Convert.ToDateTime(fila["solpj_fechaentrada"]);
                //Recuperando el ultimo estado de la solicitud.

                tsol.EstadoActual = new testadossolicitudpj();
                tsol.EstadoActual.Estado = _estados.GetItem(Convert.ToInt32(fila["esolpj_id"]));
                tsol.EstadoActual.Fecha = Convert.ToDateTime(fila["aesolpj_fecha"]);
                tsol.EstadoActual.Descripcion = fila["aesolpj_detalle"].ToString();

                tsol.FechaSiniestro = Convert.ToDateTime(fila["solpj_fsiniestro"]);
                tsol.NoExpediente = fila["solpj_noexpedientes"].ToString();

                tsol.Detalles = fila["solpj_detalle"].ToString();

                tsol.FechaConcrecion = fila["solpj_fconcrecion"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(fila["solpj_fconcrecion"]);
                tsol.PorcientoDiscapacidad = Convert.ToDouble(fila["solpj_pdiscapcidad"]);

                this.Lista.Add(tsol);
            }

            PasospjAsignados pasos = new PasospjAsignados(this.Lista);

            foreach (tsolicitudpj item in this.Lista)
            {
                foreach (TPasospjAsignados itempas in pasos.Lista)
                {
                    if (itempas.Solicitud.Id.Equals(item.Id))
                    {
                        item.Pasos = new PasospjAsignados();
                        item.Pasos.Lista.Add(itempas);
                    }
                }
                item.Tiempos = new TiemposSolicitud(item);
            }

        
        }

        public ObservableCollection<tsolicitudpj> GetItems(string cedula) {
            return new ObservableCollection<tsolicitudpj>();
        }

    }
}
