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
using System.Collections.ObjectModel;

namespace SIC.UI
{
    /// <summary>
    /// Interaction logic for MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : UserControl, Empresa.Comun.IFirma{
        private BackgroundWorker bw = new BackgroundWorker();
        private BackgroundWorker bw2 = new BackgroundWorker();

        private BackgroundWorker __bw_notificaciones = new BackgroundWorker();
        
        private void AppSecurity(){
          this.But_Entrar_PJ.IsEnabled = Empresa.Usuarios.Seccion.PermisoAutorizado(this.Cobjecto, new Empresa.USeguridad.TBoleto(new Empresa.USeguridad.TPermiso(1), new Empresa.USeguridad.TAccion(1)));
        }

		public MenuPrincipal(){
            InitializeComponent();

            try{
                this.AppSecurity();
            }
            catch {
                //Cierre de aplicación
                MessageBox.Show("La seguridad de la aplicación no puede ser verificada.", "Seguridad no verificada",MessageBoxButton.OK,MessageBoxImage.Warning);
                Application.Current.Shutdown();
            }

            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.WorkerSupportsCancellation = true;
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            bw2.DoWork += new DoWorkEventHandler(bw2_DoWork);
            bw2.WorkerSupportsCancellation = true;
            bw2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw2_RunWorkerCompleted);

            this.__bw_notificaciones.DoWork += new DoWorkEventHandler(bw_notificaiones_DoWork);
            this.__bw_notificaciones.WorkerSupportsCancellation = true;
            this.__bw_notificaciones.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_notificaciones_RunWorkerCompleted);
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e){
            Empresa.Docente.Docentes docs = new Empresa.Docente.Docentes();
            e.Result = docs.GetItem(true).Count;
        }
        
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e){
            //Asignando Letreros.
            us_Mensaje_Excluidos.Titulo = "Beneficiarios a Excluir";
            us_Mensaje_Excluidos.TituloInterno = "Cantidad Beneficiarios a Excluir";
            us_Mensaje_Excluidos.Texto = "Notificación para los beneficiarios a excluir, si existen porfavor verifique y aplique la exclución.";
            us_Mensaje_Excluidos.Cifra = e.Result.ToString();
            
            us_Mensaje_Excluidos.TerminadoEnvento();
        }

        private void bw2_DoWork(object sender, DoWorkEventArgs e){
            //e.Result = new Empresa.Docente.Nomina((byte)6, new Empresa.RHH.testadolaboral(2)).Lista;
            //new Empresa.Docente.Nomina().DameListadoCantidadNomina()
        }

        private void bw2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e){
            PointCollection puntos = new PointCollection();
            int cont =0;
            us_estadisticaPJ.us_Marco.Series[0].LegendItems.Clear();
            foreach(Empresa.Docente.TNomina itemn in (ObservableCollection<Empresa.Docente.TNomina>)e.Result){
                cont += 1;
                puntos.Add(new Point(cont,itemn.ConteoDocentes));
                us_estadisticaPJ.us_Marco.Series[0].LegendItems.Add(itemn.Fecha.ToString("MMMM") + "-" + itemn.ConteoDocentes.ToString()); 
            }

            us_estadisticaPJ.Titulo = "Ultimas 6 Nominas Pensionados";
            us_estadisticaPJ.Texto = "Comparación de las Ultimas 6 Nominas Pensionados";
            us_estadisticaPJ.us_Marco.DataContext = puntos;
            //Indica que la carga fue terminada
            us_estadisticaPJ.TerminadoEnvento();
        }


        private void bw_notificaiones_DoWork(object sender, DoWorkEventArgs e) {
            Empresa.Docente.NotificadosFallecidos __noti = new Empresa.Docente.NotificadosFallecidos();
            e.Result = __noti.Cantidad();
        }

        private void bw_notificaciones_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            us_Mensaje_Notificaciones.Titulo = "Personas Notificadas Fallecidas";
            us_Mensaje_Notificaciones.TituloInterno = "Cantidad Notificaciones de Fallecimiento";
            us_Mensaje_Notificaciones.Texto = "Notificación de Fallecimiento, Verifique la notificaciones de fallecimiento.";
            us_Mensaje_Notificaciones.Cifra = e.Result.ToString();
            us_Mensaje_Notificaciones.TerminadoEnvento();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ///Estadisticas y mensajes.
            ///
            if (!bw.IsBusy)
            {
                bw.RunWorkerAsync();
                us_Mensaje_Excluidos.InicioEnvento();
                //bw2.RunWorkerAsync();

                __bw_notificaciones.RunWorkerAsync();
                us_Mensaje_Notificaciones.InicioEnvento();
            }
            else {
                MessageBox.Show("Espere mientras termina el proceso, si el mensaje persiste reinicie la aplicación", "Espere, si el mensaje persiste reinicie.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
        }

        public string CModulo {
            get { return "__docm_09o4u3ja;hu823_"; }
        }

        public string Cobjecto {
            get { return "__doco_me__0826tTTiOp_"; }
        }

        public string Descripcion
        {
            get { throw new NotImplementedException(); }
        }

        public string Modulo
        {
            get { return "Docente"; }
        }

        public string Nombre {
            get { return "Menú de Selección Modulos"; }
        }

        public string objecto
        {
            get { return "MenuSeleccionModulos"; }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            bw.CancelAsync();
            bw.Dispose();

            bw2.CancelAsync();
            bw2.Dispose();
        }
    }
}
