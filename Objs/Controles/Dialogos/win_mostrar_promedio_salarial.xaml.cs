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
using System.Windows.Shapes;

namespace SIC.Objs.Controles.Dialogos
{
    /// <summary>
    /// Interaction logic for win_mostrar_promedio_salarial.xaml
    /// </summary>
    public partial class win_mostrar_promedio_salarial : Window
    {
        public Empresa.Docente.tdocente Docente { get; set; }

        public win_mostrar_promedio_salarial(){
            InitializeComponent();
        }

        public win_mostrar_promedio_salarial(Empresa.Docente.tdocente item){
            this.Docente = item;
            InitializeComponent();
        }


        private void But_aceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string calculo() {    
                return (Convert.ToDouble(Txt_tsueldo.Text) / Convert.ToDouble(datagrid1.Items.Count)).ToString("n");   
        }
        private void But_Calcular_Click(object sender, RoutedEventArgs e)
        {
            try{
                this.DataContext = this.Docente.HistorialPagos.DamePromedioEntre(dp_finicio.SelectedDate.Value, this.dp_ffinal.SelectedDate.Value);
                this.datagrid1.Items.Refresh();
                this.calculo();
            }
            catch { 
            }
        }

        private void datagrid1_ItemsSourceChangeCompleted(object sender, EventArgs e)
        {
            
            try{
                this.txt_spromedio.Text =  this.calculo();
            }
            catch{
                this.txt_spromedio.Text = "0";
            }

        }


        private void dp_finicio_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show("Cambio la fecha");
            try
            {
                DateTime t1 = new DateTime(dp_finicio.SelectedDate.Value.Year, dp_finicio.SelectedDate.Value.Month, 25);
                DateTime t2 = ((Empresa.Docente.TPago)txt_finicio_permitida.Tag).Fecha;
                if(t1 < t2){
                    dp_finicio.Text = string.Empty;
                    MessageBox.Show("Fecha no permitida, La Fecha no puede ser menor a la fecha minima encontrada en Nomina.", "Fecha no permitida.", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch { 
            
            }
        }

        private void dp_ffinal_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try{
                DateTime t1 = new DateTime(dp_ffinal.SelectedDate.Value.Year, dp_ffinal.SelectedDate.Value.Month, 25);
                DateTime t2 = ((Empresa.Docente.TPago)txt_ffinal_permitida.Tag).Fecha;
                if (t1 > t2){
                    dp_ffinal.Text = string.Empty;
                    MessageBox.Show(" Fecha no permitida, La Fecha no puede ser mayor a la fecha maxima encontrada en Nomina.", "Fecha no permitida.", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch{

            }
        }

    }
}
