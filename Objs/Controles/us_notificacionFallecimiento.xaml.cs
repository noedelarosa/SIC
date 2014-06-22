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
    /// Interaction logic for us_notificacionFallecimiento.xaml
    /// </summary>
    public partial class us_notificacionFallecimiento : UserControl
    {
        BackgroundWorker __bw;
        Empresa.Docente.NotificadosFallecidos _noti;
        private SIC.Objs.Controles.Dialogos.Dial_Espera Espera;

        public us_notificacionFallecimiento()
        {
            InitializeComponent();
            __bw = new BackgroundWorker();
            __bw.DoWork += bw_DoWork;
            __bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            this._noti = new Empresa.Docente.NotificadosFallecidos();
            
            But_Recarga_Click(null, null);
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = new Empresa.Docente.NotificadosFallecidos().CargaLista();
        }


        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e){
            try{
                this.DataContext = e.Result;
                this.Espera.Close();
            }
            catch {
                this.DataContext = null;
                this.Espera.Close();
            }
        }

        private void But_Verificar_Click(object sender, RoutedEventArgs e)
        {


        }

        private void But_Borrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                    if (datagrid1.SelectedItem != null)
                    {
                        if (MessageBox.Show("Desea eliminar la siguiente notificación. Si/No?", "Desea Eliminar Notifiacación, Si/No?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            this._noti.Delete((Empresa.Docente.TNotificadosFallecidos)datagrid1.SelectedItem);
                            But_Recarga_Click(null, null);
                        }
                    }
            }
            catch{

            }
        }

        private void But_Recarga_Click(object sender, RoutedEventArgs e)
        {
            this.Espera =  new Dialogos.Dial_Espera();
            this.Espera.Show();

            this.__bw.RunWorkerAsync(); 
        }
    }
}
