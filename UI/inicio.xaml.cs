using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SIC
{
	/// <summary>
	/// Interaction logic for inicio.xaml
	/// </summary>
	public partial class inicio : Window
	{
        private UI.Presentacion presen = new UI.Presentacion();
        private UI.areatrabajo workpage;
        private UI.areatrabajo_Visitas workpage_visita;
        private UI.areatrabajo_Configuracion _areatrabajo_Configuracion;
        private UI.MenuPrincipal menu = new UI.MenuPrincipal();
        private SIC.us_nominas nomina;
        private System.Threading.Thread _hl_estatico_elementos;
        SIC.Objs.Controles.win_espera_elementos_estaticos _espera_estaticos;

        delegate void del_muestra();
        delegate void del_cierra();

        private void AppSecurity(){
            menu.But_Entrar_PJ.IsEnabled = Empresa.Usuarios.Seccion.PermisoAutorizado(menu.Cobjecto, new Empresa.USeguridad.TBoleto(new Empresa.USeguridad.TPermiso(2), new Empresa.USeguridad.TAccion(1)));
        }

        static SIC.Objs.Controles.win_espera_elementos_estaticos _espera_estaticos_02;
        public static void _monstrando_espera_estatica(){
            try{
                _espera_estaticos_02 = new Objs.Controles.win_espera_elementos_estaticos();
                _espera_estaticos_02.Show();
            }
            catch{
            }
        }
        public static void _Cerrando_espera_estatica()
        {
            try{
                _espera_estaticos_02.Close();
            }
            catch{

            }
        }

        private void _descargandoelementos() 
        {
            Empresa.Docente.Decreto.Clear(); 

            Empresa.Docente.EstadoBeneficio.Clear();
            // this.pro_carga.Value += 6;
            Empresa.Docente.EstadoDecreto.Clear();
            //  this.pro_carga.Value += 6;
            Empresa.Docente.EstadoPJ.ClearObject(); 
            // this.pro_carga.Value += 6;
            Empresa.Docente.GrupoTiempos.Clear();
            // this.pro_carga.Value += 6;
            Empresa.Docente.GrupoTiempoSeguroFunerario.Clear();
            // this.pro_carga.Value += 6;
            Empresa.Docente.IngresoDescuento.Clear();
            // this.pro_carga.Value += 6;
            Empresa.Docente.OrigenBeneficio.Clear();
            //this.pro_carga.Value += 6;
            Empresa.Docente.Presidentes.Clear();
            // this.pro_carga.Value += 6;
            Empresa.Docente.Requisitos.Clear();
            //  this.pro_carga.Value += 6;
            Empresa.Docente.RequisitosSeguroFunerario.Clear();
            //  this.pro_carga.Value += 6;
            Empresa.Docente.SeguroFunerarioEstado.Clear();
            //  this.pro_carga.Value += 6;
            Empresa.Docente.TipoDocente.Clear();
            //  this.pro_carga.Value += 6;
            //Empresa.Docente.TipoDocumento.GetInstance();
            //  this.pro_carga.Value += 6;
            Empresa.Docente.TipoSolicitante.Clear();
          
            //SIC.Objs.Docentes.Reportes.Xtra_AnalisisDecreto r = new SIC.Objs.Docentes.Reportes.Xtra_AnalisisDecreto();
            //Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();
            //vista.CargaReporte(r);
            //r.Dispose();
        }
        private void _cargarelementos()
        {
            Empresa.Docente.Decreto.GetInstnace();
            Empresa.Docente.EstadoBeneficio.GetInstance();
            Empresa.Docente.EstadoDecreto.GetInstance();
            Empresa.Docente.EstadoPJ.GetInstance();
            Empresa.Docente.GrupoTiempos.GetInstance();
            Empresa.Docente.GrupoTiempoSeguroFunerario.GetInstance();
            Empresa.Docente.IngresoDescuento.GetInstance();
            Empresa.Docente.OrigenBeneficio.GetInstance();
            Empresa.Docente.Presidentes.GetInstance();
            Empresa.Docente.Requisitos.GetInstante();
            Empresa.Docente.RequisitosSeguroFunerario.GetInstante();
            Empresa.Docente.SeguroFunerarioEstado.GetInstance();
            Empresa.Docente.TipoDocente.GetInstance();
            Empresa.Docente.TipoSolicitante.GetInstance();
        }

        public inicio()
        {
			this.InitializeComponent();
            this.AppSecurity();

            menu.But_Entrar_PJ.Click += But_Entrar_PJ_Click;
            menu.But_Entrar_Visita.Click += But_Entrar_Visita_Click;

            menu.But_Inabima.Click += But_Entrar_Inabima_Click;
            presen.But_Entrar.Click += But_Presen_Click;
            menu.But_Config.Click += But_Entrar_Configuracion_Click;

            us_trangeneral.ShowPage(presen);
		}

        //Entrada Menu de Inicio
        private void But_Presen_Click(object sender, RoutedEventArgs e)
        {
            try{
                us_trangeneral.ShowPage(menu);
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);   
            } 
        }

        //Entrada a presentacion
        private void But_Inicio_Click(object sender, RoutedEventArgs e){
            us_trangeneral.ShowPage(presen);
        }

        private void But_Entrar_PJ_Click(object sender, RoutedEventArgs e){
            try
            {
                //Carga Estaticas.
                //this._hl_estatico_elementos = new System.Threading.Thread(this._monstrando_espera_estatica);
                //Configurando Hilo
                //_hl_estatico_elementos.SetApartmentState(System.Threading.ApartmentState.STA);
                //Incializando Hilo
                //this._hl_estatico_elementos.Start();
                //Carga elementos.


                this._cargarelementos();
                ///Entrada al modulo de pensiones y jubilaciones.
                workpage = new UI.areatrabajo();
                workpage.But_Inicio.Click += But_Inicio_Click;
                ///Registro de Evento
                Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(workpage.CModulo, workpage.objecto, string.Empty, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.AccesoDivicion), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName));
                us_trangeneral.ShowPage(workpage);
            }
            catch {
            
            }
        }
        
        //Entrada el Modulo de Visitas.
        private void But_Entrar_Visita_Click(object sender, RoutedEventArgs e){
            try{ 
                workpage_visita = new UI.areatrabajo_Visitas();
                workpage_visita.But_Inicio.Click += But_Inicio_Click;
                us_trangeneral.ShowPage(workpage_visita);
            }
            catch { }
        }

        //Entrada el Modulo de Configuracion
        private void But_Entrar_Configuracion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _areatrabajo_Configuracion = new UI.areatrabajo_Configuracion();
                _areatrabajo_Configuracion.But_Inicio.Click += But_Inicio_Click;
                us_trangeneral.ShowPage(_areatrabajo_Configuracion);
            }
            catch { }
        }

        private void But_Entrar_Inabima_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.nomina = new us_nominas();
                us_trangeneral.ShowPage(nomina);
            }
            catch { }
        }

        private void Window_Closed(object sender, EventArgs e){
            //_descargandoelementos();
        }

	}
}