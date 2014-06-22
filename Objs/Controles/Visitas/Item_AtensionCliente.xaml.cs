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
    /// Interaction logic for Item_AtensionCliente.xaml
    /// </summary>
    public partial class Item_AtensionCliente : UserControl
    {
        public event DInicio Event_Atencion = delegate { };
        public event DInicio Event_Declina = delegate { };

        public static DependencyProperty DepePersonal = DependencyProperty.Register("Persona", typeof(Empresa.RHH.tpersonal), typeof(SIC.Objs.Controles.Item_AtensionCliente));
        public Empresa.RHH.tpersonal Persona {
            get { return (Empresa.RHH.tpersonal)GetValue(DepePersonal); }
            set { SetValue(DepePersonal, value); }
        }

        public static DependencyProperty DepeCitas = DependencyProperty.Register("Cita", typeof(Empresa.Citas.TCitasVisitas), typeof(SIC.Objs.Controles.Item_AtensionCliente));
        public Empresa.Citas.TCitasVisitas Cita
        {
            get { return (Empresa.Citas.TCitasVisitas)GetValue(DepeCitas); }
            set { SetValue(DepeCitas, value); }
        }

        public Item_AtensionCliente()
        {
                
            InitializeComponent();
        }

        private void But_Atender_Click(object sender, RoutedEventArgs e){
            Event_Atencion(this.Cita);
        }

        private void But_Declinar_Click(object sender, RoutedEventArgs e)
        {
            Event_Declina(this.Cita);
        }
    }
}
