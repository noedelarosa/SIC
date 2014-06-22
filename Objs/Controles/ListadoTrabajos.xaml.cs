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
    /// Interaction logic for ListadoTrabajos.xaml
    /// </summary>
    public partial class ListadoTrabajos : UserControl
    {
        public event DInicio Seleccionado = delegate { };

        private void _ContextoInterface(Empresa.Docente.tdocente item) {

            List<Portadas.ItemExisteSeguroFunerario> Items = new List<Portadas.ItemExisteSeguroFunerario>();
            Portadas.ItemExisteSeguroFunerario itemfunerario;
            Portadas.ItemExisteSeguroFunerario itemsobrevivencia;

            if (item.TieneSeguroFunerario){
                itemfunerario = new Portadas.ItemExisteSeguroFunerario(Portadas.ItemExisteSeguroFunerario.EDocumento.SeguroFunerario, item.EsFallecidoMinimo);
                itemfunerario.Seleccionado += ItemExisteSeguroFunerario_Seleccionado;
                wp_contenido.Children.Add(itemfunerario);
            }

            if (item.TieneSobrevivencia){
                itemsobrevivencia = new Portadas.ItemExisteSeguroFunerario(Portadas.ItemExisteSeguroFunerario.EDocumento.Sobrevivencia, item.EsFallecidoMinimo);
                itemsobrevivencia.Seleccionado += ItemExisteSeguroFunerario_Seleccionado;
                wp_contenido.Children.Add(itemsobrevivencia);
            }
        
        }

        public ListadoTrabajos(Empresa.Docente.tdocente docente){
            InitializeComponent();
            _ContextoInterface(docente);
        }

        public void Refresh(Empresa.Docente.tdocente item){
            try
            {
                wp_contenido.Children.Clear();
                this._ContextoInterface(item);
            }
            catch {
                
            }
        }

        private void ItemExisteSeguroFunerario_Seleccionado(object arg){
            this.Seleccionado.Invoke(arg);
        }

    }
}
