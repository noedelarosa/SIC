using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIC.UI
{
    /// <summary>
    /// Interaction logic for areatrabajo.xaml
    /// </summary>
    public partial class areatrabajo : UserControl, Empresa.Comun.IFirma
    {


        private void AppSecurity(){
           //But_Entrar_PJ.IsEnabled = Empresa.USeguridad.Seccion.PermisoAutorizado(this.CModulo, new Empresa.USeguridad.TBoleto(new Empresa.USeguridad.TPermiso(0), new Empresa.USeguridad.TAccion(0)));
        }

      
      
        public enum ESeleccion{
            SOLICITUD_DISCAPACIDAD,
            BUSQUEDA_DISCAPACIDAD,
            SCAN,
            PRESENTACION,
            SOBREVIVENCIA,
            LIMITEEDAD,
            PROYECCION,
            NOTIFICACION,
            DECRETOS,
            EXCLUIDOS,
            NULA,
            SEGUROFUNERARIO,
            SEGUROFUNERARIOVISTA,
            LISTASERVICIOS
        }

        public enum ESubSeleccionSolicitud_Discapcidad { 
            Vista,
            Solicitud,
            NULA
        }

        public ESubSeleccionSolicitud_Discapcidad SubSeleccionSolicitud_Discapcidad;

        public bool _debolimpiar = true;
        public ESeleccion SeleccionActual;
        public SIC.Objs.Controles.Dialogos.Dial_SeleccionPagina_01 _DialogoPaginas_01;
        private us_mantenimiento_procesos proc;
		private us_pensionsobrev_vista visps;
        
        //staticos
        private UI.Presentacion presen = new Presentacion();
        private SIC.Objs.Controles.Screenw scn = new SIC.Objs.Controles.Screenw();
        private SIC.Objs.Controles.ListadoTrabajos listatrabajos;
        private SIC.Objs.Controles.us_ScanActas scanactas;
        private SIC.Objs.Controles.us_Mantenimiento_Decreto _us_Mantenimiento_Decreto;
        private SIC.Objs.Controles.us_MantenimientoListadoDecreto _us_MantenimientoListadoDecreto;
        private us_Proceso_SeguroFunerario _us_Proceso_SeguroFunerario;
        private SIC.Objs.Controles.us_vista_solicitudes_pj us_vistasolicutd_pj;
        private SIC.Objs.Controles.us_Busqueda_Solicitudes_PJ us_Busqueda_pension_discapacidad;
        private SIC.Objs.us_vista_solicitud_segurofunerario _us_vista_solicitud_segurofunerario;
        private SIC.Objs.Controles.BusquedaListaPensionado _BusquedaListaPensionado;
        private SIC.Objs.Controles.ListaPensionadosBeneficio _ListaPensionado;
        private SIC.Objs.Controles.us_ConsultaDependientes _ConsultaDependientes;
        private SIC.Objs.Controles.us_ConsultaDependientes_LimitePension _ConsultaDependientesLimitePension;
        private SIC.Objs.Controles.us_ConsultaDependientes_NotificacionExclucion _ConsultaDependientes_NotificacionExclucion;
        private SIC.Objs.Controles.us_ListaExcluidos _us_ListaExcluidos;
        private SIC.Objs.Controles.us_busquedaDependientes _us_busquedaDependientes;
        private SIC.Objs.Controles.SeguroFunerario.us_segurofunerario_aprobacion _us_segurofunerario_aprobacion;
        private SIC.Objs.Controles.Win_Docente_Detalle _detalledocente;
        private SIC.Objs.Controles.SeguroFunerario.us_cambiar_estado_pagado _us_cambiar_estado_pagado;
        private SIC.Objs.Controles.us_notificacionFallecimiento _us_notificacionFallecimiento;
        private bool __doc_guardado = false;



        public areatrabajo()
        {
            InitializeComponent();

            usc_buscardocente.But_PJ.Click += But_PJ_Click;
            usc_buscardocente.But_PS.Click += But_PS_Click;
            usc_buscardocente.But_Actas.Click += But_Actas_Click;
            usc_buscardocente.But_Dependientes.Click += But_Dependientes_Click;
            usc_buscardocente.But_Decretos.Click += But_Decretos_Click;
            usc_buscardocente.But_SeguroF.Click += But_SF_Click;
            usc_buscardocente.But_PDiscapacidad.Click += But_Pension_Discapacidad_General_Click;
            usc_buscardocente.But_SeguroFunerario.Click += But_SF_Menu_Click;
            usc_buscardocente.But_PensionBeneficioLista.Click += But_ListadoBeneficioPension_Click;
            usc_buscardocente.LLamandoEstado += LLamando_Estado_Docente;
            usc_buscardocente.But_AprobacionSeguroFunerario.Click += But_SeguroFunerarioAprobaciones_Menu_Click;
            usc_buscardocente.EsResultado += usc_buscardocente_EsResultado;
            usc_buscardocente.TerminadoEdicion += usc_buscardocente_TerminadoEdicion;
            usc_buscardocente.But_MasInformacionGeneral.Click += But_MasInformacionGeneral_Click;
            usc_buscardocente.But_MarcarPagoSeguroFunerario.Click += But_MarcarPagadoSeguroFunerario_Click;
            usc_buscardocente.But_NotificarFallecido.Click += But_NotificarFallecido_Click;

            usc_buscardocente.But_NotificacionFallecidoGeneral.Click += But_NotificarFallecidoGeneral_Click;



            try
            {
                pag_trans.ShowPage(scn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //
        private void But_NotificarFallecidoGeneral_Click(object sender, RoutedEventArgs e) {
            try
            {
                _us_notificacionFallecimiento = new Objs.Controles.us_notificacionFallecimiento();

                pag_trans.ShowPage(_us_notificacionFallecimiento);
            }
            catch { 
            
            }
        }
        private void But_NotificarFallecido_Click(object sender, RoutedEventArgs e){
            SIC.Objs.Controles.Dialogos.Dial_DeseaNotificarFallecido __noti = new Objs.Controles.Dialogos.Dial_DeseaNotificarFallecido();
            Empresa.Comun.EnviarEmail __env;
            try
            {
                if (!this.usc_buscardocente.Docente.EsFallecidoMinimo)
                {
                    __noti.ShowDialog();
                    if (__noti.Resultado == MessageBoxResult.Yes)
                    {
                        Empresa.Docente.NotificadosFallecidos __cnoti = new Empresa.Docente.NotificadosFallecidos();
                        Empresa.Docente.TNotificadosFallecidos __tnoti = new Empresa.Docente.TNotificadosFallecidos();

                        __tnoti.Docente = this.usc_buscardocente.Docente;
                        __tnoti.Descripcion = __noti.Txt_Decripcion.Text;
                        __tnoti.CorreoEnvidado = __noti.EnviarNotificacionEmail;
                        __cnoti.Insert(__tnoti);
                        Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, this.usc_buscardocente.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.RegistroNotificacionFallecido), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName));

                        if (__noti.EnviarNotificacionEmail)
                        {
                            try
                            {
                                __env = new Empresa.Comun.EnviarEmail();
                                //
                                __env.Enviar("miguel.perez@inabima.gob.do,mirla.florentino@inabima.gob.do", "NOTIFICACION DE FALLECIDO - " + this.usc_buscardocente.Docente.CedulaF + " -", " Notificación de fallecido para el docente " + this.usc_buscardocente.Docente.NombreCompleto + ", con cédula No." + this.usc_buscardocente.Docente.CedulaF);
                            }
                            catch
                            {

                            }
                        }
                    }
                    __noti.Close();
                }
                else {
                    MessageBox.Show("No se puede registrar la notificación, pues el docente esta registrado como fallecido.","No se puee regitrar la notificación.",MessageBoxButton.OK,MessageBoxImage.Warning);
                }
            }
            catch {
                __noti.Close();
            }
        }

        private void usc_buscardocente_TerminadoEdicion(object arg) {
            //Actualizando Formulario en funcion a las modificaciones de modificacion del docente.
            try
            {

                switch (this.SeleccionActual)
                {
                    case ESeleccion.SOLICITUD_DISCAPACIDAD:

                        break;
                    case ESeleccion.SOBREVIVENCIA:
                   
                        break;
                    case ESeleccion.LIMITEEDAD:
                   
                        break;
                    case ESeleccion.PROYECCION:
                   
                        break;
                    case ESeleccion.NOTIFICACION:
                   
                        break;
                    case ESeleccion.DECRETOS:
                   
                        break;
                    case ESeleccion.EXCLUIDOS:
                   
                        break;
                    case ESeleccion.BUSQUEDA_DISCAPACIDAD:
                   
                        break;
                    case ESeleccion.SEGUROFUNERARIO:
                        if (usc_buscardocente.Docente.EsFallecido){
                            //Recarculando seguro Funerario.
                            usc_buscardocente.Docente.Calculo_Seguro_Funerario();
                            //Refrescando Interface.
                            _us_Proceso_SeguroFunerario.Refresh(usc_buscardocente.Docente);
                        }
                        else {
                                //Pagina por defecto
                                pag_trans.ShowPage(scn);
                                MessageBox.Show("Para visualizar el formulario de Seguro Funerario, el docente debe tener primero registrada la fecha de fallecimiento.", "El docente debe estar registrado como fallecido.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }

                        break;

                    case ESeleccion.LISTASERVICIOS:
                        //Refrescando Interface.
                        this.listatrabajos.Refresh(usc_buscardocente.Docente);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Empresa.Comun.Mensajes.Documen_No_Seleccionado, "Documento no Seleccionado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        
            
        }

        private void LLamando_Estado_Docente(object arg){
            try{
                SIC.Objs.Controles.us_VisorDocente visor = new Objs.Controles.us_VisorDocente((Empresa.Docente.tdocente)arg, 0);
                pag_trans.ShowPage(visor);
            }
            catch{
                MessageBox.Show("No se puede cargar el estado del docente", "No Estado", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void ItemExisteSeguroFunerario_Seleccionado(object arg) {
            var resultado = (SIC.Objs.Controles.Portadas.ItemExisteSeguroFunerario.EDocumento)arg;
            switch (resultado){
                case Objs.Controles.Portadas.ItemExisteSeguroFunerario.EDocumento.SeguroFunerario:
                    But_SF_Click(null,null);
                    break;
                case Objs.Controles.Portadas.ItemExisteSeguroFunerario.EDocumento.Sobrevivencia:
                    But_PS_Click(null, null);
                    break;
            }
        }



        private void LimpiarVariables(){
                this.SeleccionActual = ESeleccion.NULA; 
                this.SubSeleccionSolicitud_Discapcidad = ESubSeleccionSolicitud_Discapcidad.NULA;
                _DialogoPaginas_01 = null;
                proc= null;
                visps= null;
                scanactas= null;
                _us_Mantenimiento_Decreto= null;
                _us_MantenimientoListadoDecreto= null;
                _us_Proceso_SeguroFunerario= null;
                us_vistasolicutd_pj = null;
                _ConsultaDependientes = null;
                _ConsultaDependientesLimitePension = null;
                _ConsultaDependientes_NotificacionExclucion = null;
                _us_ListaExcluidos = null;
                _us_busquedaDependientes = null;
                __doc_guardado = false;

        }

        private void But_MarcarPagadoSeguroFunerario_Click(object sender, RoutedEventArgs e)
        {
            
            try {
                _us_cambiar_estado_pagado = new Objs.Controles.SeguroFunerario.us_cambiar_estado_pagado();
                this.pag_trans.ShowPage(_us_cambiar_estado_pagado);
            }
            catch {
                

            }

        }

        private void But_AbrirSolicitudPJ_Click(object sender){
            try{

                    //Sub Seleccion de solictud.
                    __doc_guardado = false;
                    this.SubSeleccionSolicitud_Discapcidad = ESubSeleccionSolicitud_Discapcidad.Solicitud;
                    proc = new us_mantenimiento_procesos((Empresa.Docente.tsolicitudpj)sender);
                    pag_trans.ShowPage(proc);
            }
            catch { 
            
            }
        }

        private void But_ListadoBeneficioPension_Click(object sender, RoutedEventArgs e)
        {
            try {
                __doc_guardado = false;
                _BusquedaListaPensionado = new Objs.Controles.BusquedaListaPensionado();
                _BusquedaListaPensionado.Abriendo += But_AbrirListadoBeneficioPensionado_Click;

                pag_trans.ShowPage(_BusquedaListaPensionado);
            }
            catch { }
        }

        private void But_AbrirListadoBeneficioPensionado_Click(object sender) {
            try{
                __doc_guardado = false;
                this._debolimpiar = false;
                _ListaPensionado = new Objs.Controles.ListaPensionadosBeneficio((Empresa.Docente.tlistadopensionadosenbeneficio)sender);
                pag_trans.ShowPage(_ListaPensionado);
            }
            catch { 
            
            }
        }

        private void But_AbrirSolicitudSeguroFunerario_Click(object sender) { 
        
            if(sender != null){
                __doc_guardado = false;
                Empresa.Docente.tsolicitudfunenario sol = (Empresa.Docente.tsolicitudfunenario)sender;
                usc_buscardocente.SetDocente(sol.Docente.Cedula);
                But_SF_Click(null, null);
            }
        }

        private void But_MasInformacionGeneral_Click(object sender, RoutedEventArgs e){
            try
            {
                
                _detalledocente = new Objs.Controles.Win_Docente_Detalle(usc_buscardocente.Docente);
                //Buscar.
                _detalledocente.ShowDialog();
                _detalledocente.Close();
            }
            catch { 
            
            }
        }

        private void But_Pension_Discapacidad_General_Click(object sender, RoutedEventArgs e) {
            __doc_guardado = false;
            this.SeleccionActual = ESeleccion.BUSQUEDA_DISCAPACIDAD;
            us_Busqueda_pension_discapacidad = new Objs.Controles.us_Busqueda_Solicitudes_PJ();
            pag_trans.ShowPage(us_Busqueda_pension_discapacidad);
        }

        private void But_PJ_Click(object sender, RoutedEventArgs e){
            try
            {
                //SOLICITUDPJ
                __doc_guardado = false;
                _debolimpiar = true;
                //Seleccion de Principio
                this.SeleccionActual = ESeleccion.SOLICITUD_DISCAPACIDAD;
                //Sub Seleccion
                this.SubSeleccionSolicitud_Discapcidad = ESubSeleccionSolicitud_Discapcidad.Vista;

                if (!usc_buscardocente.Docente.EsFallecido)
                {
                    // Asignando Solicitud.
                    usc_buscardocente.Docente.SolicitudPJ = new Empresa.Docente.SolicitudPJ(usc_buscardocente.Docente);
                    us_vistasolicutd_pj = new Objs.Controles.us_vista_solicitudes_pj(this.usc_buscardocente.Docente);
                    //vista.Nuevo += But_NuevaSolicitudPj_Click;
                    us_vistasolicutd_pj.Abrir += But_AbrirSolicitudPJ_Click;
                    //vista.Imprimir += But_ImprimirSolicitudPJ_Click;
                    this.pag_trans.ShowPage(us_vistasolicutd_pj);
                }
                else
                {
                    MessageBox.Show("Docente Fallecido no puede entrar en proceso de Pensión o Jubilación.", "Proceso NO Permitido", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
            catch {
                MessageBox.Show("Acceso denegado.", "Acceso denegado", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

		private void But_PS_Click(object sender, RoutedEventArgs e){
            //DISCAPACIDAD
            try
            {
                _debolimpiar = true;
                __doc_guardado = false;
                this.SeleccionActual = ESeleccion.SOBREVIVENCIA;
                try
                {
                    if (usc_buscardocente.Docente.EsRenunciaSobrevivencia)
                    {
                        SIC.Objs.Controles.Dialogos.Dial_DocenteEsRenunciaSobrev dialog_01 = new Objs.Controles.Dialogos.Dial_DocenteEsRenunciaSobrev(usc_buscardocente.Docente);
                        dialog_01.ShowDialog();
                    }
                    else
                    {
                        visps = new us_pensionsobrev_vista(usc_buscardocente.Docente);
                        pag_trans.ShowPage(visps);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch {
                MessageBox.Show("Acceso denegado.", "Acceso denegado", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void But_Actas_Click(object sender, RoutedEventArgs e)
        {
            _debolimpiar = true;
            scanactas = new Objs.Controles.us_ScanActas();
            this.SeleccionActual = ESeleccion.SCAN;
            try
            {
                pag_trans.ShowPage(scanactas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Servicios del Docente.
        private void But_SF_Click(object sender, RoutedEventArgs e) {
            
            try{
                __doc_guardado = false;
                usc_buscardocente.Docente.SeguroFunerario = new Empresa.Docente.SeguroFunerario(usc_buscardocente.Docente);
                

                if (usc_buscardocente.Docente.SeguroFunerario.ExisteItem()){
                    //Existe proceso.
                    this.SeleccionActual = ESeleccion.SEGUROFUNERARIO;
                    _us_Proceso_SeguroFunerario = new us_Proceso_SeguroFunerario(usc_buscardocente.Docente);
                    pag_trans.ShowPage(_us_Proceso_SeguroFunerario);
                }
                else{
                        if(MessageBox.Show("- No Existe solicitud de Seguro Funerario en proceso para el docente, Desea Aperturar una solicitud?, Si/No", "Si/No", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes){
                        //si
                            this.SeleccionActual = ESeleccion.SEGUROFUNERARIO;
                            usc_buscardocente.Docente.SeguroFunerario = new Empresa.Docente.SeguroFunerario();

                            _us_Proceso_SeguroFunerario = new us_Proceso_SeguroFunerario(usc_buscardocente.Docente);
                            pag_trans.ShowPage(_us_Proceso_SeguroFunerario);
                    }


                }
            }
            catch {
                MessageBox.Show("Acceso denegado.", "Acceso denegado", MessageBoxButton.OK, MessageBoxImage.Warning);
            
            }
        }

        //Menu General
        private void But_SF_Menu_Click(object sender, RoutedEventArgs e) {
            try{
                //if (usc_buscardocente.Docente.EsFallecido)
                //{
                __doc_guardado = false;
                    this.SeleccionActual = ESeleccion.SEGUROFUNERARIOVISTA;
                    this._us_vista_solicitud_segurofunerario = new Objs.us_vista_solicitud_segurofunerario();
                    //Agregando Evento
                    this._us_vista_solicitud_segurofunerario.Abrir += But_AbrirSolicitudSeguroFunerario_Click;
                    pag_trans.ShowPage(_us_vista_solicitud_segurofunerario);
                //}
                //else {
                //    MessageBox.Show("Para visualizar el formulario de Seguro Funerario, el docente debe tener primero registrada la fecha de fallecimiento.", "El docente debe estar registrado como fallecido.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                //}
            }
            catch{
                MessageBox.Show("Acceso denegado.", "Acceso denegado", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void But_SeguroFunerarioAprobaciones_Menu_Click(object sender, RoutedEventArgs e) {
            _us_segurofunerario_aprobacion = new Objs.Controles.SeguroFunerario.us_segurofunerario_aprobacion();
           
            try {
                pag_trans.ShowPage(_us_segurofunerario_aprobacion);
            }
            catch{
                MessageBox.Show("Acceso denegado.", "Acceso denegado", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

       private void usc_buscardocente_EsLimpiado_1(object sender, RoutedEventArgs e){
            try{
                if (_debolimpiar){
                    __doc_guardado = false;
                    pag_trans.ShowPage(scn);
                    this.LimpiarVariables();
                }
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            } 
        }

       public void usc_buscardocente_EsResultado(object sender, RoutedEventArgs e){
            
           if (_debolimpiar)
            {
                if (usc_buscardocente.Docente.TieneSeguroFunerario == true || usc_buscardocente.Docente.TieneSobrevivencia == true){
                    //Indicando la seleccion actual.
                    this.SeleccionActual = ESeleccion.LISTASERVICIOS;
                    
                    this.listatrabajos = new Objs.Controles.ListadoTrabajos(usc_buscardocente.Docente);
                    this.listatrabajos.Seleccionado += ItemExisteSeguroFunerario_Seleccionado;

                    pag_trans.ShowPage(this.listatrabajos);
                    _debolimpiar = true;
                }
            }

            if (usc_buscardocente.Docente.EsFallecido){
                //Aviso Fecha de fallecimiento de existe.
                //if (usc_buscardocente.Docente.FechaFallecido == DateTime.MinValue || usc_buscardocente.Docente.FechaFallecido == DateTime.MaxValue){
                if(!usc_buscardocente.Docente.EsFallecidoMinimo){
                    Objs.Controles.Dialogos.Dial_NoExisteFechaFallecimiento _nofechafalleci = new Objs.Controles.Dialogos.Dial_NoExisteFechaFallecimiento();
                    
                    _nofechafalleci.ShowDialog();
                    _nofechafalleci.Close();
                }
            }

            if (!usc_buscardocente.Docente.EsDocente){
                Objs.Controles.Dialogos.Dial_AvisoNoDocente nodoc = new Objs.Controles.Dialogos.Dial_AvisoNoDocente();
                nodoc.ShowDialog();
                nodoc.Close();
            }

            ///Registro de Evento
            Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(usc_buscardocente.CModulo, usc_buscardocente.objecto, usc_buscardocente.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.ConsultaInformacion), Empresa.Usuarios.Seccion.Usuario, Empresa.Comun.Servicios.DameIdProcesador(), Environment.MachineName, Environment.UserDomainName));
        }

       private void But_Dependientes_Click(object sender, RoutedEventArgs e){
           __doc_guardado = false;
           _debolimpiar = true;
           _DialogoPaginas_01 = new Objs.Controles.Dialogos.Dial_SeleccionPagina_01();
           
           try {
                _DialogoPaginas_01.ShowDialog();

                switch(_DialogoPaginas_01.Seleccion){
                    case Objs.Controles.Dialogos.Dial_SeleccionPagina_01.ESeleccion.LimiteEdad:
                        _ConsultaDependientes = new Objs.Controles.us_ConsultaDependientes();
                        //Estableciendo La selección
                        this.SeleccionActual = ESeleccion.LIMITEEDAD;
                        pag_trans.ShowPage(_ConsultaDependientes);
                        break;
                    case Objs.Controles.Dialogos.Dial_SeleccionPagina_01.ESeleccion.ProyeccionExclucion:
                        _ConsultaDependientesLimitePension = new Objs.Controles.us_ConsultaDependientes_LimitePension();
                        //Estableciendo La Seleccion
                        this.SeleccionActual = ESeleccion.PROYECCION;
                        pag_trans.ShowPage(_ConsultaDependientesLimitePension);
                        break;

                    case Objs.Controles.Dialogos.Dial_SeleccionPagina_01.ESeleccion.NotificacionExclucion:
                        _ConsultaDependientes_NotificacionExclucion = new Objs.Controles.us_ConsultaDependientes_NotificacionExclucion();
                        //Estableciendo La Seleccion
                        this.SeleccionActual = ESeleccion.NOTIFICACION;
                        pag_trans.ShowPage(_ConsultaDependientes_NotificacionExclucion);
                        break;
                    case Objs.Controles.Dialogos.Dial_SeleccionPagina_01.ESeleccion.Excluidos:
                        _us_ListaExcluidos = new Objs.Controles.us_ListaExcluidos();
                        //Estableciendo La Seleccion
                        this.SeleccionActual = ESeleccion.EXCLUIDOS;
                        pag_trans.ShowPage(_us_ListaExcluidos);
                        break;
                    case  Objs.Controles.Dialogos.Dial_SeleccionPagina_01.ESeleccion.BusquedaBeneficiario:

                        this._us_busquedaDependientes = new Objs.Controles.us_busquedaDependientes();
                        this._us_busquedaDependientes.Seleccionando += But_BusquedaDependiente_Click;

                        pag_trans.ShowPage(_us_busquedaDependientes);
                        break;
                }

                _DialogoPaginas_01.Close();
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

       private void But_BusquedaDependiente_Click(object sender){
            try{
                __doc_guardado = false;
                this.usc_buscardocente.SetDocente(((Empresa.Docente.TFamiliares)sender).Docente);
            }
            catch { 
            
            } 
        }

        //  Botones de Accion Comun // 
       private void But_Guardar_Click(object sender, RoutedEventArgs e){
           try
           {
               switch (this.SeleccionActual)
               {
                   case ESeleccion.SOLICITUD_DISCAPACIDAD:
                   bool resul;    
                   //proc.Imprimir();
                       if (proc != null){
                           
                           //Estableciendo la actual.
                           if(proc.Solicitud.Id.Equals(0))
                           {
                                //Nueva Insert
                               resul = usc_buscardocente.Docente.SolicitudPJ.Insert(proc.Solicitud, usc_buscardocente.Docente.Cedula);
                               __doc_guardado = true;
                           }
                           else 
                           {
                                //Actualizar(Update)
                              resul = usc_buscardocente.Docente.SolicitudPJ.Update(proc.Solicitud, usc_buscardocente.Docente.Cedula);
                              __doc_guardado = true;
                           }

                           if(resul){
                               MessageBox.Show(Empresa.Comun.Mensajes.DocumentoGuardar, "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                           }
                           else{
                               MessageBox.Show(Empresa.Comun.Mensajes.Documen_FaltaRequisitos, "Falta información", MessageBoxButton.OK, MessageBoxImage.Stop);
                           }


                       }
                       break;
                   case ESeleccion.SOBREVIVENCIA:
                       //visps.Imprimir();
                       break;
                   case ESeleccion.LIMITEEDAD:
                       //_ConsultaDependientes.Print();
                       break;
                   case ESeleccion.PROYECCION:
                       //_ConsultaDependientesLimitePension.Print();
                       break;
                   case ESeleccion.NOTIFICACION:
                       //_ConsultaDependientes_NotificacionExclucion.Print();
                       break;
                   case ESeleccion.DECRETOS:
                       //_us_MantenimientoListadoDecreto.Print();
                       break;
                   case ESeleccion.EXCLUIDOS:
                       //_us_ListaExcluidos.Print();
                       break;
                   case ESeleccion.SEGUROFUNERARIO:
                       try {

                                                 
                           if(usc_buscardocente.Docente.SeguroFunerario.Actual.Existe)
                           {   
                                    usc_buscardocente.Docente.SeguroFunerario.Update(usc_buscardocente.Docente.SeguroFunerario.Actual);
                                    Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(_us_Proceso_SeguroFunerario.CModulo, _us_Proceso_SeguroFunerario.objecto, usc_buscardocente.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.ModificacionRegistro), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName));
                           }
                           else{
                                    usc_buscardocente.Docente.SeguroFunerario.Insert(usc_buscardocente.Docente.SeguroFunerario.Actual);
                                    Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(_us_Proceso_SeguroFunerario.CModulo, _us_Proceso_SeguroFunerario.objecto, usc_buscardocente.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.InsercionRegistro), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName));
                           }


                           MessageBox.Show("Solicitud Guarda con Exito", "Solicitud Guardada", MessageBoxButton.OK, MessageBoxImage.Information);
                       }
                       catch {
                           MessageBox.Show(Empresa.Comun.Mensajes.Error_Proceso, "Error, Verifique los datos suministrados.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                       }

                       break;
               }

           }
           catch (Exception ex){
               MessageBox.Show(Empresa.Comun.Mensajes.Documen_No_Seleccionado, "Documento no Seleccionado.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
           }
        }

       
       private void But_Imprimir_Click(object sender, System.Windows.RoutedEventArgs e){
       	// TODO: Add event handler implementation here.
		//impresion de documento

           try{

               switch (this.SeleccionActual){
                   case ESeleccion.SOLICITUD_DISCAPACIDAD:
                       SIC.Objs.Controles.ReportSelectDocente wselect;
                       if(this.SubSeleccionSolicitud_Discapcidad == ESubSeleccionSolicitud_Discapcidad.Vista){
                           
                           if(us_vistasolicutd_pj != null)
                           {
                               if(this.us_vistasolicutd_pj.SolicitudSelect != null)
                               {
                                   wselect = new Objs.Controles.ReportSelectDocente(this.us_vistasolicutd_pj.SolicitudSelect);
                                   wselect.Show();
                               }
                               else
                               {
                                   MessageBox.Show(Empresa.Comun.Mensajes.Documen_No_Seleccionado, "Documento no Selección", MessageBoxButton.OK, MessageBoxImage.Stop); 
                               }
                           }
                           else {
                                   MessageBox.Show(Empresa.Comun.Mensajes.Documen_No_Seleccionado, "Documento no Selección", MessageBoxButton.OK, MessageBoxImage.Stop);
                           }
                       }
                       else {
                           proc.Imprimir();
                       }

                       break;
                   case ESeleccion.SOBREVIVENCIA:
                       visps.Imprimir();
                       break;
                   case ESeleccion.LIMITEEDAD:
                       _ConsultaDependientes.Print();
                       break;
                   case  ESeleccion.PROYECCION:
                       _ConsultaDependientesLimitePension.Print();
                       break;
                   case ESeleccion.NOTIFICACION:
                       _ConsultaDependientes_NotificacionExclucion.Print();
                       break;
                   case ESeleccion.DECRETOS:
                       _us_MantenimientoListadoDecreto.Print();
                       break;
                   case ESeleccion.EXCLUIDOS:
                       _us_ListaExcluidos.Print(); 
                       break;
                   case ESeleccion.BUSQUEDA_DISCAPACIDAD:
                       us_Busqueda_pension_discapacidad.Print();
                       break;
                   case ESeleccion.SEGUROFUNERARIO:

                       if (usc_buscardocente.Docente.SeguroFunerario.Actual.Id.Equals(0)){
                           MessageBox.Show("Primero debe guardar la solicitud antes de imprimir.","Falta Guardar la solicitud",MessageBoxButton.OK,MessageBoxImage.Information);
                       }else{
                       _us_Proceso_SeguroFunerario.Print();
                       }

                       break;
               }
           }
           catch (Exception ex) {
               MessageBox.Show(Empresa.Comun.Mensajes.Documen_No_Seleccionado, "Documento no Seleccionado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
           }
       }

       private void But_Declinar_Click(object sender, System.Windows.RoutedEventArgs e) {
           // TODO: Add event handler implementation here.
           // Declinar y cambiar estado de documento

           try{

               switch (this.SeleccionActual){

                   case ESeleccion.SOLICITUD_DISCAPACIDAD:
                       //proc.Imprimir();
                       if (!proc.Solicitud.EsSoloLectura){

                           if (MessageBox.Show("Desea Declinar la solicitud, Si/No", "Desea Declinar. Si/No?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes){

                               
                               SIC.Objs.Controles.Dialogos.Dial_CambioEstadoSolicitudPJ cambio_es = new Objs.Controles.Dialogos.Dial_CambioEstadoSolicitudPJ(new Empresa.Docente.testadossolicitudpj(Empresa.Docente.EstadoPJ.GetInstance().GetItem(3)));
                               cambio_es.ShowDialog();

                               // Por defecto declinada.
                               proc.Solicitud.EstadoActual = cambio_es.Estado;
                               proc.Solicitud.Estados.Insert(proc.Solicitud); 

                               cambio_es.Close();
                               //proc.Refresh(); 
                           }
                       }
                       else {
                           MessageBox.Show("No se puede modificar el estado de la solicitud.", "No se puede modificar el estado de la solicitud.", MessageBoxButton.OK, MessageBoxImage.Warning); 
                       }
                       break;
                   case ESeleccion.SOBREVIVENCIA:
                       //visps.Imprimir();

                       break;
                   case ESeleccion.LIMITEEDAD:
                       //_ConsultaDependientes.Print();

                       break;
                   case ESeleccion.PROYECCION:
                       //_ConsultaDependientesLimitePension.Print();

                       break;
                   case ESeleccion.NOTIFICACION:
                       //_ConsultaDependientes_NotificacionExclucion.Print();

                       break;
                   case ESeleccion.DECRETOS:
                       //_us_MantenimientoListadoDecreto.Print();

                       break;
                   case ESeleccion.EXCLUIDOS:
                       //_us_ListaExcluidos.Print();

                       break;
               }

           }
           catch (Exception ex){
               MessageBox.Show(Empresa.Comun.Mensajes.Documen_No_Seleccionado, "Documento no Seleccionado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
           }


       
       }

       private void But_Nuevo_Click(object sender, RoutedEventArgs e){
            //Nuevo

            switch (this.SeleccionActual)
            {
                case ESeleccion.SOLICITUD_DISCAPACIDAD:
                    
                    if (sender != null){
                        if (!usc_buscardocente.Docente.SolicitudPJ.ExisteProceso){
                            //Estableciendo Sub Selección.
                            
                            if (MessageBox.Show("Desea Agregar una Nueva SOLICITUD DE DISCAPACIDAD para docente seleccionado. Si/No", "Desea Agregar una Nueva solicitud de Discapacidad. Si/No", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes){
                                
                                this.SubSeleccionSolicitud_Discapcidad = ESubSeleccionSolicitud_Discapcidad.Solicitud;
                                proc = new us_mantenimiento_procesos(new Empresa.Docente.tsolicitudpj(usc_buscardocente.Docente));
                                pag_trans.ShowPage(proc);

                            }
                        }
                        else{
                            MessageBox.Show("Existe una solicitud en proceso, para agregar una nueva solicitud debe terminiar la solicitud anterior.", "Existe una solicitud en proceso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }

                    break;
                case ESeleccion.SOBREVIVENCIA:
                    //visps.Imprimir();
                    break;
                case ESeleccion.LIMITEEDAD:
                    //_ConsultaDependientes.Print();
                    break;
                case ESeleccion.PROYECCION:
                    //_ConsultaDependientesLimitePension.Print();
                    break;
                case ESeleccion.NOTIFICACION:
                    //_ConsultaDependientes_NotificacionExclucion.Print();
                    break;
                case ESeleccion.DECRETOS:
                    //_us_MantenimientoListadoDecreto.Print();
                    break;
                case ESeleccion.EXCLUIDOS:
                    //_us_ListaExcluidos.Print();
                    break;
            }
        }

       public void _us_MantenimientoListadoDecreto_visitandoDocente(object e) {

           usc_buscardocente.SetDocente(((Empresa.Docente.tdocente)e).Cedula);
       }    
       private void But_Decretos_Click(object sender, RoutedEventArgs e) {
           _debolimpiar = false;
           __doc_guardado = false;
           SeleccionActual = ESeleccion.DECRETOS;

           SIC.Objs.Controles.Dialogos.Dial_SeleccionDecretoOpcion_01 decreopcion = new Objs.Controles.Dialogos.Dial_SeleccionDecretoOpcion_01();
           decreopcion.ShowDialog();


           switch (decreopcion.SeleccionActual) { 
               case Objs.Controles.Dialogos.Dial_SeleccionDecretoOpcion_01.ESeleccionOpcion.Agregar:
                   if (decreopcion.Decreto.PuedeAgregar)
                   {
                       _us_MantenimientoListadoDecreto = new Objs.Controles.us_MantenimientoListadoDecreto(decreopcion.Decreto, true);
                       _us_MantenimientoListadoDecreto.visitandoDocente += _us_MantenimientoListadoDecreto_visitandoDocente;
                       pag_trans.ShowPage(_us_MantenimientoListadoDecreto);
                   }
                   else {
                       MessageBox.Show("El Decreto seleccionado está Bloqueado, No puede agregar Docente(s), su estado es:" + decreopcion.Decreto.Estado.Nombre, "Decreto Bloqueado Estado:" + decreopcion.Decreto.Estado.Nombre, MessageBoxButton.OK, MessageBoxImage.Stop);
                   }
                   break;
               case Objs.Controles.Dialogos.Dial_SeleccionDecretoOpcion_01.ESeleccionOpcion.Aprobar:

                   break;
               case Objs.Controles.Dialogos.Dial_SeleccionDecretoOpcion_01.ESeleccionOpcion.Crear:
                   _us_Mantenimiento_Decreto = new Objs.Controles.us_Mantenimiento_Decreto();
                   pag_trans.ShowPage(_us_Mantenimiento_Decreto);
                   break;
               case Objs.Controles.Dialogos.Dial_SeleccionDecretoOpcion_01.ESeleccionOpcion.Ver:
                   _us_MantenimientoListadoDecreto = new Objs.Controles.us_MantenimientoListadoDecreto(decreopcion.Decreto, false);
                   _us_MantenimientoListadoDecreto.visitandoDocente += _us_MantenimientoListadoDecreto_visitandoDocente;
                   pag_trans.ShowPage(_us_MantenimientoListadoDecreto);
                   break;
           }

           decreopcion.Close();
       }

       private void UserControl_Loaded(object sender, RoutedEventArgs e){
           usc_buscardocente.Txt_Cedula.Focus();
       }

       public string CModulo
       {
           get { return "__docm_09o4u3ja;hu823_"; }
       }

       public string Cobjecto
       {
           get { return "__docoa_003897600-__"; }
       }

       public string Descripcion
       {
           get { throw new NotImplementedException(); }
       }

       public string Modulo
       {
           get { return "Docente"; }
       }

       public string Nombre
       {
           get { return "Area Trabajo Docente"; }
       }

       public string objecto
       {
           get { return "AreaTrabajoDocente"; }
       }
    
    }
}
