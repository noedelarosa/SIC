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

namespace SIC
{
	/// <summary>
	/// Interaction logic for ItemNomina.xaml
	/// </summary>
	public partial class ItemNomina : UserControl
	{
        public static DependencyProperty Dep_Nomina = DependencyProperty.Register("Nomina", typeof(Empresa.Docente.TNomina), typeof(UserControl));

        public Empresa.Docente.TNomina Nomina {
            get {
                return (Empresa.Docente.TNomina)GetValue(Dep_Nomina);
            }
            set {
                SetValue(Dep_Nomina, value);
            }
        }
        
        public string Mes {
            get {
                if (Nomina != null){
                    return this.Nomina.Fecha.ToString("MMMM");
                }
                else {
                    return "n/d";
                }
            }
        }



        public string Ano { 
            get {
            return this.Nomina.Fecha.Year.ToString();
            } 
        }

		public ItemNomina(){
			this.InitializeComponent();
		}

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
             
        }

	}
}