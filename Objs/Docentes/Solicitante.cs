using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.Docente
{
    public class Solicitante{

        public ObservableCollection<TSolicitante> Lista;
        /// <summary>
        /// Introduzca la cedula del docente para recuperar los representantes.
        /// </summary>
        /// <param name="cedula"></param>
        public Solicitante(string cedula){
            this.Lista = new ObservableCollection<TSolicitante>();
            ////Capturando dirección.
            //Empresa.Comun.EnlaceContacto cont;

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@doc_cedula", cedula);
            TSolicitante solicitante;

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Pensiones_SolicitantesViewC", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                //solicitante = new RHH.Persona(fila["spjsol_cedula"].ToString())[0]; 
                
                solicitante = new TSolicitante(new RHH.Persona(fila["spjsol_cedula"].ToString())[0]);
                
                solicitante.Id = Convert.ToInt32(fila["spjsol_id"]);
                solicitante.Otros = fila["spjsol_otros"].ToString();
                solicitante.Tipo = TipoSolicitante.GetInstance().GetItem(Convert.ToInt32(fila["spjtsol_id"]));

                //Buscando Direccion
                solicitante.DireccionAsignada = new Comun.DireccionAsignada(solicitante.Cedula, 3).GetLast();
                // Busqueda de Contacto.
                solicitante.Contacto = new Comun.ContactoAsignado(solicitante.Cedula).GetLast();  

                this.Lista.Add(solicitante);
            }
        }

        public Solicitante() {
            this.Lista = new ObservableCollection<TSolicitante>();
        }

        /// <summary>
        /// Devuelve un Item.
        /// </summary>
        /// <returns></returns>
        public TSolicitante GetItem(string cedula)
        {
            foreach (TSolicitante item in this.Lista){
                if (item.Cedula.Equals(cedula)) return item;
            }
            return new TSolicitante();
        }

        public TSolicitante GetFirtItem() {
            if (this.Lista.Count > 0){
                return this.Lista[0];
            }
            else { 
                return new TSolicitante();
            }
        }

        public TSolicitante GetItem(int id)
        {
            return new TSolicitante();
        }

        /// <summary>
        /// Inserta un nuevo Item.
        /// </summary>
        /// <param name="item"></param>
        public void Insert(tdocente item){
            ///direccion y contacto para solicitante.
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@doc_cedula", item.Cedula);
            consulta.Parameters.Add("@spjsol_cedula", item.SolicitudPJ.Actual.Solicitante.Cedula);
            consulta.Parameters.Add("@cont_id", item.SolicitudPJ.Actual.Solicitante.Contacto.Id);
            consulta.Parameters.Add("@dire_id", item.SolicitudPJ.Actual.Solicitante.Direccion.Id);
            consulta.Parameters.Add("@spjtsol_id", item.SolicitudPJ.Actual.Solicitante.Tipo.Id);
            consulta.Parameters.Add("@spjsol_otros", item.SolicitudPJ.Actual.Solicitante.Otros);
            consulta.Execute.NoQuery("dbo.Pensiones_SolicitantesInsert", System.Data.CommandType.StoredProcedure);

            Empresa.Comun.DireccionAsignada dires = new Comun.DireccionAsignada();
            Empresa.Comun.ContactoAsignado contas = new Comun.ContactoAsignado();

            //Actualizando Registros de Dirección, de localidad del docente.
            if (item.SolicitudPJ.Actual.Solicitante.DireccionAsignada.Existe){
                //Existe
                dires.Update(item.SolicitudPJ.Actual.Solicitante.DireccionAsignada);
            }
            else {
                //No Existe 
                //Por defecto 1, Localidad.
                dires.Insert(item.SolicitudPJ.Actual.Solicitante.Cedula, item.SolicitudPJ.Actual.Solicitante.DireccionAsignada, 3);
            }

            // Actualizando Registro de Contacto.
            if (item.SolicitudPJ.Actual.Solicitante.Contacto.Existe){
                //Existe 
                contas.Update(item.SolicitudPJ.Actual.Solicitante.Contacto);
            }
            else{
                //Existe No
                contas.Insert(item.SolicitudPJ.Actual.Solicitante.Cedula, item.SolicitudPJ.Actual.Solicitante.Contacto);
            }

        }

        public void Insert(tsolicitudpj item, string docentecedula)
        {
            ///direccion y contacto para solicitante.
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@doc_cedula", docentecedula);
            consulta.Parameters.Add("@spjsol_cedula", item.Solicitante.Cedula);
            consulta.Parameters.Add("@cont_id", item.Solicitante.Contacto.Id);
            consulta.Parameters.Add("@dire_id", item.Solicitante.Direccion.Id);
            consulta.Parameters.Add("@spjtsol_id", item.Solicitante.Tipo.Id);
            consulta.Parameters.Add("@spjsol_otros", item.Solicitante.Otros);
            consulta.Execute.NoQuery("dbo.Pensiones_SolicitantesInsert", System.Data.CommandType.StoredProcedure);

            Empresa.Comun.DireccionAsignada dires = new Comun.DireccionAsignada();
            Empresa.Comun.ContactoAsignado contas = new Comun.ContactoAsignado();

            //Actualizando Registros de Dirección, de localidad del docente.
            if (item.Solicitante.DireccionAsignada.Existe){
                //Existe
                dires.Update(item.Solicitante.DireccionAsignada);
            }
            else{
                //No Existe 
                //Por defecto 1, Localidad.
                dires.Insert(item.Solicitante.Cedula, item.Solicitante.DireccionAsignada, 3);
            }

            // Actualizando Registro de Contacto.
            if (item.Solicitante.Contacto.Existe){
                //Existe 
                contas.Update(item.Solicitante.Contacto);
            }
            else{
                //Existe No
                contas.Insert(item.Solicitante.Cedula, item.Solicitante.Contacto);
            }

        }


        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="item"></param>
        public void Update(tdocente item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@spjsol_id", item.SolicitudPJ.Actual.Solicitante.Id);
            consulta.Parameters.Add("@spjsol_cedula", item.SolicitudPJ.Actual.Solicitante.Cedula);
            consulta.Parameters.Add("@spjtsol_id", item.SolicitudPJ.Actual.Solicitante.Tipo.Id);
            consulta.Parameters.Add("@spjsol_otros", item.SolicitudPJ.Actual.Solicitante.Otros);
            consulta.Execute.NoQuery("dbo.Pensiones_SolicitantesUpdate", System.Data.CommandType.StoredProcedure);

            Empresa.Comun.DireccionAsignada dires = new Comun.DireccionAsignada();
            Empresa.Comun.ContactoAsignado contas = new Comun.ContactoAsignado();

            //Actualizando Registros de Dirección, de localidad del docente.
            if (item.SolicitudPJ.Actual.Solicitante.DireccionAsignada.Existe){
                //Existe
                dires.Update(item.SolicitudPJ.Actual.Solicitante.DireccionAsignada);
            }
            else{
                //No Existe 
                //Por defecto 1, Localidad.
                dires.Insert(item.SolicitudPJ.Actual.Solicitante.Cedula, item.SolicitudPJ.Actual.Solicitante.DireccionAsignada, 3);
            }

            // Actualizando Registro de Contacto.
            if (item.SolicitudPJ.Actual.Solicitante.Contacto.Existe){
                //Existe 
                contas.Update(item.SolicitudPJ.Actual.Solicitante.Contacto);
            }
            else{
                //Existe No
                contas.Insert(item.SolicitudPJ.Actual.Solicitante.Cedula, item.SolicitudPJ.Actual.Solicitante.Contacto);
            }

        }


        public void Update(tsolicitudpj item)
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@spjsol_id", item.Solicitante.Id);
            consulta.Parameters.Add("@spjsol_cedula", item.Solicitante.Cedula);
            consulta.Parameters.Add("@spjtsol_id", item.Solicitante.Tipo.Id);
            consulta.Parameters.Add("@spjsol_otros", item.Solicitante.Otros);
            consulta.Execute.NoQuery("dbo.Pensiones_SolicitantesUpdate", System.Data.CommandType.StoredProcedure);

            Empresa.Comun.DireccionAsignada dires = new Comun.DireccionAsignada();
            Empresa.Comun.ContactoAsignado contas = new Comun.ContactoAsignado();

            //Actualizando Registros de Dirección, de localidad del docente.
            if (item.Solicitante.DireccionAsignada.Existe){
                //Existe
                dires.Update(item.Solicitante.DireccionAsignada);
            }
            else{
                //No Existe 
                //Por defecto 1, Localidad.
                dires.Insert(item.Solicitante.Cedula, item.Solicitante.DireccionAsignada, 3);
            }

            // Actualizando Registro de Contacto.
            if (item.Solicitante.Contacto.Existe){
                //Existe 
                contas.Update(item.Solicitante.Contacto);
            }
            else{
                //Existe No
                contas.Insert(item.Solicitante.Cedula, item.Solicitante.Contacto);
            }

        }


    }
}
