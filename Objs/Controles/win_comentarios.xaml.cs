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

namespace SIC.Objs.Controles
{
    /// <summary>
    /// Interaction logic for win_comentarios.xaml
    /// </summary>
    public partial class win_comentarios : Window
    {
        private Empresa.Comun.Comentario comen;
        private object Referencia;
        private Empresa.Comun.TEstandar Tipo;
        private Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();

        private enum StEleccion { 
         solicitud,
         docente,
         familiares
        }
        StEleccion Eleccion;

        private SIC.Objs.Docentes.Reportes.Xtra_ComentarioDocente ex5;

        public win_comentarios(){
            InitializeComponent();
        }

        public win_comentarios(Empresa.Docente.tsolicitudpj item){
            comen = new Empresa.Comun.Comentario(item.Id,item.Tipo.Id);
            InitializeComponent();

            this.Tipo = item.Tipo;
            this.Referencia = item.Id;
            this.liv_historico.ItemsSource = comen.Lista;

            //sección de asignación
            this.Eleccion = StEleccion.solicitud;
        }

        public win_comentarios(Empresa.Docente.tsolicitudfunenario item)
        {
            comen = new Empresa.Comun.Comentario(item.Id, item.Tipo);
            InitializeComponent();

            this.Tipo = new Empresa.Comun.TEstandar(item.Tipo);
            this.Referencia = item.Id;
            this.liv_historico.ItemsSource = comen.Lista;

            //sección de asignación
            this.Eleccion = StEleccion.solicitud;
        }

        public win_comentarios(Empresa.Docente.tdocente item){
            comen = new Empresa.Comun.Comentario(item.Cedula, item.Tipo.Id);
            InitializeComponent();
            
            this.Tipo = item.Tipo;
            this.Referencia = item.Cedula;
            this.liv_historico.ItemsSource = comen.Lista;
            this.Eleccion = StEleccion.docente;
            
            //sección de asignación
            ex5 = new Docentes.Reportes.Xtra_ComentarioDocente();
            ex5.bindingSource1.DataSource = item;
        }

        public win_comentarios(Empresa.Docente.TFamiliares item, string referencia){
            comen = new Empresa.Comun.Comentario(referencia, item.Tipo.Id);
            InitializeComponent();


            this.Tipo = item.Tipo;
            this.Referencia = referencia;
            this.Eleccion = StEleccion.familiares;

            //sección de asignación
            this.liv_historico.ItemsSource = comen.Lista;
        }

        private void But_Agregar_Click(object sender, RoutedEventArgs e){
            if(!string.IsNullOrEmpty(Txt_Post.Text)){
                comen.Insert(new Empresa.Comun.TComentario(Empresa.Comun.Server.DameTiempo(), Txt_Post.Text, this.Tipo, this.Referencia,Convert.ToBoolean(ch_espresencial.IsChecked)));
                Txt_Post.Text = string.Empty;
            }
        }

        private void But_Salir_Click_1(object sender, RoutedEventArgs e){
            this.Close();
        }

        private void But_Imprimir_Click(object sender, RoutedEventArgs e){

            switch (Eleccion) { 
                case StEleccion.docente:
                    vista.MostarReporte(ex5);
                    break;
                case StEleccion.familiares:
                    
                    break;
                case StEleccion.solicitud:
                    
                    break;
            }
        }
    }
}
