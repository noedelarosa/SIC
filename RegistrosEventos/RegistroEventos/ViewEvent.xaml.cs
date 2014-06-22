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

namespace Empresa.RegistrosEventos.RegistroEventos
{
    /// <summary>
    /// Interaction logic for ViewEvent.xaml
    /// </summary>
    public partial class ViewEvent : UserControl
    {
        private BackgroundWorker _bw = new BackgroundWorker();
        public ViewEvent()
        {
            InitializeComponent();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {


       
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //new Empresa.RegistroEventos.Evento(new Usuarios.TUsuario(5)).Lista;
        }

        private void But_BuscarEvento_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new Empresa.RegistroEventos.Evento(new Usuarios.TUsuario(5)).Lista;
        }

        private void But_BuscarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Form1 r = new Form1();
            r.ShowDialog();
        }
    }
}
