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
using System.ComponentModel;

namespace SIC.Objs.Controles
{
    /// <summary>
    /// Interaction logic for us_BuscarDocente.xaml
    /// </summary>
    public partial class us_BuscarDocente : UserControl, Empresa.Comun.IFirma
    {
        private BackgroundWorker bkw;
        public Empresa.Docente.tdocente Docente { get; set; }
       
        //Variables privadas almacenamiento interno.
        private bool TrabajoCompleto = false;

        public event DInicio TerminadoEdicion = delegate { };

        public void DefaultFocus(){
            Txt_Cedula.Focus();
        }
		
		// Inicializando Busqueda
		public static RoutedEvent IniResultadoEvent = EventManager.RegisterRoutedEvent("IniResultado", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(us_BuscarDocente));
		public event RoutedEventHandler IniResultado 
        {
            add { AddHandler(IniResultadoEvent, value);       }
            remove { RemoveHandler(IniResultadoEvent, value); }
        }
	
		// Finalizando Busqueda
		public static RoutedEvent EsResultadoEvent = EventManager.RegisterRoutedEvent("EsResultado", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(us_BuscarDocente));
		public event RoutedEventHandler EsResultado  {
            add { AddHandler(EsResultadoEvent, value);       }
            remove { RemoveHandler(EsResultadoEvent, value); }
        }
		
		//Limpiando con Resultados.
        public static RoutedEvent EsLimpiadoEvent = EventManager.RegisterRoutedEvent("EsLimpiado", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(us_BuscarDocente));
        public event RoutedEventHandler EsLimpiado {
            add { AddHandler(EsLimpiadoEvent, value); }
            remove { RemoveHandler(EsLimpiadoEvent, value); }
        }
		
		//Limpiando Sin Resultados.
		public static RoutedEvent EsLimpiadoEventVacio = EventManager.RegisterRoutedEvent("EsLimpiadoVacio", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(us_BuscarDocente));
        public event RoutedEventHandler EsLimpiadoVacio {
            add { AddHandler(EsLimpiadoEventVacio, value); }
            remove { RemoveHandler(EsLimpiadoEventVacio, value); }
        }

		//Asistente de Disparador de Eventos.
		private void Raise(RoutedEventArgs newEventArgs){
            RaiseEvent(newEventArgs);	
        }
		
		private void Limpiando(){
            
			if(TrabajoCompleto){
				//Limpiando con resultados
				this.Raise(new RoutedEventArgs(us_BuscarDocente.EsLimpiadoEvent));
			} else {
				//Limpiando sin resultados.
				this.Raise(new RoutedEventArgs(us_BuscarDocente.EsLimpiadoEventVacio));
			}
            
            //System.Windows.ValidateValueCallback
            this.DataContext = new Empresa.Docente.tdocente();
            Txt_Cedula.Text = string.Empty;
            TrabajoCompleto = false;
            GlobalItems.DocenteGlobal = null;

            But_PS.IsEnabled = false;
        }

        private void SettingContext(){
            But_PS.IsEnabled = (this.Docente.EsFallecido && (!object.Equals(this.Docente.FechaFallecido, DateTime.MinValue)));
            But_SeguroF.IsEnabled = (this.Docente.EsFallecido && (!object.Equals(this.Docente.FechaFallecido, DateTime.MinValue)));
        }

        //Inicializacion
        public us_BuscarDocente()
        {

            InitializeComponent();

            bkw = new BackgroundWorker();
            bkw.DoWork += bw_DoWork;
            bkw.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e) {
            try{
                e.Result = new Empresa.Docente.DocenteEnDecreto(e.Argument.ToString())[0];
            }
            catch(ArgumentOutOfRangeException Ex)
            {
                e.Result = new Empresa.Docente.DocenteEnDecreto().DamePersonaEnDecreto(e.Argument.ToString());

                if (string.IsNullOrEmpty(((Empresa.Docente.tdocente)e.Result).Cedula))
                {
                    e.Result = null;
                }
          
            }
        }
      

        public void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Result != null){
                this.Docente = (Empresa.Docente.tdocente)e.Result;
                this.DataContext = this.Docente;
                
                this.Raise(new RoutedEventArgs(us_BuscarDocente.EsResultadoEvent));
                GlobalItems.DocenteGlobal = this.Docente;

                //Indica que el trabajo fue completado con resultados efectivos.
                this.TrabajoCompleto = true;
                this.SettingContext();
            }
            else {

                MessageBox.Show("Cédula no valida o no encontrada en los registros.", "-- CEDULA NO VALIDA --", MessageBoxButton.OK, MessageBoxImage.Exclamation);   
                this.Raise(new RoutedEventArgs(us_BuscarDocente.EsLimpiadoEventVacio));
            }
        }

        public void SetDocente(Empresa.Docente.tdocente docente) {
            Txt_Cedula.Text = docente.Cedula;
            this.BuscarDoncente(docente.Cedula);
        }

        public void SetDocente(string cedula){
            Txt_Cedula.Text = cedula;
            this.BuscarDoncente(cedula);
        }

        private void BuscarDoncente(string cedula)
        {
            try
            {
                // Espera(true);
				// Inicia el Proceso de espera.
                // Inicializando Busqueda con hilo paralelo.
				this.Raise(new RoutedEventArgs(us_BuscarDocente.IniResultadoEvent));
				bkw.RunWorkerAsync(cedula.Replace("-",string.Empty));
            }
            catch (Exception ex){
                //Espera(false);
                bkw.Dispose();
            }
        }

        private void Txt_Cedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter)){
                this.BuscarDoncente(Txt_Cedula.Text);
            }
            else if (e.Key.Equals(Key.Escape)){
                this.Limpiando();
            }
        }

        private void But_BuscarDoc_Click_1(object sender, RoutedEventArgs e){
           if (!TrabajoCompleto){
                if (!string.IsNullOrEmpty(Txt_Cedula.Text)) this.BuscarDoncente(Txt_Cedula.Text);
            }
            else {
                this.Limpiando();
            }
        }

        private void But_Actas_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.

        }

        private void But_EditDireccion_Click(object sender, RoutedEventArgs e){
            
            try{
                if (this.Docente != null){
                    //Vista de Ventanda de Mantenimiento
                    SIC.Objs.Controles.win_mantenimientoDocente mandoc = new win_mantenimientoDocente(this.Docente);
                    mandoc.But_Imprimir.Click += But_PrintMantenimientoDocente_Click;

                    ///Registro de Evento
                    Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(mandoc.CModulo, mandoc.objecto, this.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.AccesoDivicion), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName));
                    mandoc.ShowDialog();

                    //Docente modificado previamente, en la formulario de mantenimiento.
                    this.Docente = mandoc.Docente;

                    if (this.Docente.EsFallecidoMinimo){
                        //Refresh el calculo de seguro funerario.
                        this.Docente.Calculo_Seguro_Funerario();
                    }

                    //actualizando contexto.
                    this.SettingContext();

                    //Ejecutando Evento de Terminada la Edición
                    this.TerminadoEdicion.Invoke(this.Docente);
                }
            }
            catch{

            }
        }

        private void But_PrintMantenimientoDocente_Click(object sender, System.Windows.RoutedEventArgs e){
            try{
                this.Print(this.Docente);
            }
            catch{ } 
        }

        private void Txt_Cedula_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(((TextBox)sender).Text)){
                this.Limpiando();
            }
        }

        public void Print(Empresa.Docente.tdocente item) {

            if (item != null)
            {
                Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();

                if (item.EsFallecido)
                {
                    SIC.Objs.Controles.Dialogos.Dial_ReporteDatosFellecidos datosfallecidos = new Dialogos.Dial_ReporteDatosFellecidos();
                    datosfallecidos.ShowDialog();
                    if (datosfallecidos.EsValido)
                    {
                        switch (datosfallecidos.Seleccion)
                        {
                            case Dialogos.Dial_ReporteDatosFellecidos.EnumSeleccionTipoReporteFallecimiento.Basico:
                                Objs.Docentes.Reportes.Xtra_Docente re1 = new Objs.Docentes.Reportes.Xtra_Docente();
                                re1.bindingSource3.DataSource = item;
                                vista.MostarReporte(re1);

                                //Registrando Evento
                                Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, this.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.VistaReporte), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName, "Reporte - Docente"));
                                break;
                            case Dialogos.Dial_ReporteDatosFellecidos.EnumSeleccionTipoReporteFallecimiento.BasicoFallecimiento:
                                //Reporte extendido
                                Objs.Docentes.Reportes.Xtra_Docente_Fallecidos re3 = new Objs.Docentes.Reportes.Xtra_Docente_Fallecidos();
                                re3.bindingSource1.DataSource = item;
                                //var r = this.Docente.DatosFellecimiento;
                                vista.MostarReporte(re3);
                                //Registrando Evento
                                Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, this.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.VistaReporte), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName, "Reporte - Docente, Datos Fallecimiento"));
                                break;
                            case Dialogos.Dial_ReporteDatosFellecidos.EnumSeleccionTipoReporteFallecimiento.SeguroFunerario:
                                Objs.Docentes.Reportes.Xtra_DocenteBenPlanf re4 = new Objs.Docentes.Reportes.Xtra_DocenteBenPlanf();
                                
                                re4.bindingSource1.DataSource = item;
                                vista.MostarReporte(re4);
                                break;
                            case Dialogos.Dial_ReporteDatosFellecidos.EnumSeleccionTipoReporteFallecimiento.PostActivo:
                                Objs.Docentes.Reportes.Xtra_PostActivo re5 = new Objs.Docentes.Reportes.Xtra_PostActivo();
                                re5.bindingSource1.DataSource = item;
                                vista.MostarReporte(re5);
                                break;
                        }
                    }

                    if (datosfallecidos.IncluirDetalle) this.PrintEstado(item); 
                    datosfallecidos.Close();
                }
                else{
                    if (item.EstadoLaboral.Id != 1){
                        //Pensionado o Jubilado
                        SIC.Objs.Controles.Dialogos.Dial_Seleccion_02 datosfallecidos = new Dialogos.Dial_Seleccion_02();
                        datosfallecidos.ShowDialog();

                        switch (datosfallecidos.Seleccion){

                            case Dialogos.Dial_Seleccion_02.EnumSeleccionTipoReporteDocente.Basico:
                                Objs.Docentes.Reportes.Xtra_Docente re2 = new Objs.Docentes.Reportes.Xtra_Docente();
                                re2.bindingSource3.DataSource = item;
                                vista.MostarReporte(re2);
                                //Registrando Evento
                                Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, this.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.VistaReporte), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName, "Reporte - Docente"));
                                break;
                            case Dialogos.Dial_Seleccion_02.EnumSeleccionTipoReporteDocente.Certificacion:
                                SIC.Objs.Controles.Dialogos.Dial_empresasrecurrentes_01 emprerecurre = new Dialogos.Dial_empresasrecurrentes_01();
                                emprerecurre.ShowDialog();

                                if(emprerecurre.Suplidor != null){

                                    Objs.Docentes.Reportes.Xtra_Certificacion re4 = new Objs.Docentes.Reportes.Xtra_Certificacion();
                                    re4.Parameters[0].Value = Empresa.Comun.Server.DameTiempoFormatoC;

                                    if(item.EstadoLaboral.Id.Equals(2)){
                                        re4.Parameters[1].Value = Empresa.RHH.EstadoLaboral.GetInstance()[3].Nombre;
                                    }
                                    else{
                                        re4.Parameters[1].Value = Empresa.RHH.EstadoLaboral.GetInstance()[2].Nombre;
                                    }

                                    re4.Parameters[2].Value = emprerecurre.Suplidor.Nombre;
                                    re4.bindingSource1.DataSource = item;
                                    vista.MostarReporte(re4);
                                    //Registrando Evento
                                    Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, this.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.VistaReporte), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName, "Reporte - Docente, Certificacion"));
                                }
                                break;
                        }
                        datosfallecidos.Close();
                    }
                    else { 
                        //Activo
                        Objs.Docentes.Reportes.Xtra_Docente re2 = new Objs.Docentes.Reportes.Xtra_Docente();
                        re2.bindingSource3.DataSource = item;
                        vista.MostarReporte(re2);
                        //Registrando Evento
                        Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, this.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.VistaReporte), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName, "Reporte - Docente"));
                    }
                }
            }
        }

        private void PrintEstado(Empresa.Docente.tdocente  docente) {
            Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();
            //var r  = this.Docente.FechaFallecido.Day <= 24? this.Docente.FechaFallecido.AddMonths(-1):this.Docente.FechaFallecido;

            Objs.Docentes.Reportes.Xtra_ListadoIngresosEgresos re1 = new Objs.Docentes.Reportes.Xtra_ListadoIngresosEgresos();
            re1.Parameters[3].Value = docente.CedulaF;
            re1.Parameters[4].Value = docente.NombreCompleto;
 
            re1.bindingSource1.DataSource = docente.PagosDetalle.DameLista("81", this.Docente.FechaFallecido.Day <= 24 ? this.Docente.FechaFallecido.AddMonths(-1):this.Docente.FechaFallecido);

            vista.MostarReporte(re1);
            //Registrando Evento
            Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, this.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.VistaReporte), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName, "Reporte - Docente, Aporte a Seguro Funerario(81)"));
        }

        private void But_ImprimirDocente_Click(object sender, RoutedEventArgs e)
        {
            try{
               
                this.Print(this.Docente);
            }
            catch { 
            
            }
        }

        public string CModulo{
            get { return "__docm_09o4u3ja;hu823_"; }
        }

        public string Cobjecto{
            get { return "__doco__oeqp)98_9"; }
        }

        public string Descripcion{
            get { throw new NotImplementedException(); }
        }

        public string Modulo{
            get { return "Docente"; }
        }

        public string Nombre{
            get { return "Buscando Docente"; }
        }

        public string objecto{
            get { return "BuscandoDocente"; }
        }

        public event DInicio LLamandoEstado = delegate { };

        private void But_EstadoDocente_Click(object sender, RoutedEventArgs e){
            if(this.Docente!= null){
                this.LLamandoEstado.Invoke(this.Docente);
            }
        }
        
        Empresa.Docente.DocenteIncluir doc_incluir = new Empresa.Docente.DocenteIncluir();
        Win_IncluirPersonal _inper;
        private void But_AgregarPersonal_Click(object sender, RoutedEventArgs e)
        {
            _inper = new Win_IncluirPersonal();
            _inper.ShowDialog();

            try
            {
                if (_inper.EsValida){
                    doc_incluir.Agregar(_inper.DocenteIncluido);
                    //Buscar persona
                    this.Txt_Cedula.Text = _inper.DocenteIncluido.Cedula;
                    this.BuscarDoncente(_inper.DocenteIncluido.Cedula);
                }
                _inper.Close();
            }
            catch {
                    MessageBox.Show("Falta datos o la persona que intente introducir existe en nuestra base de datos, verifique: consulte la existencia de la persona en nuestra base de datos o debe introducir la empresa origen.", "Faltan datos o la pesona existe en nuestra base de datos.", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void But_CalculoPromedio_Click(object sender, RoutedEventArgs e)
        {
            try{
                if (this.Docente != null)
                {
                    Dialogos.win_mostrar_promedio_salarial __pro = new Dialogos.win_mostrar_promedio_salarial(this.Docente);
                    __pro.ShowDialog();
                    __pro.Close();
                }
            }
            catch { 
            
            }
        }

     
    }




}
