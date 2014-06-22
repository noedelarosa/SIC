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
    /// Interaction logic for us_Busqueda_Solicitudes_PJ.xaml
    /// </summary>
    public partial class us_Busqueda_Solicitudes_PJ : UserControl
    {
        
        private BackgroundWorker bw = new BackgroundWorker();
        private SIC.Objs.Controles.Dialogos.Dial_Espera _espera;

        public us_Busqueda_Solicitudes_PJ()
        {
            InitializeComponent();
            Com_estado.ItemsSource = Empresa.Docente.EstadoPJ.GetInstance();
            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e){
            object[] valores = (object[])e.Argument;
                //e.Result = new Empresa.Docente.SolicitudPJ((DateTime)valores[0], (DateTime)valores[1], valores[2] == null?new Empresa.Docente.testadopj():(Empresa.Docente.testadopj)valores[2]).Lista;   
            switch (Convert.ToInt32(valores[3])) { 
                case 1:
                    //Estado
                    e.Result = new Empresa.Docente.SolicitudPJ((Empresa.Docente.testadopj)valores[2]).Lista;
                    break;
                case 2:
                    //cedula y caso
                    e.Result = new Empresa.Docente.SolicitudPJ(valores[0].ToString(),valores[1].ToString()).Lista;
                    break;
                case 3:
                    //cedula,caso y estado.
                    e.Result = new Empresa.Docente.SolicitudPJ((Empresa.Docente.testadopj)valores[2],valores[0].ToString(), valores[1].ToString()).Lista;
                    break;
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DataContext = e.Result;
            this._espera.Close();
        }

        public void Print() {
            Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();
            var r = ((Xceed.Wpf.DataGrid.DataGridCollectionViewBase)this.datagrid12.Items.SourceCollection).SourceCollection;
            SIC.Objs.Docentes.Reportes.Xtra_Listado_Solicitud_PJ listado = new Docentes.Reportes.Xtra_Listado_Solicitud_PJ();

            listado.Parameters[2].Value = Com_estado.SelectedItem == null ? string.Empty : ((Empresa.Docente.testadopj)Com_estado.SelectedItem).Nombre;

            Empresa.Docente.SolicitudPJ sol = new Empresa.Docente.SolicitudPJ();
            foreach (object item in r) { 
                sol.Lista.Add((Empresa.Docente.tsolicitudpj)item); 
            } 

            listado.bindingSource1.DataSource = sol;
            vista.MostarReporte(listado);

        }

        private void But_Buscar_Click(object sender, RoutedEventArgs e){
            try
            {
                _espera = new Dialogos.Dial_Espera();
                _espera.Show();
 
                if (string.IsNullOrEmpty(Txt_cedula.Text) && string.IsNullOrEmpty(Txt_nocaso.Text))
                {
                    if (Com_estado.SelectedItem != null){
                        //estado
                        bw.RunWorkerAsync(new object[4] { string.Empty, string.Empty, Com_estado.SelectedItem, 1 });
                    }
                    else{
                        // --------------
                        _espera.Close();
                        MessageBox.Show("Debe espesificar un argumento para la busqueda.", "Falta argumento.", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else 
                {
                    if (Com_estado.SelectedItem != null){
                        //cedula, caso y estado.
                        bw.RunWorkerAsync(new object[4] { Txt_cedula.Text, Txt_nocaso.Text, Com_estado.SelectedItem, 3 });
                    }
                    else{
                        //cedula, caso.
                        bw.RunWorkerAsync(new object[4] { Txt_cedula.Text, Txt_nocaso.Text, string.Empty, 2 });
                    }   
                }


                //if (dp_ffinal.SelectedDate != null && dp_finicio.SelectedDate != null){
                //    this.Espera = new Dialogos.Dial_Espera();
                //    this.Espera.Show();  
                //    bw.RunWorkerAsync(new object[3] { dp_finicio.SelectedDate.Value, dp_ffinal.SelectedDate.Value, Com_estado.SelectedItem });
                //}
                //else {
                //    MessageBox.Show(Empresa.Comun.Mensajes.Documen_FaltaRequisitos, "Falta Datos", MessageBoxButton.OK, MessageBoxImage.Stop);
                //}

            }
            catch {
                this._espera.Close();
            }
        }

        private void But_EstadoLimpiar_Click(object sender, RoutedEventArgs e)
        {
            try{
                Com_estado.SelectedIndex = -1;
            }
            catch { 
            
            }
        }
    }
}
