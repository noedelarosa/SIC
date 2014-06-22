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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace SIC
{
	/// <summary>
	/// Interaction logic for us_Proceso_SeguroFunerario.xaml
	/// </summary>
    public partial class us_Proceso_SeguroFunerario : UserControl, INotifyPropertyChanged, Empresa.Comun.IFirma
    {
        private void _appseguridad() {
           //this.IsEnabled = Empresa.Usuarios.Seccion.PermisoAutorizado(this.Cobjecto, new Empresa.USeguridad.TPermiso(1));
        }

        public Empresa.Docente.tsolicitudfunenario Solicitud { get; set; }

        private void BindingControls(){
            this.com_relacion.ItemsSource = new Empresa.Comun.Parentesco();
        }

		public us_Proceso_SeguroFunerario(){
            this.Solicitud = new Empresa.Docente.tsolicitudfunenario();
            this.InitializeComponent();
            this._appseguridad();
            this.BindingControls();
		}

        public void Print() {
            Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();

            SIC.Objs.Docentes.Reportes.Xtra_Formulario_SeguroFunerario decrestosdocs = new Objs.Docentes.Reportes.Xtra_Formulario_SeguroFunerario();
            decrestosdocs.bindingSource1.DataSource = this.Solicitud;
            vista.MostarReporte(decrestosdocs); 
        }

        public us_Proceso_SeguroFunerario(Empresa.Docente.tsolicitudfunenario item){
            this.InitializeComponent();
            this._appseguridad();

            this.BindingControls();
            this.Solicitud = item;
     
        }
        
        private void _cambiandoestadosolicitud(Empresa.Docente.tsolicitudfunenario item)
        {
            if(!item.Id.Equals(0)){
                if (item.EstadoActual.Estado.Id.Equals(1))
                {
                    if (MessageBox.Show("Desea establecer la solicitud en Proceso de Evaluación. Si/No", "Establecer en proceso de evaluación. Si/No", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes){
                        this.Solicitud.EstadoActual = new Empresa.Docente.testadoasignado(Empresa.Docente.SeguroFunerarioEstado.GetInstance().GetItem(2));
                        _estados.Insert(this.Solicitud);

                        this.EnCambio("Solicitud");
                    }
                    else {
                        MessageBox.Show("Las solicitudes que se encuentran en estado de APROBACION O DECLINADA, No puede cambiar su estado.","No se puede cambiar el estado de la solicitud.",MessageBoxButton.OK,MessageBoxImage.Stop);
                    }
                }
            }
        }

        public us_Proceso_SeguroFunerario(Empresa.Docente.tdocente item){
            this.Solicitud = item.SeguroFunerario.Actual;
            this.Solicitud.Docente = item;
            this.InitializeComponent();
            this._appseguridad();
            
            this.usc_buscarPersona.SetItem(this.Solicitud.Solicitante.Cedula);
            this.BindingControls();
            
        }

        public void Guardar(){
            //Lis_Beneficiario.Items.Count
            

        }

        public void Refresh() {
            var temp = this.DataContext;
            this.DataContext = null;
            this.DataContext = temp;
        }

        private void But_DireccionSolicitante_Click(object sender, RoutedEventArgs e){
            try {
                SIC.Objs.Controles.Dialogos.win_direccion windire = new Objs.Controles.Dialogos.win_direccion(this.Solicitud.Solicitante.DireccionAsignada);
                windire.ShowDialog();
                this.Refresh(); 

            }
            catch{
            
            }
        }

        private void But_ContactoSolicitante_Click(object sender, RoutedEventArgs e){
            SIC.Objs.Controles.Dialogos.win_contactos windire = new Objs.Controles.Dialogos.win_contactos(this.Solicitud.Solicitante.Contacto);

            windire.ShowDialog();
            this.Refresh(); 
        }

        private void but_AgregarPersona_Click(object sender, RoutedEventArgs e)
        {
            SIC.Objs.Controles.Dialogos.Win_Busqueda_Personal_Estandar winper = new Objs.Controles.Dialogos.Win_Busqueda_Personal_Estandar();
            winper.ShowDialog();

            try {
                if (winper.Editame==true){
                    if(this.Solicitud.ExiteBeneficiario(winper.PersonaRelacion.Persona.Cedula)){
                        MessageBox.Show("El Beneficiario exite en la lista. Intento con otro Beneficiario.", "Existe Beneficiario", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                    else{
                        this.Solicitud.Beneficiarios.Add(winper.PersonaRelacion);
                        this.EnCambio("Solicitud");
                    }
                }
            }
            catch {
                MessageBox.Show(Empresa.Comun.Mensajes.Error_Proceso,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }

            winper.Close();
        }

        private void but_Agregarrequisito_Click(object sender, RoutedEventArgs e){
            //Agregando Nuevo Requisito
            SIC.Objs.Controles.Dialogos.win_seleccion_requisitos_segurofunerario requisitos = new Objs.Controles.Dialogos.win_seleccion_requisitos_segurofunerario();
            requisitos.ShowDialog();

            if (requisitos.Requisito != null) {
               //Evalua si el requisito es aceptado.
                if (requisitos.EsAceptado){
                    this.Solicitud.Requisitos.Add(requisitos.Requisito);
                    this.EnCambio("Solicitud");
                }
            }
            requisitos.Close();
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

        private void usc_buscarPersona_SeleccionItem(object e){

            if (string.IsNullOrEmpty(((Empresa.RHH.tpersonal)e).Cedula)){
                Direccion_Solicitante.IsEnabled = false;
                Contactos_Solicitante.IsEnabled = false;
                
            }
            else{
                //Encontrado
                //this.ObjDatacontext.SolicitudPJ.Actual.Solicitante = new Empresa.Docente.TSolicitante(((Empresa.RHH.tpersonal)e));

                this.Solicitud.Solicitante.Cedula = ((Empresa.RHH.tpersonal)e).Cedula;
                this.Solicitud.Solicitante.Nombres = ((Empresa.RHH.tpersonal)e).Nombres;
                this.Solicitud.Solicitante.Apellidos = ((Empresa.RHH.tpersonal)e).Apellidos;
                this.Solicitud.Solicitante.Nss = ((Empresa.RHH.tpersonal)e).Nss;
                this.Solicitud.Solicitante.EsMasculino = ((Empresa.RHH.tpersonal)e).EsMasculino;
                this.Solicitud.Solicitante.Foto = ((Empresa.RHH.tpersonal)e).Foto;

                Direccion_Solicitante.IsEnabled = true;
                Contactos_Solicitante.IsEnabled = true;
            }
            //this.Refresh(this.Solicitud);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void EnCambio(string nombre){
            PropertyChangedEventHandler manejador = PropertyChanged;
            if(manejador != null){
                manejador(this, new PropertyChangedEventArgs(nombre));
            }

        }

        private void But_QuitarPersona_Click(object sender, RoutedEventArgs e){
            
            if (Lis_Beneficiario.SelectedItem != null) {
                try
                {
                    if (MessageBox.Show("Desea Eliminar el Beneficiario seleccionado. Si/No", "Desea Eliminar el beneficiario. Si/No", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes){
                        Empresa.Docente.tpersonaRelacionada itemselect = (Empresa.Docente.tpersonaRelacionada)Lis_Beneficiario.SelectedItem;
                        if (itemselect.EsNuevo){
                            this.Solicitud.Beneficiarios.Remove(itemselect);
                        }
                        else{
                            Empresa.Docente.BeneficiariosSeguroFunerario _listadosbenes = new Empresa.Docente.BeneficiariosSeguroFunerario();
                            _listadosbenes.Delete(itemselect, this.Solicitud.Id);
                            this.Solicitud.Beneficiarios.Remove(itemselect);
                        }
                        this.EnCambio("Solicitud");
                    }
                }
                catch {
                    MessageBox.Show("Error en el Proceso", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lis_requisitos.SelectedItem != null){
                Empresa.Docente.trequesitosasignados req_select = (Empresa.Docente.trequesitosasignados)lis_requisitos.SelectedItem;
                if (MessageBox.Show("Desea Eliminar el Item Seleccionado, Si/No", "Desea Eliminar Si/No", MessageBoxButton.YesNo, MessageBoxImage.Question)== MessageBoxResult.Yes){
                    if (req_select.Id.Equals(0)){
                        this.Solicitud.Requisitos.Remove(req_select);
                        //this.
                    }
                    else{
                        MessageBox.Show("Acceso no concedido", "No Acceso", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                }

            }
        }

        Empresa.Docente.SeguroFunerarioEstados _estados = new Empresa.Docente.SeguroFunerarioEstados();
        private void But_Aprobada_Click(object sender, RoutedEventArgs e){
            SIC.Objs.Controles.Dialogos.Dial_confirmacion_AprobacionSeguroFunerario confirmacion = new Objs.Controles.Dialogos.Dial_confirmacion_AprobacionSeguroFunerario();
            confirmacion.ShowDialog();

            if (confirmacion.Resultado == MessageBoxResult.Yes) {
                this.Solicitud.EstadoActual.Estado = new Empresa.Comun.TEstandar(3);
                _estados.Insert(this.Solicitud);
                this.EnCambio("Solicitud");
            }
            confirmacion.Close();
        }

        private void But_Declinar_Click(object sender, RoutedEventArgs e){
            SIC.Objs.Controles.Dialogos.Dial_Declinar_SeguroFunerario confirmacion = new Objs.Controles.Dialogos.Dial_Declinar_SeguroFunerario();
            confirmacion.ShowDialog();

            if (confirmacion.Resultado == MessageBoxResult.Yes){
                this.Solicitud.EstadoActual.Estado = new Empresa.Comun.TEstandar(4);

                _estados.Insert(this.Solicitud);
                this.EnCambio("Solicitud");
            }

            confirmacion.Close();
        }

        private void But_ProcesoEvaluacion_Click(object sender, RoutedEventArgs e)
        {
            // Estableciendo cambio de estao de forma
            _cambiandoestadosolicitud(this.Solicitud);
        }

        private void But_Nota_Click(object sender, RoutedEventArgs e){
            SIC.Objs.Controles.win_comentarios come = new Objs.Controles.win_comentarios(this.Solicitud);
            come.ShowDialog();
        }

        private void But_EditarPersona_Click(object sender, RoutedEventArgs e)
        {
          if(this.Lis_Beneficiario.SelectedItem != null){
            SIC.Objs.Controles.Dialogos.Win_Busqueda_Personal_Estandar winper = new Objs.Controles.Dialogos.Win_Busqueda_Personal_Estandar((Empresa.Docente.tpersonaRelacionada)this.Lis_Beneficiario.SelectedItem);
            winper.ShowDialog();
            
             try {

                 if(winper.Editame == true)
                 {

                  for(int i = 0; i <= this.Solicitud.Beneficiarios.Count-1; i++){
                      if(this.Solicitud.Beneficiarios[i].Persona.Cedula.Equals(winper.PersonaRelacion.Persona.Cedula)) {
                         this.Solicitud.Beneficiarios[i] = winper.PersonaRelacion;
                         break;
                      }

                 }
             }
            }
            catch{
                MessageBox.Show(Empresa.Comun.Mensajes.Error_Proceso, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
             winper.Close();
        }

        }

        public string CModulo {
            get { return "__docmieOOp32876_"; }
        }

        public string Cobjecto {
            get { return "__doc___kie981bvasr__"; }
        }

        public string Descripcion {
            get { throw new NotImplementedException(); }
        }

        public string Modulo{
            get { return "Docente"; }
        }

        public string Nombre{
            get { return "Formulario de Solicitud Seguro Funerario"; }
        }

        public string objecto{
            get { return "FormularioSeguroFunerario"; }
        }

        private SIC.Objs.Controles.Dialogos.Dial_ViewImagen vista;
        private void But_ViewItemRequisitos_Click(object sender, RoutedEventArgs e){

            if (lis_requisitos.SelectedItem != null) {
                Empresa.Docente.trequesitosasignados req = (Empresa.Docente.trequesitosasignados)lis_requisitos.SelectedItem;
                if(req.TieneImagen){
                    try{
                        vista = new Objs.Controles.Dialogos.Dial_ViewImagen(req.AImagen);
                        vista.Show();
                    }
                    catch { 
                    
                    }
                }
            }
        }

        
	}
}