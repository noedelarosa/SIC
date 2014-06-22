using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ReitingControl.xaml
    /// </summary>
    public partial class ReitingControl : UserControl
    {
        public static DependencyProperty _depeValoraciones = DependencyProperty.Register("Valoraciones", typeof(ObservableCollection<Empresa.Citas.tvaloracion>), typeof(ReitingControl));
        public ObservableCollection<Empresa.Citas.tvaloracion> Valoraciones {
            get {
                return (ObservableCollection<Empresa.Citas.tvaloracion>)GetValue(_depeValoraciones);
            }
            set {
                SetValue(_depeValoraciones, value); 
            }
        }

        //private void _binding() {
        //    foreach (Empresa.Citas.tindicadores item in Empresa.Citas.Indicadores.GetInstance().Lista) {
        //        this.Valoraciones.Add(new Empresa.Citas.tvaloracion(item));
        //    }
        //}

        public ReitingControl(){
            //this.Valoraciones = new ObservableCollection<Empresa.Citas.tvaloracion>();
            InitializeComponent();
            
        }
    }
}
