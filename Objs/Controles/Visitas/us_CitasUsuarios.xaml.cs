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

namespace SIC.Objs.Controles
{
    /// <summary>
    /// Interaction logic for us_CitasUsuarios.xaml
    /// </summary>
    public partial class us_CitasUsuarios : UserControl, INotifyPropertyChanged
    {
        public Empresa.Comun.tcontacto Contacto   { get; set; }
        private Empresa.Comun.TDireccion _direccion;

        public event EventHandler<EventArgs> EventSiguiente = delegate { };

        
        public Empresa.Comun.TDireccion Direccion {
            get {return _direccion;}
            set { 
                _direccion = value;
                EnCambio("Direccion");
            }
        }

        public Empresa.RHH.tpersonal Persona { get; set; }
        private Empresa.Comun.EnlaceContacto _enlace;

        public us_CitasUsuarios(){
            InitializeComponent();
            control_us_contactos.Contacto = new Empresa.Comun.tcontacto();
        }

        public us_CitasUsuarios(Empresa.RHH.tpersonal item) {
            this.Persona = item;
            //Buscando Contactos.
            _enlace = new Empresa.Comun.EnlaceContacto(item.Cedula);
            this.Contacto = _enlace.Contacto;
            this.Direccion = _enlace.Direccion;

            InitializeComponent();
            //Asignandole Contacto al Control
            this.Direccion = _enlace.Direccion;
            control_us_contactos.Contacto = this.Contacto;
        }

        private void But_Siguiente_Click(object sender, RoutedEventArgs e){

           try
           {

               if(!_enlace.Existe(this.Persona.Cedula))
               {
                  Persona.Direccion = control_us_direccion.Direccion;
                  Persona.Contacto = control_us_contactos.Contacto;

                  _enlace.Insert(this.Persona.Cedula, control_us_direccion.Direccion, control_us_contactos.Contacto);
               } 
               else
               {
                    _enlace.Update(this.Persona.Cedula, control_us_direccion.Direccion, control_us_contactos.Contacto);
               }

               //update o insert.
               this.EventSiguiente(this.Persona, new EventArgs());
            } catch {
                MessageBox.Show("No se puede Guardar la dirección verifique que los datos estan completos.", "No se puede Guardar.", MessageBoxButton.OK, MessageBoxImage.Warning); 
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void EnCambio(string nombre){

            PropertyChangedEventHandler manejador = PropertyChanged;
            if (manejador != null) { 
                manejador(this,new PropertyChangedEventArgs(nombre));
            }

        }

    }
}
