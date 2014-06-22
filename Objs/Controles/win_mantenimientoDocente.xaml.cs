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
using System.Windows.Shapes;

namespace SIC.Objs.Controles
{
    /// <summary>
    /// Interaction logic for win_mantenimientoDocente.xaml
    /// </summary>
    public partial class win_mantenimientoDocente : Window,Empresa.Comun.IFirma{

		public Empresa.Docente.tdocente Docente{
            get {
                return (Empresa.Docente.tdocente)this.DataContext;
            }
            set {
                this.DataContext = value;
            }
        }

        private static Empresa.Docente.tdocente _docenteinicial;

        private void Bindingcontrols(Empresa.Docente.tdocente item) {
            com_Decretos.ItemsSource = Empresa.Docente.Decreto.GetInstnace().Lista;
            lis_aseguradoras.ItemsSource = new Empresa.Comun.AseguradoresRecurrentes().Lista;
            com_tipo.ItemsSource = Empresa.Comun.TipoMuerte.GetInstance().Lista;
 
            if(!item.EsInabima){
                eRSuplidormini.SetItem(item.Aseguradora);
            }
            
        }

        public win_mantenimientoDocente(){
            InitializeComponent();

            this.Docente = new Empresa.Docente.tdocente();
            _docenteinicial = this.Docente;

            this.Bindingcontrols((Empresa.Docente.tdocente)this.Docente);
        }

        public win_mantenimientoDocente(Empresa.Docente.tdocente item){
            _docenteinicial = item;
            InitializeComponent();
            this.Docente = item;

            this.Bindingcontrols(item) ;
        }

        private void But_Guardar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            try {

                    if(MessageBox.Show("Desea Guardar los Cambios solicitados, Si/No","Deseo Guardar Cambios, Si/No",MessageBoxButton.YesNo,MessageBoxImage.Question)==MessageBoxResult.Yes){
                        Empresa.Docente.Docente doc = new Empresa.Docente.Docente();
                        doc.Update(this.Docente);

                        ///Registro de Evento
                        Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, this.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.ModificacionRegistro), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName));
                        this.Close();
                    }
            }
            catch {
                MessageBox.Show("Error, Vefique todos los datos requeridos estan suplidos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void But_Cancelar_Click(object sender, RoutedEventArgs e){
            this.Docente = _docenteinicial;
            this.Close();
        }

        private void Refresh(object e){
            this.DataContext = null;
            this.DataContext = e;
        }

        private void But_EditContactos_Click(object sender, RoutedEventArgs e){
            //SIC.Objs.Controles.win_MantenimientoContactoDireccion mantdirec = new win_MantenimientoContactoDireccion(this.Docente.Contacto,this.Docente.Direccion);
            //mantdirec.ShowDialog();
            //this.Docente.Contacto = mantdirec.Contacto;
            //this.Docente.Direccion = mantdirec.Direccion;
        }

        private void But_AsDireccion_Click(object sender, RoutedEventArgs e){
            SIC.Objs.Controles.Dialogos.win_direccion wdireccion = new Dialogos.win_direccion(this.Docente);
            wdireccion.ShowDialog();
        }

        private void But_AsContactos_Click(object sender, RoutedEventArgs e){
            SIC.Objs.Controles.Dialogos.win_contactos wcontacto = new Dialogos.win_contactos(this.Docente);
            wcontacto.ShowDialog(); 
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e){
              //Es Fallecido
            if (this.Docente.FechaFallecido == DateTime.MinValue || this.Docente.FechaFallecido == DateTime.MaxValue){
                this.Docente.FechaFallecido = DateTime.MinValue;
            }
              this.Refresh(this.Docente);
        }

        private void ch_esinabima_Click(object sender, RoutedEventArgs e){
            //Es de Inabima
            CheckBox control = sender as CheckBox;

            this.Docente.DecretoBeneficiarios = new Empresa.Docente.TDecreto();
            this.Docente.Aseguradora = new Empresa.Comun.TSuplidor();
            this.Docente.FechaPrimerPago = DateTime.MinValue;

            
            if(control.IsChecked==true){
                //Inabima
                

            }
            else{
            
            
            }

            

            this.Refresh(this.DataContext);

        }

        private void com_Decretos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox control = sender as ComboBox;
            
            if (control.SelectedItem != null) {
                Empresa.Docente.TDecreto decreselect = (Empresa.Docente.TDecreto)control.SelectedItem;
                this.dt_fechaPrimerPago.SelectedDate = decreselect.FechaEP;
            }

        }

        private void lis_aseguradoras_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBox control = sender as ListBox;
            if (control.SelectedItem != null) {
                this.Docente.Aseguradora = (Empresa.Comun.TSuplidor)control.SelectedItem;
                eRSuplidormini.SetItem(this.Docente.Aseguradora);
                expander.IsExpanded = false;
            }
        }

        public string CModulo
        {
            get { return "__docm_09o4u3ja;hu823_"; }
        }

        public string Cobjecto
        {
            get { return "__doco)929333233)__"; }
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
            get { return "Mantenimiento Docente"; }
        }

        public string objecto
        {
            get { return "MantenimientoDocente"; }
        }

        private void But_Imprimir_Click(object sender, RoutedEventArgs e){
            
            try{
                Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();
                SIC.Objs.Docentes.Reportes.Xtra_Docente decrestosdocs = new Docentes.Reportes.Xtra_Docente();
                decrestosdocs.bindingSource3.DataSource = this.Docente;
                vista.MostarReporte(decrestosdocs);

                ///Registro de Evento
                Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, this.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.VistaReporte), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName, "Reporte - Docente"));
            }
            catch{
            
            }
        }

        private void But_AsDireccion_Fallecimiento_Click(object sender, RoutedEventArgs e){
            SIC.Objs.Controles.Dialogos.win_direccion wdireccion = new Dialogos.win_direccion(Docente.DatosFellecimiento.Direccion);
            wdireccion.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var r = e.Cancel;
           

        }

    }
}
