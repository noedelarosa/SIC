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

namespace SIC.Objs.Controles.Portadas
{



    /// <summary>
    /// Interaction logic for us_estadistica_general.xaml
    /// </summary>
    public partial class us_estadistica_general : UserControl
    {

        public List<Empresa.Comun.valores_punto> Datos { get; set; }
        public enum enum_estilo_estadistica
        {
            Columna=0,
            Serie=1,
            Linea
        }

        public enum_estilo_estadistica EnumEstiloEstadistica { get; set; }
        //private void __contru_control(enum_estilo_estadistica item, List<Empresa.Comun.valores_punto> datos){
            
        //    switch (item)
        //    {
        //        case enum_estilo_estadistica.Columna:
        //            ((System.Windows.Controls.DataVisualization.Charting.ColumnSeries)datos[0].Serie).Title                 = "Estadistica";
        //            ((System.Windows.Controls.DataVisualization.Charting.ColumnSeries)datos[0].Serie).IndependentValuePath  = "X";
        //            ((System.Windows.Controls.DataVisualization.Charting.ColumnSeries)datos[0].Serie).DependentValuePath    = "Y";
        //            ((System.Windows.Controls.DataVisualization.Charting.ColumnSeries)datos[0].Serie).ItemsSource = datos[0].Puntos;
        //            break;
        //        case enum_estilo_estadistica.Serie:
                    
        //            break;
        //        case enum_estilo_estadistica.Linea:
        //            ((System.Windows.Controls.DataVisualization.Charting.LineSeries)datos[0].Serie).Title = "Estadistica";
        //            ((System.Windows.Controls.DataVisualization.Charting.LineSeries)datos[0].Serie).IndependentValuePath  = "X";
        //            ((System.Windows.Controls.DataVisualization.Charting.LineSeries)datos[0].Serie).DependentValuePath = "Y";
        //            ((System.Windows.Controls.DataVisualization.Charting.LineSeries)datos[0].Serie).ItemsSource = datos[0].Puntos;
        //            break;
        //    }

        //    this.ch_estadistica.Series.Add(datos[0].Serie);
        //}

        private void __contru_control(enum_estilo_estadistica item, List<Empresa.Comun.valores_punto> datos){
            //Se realiza el diagrama.
            this.ch_estadistica.Diagram = new DevExpress.Xpf.Charts.XYDiagram2D();
            //Estableciendo la serie por defecto.
            DevExpress.Xpf.Charts.Series __serie = new DevExpress.Xpf.Charts.BarStackedSeries2D();
            //Estableciendo el tipo de grafico en la estadistica.
            switch (item) {  
                case enum_estilo_estadistica.Columna:
                    __serie = new DevExpress.Xpf.Charts.BarStackedSeries2D();
                    ((DevExpress.Xpf.Charts.BarStackedSeries2D)__serie).Label = new DevExpress.Xpf.Charts.SeriesLabel();
                    ((DevExpress.Xpf.Charts.BarStackedSeries2D)__serie).Model = new DevExpress.Xpf.Charts.SimpleBar2DModel();
                    ((DevExpress.Xpf.Charts.BarStackedSeries2D)__serie).LabelsVisibility = true;

                     break;
                case enum_estilo_estadistica.Linea:
                    __serie = new DevExpress.Xpf.Charts.LineStackedSeries2D();
                    break;
            }

            //Configurando el angulo de los ejes X
            ((DevExpress.Xpf.Charts.XYDiagram2D)this.ch_estadistica.Diagram).AxisX = new DevExpress.Xpf.Charts.AxisX2D();
            ((DevExpress.Xpf.Charts.XYDiagram2D)this.ch_estadistica.Diagram).AxisY = new DevExpress.Xpf.Charts.AxisY2D();

            ((DevExpress.Xpf.Charts.XYDiagram2D)this.ch_estadistica.Diagram).AxisX.Label = new DevExpress.Xpf.Charts.AxisLabel();
            ((DevExpress.Xpf.Charts.XYDiagram2D)this.ch_estadistica.Diagram).AxisX.Label.Angle = -45; 
            //Agregando la serie de puntos en el eje.
            ((DevExpress.Xpf.Charts.XYDiagram2D)this.ch_estadistica.Diagram).Series.Add(__serie);
           

            // ((DevExpress.Xpf.Charts.XYDiagram2D)this.ch_estadistica.Diagram).Series.Add(__serie);

            this.__agregando_datos(datos[0].Puntos); 
        }

        private void __agregando_datos(List<Empresa.Comun.valores_punto_axial> datos) {
            DevExpress.Xpf.Charts.SeriesPoint __punto; 
            foreach(Empresa.Comun.valores_punto_axial item in datos){
                __punto = new DevExpress.Xpf.Charts.SeriesPoint();
                __punto.Argument = item.X.ToString();
                __punto.Value = Convert.ToDouble(item.Y);
                this.ch_estadistica.Diagram.Series[0].Points.Add(__punto);              
            }
        }


        public us_estadistica_general(enum_estilo_estadistica item_estilo){
            this.Datos = new List<Empresa.Comun.valores_punto>();
            InitializeComponent();
            this.EnumEstiloEstadistica = item_estilo;
            this.__contru_control(this.EnumEstiloEstadistica, this.Datos);
        }

        public us_estadistica_general(enum_estilo_estadistica item_estilo, List<Empresa.Comun.valores_punto> datos)
        {
            this.Datos = datos;
            this.EnumEstiloEstadistica = item_estilo;
            InitializeComponent();
            this.__contru_control(this.EnumEstiloEstadistica, this.Datos);
        }

        public void CrearEntorno(enum_estilo_estadistica item_estilo, List<Empresa.Comun.valores_punto> datos){
            this.Datos = datos;
            this.EnumEstiloEstadistica = item_estilo;
            this.__contru_control(this.EnumEstiloEstadistica, this.Datos);
        }

        public us_estadistica_general(){
            this.Datos = new List<Empresa.Comun.valores_punto>();
            InitializeComponent();
        }
        
    }
}
