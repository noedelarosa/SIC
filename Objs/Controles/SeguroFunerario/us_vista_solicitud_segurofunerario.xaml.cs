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
using System.ComponentModel;

namespace SIC.Objs
{
    /// <summary>
    /// Interaction logic for us_vista_solicitud_segurofunerario.xaml
    /// </summary>
    public partial class us_vista_solicitud_segurofunerario : UserControl{
        private BackgroundWorker _bw;
        public event DInicio Abrir = delegate { };
        private SIC.Objs.Controles.Dialogos.Dial_Espera _espera = new Controles.Dialogos.Dial_Espera();

        public us_vista_solicitud_segurofunerario(){
            InitializeComponent();
            com_estado.ItemsSource = Empresa.Docente.SeguroFunerarioEstado.GetInstance().Lista;
            _bw = new BackgroundWorker();
            _bw.DoWork += bw_DoWork;
            _bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

         private void bw_DoWork(object sender, DoWorkEventArgs e)
         {
             object[] valores = (object[])e.Argument;
             
             switch((Int32)valores[0])
             {
                 case 0:
                     e.Result = new Empresa.Docente.SeguroFunerario((DateTime)valores[3], (DateTime)valores[4], (Empresa.Comun.TEstandar)valores[1], valores[2].ToString(), valores[5].ToString(), valores[6].ToString(), valores[7].ToString(), valores[8].ToString()).Lista;
                     break;
                 case 1:
                     e.Result = new Empresa.Docente.SeguroFunerario((Empresa.Comun.TEstandar)valores[1], valores[2].ToString(), valores[5].ToString(), valores[6].ToString(), valores[7].ToString(), valores[8].ToString()).Lista;
                     break;
                 case 2:
                     e.Result = new Empresa.Docente.SeguroFunerario((DateTime)valores[3], (DateTime)valores[4],(Empresa.Comun.TEstandar)valores[1], valores[2].ToString()).Lista;
                     break;
                 case 4:
                     e.Result = new Empresa.Docente.SeguroFunerario((Empresa.Comun.TEstandar)valores[1], valores[2].ToString()).Lista;
                     break;
             }

         }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
             this.DataContext = e.Result;
             if(exp_busquedaavanzada.IsExpanded == true) exp_busquedaavanzada.IsExpanded = false;
             this._espera.Hide();
        }
         
        private void But_Buscar_Click(object sender, RoutedEventArgs e){

            try{
                //Preparando Parametro.
                Empresa.Comun.TEstandar __estado;
                if(com_estado.SelectedItem != null){
                    __estado = (Empresa.Comun.TEstandar)com_estado.SelectedItem;
                }else{
                    __estado = new Empresa.Comun.TEstandar();
                }
                _espera.Show();
                if (exp_busquedaavanzada.IsExpanded){
                    if (ch_habilitar_control_contenido.IsChecked.Value){
                        //basico, Fecha y argumento: 0
                        _bw.RunWorkerAsync(new object[9] {0, __estado, Txt_NumeroSolicitud.Text, dp_finicio.SelectedDate.Value, dp_ffinal.SelectedDate.Value, txt_ceduladocente.Text, txt_nombredocente.Text, txt_cedulabeneficiario.Text, txt_nombrebeneficiario.Text});
                    }
                    else {
                        //basico, argumento: 1
                        _bw.RunWorkerAsync(new object[9] {1, __estado, Txt_NumeroSolicitud.Text, string.Empty, string.Empty, txt_ceduladocente.Text, txt_nombredocente.Text, txt_cedulabeneficiario.Text, txt_nombrebeneficiario.Text });
                    }
                }
                else{
                    if (ch_habilitar_control_contenido.IsChecked.Value){
                        //basico, fecha: 2 
                        _bw.RunWorkerAsync(new object[9] { 2, __estado, Txt_NumeroSolicitud.Text, dp_finicio.SelectedDate.Value, dp_ffinal.SelectedDate.Value, string.Empty, string.Empty, string.Empty, string.Empty });
                    }
                    else{
                        //basico: 4
                        _bw.RunWorkerAsync(new object[9] { 4, __estado, Txt_NumeroSolicitud.Text, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty });
                    }
                }

            }
            catch 
            {
                    MessageBox.Show(Empresa.Comun.Mensajes.Error_Proceso, "Verifique la información suministrada.", MessageBoxButton.OK, MessageBoxImage.Stop);
                    if (exp_busquedaavanzada.IsExpanded == true) exp_busquedaavanzada.IsExpanded = false;
                    this._espera.Hide();
            }
        }

        private void But_EstadoLimpiar_Click(object sender, RoutedEventArgs e){
            try{
                this.com_estado.SelectedIndex = -1;
            }
            catch{}
        }

        private void But_Abrir_Click(object sender, RoutedEventArgs e)
        {
            if(datagrid1.CurrentItem != null){
                this.Abrir(datagrid1.CurrentItem);
            }
            else{
                MessageBox.Show(Empresa.Comun.Mensajes.Documen_No_Seleccionado, "Falta Selección", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void But_Print_Click(object sender, RoutedEventArgs e){
            Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();
            SIC.Objs.Docentes.Reportes.Xtra_SeguroFunerario_Resultado_01 seguro = new Docentes.Reportes.Xtra_SeguroFunerario_Resultado_01();
            
            if (datagrid1.GroupLevelDescriptions.Count > 0)
            {
                string miembro  = datagrid1.GroupLevelDescriptions[0].FieldName;
                DevExpress.XtraReports.UI.GroupHeaderBand Grupo_01 = (DevExpress.XtraReports.UI.GroupHeaderBand)seguro.Bands["GroupHeader1"];

                //Label.
                seguro.xlb_titulo_grupo_01.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, miembro));
                seguro.xlb_titulo_grupo_01.Visible = true;

                Grupo_01.GroupFields.Add(new DevExpress.XtraReports.UI.GroupField(new DevExpress.XtraReports.UI.GroupField(miembro)));
                Grupo_01.Visible = true;
            }

            seguro.bindingSource1.DataSource = this.datagrid1.ItemsSource;
            vista.MostarReporte(seguro);
        }

        private void But_EstadoLimpiar_Click_1(object sender, RoutedEventArgs e)
        {
            com_estado.SelectedIndex = -1;
        }

        private void But_Estadistica_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                SIC.Objs.Controles.SeguroFunerario.Asistentes.win_dial_sel_estadistica_sf __win_dialog_select = new Controles.SeguroFunerario.Asistentes.win_dial_sel_estadistica_sf();
                List<Empresa.Comun.valores_punto> __datos = new List<Empresa.Comun.valores_punto>();

                Empresa.Comun.valores_punto _plano = new Empresa.Comun.valores_punto(new System.Windows.Controls.DataVisualization.Charting.LineSeries());
                Empresa.Comun.valores_punto_axial _punto;

                object objecto_x = new object();
                object objecto_y = new object();

                //EXISTEN GRUPOS               
                if (this.datagrid1.GroupLevelDescriptions.Count > 0)
                {
                    var resultim = this.datagrid1.Items;
                    __win_dialog_select.ShowDialog();
                    
                    if (__win_dialog_select.EsValido)
                    {
                        var resul = (System.Windows.Controls.ItemCollection)this.datagrid1.Items;
                        foreach (System.Windows.Data.CollectionViewGroup gr in resul.Groups)
                        {
                            //var resul = gr.Title;
                            objecto_x = gr.Name;
                            objecto_y = gr.ItemCount;
                            _punto = new Empresa.Comun.valores_punto_axial(objecto_x, objecto_y);
                            _plano.Puntos.Add(_punto);
                        }
                        __datos.Add(_plano);
                        __win_dialog_select.Close();
                    }

                }

                //NO EXISTEN GRUPOS
                else
                {
                    __win_dialog_select.ShowDialog();

                    if (__win_dialog_select.EsValido)
                    {

                        foreach (Empresa.Docente.tsolicitudfunenario item in this.datagrid1.Items)
                        {

                            switch (__win_dialog_select.SeleccionIndependiente)
                            {
                                case Controles.SeguroFunerario.Asistentes.win_dial_sel_estadistica_sf.enum_eje_inde.Estado:
                                    objecto_x = item.EstadoActual.Estado.Nombre;
                                    break;
                                case Controles.SeguroFunerario.Asistentes.win_dial_sel_estadistica_sf.enum_eje_inde.EstadoPago:
                                    objecto_x = item.EstadoPago.Nombre;
                                    break;
                                case Controles.SeguroFunerario.Asistentes.win_dial_sel_estadistica_sf.enum_eje_inde.Parentesco:
                                    objecto_x = item.DamePrimerBeneficiario.Parentesco.Nombre;
                                    break;
                            }

                            switch (__win_dialog_select.SeleccionDependiente)
                            {
                                case Controles.SeguroFunerario.Asistentes.win_dial_sel_estadistica_sf.enum_eje_depe.Fecha:
                                    objecto_y = item.Fecha;
                                    break;
                                case Controles.SeguroFunerario.Asistentes.win_dial_sel_estadistica_sf.enum_eje_depe.Monto:
                                    objecto_y = item.Monto;
                                    break;
                            }

                            _punto = new Empresa.Comun.valores_punto_axial(objecto_x, objecto_y);
                            _plano.Puntos.Add(_punto);
                        }

                        __datos.Add(_plano);
                        __win_dialog_select.Close();
                    }
                }

                SIC.Objs.Controles.Dialogos.win_contenedor_estadistica __content_estadis = new Controles.Dialogos.win_contenedor_estadistica(__datos);
                __content_estadis.Show();
            }
            catch{
                MessageBox.Show("No se puede presentar la tarea requerida.");
            }


        }
    }
}
