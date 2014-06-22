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

namespace SIC.UI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login(){
            InitializeComponent();
        }

        private void Entrada_Click(object sender, RoutedEventArgs e){
            if (!(string.IsNullOrEmpty(Txt_Password.Password) && string.IsNullOrEmpty(Txt_Usuario.Text)))
            {
                Empresa.Usuarios.Seccion.Iniciar(Txt_Usuario.Text, Txt_Password.Password);
                SIC.Objs.Controles.win_cambiar_clave _cam_clave;

                if (Empresa.Usuarios.Seccion.EsAutenticado)
                {
                    this.Hide();
                    try
                    {
                        inicio inic;
                        ///Registro de Evento
                        Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(string.Empty, string.Empty, string.Empty, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.AbriendoSessionUsuario), Empresa.Usuarios.Seccion.Usuario, Empresa.Comun.Servicios.DameIdProcesador(), Environment.MachineName, Environment.UserDomainName));
                        ///Mostrando Inicio Programa
                        
                        if(Empresa.Usuarios.Seccion.Usuario.EsTemporal){
                            _cam_clave = new Objs.Controles.win_cambiar_clave(Empresa.Usuarios.Seccion.Usuario);
                            _cam_clave.ShowDialog();

                             this.Txt_Password.Password = string.Empty;
                             this.Show();
                            _cam_clave.Close();
                        }
                        else {
                            inic = new inicio();
                            //Mostrar ventana de inicio.
                            inic.ShowDialog();
                            //Borrar password
                            this.Txt_Password.Password = string.Empty;
                            //cerrando session.
                            Empresa.Usuarios.Seccion.Cerrar();
                            //cerrando formulario principal.
                            inic.Close();
                            //mostrando ventana de inicio.
                            this.Show();
                        }
                        ///Cerrada la venta principal.
                    }
                    catch{

                    }
                }
                else {
                    ///Registro de Evento
                    Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(string.Empty,string.Empty, string.Empty, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.IntentoFallidoAbrirSeccion), new Empresa.Usuarios.TUsuario(), Empresa.Comun.Servicios.DameIdProcesador(), Environment.MachineName, Environment.UserDomainName));
                    MessageBox.Show("Nombre de usuario o clave, incorrecta", "autentificación incorrecta", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            else {
                MessageBox.Show("Falta Nombre de usuario o clave", "Faltan datos para la autentificación", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void But_Salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }
    }
}
