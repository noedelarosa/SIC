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
    /// Interaction logic for win_cambiar_clave.xaml
    /// </summary>
    public partial class win_cambiar_clave : Window
    {
        private Empresa.Usuarios.Usuario _usuarios;
        public bool EsValido { get; set; }
        private Manager.Win_ReentrarClave _reentrada;
        public Empresa.Usuarios.TUsuario Usuario { get; set; }
        public win_cambiar_clave(Empresa.Usuarios.TUsuario item)
        {
            this._usuarios = new Empresa.Usuarios.Usuario(true);
            this.Usuario = item;
            this.EsValido = false;
            InitializeComponent();
        }

        private void But_Guardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_clave.Password)){
                MessageBox.Show("Debe introducir algún valor para la clave.", "Debe introducir algún valor.", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else{
                _reentrada = new Manager.Win_ReentrarClave(this.Txt_clave.Password);
                _reentrada.ShowDialog();

                if(this._reentrada.EsValido){
                    if(this._usuarios.Reset(this.Usuario,this.Txt_clave.Password)){
                        this.EsValido = true;
                        MessageBox.Show("La información suministrada fue cambiada con exito, para fines de confirmación acceda nuevamente.", "Informacion cambiada con exito, Acceda de nuevo.", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Hide();
                    }
                }
            }
        }

        private void But_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.EsValido = false;
            this.Hide();
        }
    }
}
