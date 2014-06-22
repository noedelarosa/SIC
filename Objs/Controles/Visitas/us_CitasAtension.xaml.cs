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
    /// Interaction logic for CitasAtension.xaml
    /// </summary>
    public partial class CitasAtension : UserControl
    {
       private SIC.Objs.Controles.win_citasAtencion _atension;
       private Empresa.Citas.CitasVisitas _citas;
       private BackgroundWorker bw = new BackgroundWorker();
       private System.Windows.Threading.DispatcherTimer Tiempo;
       
       public event DInicio NotificancionCargaEstado = delegate{};

       private bool _autobuscar = true;
       private bool _buscartodos = false;

       //private Dialogos.Dial_Espera _espera = new Dialogos.Dial_Espera();

       private Empresa.Citas.CitasVisitas _cargacontexto(){
           
           //return new Empresa.Citas.CitasVisitas(new Empresa.Comun.TEstandar(1), Empresa.USeguridad.Seccion.Usuario.Personal, Empresa.USeguridad.Seccion.Usuario.Personal);
           return new Empresa.Citas.CitasVisitas();
       }

       public void Tiempo_Tick(object sedner, EventArgs e) {
           this.Tiempo.Stop(); 
           if (_autobuscar) __ejecutarconsulta();
       }

       private void bw_DoWork(object sender, DoWorkEventArgs e){
            e.Result =   _cargacontexto();
       }

       private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e){
           //se asigna el resultado de las citas buscadas por el procedimiento.
           this._citas = (Empresa.Citas.CitasVisitas)e.Result;
           //se debloquea la lista.
           this.listbox1.IsEnabled = true;
           //se asigna el resultado del procedimiento a la lista.
           this.listbox1.ItemsSource = _citas.Lista;
           // se oculta el aviso de coneccion con el servidor.
           this.Item_Serverconect.Visibility = System.Windows.Visibility.Hidden;
           this.Tiempo.Start();
       }

       public CitasAtension(){
            InitializeComponent();

            this.Tiempo = new System.Windows.Threading.DispatcherTimer();
            this.Tiempo.Interval = new TimeSpan(0, 0, 0, 31);

            ch_mostrartodos.IsChecked = this._buscartodos;
            ch_autobuscar.IsChecked = this._autobuscar;

            this.Tiempo.Tick += Tiempo_Tick;
            this.Tiempo.Start();
 
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            this.But_Refrescar_Click(null, null);
        }

       private void But_CargaEstado_Click(object sender, RoutedEventArgs e) {
           this.Tiempo.Stop(); 
           this.NotificancionCargaEstado(this.listbox1.SelectedItem);
       }

       private void Item_AtensionCliente_Event_Atencion(object arg){
           //tomamos la cita que devuelve el item select(cita selecionada) 
           Empresa.Citas.TCitasVisitas ct = (Empresa.Citas.TCitasVisitas)arg;
           //parada de llamdas a procedimiento de citas.
           Tiempo.Stop(); 

           //asignamos al selecitem de la lista.
            this.listbox1.SelectedItem = ct;
           //bloqueamos la cita para que pueda ser seleccionada otra
            this.listbox1.IsEnabled = false; 
           
           //Asistente para la atension de citas.
            _atension = new win_citasAtencion(ct);
           //asiganacion de evento para carga de visor de docente, solo si es docente.
            _atension.But_Estado.Click += But_CargaEstado_Click;

           //Evento de acciones para el asistente, Finalizo con exito o cerro la ventana.
            _atension.Finalizando += FinalizandoManejo;
            _atension.Cerrando += CerrandoManejo;

            //Estado por defecto 2, en atension.
             ct.Estado = new Empresa.Comun.TEstandar(2);
           // se aplica un update para asignarle un estado nuevo al cliente(en Atension)
            _citas.Update(ct);

            //se muestra el asistente. 
            _atension.Show(); 
        }

       private void Item_AtensionCliente_Event_Declina(object arg)
       {
           var r = arg;

           if (MessageBox.Show("Desea Declinar el Siguiente Cliente(Docente), Si/No", "Declinar Cliente(Docenete), Si/No", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
           {


           }

       }
        
       public void CerrandoManejo(object e) {
            //_atension.Close();
            _atension.Cerrar();
            _citas.Update((Empresa.Citas.TCitasVisitas)e);

            this.Tiempo.Stop();
            this.__ejecutarconsulta();
        }

       public void FinalizandoManejo(object e){
           //Cerrando Asistente.
           _atension.Close();
           // se actualiza con los nuevos cambios.
           _citas.Update((Empresa.Citas.TCitasVisitas)e);

           //desbloquea la para su posterior seleccion Lista;
           this.Tiempo.Stop(); 
           __ejecutarconsulta();
       }

       private void __ejecutarconsulta() {
           try
           {

               if (!bw.IsBusy)
               {
                   //se visuliza el aviso de coneccion con el servidor.
                   this.Item_Serverconect.Visibility = System.Windows.Visibility.Visible;
                   //bloqueo de lista mientras actualiza
                   this.listbox1.IsEnabled = false;
                   //ejecucion del procedimiento de citas.
                   bw.RunWorkerAsync();
               }
               else {
                   this.Item_Serverconect.Visibility = System.Windows.Visibility.Hidden; 
               } 

           }
           catch
           {
               this.Item_Serverconect.Visibility = System.Windows.Visibility.Hidden;
           }

       }

       private void But_Refrescar_Click(object sender, RoutedEventArgs e){
           Tiempo.Stop(); 
           this.__ejecutarconsulta();
       }

       private void ch_autobuscar_Checked(object sender, RoutedEventArgs e)
        {
            
        }

       private void ch_mostrartodos_Checked(object sender, RoutedEventArgs e)
        {
            this._buscartodos = Convert.ToBoolean(((CheckBox)sender).IsChecked);
        }

       private void ch_autobuscar_Click(object sender, RoutedEventArgs e)
        {
            this._autobuscar = Convert.ToBoolean(((CheckBox)sender).IsChecked);
        }

       private void us_CitasAtension_control_Unloaded(object sender, RoutedEventArgs e){
            this.Tiempo.Stop();
        }

    }
}
