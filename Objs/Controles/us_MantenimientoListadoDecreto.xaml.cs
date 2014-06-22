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
    public partial class us_MantenimientoListadoDecreto : UserControl
    {
        private BackgroundWorker bw = new BackgroundWorker();
        private SIC.Objs.Controles.Dialogos.Dial_Espera Espera = new Dialogos.Dial_Espera();
        //public Empresa.Docente.TDecreto Decreto { get; set; }

        public Empresa.Docente.TDecreto Decreto { get; set; }
        private SIC.Objs.Controles.Dialogos.Dial_IndiqueSueldoDecreto _indiquelesueldo;
        private bool Vista { get;  set; }

        public ObservableCollection<Empresa.Docente.tdocente> Docentes { 
            get {
                ObservableCollection<Empresa.Docente.tdocente> items = new ObservableCollection<Empresa.Docente.tdocente>();
                foreach (Empresa.Docente.tdocente item in ((Xceed.Wpf.DataGrid.DataGridCollectionViewBase)this.datagrid1.Items.SourceCollection).SourceCollection) {
                    items.Add(item);
                }
                return items;
            } 
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e) {
            e.Result = new Empresa.Docente.DocenteDecreto((Empresa.Docente.TDecreto)e.Argument);
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            DataContext = e.Result;
            Espera.Hide();
        }

        public void Print(){
            Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();
            SIC.Objs.Docentes.Reportes.Xtra_DecretoDocentes decrestosdocs = new Docentes.Reportes.Xtra_DecretoDocentes();
            
            decrestosdocs.bindingSource1.DataSource = this.Docentes;
            vista.MostarReporte(decrestosdocs); 
        }

        private void InicializandoSeguridad() {
            if (this.Vista){But_Agregar.Visibility = System.Windows.Visibility.Visible;}else {But_Agregar.Visibility = System.Windows.Visibility.Hidden;}
            But_Agregar.IsEnabled = this.Vista;

            if (this.Vista) { But_Eliminar.Visibility = System.Windows.Visibility.Visible; } else { But_Eliminar.Visibility = System.Windows.Visibility.Hidden; }
            But_Eliminar.IsEnabled = this.Vista;

            if (this.Vista) { But_Preparado.Visibility = System.Windows.Visibility.Visible; } else { But_Preparado.Visibility = System.Windows.Visibility.Hidden; }
            But_Preparado.IsEnabled = this.Vista;
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

        private void But_Agregar_Click(object sender, RoutedEventArgs e){
            Empresa.Docente.tdocente docenteseleccionado = GlobalItems.DocenteGlobal;

            if(docenteseleccionado != null){
               // docenteseleccionado.Decretos = new Empresa.Docente.DecretoDocente(docenteseleccionado).Docentes[0].Decretos;

                    this._indiquelesueldo = new Dialogos.Dial_IndiqueSueldoDecreto(docenteseleccionado, this.Decreto);
                    this._indiquelesueldo.ShowDialog();

                    if(Decreto.InclusionExlucion.Regla(docenteseleccionado,_indiquelesueldo.Tipo) == true)
                    {
                        if(!this.Decreto.InclusionExlucion.Existe(docenteseleccionado)){
                            //No Existe Docente
                            if(docenteseleccionado.EstadoLaboral.Id == 1){
                                //Docente Activo 
                                docenteseleccionado.Decretos.Add(new Empresa.Docente.TDecretoDocente(this.Decreto, _indiquelesueldo.SueldoDecreto, _indiquelesueldo.Tipo));
                                this.Decreto.InclusionExlucion.Agregar(docenteseleccionado);
                                //Actulizacion de datos
                                bw.RunWorkerAsync(this.Decreto);
                                Espera.ShowDialog();
                            }
                            else{
                                if(MessageBox.Show("El Docente Seleccionado existe en el Decreto; " + docenteseleccionado.DecretoActual.Decreto.Nombre + " en Estado de; " + docenteseleccionado.EstadoLaboral.Nombre + ". Desea incluirlo en el presente Decreto, Si/No?", "Docente Presente el otro Decreto, Desea Incluirlo, Si/No?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes){
                                        docenteseleccionado.Decretos.Add(new Empresa.Docente.TDecretoDocente(this.Decreto, _indiquelesueldo.SueldoDecreto, _indiquelesueldo.Tipo));
                                        this.Decreto.InclusionExlucion.Agregar(docenteseleccionado);
                                        //Actulizacion de datos.
                                        bw.RunWorkerAsync(this.Decreto);
                                        Espera.ShowDialog();
                                }
                            } 
                        }else{
                            //Existe Docente
                            Dialogos.Dial_ExisteDocente mesnsajeExisteDocente = new Dialogos.Dial_ExisteDocente();
                            mesnsajeExisteDocente.ShowDialog();

                            if(mesnsajeExisteDocente.Resultado == MessageBoxResult.Yes) {
                                //Asignando al docente.    
                                if (docenteseleccionado.EstadoLaboral.Id == 1){
                                       //Activo Docente
                                    docenteseleccionado.Decretos.Add(new Empresa.Docente.TDecretoDocente(this.Decreto, _indiquelesueldo.SueldoDecreto, _indiquelesueldo.Tipo));
                                    this.Decreto.InclusionExlucion.Agregar(docenteseleccionado);
                                    bw.RunWorkerAsync(this.Decreto);
                                }else {
                                    
                                    if(MessageBox.Show("El Docente Seleccionado existe en el Decreto; " + docenteseleccionado.DecretoActual.Decreto.Numero + " en Estado de; " + docenteseleccionado.EstadoLaboral.Nombre + ". Desea incluirlo en el presente Decreto, Si/No?", "Docente Presente el otro Decreto, Desea Incluirlo, Si/No?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                                        docenteseleccionado.Decretos.Add(new Empresa.Docente.TDecretoDocente(this.Decreto, _indiquelesueldo.SueldoDecreto, _indiquelesueldo.Tipo));
                                        this.Decreto.InclusionExlucion.Agregar(docenteseleccionado);
                                        bw.RunWorkerAsync(this.Decreto);
                                    }

                                }
                                Espera.ShowDialog();
                            }
                            mesnsajeExisteDocente.Close();
                        }

                    }
                    else{
                        MessageBox.Show("El Docente Seleccionado no se puede incluir en el siguiente decreto, Existe con el mismo estado(" + docenteseleccionado.EstadoLaboral.Nombre + " o es Fallecido", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                this._indiquelesueldo.Close();
             }
            else {
                MessageBox.Show("Debe primero seleccionar un Docente, en la parte izquierda introduzca la cedula del docente.","Debe Seleccionar un Decreto",MessageBoxButton.OK,MessageBoxImage.Stop);
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
                
                docenteselect.HistorialPagos = new Empresa.Docente.Pagos(docenteselect.Cedula);
                docenteselect.Calculando_MontoDecretoCalculado();

                win_mantenimientoDocente mantdoc = new win_mantenimientoDocente(docenteselect);
                mantdoc.ShowDialog();
            }


        }
    }
}
