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

namespace SIC.Objs
{
    /// <summary>
    /// Interaction logic for us_vista_solicitud_segurofunerario.xaml
    /// </summary>
    public partial class us_vista_solicitud_segurofunerario : UserControl{
        private BackgroundWorker _bw;
        public event DInicio Abrir = delegate { };
        private SIC.Objs.Controles.Dialogos.Dial_Espera _espera = new Controles.Dialogos.Dial_Espera();

        public us_vista_solicitud_segurofunerario(){
            InitializeComponent();
            com_estado.ItemsSource = Empresa.Docente.SeguroFunerarioEstado.GetInstance().Lista;
            _bw = new BackgroundWorker();
            
            _bw.DoWork += bw_DoWork;
            _bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }


         private void bw_DoWork(object sender, DoWorkEventArgs e){
             object[] valores = (object[])e.Argument;
             e.Result = new Empresa.Docente.SeguroFunerario((DateTime)valores[0], (DateTime)valores[1], (Empresa.Comun.TEstandar)valores[2]).Lista;
         }

         private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e){
             this.DataContext = e.Result;
             this._espera.Hide();
         }
         
        private void But_Buscar_Click(object sender, RoutedEventArgs e){

            try {
                //Preparando Parametro
                Empresa.Comun.TEstandar est;

                if(com_estado.SelectedItem != null){
                    est = (Empresa.Comun.TEstandar)com_estado.SelectedItem;
                }else{
                    est = new Empresa.Comun.TEstandar();
                }

                _espera.Show();
                _bw.RunWorkerAsync(new object[3]{ dp_finicio.SelectedDate.Value, dp_ffinal.SelectedDate.Value,est}); 
            }
            catch {
                MessageBox.Show(Empresa.Comun.Mensajes.Error_Proceso, "Error Verifique la información.", MessageBoxButton.OK, MessageBoxImage.Stop);
                this._espera.Hide();
            }

        }

        private void But_EstadoLimpiar_Click(object sender, RoutedEventArgs e){
            try{
                this.com_estado.SelectedIndex = -1;
            }
            catch{}
        }

        private void But_Abrir_Click(object sender, RoutedEventArgs e)
        {
            
            if (datagrid1.SelectedItem != null){
                this.Abrir(datagrid1.SelectedItem);
            }
            else {
                MessageBox.Show(Empresa.Comun.Mensajes.Documen_No_Seleccionado, "Falta Selección", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

        }
    }
}
