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
    public partial class us_BuscarPersonas : UserControl, Empresa.Comun.IFirma 
    {
        private BackgroundWorker bkw;
        public Empresa.RHH.tpersonal Persona { get; set; }
        private bool TrabajoCompleto = false;

        public void DefaultFocus(){
            Txt_Cedula.Focus();
        }
		
		// Inicializando Busqueda
        public static RoutedEvent IniResultadoEvent = EventManager.RegisterRoutedEvent("IniResultadoPersona", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(us_BuscarPersonas));
		public event RoutedEventHandler IniResultadoPersona {
            add { AddHandler(IniResultadoEvent, value);       }
            remove { RemoveHandler(IniResultadoEvent, value); }
        }
	
		// Finalizando Busqueda
        public static RoutedEvent EsResultadoEvent = EventManager.RegisterRoutedEvent("EsResultadoPersona", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(us_BuscarPersonas));
		public event RoutedEventHandler EsResultadoPersona  {
            add { AddHandler(EsResultadoEvent, value);       }
            remove { RemoveHandler(EsResultadoEvent, value); }
        }
		
		//Limpiando con Resultados.
        public static RoutedEvent EsLimpiadoEvent = EventManager.RegisterRoutedEvent("EsLimpiadoPersona", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(us_BuscarPersonas));
        public event RoutedEventHandler EsLimpiadoPersona {
            add { AddHandler(EsLimpiadoEvent, value); }
            remove { RemoveHandler(EsLimpiadoEvent, value); }
        }
		
		//Limpiando Sin Resultados.
        public static RoutedEvent EsLimpiadoEventVacio = EventManager.RegisterRoutedEvent("EsLimpiadoVacioPersona", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(us_BuscarPersonas));
        public event RoutedEventHandler EsLimpiadoVacioPersona {
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
                this.Raise(new RoutedEventArgs(us_BuscarPersonas.EsLimpiadoEvent));
			}else{
				//Limpiando sin resultados.
                this.Raise(new RoutedEventArgs(us_BuscarPersonas.EsLimpiadoEventVacio));
			}
             
            //System.Windows.ValidateValueCallback
            this.DataContext = new Empresa.Docente.tdocente();
            Txt_Cedula.Text = string.Empty;
            
            //TrabajoCompleto = false;
            //But_PS.IsEnabled = false;
        }

        private void SettingContext(){
            //But_PS.IsEnabled = (this.Docente.EsFallecido && (!object.Equals(this.Docente.FechaFallecido, DateTime.MinValue)));
        }

        //Inicializacion
        public us_BuscarPersonas(){
            InitializeComponent();
            bkw = new BackgroundWorker();
            bkw.DoWork += bw_DoWork;
            bkw.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e) {
            
            try {
                e.Result = new Empresa.RHH.Persona(e.Argument.ToString())[0];
            }
            catch (ArgumentOutOfRangeException Ex){
                e.Result = null;
            }

        }

        public void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Result != null){
                
                this.Persona = (Empresa.RHH.tpersonal)e.Result;
                this.DataContext = this.Persona;

                this.Raise(new RoutedEventArgs(us_BuscarPersonas.EsResultadoEvent, this.Persona));
                //Indica que el trabajo fue completado con resultados efectivos.
                this.TrabajoCompleto = true;

            }
            else {
                //MessageBox.Show("Cedula no valida o no Encontrada en los registros.", "-- CEDULA NO VALIDA --", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                
                this.Raise(new RoutedEventArgs(us_BuscarPersonas.EsLimpiadoEventVacio));
            }
        }
        
        private void BuscarDoncente(string cedula)
        {
            try{
                // Espera(true);
				// Inicia el Proceso de espera.
                // Inicializando Busqueda con hilo paralelo.
                this.Raise(new RoutedEventArgs(us_BuscarPersonas.IniResultadoEvent));
				bkw.RunWorkerAsync(cedula);
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

        private void But_EditDireccion_Click(object sender, RoutedEventArgs e)
        {
            if (this.Persona != null){
                //SIC.Objs.Controles.win_mantenimientoDocente mandoc = new win_mantenimientoDocente(this.Persona);
                //mandoc.ShowDialog();
                //this.Persona = mandoc.Docente;
                this.SettingContext();
            }
        }

        private void Txt_Cedula_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text)){
                this.Limpiando();
            }
        }

        public void Limpiar() {
            this.Limpiando();
        }

        public string CModulo
        {
            get { return "__docm_09o4u3ja;hu823_"; }
        }

        public string Cobjecto
        {
            get { return "__doco_Opei_0e92229083"; }
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
            get { return "Buscando Persona"; }
        }

        public string objecto
        {
            get { return "BuscandoPersona"; }
        }

    }
}
