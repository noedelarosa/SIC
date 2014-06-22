using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class SeguroFunerario
    {
        public ObservableCollection<tsolicitudfunenario> Lista { get; set; }
        Comun.Parentesco __paren = new Comun.Parentesco();
        public tsolicitudfunenario Actual { get; set; }
        
        private void _setActual(){
           //foreach(tsolicitudfunenario item in this.Lista){ 
           //    if (item.EstadoActual.Estado.Id.Equals(3)){
           //        this.Actual = item;
           //    }
           //    if(item.EstadoActual.Estado.Id.Equals(1) || item.EstadoActual.Estado.Id.Equals(2)) this.Actual = item;
           //}
            if(this.Lista.Count != 0) this.Actual = this.Lista[0];
        }

        public bool ExisteItem(){
            return (this.Lista.Count > 0);
        }

        public SeguroFunerario() {
            this.Lista = new ObservableCollection<tsolicitudfunenario>();
            Actual = new tsolicitudfunenario();
        }

        /// <summary>
        /// Id de la solicitud.
        /// </summary>
        /// <param name="id"></param>
        public SeguroFunerario(int id){
            this.Lista = new ObservableCollection<tsolicitudfunenario>();
            _setActual();
        }

        /// <summary>
        /// Docente fallecido.
        /// </summary>
        /// <param name="cedula"></param>
        public SeguroFunerario(tdocente docente){
            this.Lista = new ObservableCollection<tsolicitudfunenario>();
            this._constructor(docente.Cedula); 
            _setActual();
        }


        /// <summary>
        /// Cedula del solicitante.
        /// </summary>
        /// <param name="cedula"></param>
        public SeguroFunerario(string cedula){
            this.Lista = new ObservableCollection<tsolicitudfunenario>();
            this._constructor(cedula); 
        }


        private void _constructor(string cedula)
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@solsf_cedula", cedula);

            tsolicitudfunenario sol;
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.SeguroFunerario_Solicitud_View", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                sol = new tsolicitudfunenario();

                sol.Id = Convert.ToInt32(fila["solsf_id"]);
                sol.Fecha = fila["solsf_fecha"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["solsf_fecha"]);
                sol.FechaEntrada = fila["solsf_fechaentrada"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["solsf_fechaentrada"]);
                sol.Numero = fila["solsf_noexpediente"].ToString();
                sol.Detalle = fila["solsf_detalle"].ToString();
                sol.Docente = new tdocente(fila["solsf_cedula"].ToString());
                sol.Porciento = Convert.ToInt32(fila["solsf_porciento"]);
                sol.EsPago = Convert.ToBoolean(fila["solsf_espago"]);

                testadoasignado _estado = new testadoasignado();

                _estado.Id = Convert.ToInt32(fila["esolsfa_id"]);
                _estado.Fecha = fila["esolsfa_fecha"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["esolsfa_fecha"]);
                _estado.Estado = new Comun.TEstandar(fila["esolsf_nombre"].ToString(), string.Empty, Convert.ToInt32(fila["esolsf_id"]));

                sol.EstadoActual = _estado;
                sol.EstadoPago = Empresa.Comun.EstadoPago.GetInstance().GetItem(Convert.ToInt32(fila["estp_id"]));
                sol.Existe = true;
                //Recuperando Solicitante.
                sol.Solicitante = new SolicitanteSeguroFunerario(sol).Solicitante;

                //Recuperando Beneficiarios.
                sol.Beneficiarios = new BeneficiariosSeguroFunerario(sol).Lista;
                //Estableciendo el primer beneficiario
                if (sol.Beneficiarios.Count > 0) sol.DamePrimerBeneficiario = sol.Beneficiarios[0];

                //Recuperando Requisitos
                sol.Requisitos = new RequisitosAsignadorSeguroFunerario(sol).Lista;

                //Estableciendo Tiempos.
                sol.Tiempos = new TiempoSolicitudSeguroFunerario(sol);

                //Añadiendo A la Lista.
                this.Lista.Add(sol);
            }
            _setActual();
        }


        private void _constructor(Empresa.Comun.TEstandar estado, string numero){

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            consulta.Parameters.Add("@p_estado", estado.Id.Equals(0) ? string.Empty : estado.Id.ToString());
            consulta.Parameters.Add("@p_numero", numero);

            tsolicitudfunenario sol;

            Empresa.Comun.Parentesco paren = new Empresa.Comun.Parentesco();
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.[SeguroFunerario_Solicitud_View_Estado_Numero]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                sol = new tsolicitudfunenario();

                sol.Id = Convert.ToInt32(fila["solsf_id"]);
                sol.Fecha = fila["solsf_fecha"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["solsf_fecha"]);
                sol.FechaEntrada = fila["solsf_fechaentrada"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["solsf_fechaentrada"]);
                sol.Numero = fila["solsf_noexpediente"].ToString();
                sol.Detalle = fila["solsf_detalle"].ToString();
                sol.Docente = new tdocente(fila["solsf_cedula"].ToString());
                sol.Porciento = Convert.ToInt32(fila["solsf_porciento"]);
                sol.Monto = Convert.ToDouble(fila["solsf_monto"]);

                sol.EsPago = Convert.ToBoolean(fila["solsf_espago"]);
                testadoasignado _estado = new testadoasignado();

                _estado.Id = Convert.ToInt32(fila["esolsfa_id"]);
                _estado.Fecha = fila["esolsfa_fecha"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["esolsfa_fecha"]);
                _estado.Estado = new Comun.TEstandar(fila["esolsf_nombre"].ToString(), string.Empty, Convert.ToInt32(fila["esolsf_id"]));
                sol.EstadoActual = _estado;
                sol.Existe = true;

                sol.Docente = new tdocente();
                sol.Docente.Cedula = fila["solsf_cedula"].ToString();
                sol.Docente.Nombres = fila["nombres"].ToString();
                sol.Docente.Apellidos = fila["apellidos"].ToString();
                sol.EstadoPago = Empresa.Comun.EstadoPago.GetInstance().GetItem(Convert.ToInt32(fila["estp_id"]));

                sol.Beneficiarios = new ObservableCollection<tpersonaRelacionada>();
                tpersonaRelacionada _bene = new tpersonaRelacionada();

                _bene.EsNuevo = false;
                _bene.Parentesco = new Comun.TEstandar(fila["parn_nombres_bene"].ToString(), string.Empty);
                _bene.Persona.Cedula = fila["cedula_bene"].ToString();
                _bene.Persona.Nombres = fila["nombres_bene"].ToString();
                _bene.Persona.Apellidos = fila["apellidos_bene"].ToString();


                sol.Beneficiarios.Add(_bene);
                if (sol.Beneficiarios.Count > 0) sol.DamePrimerBeneficiario = sol.Beneficiarios[0];

                //Estableciendo Tiempos.
                sol.Tiempos = new TiempoSolicitudSeguroFunerario(sol);
                //Añadiendo A la Lista.
                this.Lista.Add(sol);
            }


        
        }

        private void _constructor(DateTime fechainicio, DateTime fechafinal, Empresa.Comun.TEstandar estado, string numero){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@p_finicio", fechainicio);
            consulta.Parameters.Add("@p_ffinal", fechafinal);
            consulta.Parameters.Add("@p_estado", estado.Id.Equals(0) ? string.Empty: estado.Id.ToString());
            consulta.Parameters.Add("@p_numero", numero);
            tsolicitudfunenario sol;

            Empresa.Comun.Parentesco paren = new Empresa.Comun.Parentesco();
            foreach(System.Data.DataRow fila in consulta.Execute.Dataset("dbo.SeguroFunerario_Solicitud_View_C", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                sol = new tsolicitudfunenario();

                sol.Id = Convert.ToInt32(fila["solsf_id"]);
                sol.Fecha = fila["solsf_fecha"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["solsf_fecha"]);
                sol.FechaEntrada = fila["solsf_fechaentrada"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["solsf_fechaentrada"]);
                sol.Numero = fila["solsf_noexpediente"].ToString();
                sol.Detalle = fila["solsf_detalle"].ToString();
                sol.Docente = new tdocente(fila["solsf_cedula"].ToString());
                sol.Porciento = Convert.ToInt32(fila["solsf_porciento"]);
                sol.Monto = Convert.ToDouble(fila["solsf_monto"]);

                sol.EsPago = Convert.ToBoolean(fila["solsf_espago"]);
                testadoasignado _estado = new testadoasignado();

                _estado.Id = Convert.ToInt32(fila["esolsfa_id"]);
                _estado.Fecha = fila["esolsfa_fecha"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["esolsfa_fecha"]);
                _estado.Estado = new Comun.TEstandar(fila["esolsf_nombre"].ToString(), string.Empty, Convert.ToInt32(fila["esolsf_id"]));
                sol.EstadoActual = _estado;
                sol.Existe = true;

                sol.Docente = new tdocente();
                sol.Docente.Cedula = fila["solsf_cedula"].ToString();
                sol.Docente.Nombres = fila["nombres"].ToString();
                sol.Docente.Apellidos = fila["apellidos"].ToString();
                sol.EstadoPago = Empresa.Comun.EstadoPago.GetInstance().GetItem(Convert.ToInt32(fila["estp_id"]));

                sol.Beneficiarios = new ObservableCollection<tpersonaRelacionada>();
                tpersonaRelacionada _bene =new tpersonaRelacionada();
                
                _bene.EsNuevo = false;
                _bene.Parentesco = new Comun.TEstandar(fila["parn_nombres_bene"].ToString(), string.Empty);
                _bene.Persona.Cedula = fila["cedula_bene"].ToString();
                _bene.Persona.Nombres = fila["nombres_bene"].ToString();
                _bene.Persona.Apellidos = fila["apellidos_bene"].ToString();


                sol.Beneficiarios.Add(_bene);
                if(sol.Beneficiarios.Count > 0) sol.DamePrimerBeneficiario = sol.Beneficiarios[0];

                //Estableciendo Tiempos.
                sol.Tiempos = new TiempoSolicitudSeguroFunerario(sol);
                //Añadiendo A la Lista.
                this.Lista.Add(sol);
            }

        }

        private void _constructor(Empresa.Comun.TEstandar estado, string numero, string ceduladocente, string nombredocente, string cedulabeneficiario, string nombrebeneficiario) {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            //consulta.Parameters.Add("@p_finicio", fechainicio);
            //consulta.Parameters.Add("@p_ffinal", fechafinal);
            consulta.Parameters.Add("@p_estado", estado.Id.Equals(0) ? string.Empty : estado.Id.ToString());
            consulta.Parameters.Add("@p_numero", numero);

            consulta.Parameters.Add("@p_cedula_docente", ceduladocente);
            consulta.Parameters.Add("@p_nombre_docente", nombredocente);
            consulta.Parameters.Add("@p_cedula_beneficiario", cedulabeneficiario);
            consulta.Parameters.Add("@p_nombre_beneficiario", nombrebeneficiario);

            tsolicitudfunenario sol;
            Empresa.Comun.Parentesco paren = new Empresa.Comun.Parentesco();

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.[SeguroFunerario_Solicitud_View_C_Avanzada_02]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                sol = new tsolicitudfunenario();

                sol.Id = Convert.ToInt32(fila["solsf_id"]);
                sol.Fecha = fila["solsf_fecha"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["solsf_fecha"]);
                sol.FechaEntrada = fila["solsf_fechaentrada"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["solsf_fechaentrada"]);
                sol.Numero = fila["solsf_noexpediente"].ToString();
                sol.Detalle = fila["solsf_detalle"].ToString();
                sol.Docente = new tdocente(fila["solsf_cedula"].ToString());
                sol.Monto = Convert.ToDouble(fila["solsf_monto"]);
                sol.Porciento = Convert.ToInt32(fila["solsf_porciento"]);
                sol.EsPago = Convert.ToBoolean(fila["solsf_espago"]);
                testadoasignado _estado = new testadoasignado();

                _estado.Id = Convert.ToInt32(fila["esolsfa_id"]);
                _estado.Fecha = fila["esolsfa_fecha"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["esolsfa_fecha"]);
                _estado.Estado = new Comun.TEstandar(fila["esolsf_nombre"].ToString(), string.Empty, Convert.ToInt32(fila["esolsf_id"]));
                sol.EstadoActual = _estado;
                sol.Existe = true;
                sol.EstadoPago = Empresa.Comun.EstadoPago.GetInstance().GetItem(Convert.ToInt32(fila["estp_id"]));

                sol.Docente = new tdocente();
                sol.Docente.Cedula = fila["solsf_cedula"].ToString();
                sol.Docente.Nombres = fila["nombres"].ToString();
                sol.Docente.Apellidos = fila["apellidos"].ToString();


                sol.Beneficiarios = new ObservableCollection<tpersonaRelacionada>();
                tpersonaRelacionada _bene = new tpersonaRelacionada();

                _bene.EsNuevo = false;
                _bene.Parentesco = new Comun.TEstandar(fila["parn_nombres_bene"].ToString(), string.Empty);
                _bene.Persona.Cedula = fila["cedula_bene"].ToString();
                _bene.Persona.Nombres = fila["nombres_bene"].ToString();
                _bene.Persona.Apellidos = fila["apellidos_bene"].ToString();

                sol.Beneficiarios.Add(_bene);
                if (sol.Beneficiarios.Count > 0) sol.DamePrimerBeneficiario = sol.Beneficiarios[0];


                //sol.Solicitante = new TSolicitante();
                //sol.Solicitante.Cedula= fila["solisf_cedula"].ToString();
                //sol.Solicitante.Nombres= fila["nombres_soli"].ToString();
                //sol.Solicitante.Apellidos = fila["apellidos_soli"].ToString();
                //sol.Solicitante.Parentesco = paren.GetItem(Convert.ToInt32(fila["parn_id"]));

                //Estableciendo Tiempos.
                sol.Tiempos = new TiempoSolicitudSeguroFunerario(sol);

                //Añadiendo A la Lista.
                this.Lista.Add(sol);
            }
            


        }

        private void _constructor(DateTime fechainicio, DateTime fechafinal, Empresa.Comun.TEstandar estado, string numero, string ceduladocente, string nombredocente, string cedulabeneficiario, string nombrebeneficiario) {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@p_finicio", fechainicio);
            consulta.Parameters.Add("@p_ffinal", fechafinal);
            consulta.Parameters.Add("@p_estado", estado.Id.Equals(0) ? string.Empty : estado.Id.ToString());
            consulta.Parameters.Add("@p_numero", numero);

            consulta.Parameters.Add("@p_cedula_docente", ceduladocente);
            consulta.Parameters.Add("@p_nombre_docente", nombredocente);
            consulta.Parameters.Add("@p_cedula_beneficiario", cedulabeneficiario);
            consulta.Parameters.Add("@p_nombre_beneficiario", nombrebeneficiario);

            tsolicitudfunenario sol;
            Empresa.Comun.Parentesco paren = new Empresa.Comun.Parentesco();

            foreach(System.Data.DataRow fila in consulta.Execute.Dataset("dbo.SeguroFunerario_Solicitud_View_C_Avanzada", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                sol = new tsolicitudfunenario();

                sol.Id = Convert.ToInt32(fila["solsf_id"]);
                sol.Fecha = fila["solsf_fecha"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["solsf_fecha"]);
                sol.FechaEntrada = fila["solsf_fechaentrada"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["solsf_fechaentrada"]);
                sol.Numero = fila["solsf_noexpediente"].ToString();
                sol.Detalle = fila["solsf_detalle"].ToString();
                sol.Docente = new tdocente(fila["solsf_cedula"].ToString());
                sol.Monto = Convert.ToDouble(fila["solsf_monto"]);
                sol.Porciento = Convert.ToInt32(fila["solsf_porciento"]);
                sol.EsPago = Convert.ToBoolean(fila["solsf_espago"]);
                testadoasignado _estado = new testadoasignado();

                _estado.Id = Convert.ToInt32(fila["esolsfa_id"]);
                _estado.Fecha = fila["esolsfa_fecha"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["esolsfa_fecha"]);
                _estado.Estado = new Comun.TEstandar(fila["esolsf_nombre"].ToString(), string.Empty, Convert.ToInt32(fila["esolsf_id"]));
                sol.EstadoActual = _estado;
                sol.Existe = true;
                sol.EstadoPago = Empresa.Comun.EstadoPago.GetInstance().GetItem(Convert.ToInt32(fila["estp_id"]));

                sol.Docente = new tdocente();
                sol.Docente.Cedula = fila["solsf_cedula"].ToString();
                sol.Docente.Nombres = fila["nombres"].ToString();
                sol.Docente.Apellidos = fila["apellidos"].ToString();
                

                sol.Beneficiarios = new ObservableCollection<tpersonaRelacionada>();
                tpersonaRelacionada _bene = new tpersonaRelacionada();

                _bene.EsNuevo = false;
                _bene.Parentesco = new Comun.TEstandar(fila["parn_nombres_bene"].ToString(), string.Empty);
                _bene.Persona.Cedula = fila["cedula_bene"].ToString();
                _bene.Persona.Nombres = fila["nombres_bene"].ToString();
                _bene.Persona.Apellidos = fila["apellidos_bene"].ToString();

                sol.Beneficiarios.Add(_bene);
                if (sol.Beneficiarios.Count > 0) sol.DamePrimerBeneficiario = sol.Beneficiarios[0];


                //sol.Solicitante = new TSolicitante();
                //sol.Solicitante.Cedula= fila["solisf_cedula"].ToString();
                //sol.Solicitante.Nombres= fila["nombres_soli"].ToString();
                //sol.Solicitante.Apellidos = fila["apellidos_soli"].ToString();
                //sol.Solicitante.Parentesco = paren.GetItem(Convert.ToInt32(fila["parn_id"]));

                //Estableciendo Tiempos.
                sol.Tiempos = new TiempoSolicitudSeguroFunerario(sol);

                //Añadiendo A la Lista.
                this.Lista.Add(sol);
            }
            
            

        }

        public void _constructor(Empresa.Comun.TEstandar estado, Empresa.Comun.TEstandar estadopago)
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@p_estado", estado.Id);
            consulta.Parameters.Add("@p_estado_pago", estadopago.Id.Equals(0) ? string.Empty : estadopago.Id.ToString());

            tsolicitudfunenario sol;

            Empresa.Comun.Parentesco paren = new Empresa.Comun.Parentesco();
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[SeguroFunerario_Solicitud_View_Estados]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                sol = new tsolicitudfunenario();

                sol.Id = Convert.ToInt32(fila["solsf_id"]);
                sol.Fecha = fila["solsf_fecha"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["solsf_fecha"]);
                sol.FechaEntrada = fila["solsf_fechaentrada"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["solsf_fechaentrada"]);
                sol.Numero = fila["solsf_noexpediente"].ToString();
                sol.Detalle = fila["solsf_detalle"].ToString();
                sol.Docente = new tdocente(fila["solsf_cedula"].ToString());
                sol.Porciento = Convert.ToInt32(fila["solsf_porciento"]);
                sol.Monto = Convert.ToDouble(fila["solsf_monto"]);

                var r = fila["solsf_espago"];
                sol.EsPago = Convert.ToBoolean(fila["solsf_espago"]);
                testadoasignado _estado = new testadoasignado();

                _estado.Id = Convert.ToInt32(fila["esolsfa_id"]);
                _estado.Fecha = fila["esolsfa_fecha"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["esolsfa_fecha"]);
                _estado.Estado = new Comun.TEstandar(fila["esolsf_nombre"].ToString(), string.Empty, Convert.ToInt32(fila["esolsf_id"]));
                sol.EstadoActual = _estado;
                sol.Existe = true;

                sol.Docente = new tdocente();
                sol.Docente.Cedula = fila["solsf_cedula"].ToString();
                sol.Docente.Nombres = fila["nombres"].ToString();
                sol.Docente.Apellidos = fila["apellidos"].ToString();
                sol.EstadoPago = Empresa.Comun.EstadoPago.GetInstance().GetItem(Convert.ToInt32(fila["estp_id"]));

                sol.Beneficiarios = new ObservableCollection<tpersonaRelacionada>();
                tpersonaRelacionada _bene = new tpersonaRelacionada();

                _bene.EsNuevo = false;
                _bene.Parentesco = new Comun.TEstandar(fila["parn_nombres_bene"].ToString(), string.Empty);
                _bene.Persona.Cedula = fila["cedula_bene"].ToString();
                _bene.Persona.Nombres = fila["nombres_bene"].ToString();
                _bene.Persona.Apellidos = fila["apellidos_bene"].ToString();


                sol.Beneficiarios.Add(_bene);
                if (sol.Beneficiarios.Count > 0) sol.DamePrimerBeneficiario = sol.Beneficiarios[0];

                //Estableciendo Tiempos.
                sol.Tiempos = new TiempoSolicitudSeguroFunerario(sol);
                //Añadiendo A la Lista.
                this.Lista.Add(sol);
            }


        }

        public void _constructor(Empresa.Comun.TEstandar estado, Empresa.Comun.TEstandar estadopago, DateTime fechainicio, DateTime fechafinal)
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@p_finicio", fechainicio);
            consulta.Parameters.Add("@p_ffinal", fechafinal);

            consulta.Parameters.Add("@p_estado", estado.Id);
            consulta.Parameters.Add("@p_estado_pago", estadopago.Id.Equals(0) ? string.Empty : estadopago.Id.ToString());

            tsolicitudfunenario sol;
            Empresa.Comun.Parentesco paren = new Empresa.Comun.Parentesco();
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[SeguroFunerario_Solicitud_View_Estados_Fecha]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                sol = new tsolicitudfunenario();

                sol.Id = Convert.ToInt32(fila["solsf_id"]);
                sol.Fecha = fila["solsf_fecha"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["solsf_fecha"]);
                sol.FechaEntrada = fila["solsf_fechaentrada"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["solsf_fechaentrada"]);
                sol.Numero = fila["solsf_noexpediente"].ToString();
                sol.Detalle = fila["solsf_detalle"].ToString();
                sol.Docente = new tdocente(fila["solsf_cedula"].ToString());
                sol.Porciento = Convert.ToInt32(fila["solsf_porciento"]);
                sol.Monto = Convert.ToDouble(fila["solsf_monto"]);

                var r = fila["solsf_espago"];
                sol.EsPago = Convert.ToBoolean(fila["solsf_espago"]);
                testadoasignado _estado = new testadoasignado();

                _estado.Id = Convert.ToInt32(fila["esolsfa_id"]);
                _estado.Fecha = fila["esolsfa_fecha"] == null ? DateTime.MinValue : Convert.ToDateTime(fila["esolsfa_fecha"]);
                _estado.Estado = new Comun.TEstandar(fila["esolsf_nombre"].ToString(), string.Empty, Convert.ToInt32(fila["esolsf_id"]));
                sol.EstadoActual = _estado;
                sol.Existe = true;

                sol.Docente = new tdocente();
                sol.Docente.Cedula = fila["solsf_cedula"].ToString();
                sol.Docente.Nombres = fila["nombres"].ToString();
                sol.Docente.Apellidos = fila["apellidos"].ToString();
                sol.EstadoPago = Empresa.Comun.EstadoPago.GetInstance().GetItem(Convert.ToInt32(fila["estp_id"]));

                sol.Beneficiarios = new ObservableCollection<tpersonaRelacionada>();
                tpersonaRelacionada _bene = new tpersonaRelacionada();

                _bene.EsNuevo = false;
                _bene.Parentesco = new Comun.TEstandar(fila["parn_nombres_bene"].ToString(), string.Empty);
                _bene.Persona.Cedula = fila["cedula_bene"].ToString();
                _bene.Persona.Nombres = fila["nombres_bene"].ToString();
                _bene.Persona.Apellidos = fila["apellidos_bene"].ToString();


                sol.Beneficiarios.Add(_bene);
                if (sol.Beneficiarios.Count > 0) sol.DamePrimerBeneficiario = sol.Beneficiarios[0];

                //Estableciendo Tiempos.
                sol.Tiempos = new TiempoSolicitudSeguroFunerario(sol);
                //Añadiendo A la Lista.
                this.Lista.Add(sol);
            }



        
        }

        public SeguroFunerario(Empresa.Comun.TEstandar estado, Empresa.Comun.TEstandar estadopago, DateTime fechainicio, DateTime fechafinal)
        {
            this.Lista = new ObservableCollection<tsolicitudfunenario>();
            this._constructor(estado, estadopago, fechainicio, fechafinal);
        }

        public SeguroFunerario(Empresa.Comun.TEstandar estado, string numero)
        {
            this.Lista = new ObservableCollection<tsolicitudfunenario>();
            this._constructor(estado, numero);
        }

        public  SeguroFunerario(Empresa.Comun.TEstandar estado, Empresa.Comun.TEstandar estadopago)
        {
            this.Lista = new ObservableCollection<tsolicitudfunenario>();
            this._constructor(estado, estadopago);
        }

        public SeguroFunerario(DateTime fechainicio, DateTime fechafinal, Empresa.Comun.TEstandar estado, string numero){
            this.Lista = new ObservableCollection<tsolicitudfunenario>();   
            this._constructor(fechainicio, fechafinal, estado, numero); 
        }


        // ///
        public SeguroFunerario(Empresa.Comun.TEstandar estado, string numero, string ceduladocente, string nombredocente, string cedulabeneficiario, string nombrebeneficiario)
        {
            this.Lista = new ObservableCollection<tsolicitudfunenario>();
            this._constructor(estado, numero, ceduladocente, nombredocente, cedulabeneficiario, nombrebeneficiario);
        }


        public SeguroFunerario(DateTime fechainicio, DateTime fechafinal, Empresa.Comun.TEstandar estado, string numero, string ceduladocente, string nombredocente, string cedulabeneficiario, string nombrebeneficiario) {
            this.Lista = new ObservableCollection<tsolicitudfunenario>();
            this._constructor(fechainicio, fechafinal, estado, numero, ceduladocente, nombredocente, cedulabeneficiario, nombrebeneficiario); 
        }

        public int Insert(tsolicitudfunenario item){
            int id = 0;
            //Insert solicitud.
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@solsf_detalle", item.Detalle);
            consulta.Parameters.Add("@solsf_cedula", item.Docente.Cedula);
            consulta.Parameters.Add("@solsf_fechaentrada", item.FechaEntrada);
            consulta.Parameters.Add("@solsf_porciento", item.Porciento);
            consulta.Parameters.Add("@solsf_monto", item.Monto);

            using (System.Data.SqlClient.SqlDataReader lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("dbo.SeguroFunerario_SolicitudInsert", System.Data.CommandType.StoredProcedure)){
                if(lector.Read()) {
                    item.Id = Convert.ToInt32(lector[0]);
                    item.Numero = lector[1].ToString();
                }
                else {
                    item.Id = 0;
                    item.Numero = string.Empty;
                }
            }

            //Insertando Estado.
            SeguroFunerarioEstados _estado = new SeguroFunerarioEstados();
            _estado.Insert(item);

            //Insertando Solicitante. 
            //Existe Seleccion de Solicitante.
            if(!string.IsNullOrEmpty(item.Solicitante.Cedula)){
                SolicitanteSeguroFunerario _solicitante = new SolicitanteSeguroFunerario(item.Solicitante.Cedula);

                if(!item.Solicitante.Exite){
                    //Insert
                    _solicitante.Insert(item);
                }
                else{
                    _solicitante.Update(item);
                }
            }

            BeneficiariosSeguroFunerario _beneficiarios = new BeneficiariosSeguroFunerario();
            _beneficiarios.Insert(item);  
            
            //insert Requesitos.
            RequisitosAsignadorSeguroFunerario reqs = new RequisitosAsignadorSeguroFunerario();
            reqs.Insert(item);

            _setActual();
            return id;
        }

        public void Update(tsolicitudfunenario item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@solsf_id", item.Id);
            consulta.Parameters.Add("@solsf_detalle", item.Detalle);
            consulta.Parameters.Add("@solsf_cedula", item.Docente.Cedula);
            consulta.Parameters.Add("@solsf_fechaentrada", item.FechaEntrada);
            consulta.Parameters.Add("@solsf_porciento", item.Porciento);
            consulta.Parameters.Add("@solsf_monto", item.Monto);

            consulta.Execute.NoQuery("dbo.SeguroFunerario_SolicitudUpdate", System.Data.CommandType.StoredProcedure);
            //Insertando Estado.
            //SeguroFunerarioEstados _estado = new SeguroFunerarioEstados();
            //_estado.Insert(item);

            //Insertando Solicitante. 
            //Existe Seleccion de Solicitante.
            if(!string.IsNullOrEmpty(item.Solicitante.Cedula)){
                SolicitanteSeguroFunerario _solicitante = new SolicitanteSeguroFunerario(item.Solicitante.Cedula);

                if (!item.Solicitante.Exite){
                    //Insert
                    _solicitante.Insert(item);
                }
                else{
                    _solicitante.Update(item);
                }
            }
            //Beneficiario
            BeneficiariosSeguroFunerario _beneficiarios = new BeneficiariosSeguroFunerario();

            foreach (Empresa.Docente.tpersonaRelacionada per in item.Beneficiarios) {
                if(per.EsNuevo)
                {
                    _beneficiarios.Insert(per,item.Id);
                }
                else{
                    _beneficiarios.Update(per,item.Id);
                }
            }

            //Update Requisitos.
            RequisitosAsignadorSeguroFunerario reqs = new RequisitosAsignadorSeguroFunerario();
            reqs.Update(item);
            _setActual();
            // return id;
        }

        public void CambioEstadoPago(tsolicitudfunenario item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            consulta.Parameters.Add("@solsf_id", item.Id);
            consulta.Parameters.Add("@estp_id", item.EstadoPago.Id);
            consulta.Parameters.Add("@solsf_espago", item.EstadoPago.Id == 2?1:0);

            consulta.Execute.NoQuery("dbo.SeguroFunerario_Solicitud_Update_Cambio_EsPagado", System.Data.CommandType.StoredProcedure);
        }

    }
}
