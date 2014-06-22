namespace Empresa.RegistrosEventos.RegistroEventos
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lis_lista = new System.Windows.Forms.ListBox();
            this.but_seleccionar = new System.Windows.Forms.Button();
            this.but_salir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ch_habilitado = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_usuario = new System.Windows.Forms.Label();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lis_lista
            // 
            this.lis_lista.DisplayMember = "Nombre";
            this.lis_lista.FormattingEnabled = true;
            this.lis_lista.Location = new System.Drawing.Point(12, 149);
            this.lis_lista.Name = "lis_lista";
            this.lis_lista.Size = new System.Drawing.Size(496, 186);
            this.lis_lista.TabIndex = 0;
            this.lis_lista.SelectedIndexChanged += new System.EventHandler(this.lis_lista_SelectedIndexChanged);
            // 
            // but_seleccionar
            // 
            this.but_seleccionar.Location = new System.Drawing.Point(12, 341);
            this.but_seleccionar.Name = "but_seleccionar";
            this.but_seleccionar.Size = new System.Drawing.Size(75, 23);
            this.but_seleccionar.TabIndex = 1;
            this.but_seleccionar.Text = "Aceptar";
            this.but_seleccionar.UseVisualStyleBackColor = true;
            this.but_seleccionar.Click += new System.EventHandler(this.but_seleccionar_Click);
            // 
            // but_salir
            // 
            this.but_salir.Location = new System.Drawing.Point(93, 341);
            this.but_salir.Name = "but_salir";
            this.but_salir.Size = new System.Drawing.Size(75, 23);
            this.but_salir.TabIndex = 2;
            this.but_salir.Text = "Salir";
            this.but_salir.UseVisualStyleBackColor = true;
            this.but_salir.Click += new System.EventHandler(this.but_salir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario";
            // 
            // ch_habilitado
            // 
            this.ch_habilitado.AutoSize = true;
            this.ch_habilitado.Location = new System.Drawing.Point(15, 59);
            this.ch_habilitado.Name = "ch_habilitado";
            this.ch_habilitado.Size = new System.Drawing.Size(73, 17);
            this.ch_habilitado.TabIndex = 5;
            this.ch_habilitado.Text = "Habilitado";
            this.ch_habilitado.UseVisualStyleBackColor = true;
            this.ch_habilitado.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Selección de usuario";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_usuario);
            this.panel1.Controls.Add(this.lbl_nombre);
            this.panel1.Controls.Add(this.ch_habilitado);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 88);
            this.panel1.TabIndex = 7;
            // 
            // lbl_usuario
            // 
            this.lbl_usuario.AutoSize = true;
            this.lbl_usuario.Location = new System.Drawing.Point(79, 33);
            this.lbl_usuario.Name = "lbl_usuario";
            this.lbl_usuario.Size = new System.Drawing.Size(0, 13);
            this.lbl_usuario.TabIndex = 7;
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.Location = new System.Drawing.Point(78, 10);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(0, 13);
            this.lbl_nombre.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 390);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.but_salir);
            this.Controls.Add(this.but_seleccionar);
            this.Controls.Add(this.lis_lista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccion de usuario";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lis_lista;
        private System.Windows.Forms.Button but_seleccionar;
        private System.Windows.Forms.Button but_salir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ch_habilitado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_usuario;
        private System.Windows.Forms.Label lbl_nombre;
    }
}