namespace CpPresentacion
{
    partial class cpLogin
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtUsuario = new TextBox();
            txtClave = new TextBox();
            btnIngresar = new Button();
            btnRecuperarClave = new Button();
            pbCerrar = new PictureBox();
            pbMinimizar = new PictureBox();
            pbPassword = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPassword).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.Logo;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(236, 250);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(429, 31);
            label1.Name = "label1";
            label1.Size = new Size(90, 30);
            label1.TabIndex = 1;
            label1.Text = "LOGIN";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(367, 89);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(205, 23);
            txtUsuario.TabIndex = 1;
            txtUsuario.Text = "USUARIO";
            txtUsuario.Enter += txtUsuario_Enter;
            txtUsuario.Leave += txtUsuario_Leave;
            // 
            // txtClave
            // 
            txtClave.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtClave.Location = new Point(367, 127);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.Size = new Size(205, 25);
            txtClave.TabIndex = 2;
            // 
            // btnIngresar
            // 
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(429, 174);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(75, 23);
            btnIngresar.TabIndex = 3;
            btnIngresar.Text = "Acceder";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnRecuperarClave
            // 
            btnRecuperarClave.Cursor = Cursors.Hand;
            btnRecuperarClave.FlatAppearance.BorderSize = 0;
            btnRecuperarClave.FlatStyle = FlatStyle.Flat;
            btnRecuperarClave.Location = new Point(380, 215);
            btnRecuperarClave.Name = "btnRecuperarClave";
            btnRecuperarClave.Size = new Size(177, 23);
            btnRecuperarClave.TabIndex = 4;
            btnRecuperarClave.Text = "¿Has olvidado tu contraseña?";
            btnRecuperarClave.UseVisualStyleBackColor = true;
            btnRecuperarClave.Click += btnRecuperarClave_Click;
            // 
            // pbCerrar
            // 
            pbCerrar.Image = Properties.Resources.icone_x_grise;
            pbCerrar.Location = new Point(664, 0);
            pbCerrar.Name = "pbCerrar";
            pbCerrar.Size = new Size(16, 12);
            pbCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            pbCerrar.TabIndex = 5;
            pbCerrar.TabStop = false;
            pbCerrar.Click += pbCerrar_Click;
            // 
            // pbMinimizar
            // 
            pbMinimizar.Image = Properties.Resources.Minimizar;
            pbMinimizar.Location = new Point(652, 0);
            pbMinimizar.Name = "pbMinimizar";
            pbMinimizar.Size = new Size(16, 12);
            pbMinimizar.SizeMode = PictureBoxSizeMode.Zoom;
            pbMinimizar.TabIndex = 6;
            pbMinimizar.TabStop = false;
            pbMinimizar.Click += pbMinimizar_Click;
            // 
            // pbPassword
            // 
            pbPassword.Image = Properties.Resources.OjoCerrado;
            pbPassword.Location = new Point(580, 127);
            pbPassword.Name = "pbPassword";
            pbPassword.Size = new Size(32, 25);
            pbPassword.SizeMode = PictureBoxSizeMode.Zoom;
            pbPassword.TabIndex = 7;
            pbPassword.TabStop = false;
            pbPassword.Click += pbPassword_Click;
            // 
            // cpLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(680, 250);
            Controls.Add(pbPassword);
            Controls.Add(pbMinimizar);
            Controls.Add(pbCerrar);
            Controls.Add(btnRecuperarClave);
            Controls.Add(btnIngresar);
            Controls.Add(txtClave);
            Controls.Add(txtUsuario);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "cpLogin";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "cpLogin";
            Load += cpLogin_Load;
            KeyDown += cpLogin_KeyDown;
            MouseDown += cpLogin_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMinimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPassword).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtUsuario;
        private TextBox txtClave;
        private Button btnIngresar;
        private Button btnRecuperarClave;
        private PictureBox pbCerrar;
        private PictureBox pbMinimizar;
        private PictureBox pbPassword;
    }
}