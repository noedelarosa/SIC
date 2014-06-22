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
    /// Interaction logic for Dial_Config_CitasMostrador.xaml
    /// </summary>
    public partial class Dial_Config_CitasMostrador : Window
    {
        Win_citas_mostrador _mostrador;
        Empresa.RHH.Departamento _depar = Empresa.RHH.Departamento.GetInstance();
        public Dial_Config_CitasMostrador()
        {
            InitializeComponent();
            
            this.com_departamento.ItemsSource = _depar;

        }

        private void But_View_Click(object sender, RoutedEventArgs e)
        {
            try{
                if (com_departamento.SelectedItem != null) {
                    this._mostrador = new Win_citas_mostrador((Empresa.RHH.TDepartamento)com_departamento.SelectedItem);        
                    this._mostrador.ShowDialog();
                }
            }
            catch { 
            
            }
        }
    }
}
