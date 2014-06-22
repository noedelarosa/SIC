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
	/// Interaction logic for us_nominas.xaml
	/// </summary>
	public partial class us_nominas : UserControl
	{

        private BackgroundWorker _bw = new BackgroundWorker();
        private SIC.Objs.Controles.Dialogos.Dial_Espera _espera = new SIC.Objs.Controles.Dialogos.Dial_Espera();

		public us_nominas(){
			this.InitializeComponent();
            com_nomina.ItemsSource = Empresa.Docente.TipoDocente.GetInstance().Lista;

            _bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
		}

        private void bw_DoWork(object sender, DoWorkEventArgs e){ 
            object[] args = (object[])e.Argument;
            int anio = (int)args[0];
            Empresa.RHH.testadolaboral estado = (Empresa.RHH.testadolaboral)args[1];
            e.Result = new Empresa.Docente.Nomina(anio,estado).Lista;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Lis_Nomina.DataContext = e.Result;
            this._espera.Hide();
        }

        private void But_Aplicar_Click(object sender, RoutedEventArgs e){
            if (com_nomina.SelectedItem != null){
                try
                {
                    _espera.Show();
                    _bw.RunWorkerAsync(new object[2] {Convert.ToInt32(Txt_Ano.Text), com_nomina.SelectedItem});
                }
                catch {
                    _espera.Hide();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ItemNomina item = new ItemNomina();
            item.Nomina = (Empresa.Docente.TNomina)Lis_Nomina.SelectedItem;
            
            grid_Espacio.Children.Add(item);

        }
	}
}