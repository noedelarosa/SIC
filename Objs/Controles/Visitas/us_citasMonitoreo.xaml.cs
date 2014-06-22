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
    /// Interaction logic for us_citasMonitoreo.xaml
    /// </summary>
    public partial class us_citasMonitoreo : UserControl
    {
        private BackgroundWorker bw;
        private Dialogos.Dial_Espera _espera = new Dialogos.Dial_Espera();
        private DateTime _fechadeldia = Empresa.Comun.Server.DameTiempo(); 


        private void bw_DoWork(object sender, DoWorkEventArgs e){ 
            
            if(e.Argument == null){
                e.Result = new Empresa.Citas.CitasVisitas().Lista;
            }
            else {
                e.Result = new Empresa.Citas.CitasVisitas((Empresa.Comun.TEstandar)e.Argument).Lista;
            }

         }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            this.DataContext = e.Result;
            this._espera.Hide();
        }

        

        public us_citasMonitoreo(){
            InitializeComponent();
            this.com_estado.ItemsSource = Empresa.Citas.EstadoVisita.GetInstance().Lista;    
           
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }


        private void _ejecutandobusqueda(Empresa.Comun.TEstandar estado){
            this.bw.RunWorkerAsync(estado); 
        }

        private void _ejecutandobusqueda(){
            this.bw.RunWorkerAsync(null);
        }

        private void But_Buscar_Click(object sender, RoutedEventArgs e){
            try{
                this._espera.Show();
                if (com_estado.SelectedItem != null){
                    _ejecutandobusqueda((Empresa.Comun.TEstandar)com_estado.SelectedItem);
                }
                else {
                    _ejecutandobusqueda();
                 }
               }
            catch {
                this._espera.Hide();
            }
        }
    }
}
