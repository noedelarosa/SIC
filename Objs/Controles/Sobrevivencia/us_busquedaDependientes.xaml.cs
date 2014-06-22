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
    /// Interaction logic for us_busquedaDependientes.xaml
    /// </summary>
    public partial class us_busquedaDependientes : UserControl
    {
        public Empresa.Docente.TFamiliares Familia { get; set; }
        public Empresa.Docente.Familiares Familiares { get; set; }

        public event DInicio Seleccionando = delegate { };

        private BackgroundWorker bw = new BackgroundWorker();
        private SIC.Objs.Controles.Dialogos.Dial_Espera Espera = new Dialogos.Dial_Espera();

        private void bw_DoWork(object sender, DoWorkEventArgs e){
            object[] valores = (object[])e.Argument;       
            e.Result = new Empresa.Docente.Familiares("%" +  valores[1].ToString() + "%", "%" + valores[0].ToString() + "%"); 
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DataContext = e.Result;
            Espera.Hide();
        }
        
        public us_busquedaDependientes()
        {
            InitializeComponent();
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.DoWork += bw_DoWork;

        }

        private void But_Buscar_Click(object sender, RoutedEventArgs e){
            try{
                this.Espera.Show();  
                bw.RunWorkerAsync(new object[2] { Txt_cedulas.Text, Txt_nombre.Text });
            }
            catch {
                this.Espera.Hide();  
            }
            //this.DataContext = bw.RunWorkerAsync(); 

            //new Empresa.Docente.Familiares(Txt_nombre.Text, Txt_cedulas.Text)[].EsMasculinof                  ;
         
            //NombreCompleto
            //Cedula
            //Parentesco.Nombre
            //EstadoBeneficio.Nombre
            //EsMasculinof


            //Tutor.Nombres
            //Tutor.Apellidos
            //Tutor.Cedula

            //Docente.Nombres
            //Docente.Apellidos
            //Docente.CedulaF

        }

        private void But_Refresh_Copy_Click(object sender, RoutedEventArgs e){
            if (this.datagrid12.SelectedItem != null){
                this.Familia = (Empresa.Docente.TFamiliares)datagrid12.SelectedItem;
                this.Seleccionando(this.Familia);
            }
        }

    }
}
