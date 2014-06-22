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
        private void _appseguridad() 
        {
           //this.IsEnabled = Empresa.Usuarios.Seccion.PermisoAutorizado(this.Cobjecto, new Empresa.USeguridad.TPermiso(1));
        }
        public Empresa.Docente.tsolicitudfunenario Solicitud { get; set; }
        private Empresa.Docente.SeguroFunerario _solictud = new Empresa.Docente.SeguroFunerario();

        private void BindingControls()
        {
            this.com_relacion.ItemsSource = new Empresa.Comun.Parentesco();
        }

		public us_Proceso_SeguroFunerario()
        {
            this.Solicitud = new Empresa.Docente.tsolicitudfunenario();
            this.InitializeComponent();
            this._appseguridad();
            this.BindingControls();

            //Registro de entrada Seguro Funerario.
            Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, string.Empty, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.AccesoDivicion), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName));
		}
        Empresa.Comun.ImpresionDocumento _ipdoc = new Empresa.Comun.ImpresionDocumento();

        public void Print() {
            //Reporte 
            SIC.Objs.Docentes.Reportes.Xtra_Formulario_SeguroFunerario decrestosdocs = new Objs.Docentes.Reportes.Xtra_Formulario_SeguroFunerario();

            //estableciendo el tipo de documento que se guardara(formulario de seguro funerario
            Empresa.Comun.timpresiondocumento __itemimpre;
            __itemimpre = new Empresa.Comun.timpresiondocumento();

            //Llenando parametros del tipo de documento
            __itemimpre.IdSolicitudSeguroFunerario = this.Solicitud.Id;
            __itemimpre.IdUsuario = Empresa.Usuarios.Seccion.Usuario.Id;
            __itemimpre.Documento = Empresa.Docente.EnumDocumento.SeguroFunerario;
            __itemimpre.Comentario = string.Empty;

            //Verificando si existe una copia.
            if (!_ipdoc.ExisteDocumento(this.Solicitud))
            {
                //Primera copia WaterMarket limpio
                decrestosdocs.Watermark.Text = string.Empty;
                //Insertar copia
                _ipdoc.Insert(__itemimpre);
            }
    
            Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();
            bool incluirformulario = false;

            if(MessageBox.Show("Desea Incluir el Formulario INB-PJ-16, Si/No ", "Incluir Formulario INB-PJ-16, Si/No", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes){
                incluirformulario = true;
            }
            
            decrestosdocs.bindingSource1.DataSource = this.Solicitud;
            
            if(incluirformulario){
                SIC.Objs.Docentes.Reportes.Xtra_Formulario_SeguroFunerario_PJ16 seguros_pj16 = new Objs.Docentes.Reportes.Xtra_Formulario_SeguroFunerario_PJ16();
                seguros_pj16.Parameters[0].Value = Empresa.Comun.Server.DameTiempoFormatoC;

                seguros_pj16.Parameters[1].Value = this.Solicitud.Docente.EstadoLaboral.Nombre;
                if (this.Solicitud.Docente.EstadoLaboral.Id >= 2) seguros_pj16.Parameters[1].Value = this.Solicitud.Docente.EstadoLaboral.Nombre + " en el Decreto No." + this.Solicitud.Docente.DecretoActual.Decreto.Numero + " emitido " + Empresa.Comun.ConverToDates.FormatoC(this.Solicitud.Docente.DecretoActual.Decreto.FechaEmision);
                
                seguros_pj16.bindingSource1.DataSource = this.Solicitud;
                vista.MostarReporte(seguros_pj16);
            }

            vista.MostarReporte(decrestosdocs);
        }

        public us_Proceso_SeguroFunerario(Empresa.Docente.tsolicitudfunenario item){
            this.InitializeComponent();
            this._appseguridad();

            this.BindingControls();
            this.Solicitud = item;

            //Registro de entrada Seguro Funerario.
            Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, item.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.AccesoDivicion), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName));
        }
        
        private void _cambiandoestadosolicitud(Empresa.Docente.tsolicitudfunenario item)
        {
            if(!item.Id.Equals(0)){
                if (item.EstadoActual.Estado.Id.Equals(1))
                {
                    if(MessageBox.Show("Desea establecer la solicitud en Proceso de Evaluación. Si/No", "Establecer en proceso de evaluación. Si/No", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        this.Solicitud.EstadoActual = new Empresa.Docente.testadoasignado(Empresa.Docente.SeguroFunerarioEstado.GetInstance().GetItem(2));
                        _estados.Insert(this.Solicitud);

                        this.EnCambio("Solicitud");
                        Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, item.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.ModificacionRegistro), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName));
                    }
                    else 
                    {
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

            //Registro de entrada Seguro Funerario.
            Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, item.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.AccesoDivicion), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName));
        }

        public void Guardar(){
            //Lis_Beneficiario.Items.Count
            

        }

        public void Refresh()
        {
            var temp = this.DataContext;
            this.DataContext = null;
            this.DataContext = temp;
        }

        public void Refresh(Empresa.Docente.tsolicitudfunenario item)
        {
            this.Solicitud = item;
            this.EnCambio("Solicitud");
        }

        public void Refresh(Empresa.Docente.tdocente item)
        {
            this.Solicitud = item.SeguroFunerario.Actual;
            this.Solicitud.Docente = item;
            this.usc_buscarPersona.SetItem(this.Solicitud.Solicitante.Cedula);
            this.EnCambio("Solicitud");
        }

        private void But_DireccionSolicitante_Click(object sender, RoutedEventArgs e){
            try {
                SIC.Objs.Controles.Dialogos.win_direccion windire = new Objs.Controles.Dialogos.win_direccion(this.Solicitud.Solicitante.DireccionAsignada);
                windire.ShowDialog();

                //Modificacion de Dirección
                Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, this.Solicitud.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.AccesoDivicion), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName));
                this.Refresh(); 
            }
            catch{
            
            }
        }

        private void But_ContactoSolicitante_Click(object sender, RoutedEventArgs e){
            SIC.Objs.Controles.Dialogos.win_contactos windire = new Objs.Controles.Dialogos.win_contactos(this.Solicitud.Solicitante.Contacto);
            windire.ShowDialog();

            //Modificando contactos.
            Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, this.Solicitud.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.AccesoDivicion), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName));
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

        private bool ExisteRequisitoEnLista(Empresa.Docente.trequesitosasignados item) {
            foreach(Empresa.Docente.trequesitosasignados initem in this.lis_requisitos.Items){
                if (initem.Requisito.Id.Equals(item.Requisito.Id)) return true;
            }
            return false;
            //return this.lis_requisitos.Items.Contains(item); 
        }

        private void but_Agregarrequisito_Click(object sender, RoutedEventArgs e)
        {
            //Agregando Nuevo Requisito
            SIC.Objs.Controles.Dialogos.win_seleccion_requisitos_segurofunerario requisitos = new Objs.Controles.Dialogos.win_seleccion_requisitos_segurofunerario();
            requisitos.ShowDialog();

            if (requisitos.RequisitoSeleccionado != null){
                if (ExisteRequisitoEnLista(requisitos.RequisitoSeleccionado)){
                    if (MessageBox.Show("El Requisito Seleccionado Existe, Desea Ingresarlo Nuevamente?, Si/No.", "Requisito existe, ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes){
                        //Evalua si el requisito es aceptado.
                        if (requisitos.EsAceptado){

                            this.Solicitud.Requisitos.Add(requisitos.RequisitoSeleccionado);
                            this.EnCambio("Solicitud");

                        }
                    }
                }
                else {

                    //Evalua si el requisito es aceptado.
                    if (requisitos.EsAceptado){
                        this.Solicitud.Requisitos.Add(requisitos.RequisitoSeleccionado);
                        this.EnCambio("Solicitud");
                    }

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
            
            SIC.Objs.Controles.Dialogos.Dial_confirmacion_AprobacionSeguroFunerario confirmacion = new Objs.Controles.Dialogos.Dial_confirmacion_AprobacionSeguroFunerario(this.Solicitud);
            //Asignacion desde calculo de monto seguro funerario.
            this.Solicitud.Monto = Solicitud.Docente.MontoFunerario;
            
            confirmacion.ShowDialog();
            if(confirmacion.Resultado == MessageBoxResult.Yes){
                //
                this.Solicitud.EstadoActual.Estado = new Empresa.Comun.TEstandar(3);
                //Insertando estado nuevo de la solicitud.
                _estados.Insert(this.Solicitud);
                //Guardando el monto aprobado.
                _solictud.Update(this.Solicitud);
                //Cambio de contexto.
                this.EnCambio("Solicitud");
                
                //Cambiando Estado de aplicación
                Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, this.Solicitud.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.ModificancionEstadoRegistro), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName));
            }

            confirmacion.Close();
        }

        private void But_Declinar_Click(object sender, RoutedEventArgs e){
            SIC.Objs.Controles.Dialogos.Dial_Declinar_SeguroFunerario confirmacion = new Objs.Controles.Dialogos.Dial_Declinar_SeguroFunerario();
            confirmacion.ShowDialog();

            if (confirmacion.Resultado == MessageBoxResult.Yes){
                this.Solicitud.EstadoActual.Estado = new Empresa.Comun.TEstandar(4);
                _estados.Insert(this.Solicitud);

                //Cambiando Estado de aplicación
                Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, this.Solicitud.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.ModificancionEstadoRegistro), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName));
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
            try{
                SIC.Objs.Controles.win_comentarios come = new Objs.Controles.win_comentarios(this.Solicitud);
                come.ShowDialog();

                //Insertando evento.
                Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, this.Solicitud.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.InsercionNota), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName));
            }
            catch { 
            
            }
        }

        private void But_EditarPersona_Click(object sender, RoutedEventArgs e)
        {
          
            if(this.Lis_Beneficiario.SelectedItem != null)
            {

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
            catch {
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

            if (lis_requisitos.SelectedItem != null) 
            {
                Empresa.Docente.trequesitosasignados req = (Empresa.Docente.trequesitosasignados)lis_requisitos.SelectedItem;
                
                if(req.TieneImagen)
                {
                    try
                    {
                        vista = new Objs.Controles.Dialogos.Dial_ViewImagen(req.AImagen);
                        vista.Show();
                        //Registro de Eventos.
                        Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(this.CModulo, this.objecto, this.Solicitud.Docente.Cedula, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.VistaDatos), Empresa.Usuarios.Seccion.Usuario, GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName));
                    }
                    catch{ 
                    }
                }
            }

        }

        /// <summary>
        /// Editar Requisito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void But_Editar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (lis_requisitos.SelectedItem != null)
                {
                    SIC.Objs.Controles.Dialogos.win_seleccion_requisitos_segurofunerario requisitos = new Objs.Controles.Dialogos.win_seleccion_requisitos_segurofunerario((Empresa.Docente.trequesitosasignados)lis_requisitos.SelectedItem);
                    requisitos.ShowDialog();

                    if(requisitos.RequisitoSeleccionado != null){
                        //Evalua si el requisito es aceptado.
                        if (requisitos.EsAceptado){    
                            this.Solicitud.Requisitos[this.Solicitud.Requisitos.IndexOf((Empresa.Docente.trequesitosasignados)this.lis_requisitos.SelectedItem)] = requisitos.RequisitoSeleccionado;
                            this.EnCambio("Solicitud");
                        }
                    }
                    requisitos.Close();
                }

            }
            catch { 
            
            }
        }
	}
}