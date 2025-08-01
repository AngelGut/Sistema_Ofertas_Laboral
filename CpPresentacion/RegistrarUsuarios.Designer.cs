namespace CpPresentacion
{
    partial class RegistrarUsuarios
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
            groupBox1 = new GroupBox();
            label1 = new Label();
            btnCancelar = new Button();
            btnRegistrar = new Button();
            cmbRol = new ComboBox();
            txtCorreo = new TextBox();
            txtContraseña = new TextBox();
            txtUsuario = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            lblusuario = new Label();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnRegistrar);
            groupBox1.Controls.Add(cmbRol);
            groupBox1.Controls.Add(txtCorreo);
            groupBox1.Controls.Add(txtContraseña);
            groupBox1.Controls.Add(txtUsuario);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblusuario);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(410, 457);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(53, 187);
            label1.Name = "label1";
            label1.Size = new Size(209, 24);
            label1.TabIndex = 11;
            label1.Text = "REGISTRO USUARIOS";
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(254, 414);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Cursor = Cursors.Hand;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Location = new Point(140, 414);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(75, 23);
            btnRegistrar.TabIndex = 9;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(173, 356);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(166, 23);
            cmbRol.TabIndex = 8;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(173, 316);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(166, 23);
            txtCorreo.TabIndex = 7;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(173, 279);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(166, 23);
            txtContraseña.TabIndex = 6;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(173, 238);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(166, 23);
            txtUsuario.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(53, 359);
            label4.Name = "label4";
            label4.Size = new Size(27, 15);
            label4.TabIndex = 4;
            label4.Text = "Rol:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 319);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 3;
            label3.Text = "Correo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 282);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 2;
            label2.Text = "Contraseña:";
            // 
            // lblusuario
            // 
            lblusuario.AutoSize = true;
            lblusuario.Location = new Point(53, 239);
            lblusuario.Name = "lblusuario";
            lblusuario.Size = new Size(50, 15);
            lblusuario.TabIndex = 1;
            lblusuario.Text = "Usuario:";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = Properties.Resources.Logo;
            pictureBox1.Location = new Point(3, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(404, 152);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // RegistrarUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DodgerBlue;
            ClientSize = new Size(434, 481);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegistrarUsuarios";
            Opacity = 0.95D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegistrarUsuarios";
            Load += RegistrarUsuarios_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtUsuario;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label lblusuario;
        private PictureBox pictureBox1;
        private ComboBox cmbRol;
        private TextBox txtCorreo;
        private TextBox txtContraseña;
        private Button btnCancelar;
        private Button btnRegistrar;
        private Label label1;
    }
}