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

namespace SIC.Objs.Controles.Sobrevivencia
{
    /// <summary>
    /// Interaction logic for us_formulario_sobrevivencia.xaml
    /// </summary>
    public partial class us_formulario_sobrevivencia : UserControl
    {
        public Empresa.Docente.tsolicitudpj Solicitud { get; set; }


        private void AppBindingSecurity() 
        {
                
                

        }

        public us_formulario_sobrevivencia(){
            this.Solicitud = new Empresa.Docente.tsolicitudpj();
            InitializeComponent();
        }

        public us_formulario_sobrevivencia(Empresa.Docente.tsolicitudpj item){
            this.Solicitud = item;
            InitializeComponent();
        }



    }
}
