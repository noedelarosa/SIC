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
    /// Interaction logic for us_contactos.xaml
    /// </summary>
    public partial class us_contactos : UserControl
    {
     
        public Empresa.Comun.tcontacto Contacto{
            get {
                return (Empresa.Comun.tcontacto)this.DataContext;
            }
            set {
                this.DataContext = value;
            }
        }

        public us_contactos(){
            InitializeComponent();
            //contatos = new Empresa.Comun.Contactos(false);
            this.DataContext = new Empresa.Comun.tcontacto();
        }

      

    }

}
