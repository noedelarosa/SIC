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

namespace SIC.Objs.Controles.Dialogos
{
    /// <summary>
    /// Interaction logic for item_Visitas_Mostrador.xaml
    /// </summary>
    public partial class item_Visitas_Mostrador : UserControl{

        public static DependencyProperty _depeCita = DependencyProperty.Register("Cita", typeof(Empresa.Citas.TCitasVisitas), typeof(item_Visitas_Mostrador));
        public Empresa.Citas.TCitasVisitas Cita {
            get {
                return (Empresa.Citas.TCitasVisitas)GetValue(_depeCita);
            }
            set {
                SetValue(_depeCita, value);
            }
        }

        public item_Visitas_Mostrador(){
            InitializeComponent();
        }
    }
}
