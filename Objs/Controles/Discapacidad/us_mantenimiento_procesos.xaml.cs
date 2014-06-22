using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SIC {
	/// <summary>
	/// Interaction logic for us_mantenimiento_procesos.xaml
	/// </summary>
    /// 
	public partial class us_mantenimiento_procesos : UserControl,Empresa.Comun.IFirma, INotifyPropertyChanged {
        public ICommand Grabar;
        public Empresa.Docente.tsolicitudpj Solicitud { get; set; }

        private void _InicializacionComponentes(){
            //this.ObjDatacontext.
            Com_TipoSiniestro.ItemsSource = new Empresa.Docente.TipoSiniestros();
            Com_OrigenSiniestro.ItemsSource = new Empresa.Docente.OrigenSiniestro();
            Com_OrigenBeneficio.ItemsSource = Empresa.Docente.OrigenBeneficio.GetInstance().Lista;
            this.com_relacion.ItemsSource = Empresa.Docente.TipoSolicitante.GetInstance().Lista;
        }

		public us_mantenimiento_procesos(){
            this.InitializeComponent();
            this._InicializacionComponentes();
            this.DataContext = new Empresa.Docente.tdocente();
		}

        public us_mantenimiento_procesos(Empresa.Docente.tdocente item){
            
            this.InitializeComponent();
            this._InicializacionComponentes();
            //this.ObjDatacontext = item;
            //Recuperando items

            usc_aseguradora.SetItem(item.SolicitudPJ.Actual.Aseguradora);
            usc_buscarPersona.SetItem(item.SolicitudPJ.Actual.Solicitante);

            pro_barglobal.Maximum = item.SolicitudPJ.Actual.Tiempos.TotalTiempoGlobal;
            pro_barglobal.Value = item.SolicitudPJ.Actual.Tiempos.TiempoGlobal;
        }

        public us_mantenimiento_procesos(Empresa.Docente.tsolicitudpj item){
            
            //Solicitud 
            this.Solicitud = item;

            this.InitializeComponent();
            
            //Inicializazndo 
            this._InicializacionComponentes();

            //Recuperando items
            usc_aseguradora.SetItem(this.Solicitud.Aseguradora);
            usc_buscarPersona.SetItem(this.Solicitud.Solicitante);
           
            //Estableciendo valores de tiempo.
            pro_barglobal.Value = this.Solicitud.Tiempos.DiferenciaTiemposPorciento;
            
            //Refresh UI
            this.EnCambio("Solicitud");
        }

        //public void Guardar(){
        //    try{
        //        //Atrapando Contactos.
        //        ObjDatacontext.SolicitudPJ.Actual.Aseguradora = usc_aseguradora.SelectItem;
        //        bool resul=false;

        //        if(ObjDatacontext.SolicitudPJ.Actual.Id.Equals(0)){
        //             resul = ObjDatacontext.SolicitudPJ.Insert(this.ObjDatacontext);
        //        }else{
        //            resul = ObjDatacontext.SolicitudPJ.Update(this.ObjDatacontext);
        //        }

        //        if(resul){
        //            MessageBox.Show("Solicitud Guardada con exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
        //        }
        //        else{
        //            MessageBox.Show("Verifique la Solicitud falta información.", "Falta información", MessageBoxButton.OK, MessageBoxImage.Stop);
        //        }


        //    }catch (Exception ex){
        //        MessageBox.Show("Error en el proceso", "Error en el proceso.", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}


        //public void Guardar()
        //{
        //    try
        //    {
        //        //Atrapando Contactos.
        //        ObjDatacontext.SolicitudPJ.Actual.Aseguradora = usc_aseguradora.SelectItem;
        //        bool resul = false;

        //        if (ObjDatacontext.SolicitudPJ.Actual.Id.Equals(0))
        //        {
        //            resul = ObjDatacontext.SolicitudPJ.Insert(this.ObjDatacontext);
        //        }
        //        else
        //        {
        //            resul = ObjDatacontext.SolicitudPJ.Update(this.ObjDatacontext);
        //        }

        //        if (resul)
        //        {
        //            MessageBox.Show("Solicitud Guardada con exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Verifique la Solicitud falta información.", "Falta información", MessageBoxButton.OK, MessageBoxImage.Stop);
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error en el proceso", "Error en el proceso.", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        public void Imprimir(){
            SIC.Objs.Controles.ReportSelectDocente wselect = new Objs.Controles.ReportSelectDocente(this.Solicitud);
            wselect.Show();
        }

        private void usc_buscarPersona_FinBusqueda_1(object e){
            if (e != null){
                Txt_NombreSol.Text = ((Empresa.RHH.tpersonal)e).NombreCompleto;
            }
        }

        private void usc_buscarPersona_Limpiando_1(object e){
            Txt_NombreSol.Text = string.Empty;

            Direccion_Solicitante.IsEnabled = false;
            Contactos_Solicitante.IsEnabled = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e){
            SIC.Objs.Controles.win_requisitosseleccion req = new Objs.Controles.win_requisitosseleccion();
            req.ShowDialog();

            if (req.Requisito != null){
                this.Solicitud.Requisitos.Add(req.Requisito);
                EnCambio("Solicitud");
            }

        }
       
        private void But_DireccionSolicitante_Click(object sender, RoutedEventArgs e) {
            SIC.Objs.Controles.Dialogos.win_direccion diresdialog = new Objs.Controles.Dialogos.win_direccion(this.Solicitud.Solicitante.DireccionAsignada);
            diresdialog.ShowDialog();
            //this.Refresh(this.Solicitud);
        }

        private void But_ContactoSolicitante_Click(object sender, RoutedEventArgs e){
            //contacto del solicitante
            SIC.Objs.Controles.wus_contacto conta = new Objs.Controles.wus_contacto(this.Solicitud.Solicitante.Contacto);
            conta.ShowDialog();
            
            if (conta.Contacto != null){
                //asignación de contactos.
                this.Solicitud.Solicitante.Contacto = conta.Contacto;
            }

            //this.Refresh(this.Solicitud);
        }

        private void usc_buscarPersona_SeleccionItem(object e){

            if(string.IsNullOrEmpty(((Empresa.RHH.tpersonal)e).Cedula)){
                Direccion_Solicitante.IsEnabled = false;
                Contactos_Solicitante.IsEnabled = false;
            }else{
                //Encontrado
                //this.ObjDatacontext.SolicitudPJ.Actual.Solicitante = new Empresa.Docente.TSolicitante(((Empresa.RHH.tpersonal)e));
             
                this.Solicitud.Solicitante.Cedula = ((Empresa.RHH.tpersonal)e).Cedula;
                this.Solicitud.Solicitante.Nombres = ((Empresa.RHH.tpersonal)e).Nombres;
                this.Solicitud.Solicitante.Apellidos = ((Empresa.RHH.tpersonal)e).Apellidos;
                this.Solicitud.Solicitante.Nss = ((Empresa.RHH.tpersonal)e).Nss;
                this.Solicitud.Solicitante.EsMasculino = ((Empresa.RHH.tpersonal)e).EsMasculino;
               
                Direccion_Solicitante.IsEnabled = true;
                Contactos_Solicitante.IsEnabled = true;
            }
            //this.Refresh(this.Solicitud);
        }

        private void Lis_Pasos_MouseDoubleClick(object sender, MouseButtonEventArgs e){
            //this.Refresh(this.DataContext);
        }

        private void gridview1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(gridview1.SelectedItem != null){

                this.Solicitud.Pasos.ActivarItem(((Empresa.Docente.TPasospjAsignados)gridview1.SelectedItem));
                this.Solicitud.Pasos.Refres();
              //  this.Refresh(DataContext);
            }
        }

        private void CommandBinding_CanExecute_1(object sender, CanExecuteRoutedEventArgs e)
        {
            var ee = e;
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            var ee = e;
        }

        public string CModulo
        {
            get { return "__docm_09o4u3ja;hu823_"; }
        }

        public string Cobjecto
        {
            get { return "__doco_0829jk_028i12"; }
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
            get { return "Consulta Formulario Pension Discapacidad"; }
        }

        public string objecto
        {
            get { return "ConsultaFormularioPensionDiscapacidad"; }
        }

        private void But_Completar_Click(object sender, RoutedEventArgs e){
            this.gridview1_MouseDoubleClick(null, null);
        }

        private void usc_aseguradora_SeleccionItem(object e){
            try{
                this.Solicitud.Aseguradora = (Empresa.Comun.TSuplidor)e;
            }
            catch {
                this.Solicitud.Aseguradora = new Empresa.Comun.TSuplidor();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void EnCambio(string nombre)
        {
            PropertyChangedEventHandler manejador = PropertyChanged;
            if (manejador != null)
            {
                manejador(this, new PropertyChangedEventArgs(nombre));
            }
        }

	}
}