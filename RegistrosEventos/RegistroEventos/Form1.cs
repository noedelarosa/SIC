using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Empresa.RegistrosEventos.RegistroEventos
{
    public partial class Form1 : Form
    {
        public bool EsValido = false;
        public Empresa.Usuarios.TUsuario UsuarioSelect { get; set; }

        public Form1(){
            InitializeComponent();
            this.lis_lista.DataSource = new Empresa.Usuarios.Usuario(true).ToList();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e){





        }

        private void but_salir_Click(object sender, EventArgs e){
            EsValido = false;
            this.Hide();
        }

        private void but_seleccionar_Click(object sender, EventArgs e){
            EsValido = true;
            this.Hide();
        }

        private void lis_lista_SelectedIndexChanged(object sender, EventArgs e){
            var _lista = sender as ListBox;
            if(_lista.SelectedItem != null){
                Empresa.Usuarios.TUsuario _usu = _lista.SelectedItem as Empresa.Usuarios.TUsuario;
                this.UsuarioSelect = _usu;
                lbl_nombre.Text = _usu.Personal.NombreCompleto;
                lbl_usuario.Text = _usu.Nombre;
                //ch_habilitado.va
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {


        }

    }
}
