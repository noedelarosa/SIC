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
    /// Interaction logic for win_contenedor_estadistica.xaml
    /// </summary>
    public partial class win_contenedor_estadistica : Window
    {
        public List<Empresa.Comun.valores_punto> Datos { get; set; }
        public win_contenedor_estadistica()
        {
            this.Datos = new List<Empresa.Comun.valores_punto>();
            InitializeComponent();
            SIC.Objs.Controles.Portadas.us_estadistica_general est = new Portadas.us_estadistica_general(Portadas.us_estadistica_general.enum_estilo_estadistica.Columna);
            this.grid_contenedor.Children.Add(est);
        }

        public win_contenedor_estadistica(List<Empresa.Comun.valores_punto> datos)
        {
            this.Datos = datos;
            InitializeComponent();
            ch_estadistica.CrearEntorno(Portadas.us_estadistica_general.enum_estilo_estadistica.Columna, this.Datos);

            //SIC.Objs.Controles.Portadas.us_estadistica_general est = new Portadas.us_estadistica_general(Portadas.us_estadistica_general.enum_estilo_estadistica.Linea,this.Datos);
            //this.grid_contenedor.Children.Add(est);
        }


    }
}
