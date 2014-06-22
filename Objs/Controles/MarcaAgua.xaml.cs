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
	/// Interaction logic for MarcaAgua.xaml
	/// </summary>
	public partial class MarcaAgua : UserControl
	{
        public string Titulo {
            get {
                return this.Txt_Aviso.Text;
            }
            set {
                this.Txt_Aviso.Text = value; 
            }
        }


        public static DependencyProperty _dep_esdocente = DependencyProperty.Register("EsDocente", typeof(bool), typeof(MarcaAgua));
        public bool EsDocente {
            get {
                return (bool)GetValue(_dep_esdocente);
            }
            set {
                SetValue(_dep_esdocente, value);
            }
        }


		public MarcaAgua()
		{
            
			this.InitializeComponent();
		}
	}
}