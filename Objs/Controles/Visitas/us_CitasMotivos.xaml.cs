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

namespace SIC.Objs.Controles
{
    /// <summary>
    /// Interaction logic for us_CitasMotivos.xaml
    /// </summary>
    public partial class us_CitasMotivos : UserControl
    {
        Empresa.Citas.MotivoVisitas motivos;
        public us_CitasMotivos(){
            motivos = Empresa.Citas.MotivoVisitas.GetInstance();
            this.DataContext = new Empresa.Citas.TMotivoVisitas();
            InitializeComponent();
            this.RecargaLista(); 
        }

        private void RecargaLista() {
            this.motivos = Empresa.Citas.MotivoVisitas.Recarga(); 
            this.datagrid1.ItemsSource = this.motivos.Lista;
        }
        private void But_Agregar_Click(object sender, RoutedEventArgs e){
            Empresa.Citas.TMotivoVisitas mvisita = (Empresa.Citas.TMotivoVisitas)this.DataContext;
            if (mvisita.IsValid()) {
                motivos.Insert(mvisita);
                this.RecargaLista(); 
            } 

        }

    }
}
