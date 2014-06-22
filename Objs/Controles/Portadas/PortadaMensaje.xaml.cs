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
    /// Interaction logic for PortadaMensaje.xaml
    /// </summary>
    public partial class PortadaMensaje : UserControl
    {
        public string Titulo
        {
            get
            {
                return TxT_Titulo.Text;
            }
            set
            {
                TxT_Titulo.Text = value;
            }
        }

        public string Texto
        {
            get
            {
                return this.Txt_Texto.Text;
            }
            set
            {
                this.Txt_Texto.Text = value;
            }
        }

        public string TituloInterno
        {
            get
            {
                return Txt_TituloInterno.Text;
            }
            set
            {
                Txt_TituloInterno.Text = value;
            }
        }

        public string Cifra
        {
            get
            {

                return this.Txt_Cifra.Text;
            }
            set
            {
                this.Txt_Cifra.Text = value;
            }
        }


        public static RoutedEvent EsTerminadoEvento = EventManager.RegisterRoutedEvent("EsTerminado", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PortadaMensaje));
        public event RoutedEventHandler EsTerminado{
            add { AddHandler(EsTerminadoEvento, value); }
            remove { RemoveHandler(EsTerminadoEvento, value); }
        }

        public static RoutedEvent EsInicioEvento = EventManager.RegisterRoutedEvent("EsInicio", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PortadaMensaje));
        public event RoutedEventHandler EsInicio
        {
            add { AddHandler(EsInicioEvento, value); }
            remove { RemoveHandler(EsInicioEvento, value); }
        }

        //Asistente de Disparador de Eventos.
        private void Raise(RoutedEventArgs newEventArgs){
            RaiseEvent(newEventArgs);
        }

        public void TerminadoEnvento(){
            this.Raise(new RoutedEventArgs(PortadaMensaje.EsTerminadoEvento));
        }

        public void InicioEnvento()
        {
            this.Raise(new RoutedEventArgs(PortadaMensaje.EsInicioEvento));
        }

        public PortadaMensaje()
        {
            InitializeComponent();
        }
    }
}
