using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for us_MantenimientoListadoDecreto.xaml
    /// </summary>
    public partial class us_MantenimientoListadoDecreto : UserControl, INotifyPropertyChanged
    {
        public event DInicio visitandoDocente = delegate { };
        private BackgroundWorker bw = new BackgroundWorker();
        private SIC.Objs.Controles.Dialogos.Dial_Espera Espera = new Dialogos.Dial_Espera();
        //public Empresa.Docente.TDecreto Decreto { get; set; }

        public Empresa.Docente.TDecreto Decreto {get;set;}
        private SIC.Objs.Controles.Dialogos.Dial_IndiqueSueldoDecreto _indiquelesueldo;
        private bool Vista { get; set; }

        public ObservableCollection<Empresa.Docente.tdocente> Docentes 
        { 
            get {
                ObservableCollection<Empresa.Docente.tdocente> items = new ObservableCollection<Empresa.Docente.tdocente>();
                foreach (Empresa.Docente.tdocente item in ((Xceed.Wpf.DataGrid.DataGridCollectionViewBase)this.datagrid1.Items.SourceCollection).SourceCollection) {
                    items.Add(item);
                }
                return items;
            } 
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e) {
            e.Result = new Empresa.Docente.DocenteEnDecreto((Empresa.Docente.TDecreto)e.Argument);
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            DataContext = e.Result;
            Espera.Hide();
        }


        private string DameRuta(string arg) {
            Xceed.Wpf.DataGrid.DataGridCollectionViewSource resor = (Xceed.Wpf.DataGrid.DataGridCollectionViewSource)FindResource("source_data");
            foreach (Xceed.Wpf.DataGrid.DataGridItemProperty item in resor.ItemProperties) {
                if (item.Name.Equals(arg)) return item.ValuePath;
            }
            return string.Empty;
        }

        public void Print(){
            Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();

            if (this.Decreto.Estado.Id != 3)
            {
                SIC.Objs.Controles.Decreto.Reportes.XtraDecreto_Docente_temporal __dectemp = new Decreto.Reportes.XtraDecreto_Docente_temporal();

                if (datagrid1.GroupLevelDescriptions.Count > 0)
                {
                    string miembro = this.DameRuta(datagrid1.GroupLevelDescriptions[0].FieldName);
                    DevExpress.XtraReports.UI.GroupHeaderBand Grupo_01 = (DevExpress.XtraReports.UI.GroupHeaderBand)__dectemp.Bands["GroupHeader1"];
                    __dectemp.Txt_TituloGrupo.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, miembro));
                    __dectemp.Visible = true;

                    Grupo_01.GroupFields.Add(new DevExpress.XtraReports.UI.GroupField(new DevExpress.XtraReports.UI.GroupField(miembro)));
                    Grupo_01.Visible = true;
                }
                __dectemp.bindingSource1.DataSource = this.Docentes;
                vista.MostarReporte(__dectemp);
            
            }else{
            
                SIC.Objs.Docentes.Reportes.Xtra_DecretoDocentes decrestosdocs = new Docentes.Reportes.Xtra_DecretoDocentes();
                if (datagrid1.GroupLevelDescriptions.Count > 0)
                {
                    string miembro = this.DameRuta(datagrid1.GroupLevelDescriptions[0].FieldName);
                    DevExpress.XtraReports.UI.GroupHeaderBand Grupo_01 = (DevExpress.XtraReports.UI.GroupHeaderBand)decrestosdocs.Bands["GroupHeader1"];
                    decrestosdocs.Txt_TituloGrupo.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, miembro));

                    decrestosdocs.Visible = true;
                    Grupo_01.GroupFields.Add(new DevExpress.XtraReports.UI.GroupField(new DevExpress.XtraReports.UI.GroupField(miembro)));
                    Grupo_01.Visible = true;
                }

                decrestosdocs.bindingSource1.DataSource = this.Docentes;
                vista.MostarReporte(decrestosdocs);
            }
        }

        private void InicializandoSeguridad() 
        {
            if (this.Vista){But_Agregar.Visibility = System.Windows.Visibility.Visible;}else {But_Agregar.Visibility = System.Windows.Visibility.Hidden;}
            But_Agregar.IsEnabled = this.Vista;

            if (this.Vista) { But_Eliminar.Visibility = System.Windows.Visibility.Visible; } else { But_Eliminar.Visibility = System.Windows.Visibility.Hidden; }
            But_Eliminar.IsEnabled = this.Vista;

            if (this.Vista) { But_Preparado.Visibility = System.Windows.Visibility.Visible; } else { But_Preparado.Visibility = System.Windows.Visibility.Hidden; }
            But_Preparado.IsEnabled = this.Vista;

            if (this.Vista) { But_Editar.Visibility = System.Windows.Visibility.Visible; } else { But_Editar.Visibility = System.Windows.Visibility.Hidden; }
            But_Editar.IsEnabled = this.Vista;
            

        }

        public us_MantenimientoListadoDecreto(){
            this.Decreto = new Empresa.Docente.TDecreto();
            InitializeComponent();

            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        public us_MantenimientoListadoDecreto(Empresa.Docente.TDecreto decreto, bool vista){
            this.Decreto = decreto;
            this.Vista = vista;

            InitializeComponent();
            this.InicializandoSeguridad();

            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            try {
                bw.RunWorkerAsync(decreto);
                Espera.ShowDialog(); 
            }
            catch{
                Espera.Hide();
            }
        }
        private bool ExistePresenteLista(Empresa.Docente.tdocente item) {
            foreach(Empresa.Docente.tdocente items in (IEnumerable<Empresa.Docente.tdocente>)this.DataContext){
                if (item.Cedula.Equals(items.Cedula)) return true;
            }
            return false;
        }

        private Empresa.Docente.tdocente docenteseleccionado;
        private Empresa.Docente.DocenteEnDecreto _decretodocente = new Empresa.Docente.DocenteEnDecreto();

        private void But_Agregar_Click(object sender, RoutedEventArgs e){
            docenteseleccionado = GlobalItems.DocenteGlobal;
            
            //docenteseleccionado.Decretos.Add();

            if(docenteseleccionado != null){

                if(_decretodocente.EsValidaIncluir(this.Decreto, docenteseleccionado))
                {
                    this._indiquelesueldo = new Dialogos.Dial_IndiqueSueldoDecreto(docenteseleccionado, this.Decreto);
                    this._indiquelesueldo.ShowDialog();

                    
                    if (this._indiquelesueldo.EsValido)
                    {
                        if (_indiquelesueldo.Docente.EstadoLaboral.Id == 2 || _indiquelesueldo.Docente.EstadoLaboral.Id == 3){
                            if (MessageBox.Show("El DOCENTE EXISTE EN OTRO DECRETO COMO;" + docenteseleccionado.EstadoLaboral.Nombre + ". Desea incluirlo en el presente Decreto, Si/No?", "Docente presente en otro decreto, Desea incluirlo, Si/No?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes){
                                //Existe en otro Decreto.
                                _decretodocente.Agregar(_indiquelesueldo.Docente);
                            }
                        }
                        else{
                            _decretodocente.Agregar(_indiquelesueldo.Docente);
                        }
                    }//el resultado del dialogo del sueldo es valido.

                    this._indiquelesueldo.Close();
                }
                else {
                    MessageBox.Show("El docente seleccionado no se puede incluir en el siguiente decreto, Porque existe o es fallecido.", "No se puede incluir en el presente decreto", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else {
                MessageBox.Show("Debe primero seleccionar un docente, en la parte izquierda introdusca la cédula del docente.","Debe seleccionar un docente.",MessageBoxButton.OK,MessageBoxImage.Stop);
            }

        }

        private void usercontrol_Loaded(object sender, RoutedEventArgs e){





        }

        private void But_Analisis_Click(object sender, RoutedEventArgs e){
            Dialogos.Dial_AnalisisDecreto analisi = new Dialogos.Dial_AnalisisDecreto(this.Docentes, this.Decreto);
            analisi.ShowDialog();
        }

        private void But_Docente_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid1.SelectedItem != null){
                Empresa.Docente.tdocente docenteselect = (Empresa.Docente.tdocente)datagrid1.SelectedItem;
                visitandoDocente.Invoke(docenteselect);

                //docenteselect.HistorialPagos = new Empresa.Docente.Pagos(docenteselect.Cedula);
                //docenteselect.Calculando_MontoDecretoCalculado();

                //win_mantenimientoDocente mantdoc = new win_mantenimientoDocente(docenteselect);
                //mantdoc.ShowDialog();
            }


        }

        private void But_Eliminar_Click(object sender, RoutedEventArgs e){
            try
            {
                Empresa.Docente.tdocente __docenteselecitem = (Empresa.Docente.tdocente)datagrid1.SelectedItem;
                if (datagrid1.SelectedItem != null)
                {
                    if (this.Decreto.Estado.Id == 1)
                    {
                        if (MessageBox.Show("Desea borrar el siguiente item de la lista? Si/No.", "Desea borrar el siguiente item. Si/No", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            _decretodocente.Eliminar(__docenteselecitem);
                        }
                    }
                    else {
                        MessageBox.Show("Accion denegada", "accion denegada", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }else {
                            MessageBox.Show("Debe seleccionar un docente.", "Debe seleccionar un Docente.", MessageBoxButton.OK, MessageBoxImage.Stop);
                 }
            }
            catch {
                this.Espera.Hide();
                MessageBox.Show("Error en el proceso.", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
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

        private void But_Preparado_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Acceso denegado.");
            //if (MessageBox.Show("") == MessageBoxResult.Yes) { 
            //}
        }

        private void But_Editar_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid1.SelectedItem != null)
            {
                Empresa.Docente.tdocente __docenteselecitem = (Empresa.Docente.tdocente)datagrid1.SelectedItem;
                this._indiquelesueldo = new Dialogos.Dial_IndiqueSueldoDecreto(__docenteselecitem);

                this._indiquelesueldo.ShowDialog();

                if (this._indiquelesueldo.EsValido)
                {
                    if (_indiquelesueldo.EsEdicion)
                    {
                        _decretodocente.Update(_indiquelesueldo.Docente);
                        datagrid1.SelectedItem = _indiquelesueldo.Docente;
                        datagrid1.Items.Refresh();
                    }
                }
                _indiquelesueldo.Close();
            }
            else {
                MessageBox.Show("Debe seleccionar un docente.", "Debe seleccionar un Docente.", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void But_Recarga_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bw.RunWorkerAsync(this.Decreto);
                Espera.ShowDialog();
            }
            catch
            {
                Espera.Hide();
            }
        }
    }
}
