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
    /// Interaction logic for win_seleccion_ejes_reporte_estadistica.xaml
    /// </summary>
    public partial class win_seleccion_ejes_reporte_estadistica : Window
    {
        public List<Empresa.Comun.valores_dependientes_independientes> ValoresEjes { get; set; }
        public List<Empresa.Comun.valores_punto> Datos;

        public win_seleccion_ejes_reporte_estadistica(){
            ValoresEjes = new List<Empresa.Comun.valores_dependientes_independientes>();
            InitializeComponent();
        }

        public win_seleccion_ejes_reporte_estadistica(List<Empresa.Comun.valores_dependientes_independientes> lista){
            ValoresEjes = lista;
            InitializeComponent();
            this.lis_items.ItemsSource = this.ValoresEjes;
        }

        private Xceed.Wpf.DataGrid.DataGridControl __grid;

        //private void _datos(Xceed.Wpf.DataGrid.DataGridControl grid) {
        //    List<Empresa.Comun.valores_dependientes_independientes> _lista = new List<Empresa.Comun.valores_dependientes_independientes>();
        //    if (grid.HasItems){
        //        Xceed.Wpf.DataGrid.DataRow row = (Xceed.Wpf.DataGrid.DataRow)grid.GetContainerFromItem(grid.Items[0]);    
        //        for(int icont = 0; icont <= row.Cells.Count - 1; icont++){
        //            _lista.Add(new Empresa.Comun.valores_dependientes_independientes(row.Cells[icont].Content.GetType(), grid.Columns[icont].Title.ToString()));
        //        }
        //    }
        //}

        private void __valores_item() {
          Xceed.Wpf.DataGrid.DataRow row = (Xceed.Wpf.DataGrid.DataRow)this.__grid.GetContainerFromItem(__grid.Items[0]);
           for (int icont = 0; icont <= row.Cells.Count - 1; icont++){
                        this.ValoresEjes.Add(new Empresa.Comun.valores_dependientes_independientes(row.Cells[icont].Content.GetType(), __grid.Columns[icont].Title.ToString()));
          }
           this.lis_items.ItemsSource = this.ValoresEjes;
        }
        public win_seleccion_ejes_reporte_estadistica(Xceed.Wpf.DataGrid.DataGridControl grid)
        {
            ValoresEjes = new List<Empresa.Comun.valores_dependientes_independientes>();
            InitializeComponent();
            this.__grid = grid;
            __valores_item();
            //_datos(__grid);
            
        }

        private void But_Agregar_Dependientes_Click(object sender, RoutedEventArgs e)
        {
            this.lis_d_dependientes.Items.Add(lis_items.SelectedItem);
        }

        private void But_Agregar_Dependiente_Click(object sender, RoutedEventArgs e)
        {
            this.lis_d_inpendientes.Items.Add(lis_items.SelectedItem);
        }

        private void But_Crear_Reporte_Click(object sender, RoutedEventArgs e)
        {
           Xceed.Wpf.DataGrid.DataRow row;
           this.Datos = new List<Empresa.Comun.valores_punto>();
           
           Empresa.Comun.valores_punto valorpunto;
           valorpunto = new Empresa.Comun.valores_punto();
           valorpunto.Serie = new System.Windows.Controls.DataVisualization.Charting.ColumnSeries();
           
            
            List<Empresa.Docente.tsolicitudfunenario_view> vista_sol = new List<Empresa.Docente.tsolicitudfunenario_view>();
            Empresa.Docente.tsolicitudfunenario_view item_vista_sol;
            
            //Empresa.Docente
            //Recorriendo la filas
            //for(int row_index =0 ; row_index <= __grid.Items.Count -1; row_index ++){
           foreach (Empresa.Docente.tsolicitudfunenario item_seg in __grid.Items)
           {

               item_vista_sol = new Empresa.Docente.tsolicitudfunenario_view();

               item_vista_sol.Monto = 1;


               //row = (Xceed.Wpf.DataGrid.DataRow)__grid.GetContainerFromItem(item_seg);
               //if (row != null)
               //{
               //    //Recorriendo las columnas
               //    object yvalue = 0.0;
               //    object xvalue = string.Empty;
               //    for (int icont = 0; icont <= row.Cells.Count - 1; icont++)
               //    {
               //        if (((Empresa.Comun.valores_dependientes_independientes)lis_d_dependientes.Items[0]).Nombre == __grid.Columns[icont].Title.ToString()){
               //            //Encontro el valor dependiente.
               //            yvalue = row.Cells[icont].Content;
               //        }
               //        if (((Empresa.Comun.valores_dependientes_independientes)lis_d_inpendientes.Items[0]).Nombre == __grid.Columns[icont].Title.ToString()){
               //            //Encontro el valor dependiente.
               //            xvalue = row.Cells[icont].Content;
               //        }
               //    }
               //    valorpunto.Puntos.Add(new Empresa.Comun.valores_punto_axial(xvalue.ToString(), (double)yvalue));
               //}
               

           }
           

        }

    }
}
