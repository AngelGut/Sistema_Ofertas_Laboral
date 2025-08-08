namespace CpPresentacion
{
    partial class Menu
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
            components = new System.ComponentModel.Container();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            lblfecha = new Label();
            lblhora = new Label();
            mtbtnSoporte = new MaterialSkin.Controls.MaterialButton();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            BtnSalir = new MaterialSkin.Controls.MaterialButton();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            tabPage7 = new TabPage();
            tabPage8 = new TabPage();
            tabPage9 = new TabPage();
            horafecha = new System.Windows.Forms.Timer(components);
            materialTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Controls.Add(tabPage3);
            materialTabControl1.Controls.Add(tabPage4);
            materialTabControl1.Controls.Add(tabPage5);
            materialTabControl1.Controls.Add(tabPage6);
            materialTabControl1.Controls.Add(tabPage7);
            materialTabControl1.Controls.Add(tabPage8);
            materialTabControl1.Controls.Add(tabPage9);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.Location = new Point(2, 38);
            materialTabControl1.Margin = new Padding(2);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1486, 930);
            materialTabControl1.TabIndex = 0;
            materialTabControl1.SelectedIndexChanged += materialTabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lblfecha);
            tabPage1.Controls.Add(lblhora);
            tabPage1.Controls.Add(mtbtnSoporte);
            tabPage1.Controls.Add(pictureBox2);
            tabPage1.Controls.Add(pictureBox1);
            tabPage1.Controls.Add(BtnSalir);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2);
            tabPage1.Size = new Size(1478, 902);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Menu";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // lblfecha
            // 
            lblfecha.AutoSize = true;
            lblfecha.Font = new Font("Segoe UI", 30F);
            lblfecha.ForeColor = SystemColors.ControlDarkDark;
            lblfecha.Location = new Point(825, 111);
            lblfecha.Name = "lblfecha";
            lblfecha.Size = new Size(0, 54);
            lblfecha.TabIndex = 5;
            // 
            // lblhora
            // 
            lblhora.AutoSize = true;
            lblhora.Font = new Font("Segoe UI", 60F);
            lblhora.ForeColor = Color.DodgerBlue;
            lblhora.Location = new Point(825, 15);
            lblhora.Name = "lblhora";
            lblhora.Size = new Size(0, 106);
            lblhora.TabIndex = 4;
            // 
            // mtbtnSoporte
            // 
            mtbtnSoporte.AutoSize = false;
            mtbtnSoporte.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mtbtnSoporte.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            mtbtnSoporte.Depth = 0;
            mtbtnSoporte.HighEmphasis = true;
            mtbtnSoporte.Icon = null;
            mtbtnSoporte.Location = new Point(18, 592);
            mtbtnSoporte.Margin = new Padding(3, 4, 3, 4);
            mtbtnSoporte.MouseState = MaterialSkin.MouseState.HOVER;
            mtbtnSoporte.Name = "mtbtnSoporte";
            mtbtnSoporte.NoAccentTextColor = Color.Empty;
            mtbtnSoporte.Size = new Size(110, 22);
            mtbtnSoporte.TabIndex = 3;
            mtbtnSoporte.Text = "Soporte";
            mtbtnSoporte.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            mtbtnSoporte.UseAccentColor = false;
            mtbtnSoporte.UseVisualStyleBackColor = true;
            mtbtnSoporte.Click += mtbtnSoporte_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.ChatGPT_Image_6_jul_2025__19_27_041;
            pictureBox2.Location = new Point(671, 131);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(436, 368);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Gemini_Generated_Image_eufcczeufcczeufc1;
            pictureBox1.Location = new Point(232, 131);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(436, 368);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // BtnSalir
            // 
            BtnSalir.AutoSize = false;
            BtnSalir.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnSalir.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnSalir.Depth = 0;
            BtnSalir.HighEmphasis = true;
            BtnSalir.Icon = null;
            BtnSalir.Location = new Point(1185, 592);
            BtnSalir.Margin = new Padding(3, 4, 3, 4);
            BtnSalir.MouseState = MaterialSkin.MouseState.HOVER;
            BtnSalir.Name = "BtnSalir";
            BtnSalir.NoAccentTextColor = Color.Empty;
            BtnSalir.Size = new Size(110, 22);
            BtnSalir.TabIndex = 0;
            BtnSalir.Text = "Salir";
            BtnSalir.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            BtnSalir.UseAccentColor = false;
            BtnSalir.UseVisualStyleBackColor = true;
            BtnSalir.Click += BtnSalir_Click;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2);
            tabPage2.Size = new Size(1462, 863);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ofertas Laborales";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(2);
            tabPage3.Size = new Size(1462, 863);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Empresas";
            tabPage3.UseVisualStyleBackColor = true;
            tabPage3.Click += tabPage3_Click;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Margin = new Padding(2);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1462, 863);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Postulantes";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 24);
            tabPage5.Margin = new Padding(3, 2, 3, 2);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1462, 863);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Asignar Oferta";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Location = new Point(4, 24);
            tabPage6.Margin = new Padding(2);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(1462, 863);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Historial Correos";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            tabPage7.Location = new Point(4, 24);
            tabPage7.Margin = new Padding(2);
            tabPage7.Name = "tabPage7";
            tabPage7.Size = new Size(1462, 863);
            tabPage7.TabIndex = 6;
            tabPage7.Text = "Carnet";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            tabPage8.Location = new Point(4, 24);
            tabPage8.Margin = new Padding(2);
            tabPage8.Name = "tabPage8";
            tabPage8.Size = new Size(1462, 863);
            tabPage8.TabIndex = 7;
            tabPage8.Text = "Registro interno";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            tabPage9.Location = new Point(4, 24);
            tabPage9.Margin = new Padding(2);
            tabPage9.Name = "tabPage9";
            tabPage9.Size = new Size(1462, 863);
            tabPage9.TabIndex = 8;
            tabPage9.Text = "Historial Postulaciones";
            tabPage9.UseVisualStyleBackColor = true;
            // 
            // horafecha
            // 
            horafecha.Enabled = true;
            horafecha.Tick += horafecha_Tick;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1490, 970);
            Controls.Add(materialTabControl1);
            DrawerTabControl = materialTabControl1;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Menu";
            Padding = new Padding(2, 38, 2, 2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            materialTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private MaterialSkin.Controls.MaterialButton BtnSalir;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private MaterialSkin.Controls.MaterialButton mtbtnSoporte;
        private Label lblfecha;
        private Label lblhora;
        private System.Windows.Forms.Timer horafecha;
    }
}