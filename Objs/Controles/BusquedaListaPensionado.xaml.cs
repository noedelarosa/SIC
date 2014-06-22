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
    /// Interaction logic for BusquedaListaPensionado.xaml
    /// </summary>
    public partial class BusquedaListaPensionado : UserControl
    {
        public event DInicio Abriendo = delegate {};

        public Empresa.Docente.ListaPensionadoenBeneficio Lista { get; set; }
        private BackgroundWorker bw = new BackgroundWorker();
        private SIC.Objs.Controles.Dialogos.Dial_Espera _espera;


        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
             e.Result = new Empresa.Docente.ListaPensionadoenBeneficio().Lista;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DataContext = e.Result;
            _espera.Hide();
        }


        public BusquedaListaPensionado(){
            this.Lista = new Empresa.Docente.ListaPensionadoenBeneficio();
            InitializeComponent();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;

            this.But_Buscar_Click(null, null); 
        }

        private void But_Buscar_Click(object sender, RoutedEventArgs e)
        {
            try {
                this._espera = new Dialogos.Dial_Espera();

                this._espera.Show();
                bw.RunWorkerAsync();
            }
            catch{
                this._espera.Hide();
            } 
        }

        private void But_Nuevo_Click(object sender, RoutedEventArgs e){
            //Nueva Lista.
            try{
                SIC.Objs.Controles.Dialogos.win_datos_listadopensionbeneficio datos = new Dialogos.win_datos_listadopensionbeneficio();
                datos.ShowDialog();

                if (datos.Item != null){
                    this.Lista.Insert(datos.Item);
                }
                datos.Close();
            }
            catch { 
            
            }
        }

        private void But_Abrir_Click(object sender, RoutedEventArgs e){

            try{
                ListaPensionadosBeneficio _lista = new ListaPensionadosBeneficio();
                if (this.datagrid1.SelectedItem != null){
                    this.Abriendo(this.datagrid1.SelectedItem);
                }
            }
            catch { 
            
            }

        }

    }
}
