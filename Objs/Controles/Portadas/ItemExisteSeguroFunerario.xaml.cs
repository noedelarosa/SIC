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
    /// Interaction logic for ItemExisteSeguroFunerario.xaml
    /// </summary>
    public partial class ItemExisteSeguroFunerario : UserControl
    {
        private Color _colorSegurofunerario = Color.FromRgb(158, 158, 201);
        private Color _colorSobrevivencia = Color.FromRgb(168, 201, 158);
        private Color _colorDiscapacidad = Color.FromRgb(197, 179, 132);

        public event DInicio Seleccionado = delegate { };
        public enum EDocumento 
        {
            SeguroFunerario,
            Sobrevivencia,
            Visita,
            NoSeleccion,
            Discapacidad
        };

        private EDocumento _SeleccionEntorno { get; set; }
        private void _configurandoentorno(EDocumento item, bool puedover){
            //propiedads comun
            this.But_Aceptar.IsEnabled = puedover;

            switch(item){
                case EDocumento.SeguroFunerario:
                    this.Txt_Titulo.Text = "Seguro Funerario";
                    this.Rec_Arriba.Fill= new SolidColorBrush(_colorSegurofunerario);
                    this.Rec_Inferior.Fill= new SolidColorBrush(_colorSegurofunerario);
                    this.Txt_Texto.Text = "Existe una solicitud de Seguro Funerario, para visualizar PULSE, el botón inferior.";
                    //_colorSegurofunerario;
                    break;
                case EDocumento.Sobrevivencia:
                    
                    this.Txt_Titulo.Text = "Sobrevivencia";
                    this.Rec_Arriba.Fill= new SolidColorBrush(_colorSobrevivencia);
                    this.Rec_Inferior.Fill = new SolidColorBrush(_colorSobrevivencia);
                    this.Txt_Texto.Text = "Existe una solicitud de Pensión por Sobrevivencia, para visualizar PULSE, el botón inferior.";
                    break;
                case EDocumento.Visita:
                    this.Txt_Titulo.Text = "Visita";

                    break;
                case EDocumento.Discapacidad:
                    this.Txt_Titulo.Text = "Discapacidad";
                    this.Rec_Arriba.Fill= new SolidColorBrush(_colorSobrevivencia);
                    this.Rec_Inferior.Fill = new SolidColorBrush(_colorSobrevivencia);
                    this.Txt_Texto.Text = "Existe una solicitud de Pensión por Discapacidad, para visualizar PULSE, el botón inferior.";


                    break;
                
            }
        }

        public ItemExisteSeguroFunerario(EDocumento item, bool PuedoVer){
            this._SeleccionEntorno = item;
            InitializeComponent();

            this._configurandoentorno(this._SeleccionEntorno,PuedoVer);
        }

        public ItemExisteSeguroFunerario() {
            this._SeleccionEntorno = EDocumento.NoSeleccion;
            InitializeComponent();
        }
        private void But_Aceptar_Click(object sender, RoutedEventArgs e){
            this.Seleccionado.Invoke(this._SeleccionEntorno);
        }

    }
}
