namespace CpPresentacion
{
    partial class cpHistorialPostulaciones
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
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            tabPage7 = new TabPage();
            tabPage8 = new TabPage();
            tabPage9 = new TabPage();
            btnLimpiarFiltros = new MaterialSkin.Controls.MaterialButton();
            panel1 = new Panel();
            cmbFiltro = new ComboBox();
            txtBusqueda = new TextBox();
            label8 = new Label();
            lblBuscar = new Label();
            pictureBox1 = new PictureBox();
            dgvHistorialPostulaciones = new DataGridView();
            btnBuscar = new MaterialSkin.Controls.MaterialButton();
            materialTabControl1.SuspendLayout();
            tabPage9.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialPostulaciones).BeginInit();
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
            materialTabControl1.Margin = new Padding(1);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1183, 407);
            materialTabControl1.TabIndex = 1;
            materialTabControl1.SelectedIndexChanged += materialTabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(1);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(1);
            tabPage1.Size = new Size(1175, 379);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Menu";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(1);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(1);
            tabPage2.Size = new Size(1175, 379);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ofertas Laborales";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(1);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1175, 379);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Empresas";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Margin = new Padding(1);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1175, 379);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Postulantes";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 24);
            tabPage5.Margin = new Padding(1);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1175, 379);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Asignar Oferta";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Location = new Point(4, 24);
            tabPage6.Margin = new Padding(1);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(1175, 379);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Historial Correos";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            tabPage7.Location = new Point(4, 24);
            tabPage7.Margin = new Padding(1);
            tabPage7.Name = "tabPage7";
            tabPage7.Size = new Size(1175, 379);
            tabPage7.TabIndex = 6;
            tabPage7.Text = "Carnet";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            tabPage8.Location = new Point(4, 24);
            tabPage8.Margin = new Padding(1);
            tabPage8.Name = "tabPage8";
            tabPage8.Size = new Size(1175, 379);
            tabPage8.TabIndex = 7;
            tabPage8.Text = "Registro Interno";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            tabPage9.Controls.Add(btnLimpiarFiltros);
            tabPage9.Controls.Add(panel1);
            tabPage9.Controls.Add(dgvHistorialPostulaciones);
            tabPage9.Controls.Add(btnBuscar);
            tabPage9.Location = new Point(4, 24);
            tabPage9.Margin = new Padding(2);
            tabPage9.Name = "tabPage9";
            tabPage9.Size = new Size(1175, 379);
            tabPage9.TabIndex = 8;
            tabPage9.Text = "Historial Postulaciones";
            tabPage9.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLimpiarFiltros.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLimpiarFiltros.Depth = 0;
            btnLimpiarFiltros.HighEmphasis = true;
            btnLimpiarFiltros.Icon = null;
            btnLimpiarFiltros.Location = new Point(413, 316);
            btnLimpiarFiltros.Margin = new Padding(4, 6, 4, 6);
            btnLimpiarFiltros.MouseState = MaterialSkin.MouseState.HOVER;
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.NoAccentTextColor = Color.Empty;
            btnLimpiarFiltros.Size = new Size(79, 36);
            btnLimpiarFiltros.TabIndex = 4;
            btnLimpiarFiltros.Text = "Limpiar";
            btnLimpiarFiltros.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLimpiarFiltros.UseAccentColor = false;
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += btnLimpiar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Controls.Add(cmbFiltro);
            panel1.Controls.Add(txtBusqueda);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(lblBuscar);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(287, 379);
            panel1.TabIndex = 3;
            // 
            // cmbFiltro
            // 
            cmbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltro.FormattingEnabled = true;
            cmbFiltro.Location = new Point(95, 185);
            cmbFiltro.Name = "cmbFiltro";
            cmbFiltro.Size = new Size(172, 23);
            cmbFiltro.TabIndex = 10;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(95, 233);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(172, 23);
            txtBusqueda.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 9.75F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(21, 188);
            label8.Name = "label8";
            label8.Size = new Size(38, 17);
            label8.TabIndex = 6;
            label8.Text = "Filtro";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Century Gothic", 9.75F);
            lblBuscar.ForeColor = Color.White;
            lblBuscar.Location = new Point(21, 236);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(49, 17);
            lblBuscar.TabIndex = 5;
            lblBuscar.Text = "Buscar";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = Properties.Resources.Logo;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(287, 153);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // dgvHistorialPostulaciones
            // 
            dgvHistorialPostulaciones.AllowUserToAddRows = false;
            dgvHistorialPostulaciones.AllowUserToDeleteRows = false;
            dgvHistorialPostulaciones.AllowUserToOrderColumns = true;
            dgvHistorialPostulaciones.AllowUserToResizeColumns = false;
            dgvHistorialPostulaciones.AllowUserToResizeRows = false;
            dgvHistorialPostulaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorialPostulaciones.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvHistorialPostulaciones.Location = new Point(314, 14);
            dgvHistorialPostulaciones.Name = "dgvHistorialPostulaciones";
            dgvHistorialPostulaciones.ReadOnly = true;
            dgvHistorialPostulaciones.RowHeadersWidth = 62;
            dgvHistorialPostulaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorialPostulaciones.Size = new Size(836, 280);
            dgvHistorialPostulaciones.TabIndex = 0;
            // 
            // btnBuscar
            // 
            btnBuscar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBuscar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBuscar.Depth = 0;
            btnBuscar.HighEmphasis = true;
            btnBuscar.Icon = null;
            btnBuscar.Location = new Point(314, 316);
            btnBuscar.Margin = new Padding(4, 6, 4, 6);
            btnBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            btnBuscar.Name = "btnBuscar";
            btnBuscar.NoAccentTextColor = Color.Empty;
            btnBuscar.Size = new Size(77, 36);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar";
            btnBuscar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBuscar.UseAccentColor = false;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // cpHistorialPostulaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1187, 447);
            Controls.Add(materialTabControl1);
            DrawerTabControl = materialTabControl1;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "cpHistorialPostulaciones";
            Padding = new Padding(2, 38, 2, 2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historial Postulaciones";
            Load += cpHistorialPostulaciones_Load;
            materialTabControl1.ResumeLayout(false);
            tabPage9.ResumeLayout(false);
            tabPage9.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialPostulaciones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private DataGridView dgvHistorialPostulaciones;
        private Panel panel1;
        private MaterialSkin.Controls.MaterialButton btnBuscar;
        private Label lblBuscar;
        private PictureBox pictureBox1;
        private ComboBox cmbFiltro;
        private MaterialSkin.Controls.MaterialButton btnLimpiarFiltros;
        private TextBox txtBusqueda;
        private Label label8;
    }
}