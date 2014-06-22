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
    /// Interaction logic for Dial_SeleccionDecretoOpcion_01.xaml
    /// </summary>
    public partial class Dial_SeleccionDecretoOpcion_01 : Window
    {
        public enum ESeleccionOpcion { 
            Crear,
            Agregar,
            Aprobar,
            Ver,
            Nada
        }
        public ESeleccionOpcion SeleccionActual { get; set; }
        public Empresa.Docente.TDecreto Decreto{
            get { 
                if(Com_Decreto.SelectedItem != null){
                    return (Empresa.Docente.TDecreto)Com_Decreto.SelectedItem;
                }else {
                    return new Empresa.Docente.TDecreto();
                }
            }
        }

        public Dial_SeleccionDecretoOpcion_01(){
            InitializeComponent();
            SeleccionActual = ESeleccionOpcion.Nada;

            this.Com_Decreto.ItemsSource = Empresa.Docente.Decreto.GetInstnace().Lista; 
        }

        private void But_Crear_Click(object sender, RoutedEventArgs e){
            //us_Mantenimiento_Decreto decreman = new us_Mantenimiento_Decreto();
            this.SeleccionActual = ESeleccionOpcion.Crear;
            this.Hide();
        }

        private void But_Aprobar_Click(object sender, RoutedEventArgs e){
            this.SeleccionActual = ESeleccionOpcion.Aprobar;
            this.Hide();
        }

        private void But_Agregar_Click(object sender, RoutedEventArgs e){
            if(Com_Decreto.SelectedItem != null){
                this.SeleccionActual = ESeleccionOpcion.Agregar;
                this.Hide();
            }
            else {
                MessageBox.Show("Debe Seleccionar un Decreto de la lista.", "Seleccione Decreto", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void But_Ver_Click(object sender, RoutedEventArgs e)
        {
            if (Com_Decreto.SelectedItem != null)
            {
                this.SeleccionActual = ESeleccionOpcion.Ver;
                this.Hide();
            }
            else{
                MessageBox.Show("Debe Seleccionar un Decreto de la lista.", "Seleccione Decreto", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
