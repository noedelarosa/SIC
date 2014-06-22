using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;

namespace Empresa.Comun
{


    public class valores_punto {
        public ISeries Serie;
        public List<valores_punto_axial> Puntos { get; set; }
        public valores_punto() {
            this.Puntos = new List<valores_punto_axial>();
        }

        public valores_punto(ISeries serie)
        {
            this.Serie = serie;
            this.Puntos = new List<valores_punto_axial>();
        }
    }


    public class valores_punto_axial
    {
       public object X {get;set;}
       public object Y {get;set;}
       
        public object Axial;
        public valores_punto_axial(){
            X = (double)0;
            Y = (double)0;
            Axial = new object();
        }
        public valores_punto_axial(double x, double y){
            X = (double)x;
            Y = (double)y;
            Axial = new object();
        }

        public valores_punto_axial(object x, object y)
        {
            X = x;
            Y = y;
            Axial = new object();
        }

        public valores_punto_axial(string x, double y)
        {
            X = (string)x;
            Y = (double)y;
            Axial = new object();
        }
    }
}
