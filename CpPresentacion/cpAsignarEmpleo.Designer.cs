namespace CpPresentacion
{
    partial class cpAsignarEmpleo
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            btnAsignar = new MaterialSkin.Controls.MaterialButton();
            cmbNuevo = new MaterialSkin.Controls.MaterialComboBox();
            cmbFiltroArea = new MaterialSkin.Controls.MaterialComboBox();
            btnBuscar2 = new MaterialSkin.Controls.MaterialButton();
            cmbFiltroEmpresa = new MaterialSkin.Controls.MaterialComboBox();
            btnBuscarID = new MaterialSkin.Controls.MaterialButton();
            txtBuscarID = new MaterialSkin.Controls.MaterialMaskedTextBox();
            txtBuscarDNI = new MaterialSkin.Controls.MaterialMaskedTextBox();
            dgvEmpresas = new DataGridView();
            dgvPostulantes = new DataGridView();
            tabPage6 = new TabPage();
            tabPage7 = new TabPage();
            tabPage8 = new TabPage();
            materialTabControl1.SuspendLayout();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmpresas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPostulantes).BeginInit();
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
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.Location = new Point(2, 51);
            materialTabControl1.Margin = new Padding(2);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1550, 829);
            materialTabControl1.TabIndex = 1;
            materialTabControl1.SelectedIndexChanged += materialTabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2);
            tabPage1.Size = new Size(1542, 796);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Menu";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2);
            tabPage2.Size = new Size(1542, 796);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ofertas Laborales";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 29);
            tabPage3.Margin = new Padding(2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(2);
            tabPage3.Size = new Size(1542, 796);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Empresas";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 29);
            tabPage4.Margin = new Padding(2);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1542, 796);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Postulantes";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(materialLabel2);
            tabPage5.Controls.Add(materialLabel1);
            tabPage5.Controls.Add(btnAsignar);
            tabPage5.Controls.Add(cmbNuevo);
            tabPage5.Controls.Add(cmbFiltroArea);
            tabPage5.Controls.Add(btnBuscar2);
            tabPage5.Controls.Add(cmbFiltroEmpresa);
            tabPage5.Controls.Add(btnBuscarID);
            tabPage5.Controls.Add(txtBuscarID);
            tabPage5.Controls.Add(txtBuscarDNI);
            tabPage5.Controls.Add(dgvEmpresas);
            tabPage5.Controls.Add(dgvPostulantes);
            tabPage5.Location = new Point(4, 29);
            tabPage5.Margin = new Padding(2);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1542, 796);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Asignar Oferta";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            materialLabel2.Location = new Point(1008, 23);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(228, 19);
            materialLabel2.TabIndex = 12;
            materialLabel2.Text = "Ofertas Disponibles Registradas";
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            materialLabel1.Location = new Point(236, 23);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(173, 19);
            materialLabel1.TabIndex = 11;
            materialLabel1.Text = "Postulantes Registrados";
            // 
            // btnAsignar
            // 
            btnAsignar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAsignar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAsignar.Depth = 0;
            btnAsignar.HighEmphasis = true;
            btnAsignar.Icon = null;
            btnAsignar.Location = new Point(600, 492);
            btnAsignar.Margin = new Padding(4, 6, 4, 6);
            btnAsignar.MouseState = MaterialSkin.MouseState.HOVER;
            btnAsignar.Name = "btnAsignar";
            btnAsignar.NoAccentTextColor = Color.Empty;
            btnAsignar.Size = new Size(83, 36);
            btnAsignar.TabIndex = 10;
            btnAsignar.Text = "Asignar";
            btnAsignar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAsignar.UseAccentColor = false;
            btnAsignar.UseVisualStyleBackColor = true;
            btnAsignar.Click += btnAsignar_Click;
            // 
            // cmbNuevo
            // 
            cmbNuevo.AutoResize = false;
            cmbNuevo.BackColor = Color.FromArgb(255, 255, 255);
            cmbNuevo.Depth = 0;
            cmbNuevo.DrawMode = DrawMode.OwnerDrawVariable;
            cmbNuevo.DropDownHeight = 174;
            cmbNuevo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNuevo.DropDownWidth = 121;
            cmbNuevo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbNuevo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbNuevo.FormattingEnabled = true;
            cmbNuevo.IntegralHeight = false;
            cmbNuevo.ItemHeight = 43;
            cmbNuevo.Location = new Point(76, 438);
            cmbNuevo.MaxDropDownItems = 4;
            cmbNuevo.MouseState = MaterialSkin.MouseState.OUT;
            cmbNuevo.Name = "cmbNuevo";
            cmbNuevo.Size = new Size(120, 49);
            cmbNuevo.StartIndex = 0;
            cmbNuevo.TabIndex = 9;
            // 
            // cmbFiltroArea
            // 
            cmbFiltroArea.AutoResize = false;
            cmbFiltroArea.BackColor = Color.FromArgb(255, 255, 255);
            cmbFiltroArea.Depth = 0;
            cmbFiltroArea.DrawMode = DrawMode.OwnerDrawVariable;
            cmbFiltroArea.DropDownHeight = 174;
            cmbFiltroArea.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroArea.DropDownWidth = 121;
            cmbFiltroArea.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbFiltroArea.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbFiltroArea.FormattingEnabled = true;
            cmbFiltroArea.IntegralHeight = false;
            cmbFiltroArea.ItemHeight = 43;
            cmbFiltroArea.Location = new Point(1157, 438);
            cmbFiltroArea.MaxDropDownItems = 4;
            cmbFiltroArea.MouseState = MaterialSkin.MouseState.OUT;
            cmbFiltroArea.Name = "cmbFiltroArea";
            cmbFiltroArea.Size = new Size(213, 49);
            cmbFiltroArea.StartIndex = 0;
            cmbFiltroArea.TabIndex = 8;
            // 
            // btnBuscar2
            // 
            btnBuscar2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBuscar2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBuscar2.Depth = 0;
            btnBuscar2.HighEmphasis = true;
            btnBuscar2.Icon = null;
            btnBuscar2.Location = new Point(1220, 547);
            btnBuscar2.Margin = new Padding(4, 6, 4, 6);
            btnBuscar2.MouseState = MaterialSkin.MouseState.HOVER;
            btnBuscar2.Name = "btnBuscar2";
            btnBuscar2.NoAccentTextColor = Color.Empty;
            btnBuscar2.Size = new Size(77, 36);
            btnBuscar2.TabIndex = 7;
            btnBuscar2.Text = "Buscar";
            btnBuscar2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBuscar2.UseAccentColor = false;
            btnBuscar2.UseVisualStyleBackColor = true;
            // 
            // cmbFiltroEmpresa
            // 
            cmbFiltroEmpresa.AutoResize = false;
            cmbFiltroEmpresa.BackColor = Color.FromArgb(255, 255, 255);
            cmbFiltroEmpresa.Depth = 0;
            cmbFiltroEmpresa.DrawMode = DrawMode.OwnerDrawVariable;
            cmbFiltroEmpresa.DropDownHeight = 174;
            cmbFiltroEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroEmpresa.DropDownWidth = 121;
            cmbFiltroEmpresa.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbFiltroEmpresa.ForeColor = Color.White;
            cmbFiltroEmpresa.FormattingEnabled = true;
            cmbFiltroEmpresa.IntegralHeight = false;
            cmbFiltroEmpresa.ItemHeight = 43;
            cmbFiltroEmpresa.Location = new Point(783, 438);
            cmbFiltroEmpresa.MaxDropDownItems = 4;
            cmbFiltroEmpresa.MouseState = MaterialSkin.MouseState.OUT;
            cmbFiltroEmpresa.Name = "cmbFiltroEmpresa";
            cmbFiltroEmpresa.Size = new Size(199, 49);
            cmbFiltroEmpresa.StartIndex = 0;
            cmbFiltroEmpresa.TabIndex = 6;
            // 
            // btnBuscarID
            // 
            btnBuscarID.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBuscarID.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBuscarID.Depth = 0;
            btnBuscarID.HighEmphasis = true;
            btnBuscarID.Icon = null;
            btnBuscarID.Location = new Point(377, 547);
            btnBuscarID.Margin = new Padding(4, 6, 4, 6);
            btnBuscarID.MouseState = MaterialSkin.MouseState.HOVER;
            btnBuscarID.Name = "btnBuscarID";
            btnBuscarID.NoAccentTextColor = Color.Empty;
            btnBuscarID.Size = new Size(77, 36);
            btnBuscarID.TabIndex = 4;
            btnBuscarID.Text = "Buscar";
            btnBuscarID.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBuscarID.UseAccentColor = false;
            btnBuscarID.UseVisualStyleBackColor = true;
            btnBuscarID.Click += btnBuscarID_Click;
            // 
            // txtBuscarID
            // 
            txtBuscarID.AllowPromptAsInput = true;
            txtBuscarID.AnimateReadOnly = false;
            txtBuscarID.AsciiOnly = false;
            txtBuscarID.BackgroundImageLayout = ImageLayout.None;
            txtBuscarID.BeepOnError = false;
            txtBuscarID.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtBuscarID.Depth = 0;
            txtBuscarID.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBuscarID.HidePromptOnLeave = false;
            txtBuscarID.HideSelection = true;
            txtBuscarID.InsertKeyMode = InsertKeyMode.Default;
            txtBuscarID.LeadingIcon = null;
            txtBuscarID.Location = new Point(860, 547);
            txtBuscarID.Mask = "";
            txtBuscarID.MaxLength = 32767;
            txtBuscarID.MouseState = MaterialSkin.MouseState.OUT;
            txtBuscarID.Name = "txtBuscarID";
            txtBuscarID.PasswordChar = '\0';
            txtBuscarID.PrefixSuffixText = null;
            txtBuscarID.PromptChar = '_';
            txtBuscarID.ReadOnly = false;
            txtBuscarID.RejectInputOnFirstFailure = false;
            txtBuscarID.ResetOnPrompt = true;
            txtBuscarID.ResetOnSpace = true;
            txtBuscarID.RightToLeft = RightToLeft.No;
            txtBuscarID.SelectedText = "";
            txtBuscarID.SelectionLength = 0;
            txtBuscarID.SelectionStart = 0;
            txtBuscarID.ShortcutsEnabled = true;
            txtBuscarID.Size = new Size(312, 48);
            txtBuscarID.SkipLiterals = true;
            txtBuscarID.TabIndex = 3;
            txtBuscarID.TabStop = false;
            txtBuscarID.TextAlign = HorizontalAlignment.Left;
            txtBuscarID.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtBuscarID.TrailingIcon = null;
            txtBuscarID.UseSystemPasswordChar = false;
            txtBuscarID.ValidatingType = null;
            // 
            // txtBuscarDNI
            // 
            txtBuscarDNI.AllowPromptAsInput = true;
            txtBuscarDNI.AnimateReadOnly = false;
            txtBuscarDNI.AsciiOnly = false;
            txtBuscarDNI.BackgroundImageLayout = ImageLayout.None;
            txtBuscarDNI.BeepOnError = false;
            txtBuscarDNI.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtBuscarDNI.Depth = 0;
            txtBuscarDNI.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBuscarDNI.HidePromptOnLeave = false;
            txtBuscarDNI.HideSelection = true;
            txtBuscarDNI.InsertKeyMode = InsertKeyMode.Default;
            txtBuscarDNI.LeadingIcon = null;
            txtBuscarDNI.Location = new Point(63, 547);
            txtBuscarDNI.Mask = "";
            txtBuscarDNI.MaxLength = 32767;
            txtBuscarDNI.MouseState = MaterialSkin.MouseState.OUT;
            txtBuscarDNI.Name = "txtBuscarDNI";
            txtBuscarDNI.PasswordChar = '\0';
            txtBuscarDNI.PrefixSuffixText = null;
            txtBuscarDNI.PromptChar = '_';
            txtBuscarDNI.ReadOnly = false;
            txtBuscarDNI.RejectInputOnFirstFailure = false;
            txtBuscarDNI.ResetOnPrompt = true;
            txtBuscarDNI.ResetOnSpace = true;
            txtBuscarDNI.RightToLeft = RightToLeft.No;
            txtBuscarDNI.SelectedText = "";
            txtBuscarDNI.SelectionLength = 0;
            txtBuscarDNI.SelectionStart = 0;
            txtBuscarDNI.ShortcutsEnabled = true;
            txtBuscarDNI.Size = new Size(286, 48);
            txtBuscarDNI.SkipLiterals = true;
            txtBuscarDNI.TabIndex = 2;
            txtBuscarDNI.TabStop = false;
            txtBuscarDNI.TextAlign = HorizontalAlignment.Left;
            txtBuscarDNI.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtBuscarDNI.TrailingIcon = null;
            txtBuscarDNI.UseSystemPasswordChar = false;
            txtBuscarDNI.ValidatingType = null;
            // 
            // dgvEmpresas
            // 
            dgvEmpresas.AllowUserToAddRows = false;
            dgvEmpresas.AllowUserToDeleteRows = false;
            dgvEmpresas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(192, 0, 192);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvEmpresas.DefaultCellStyle = dataGridViewCellStyle3;
            dgvEmpresas.Location = new Point(783, 62);
            dgvEmpresas.Name = "dgvEmpresas";
            dgvEmpresas.ReadOnly = true;
            dgvEmpresas.RowHeadersWidth = 51;
            dgvEmpresas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpresas.Size = new Size(630, 354);
            dgvEmpresas.TabIndex = 1;
            dgvEmpresas.CellClick += dgvEmpresas_CellClick;
            dgvEmpresas.CellContentClick += dgvEmpresas_CellContentClick;
            // 
            // dgvPostulantes
            // 
            dgvPostulantes.AllowUserToAddRows = false;
            dgvPostulantes.AllowUserToDeleteRows = false;
            dgvPostulantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(192, 0, 192);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvPostulantes.DefaultCellStyle = dataGridViewCellStyle4;
            dgvPostulantes.Location = new Point(47, 65);
            dgvPostulantes.Name = "dgvPostulantes";
            dgvPostulantes.ReadOnly = true;
            dgvPostulantes.RowHeadersWidth = 51;
            dgvPostulantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPostulantes.Size = new Size(636, 351);
            dgvPostulantes.TabIndex = 0;
            dgvPostulantes.CellClick += dgvPostulantes_CellClick;
            dgvPostulantes.CellContentClick += dgvPostulantes_CellContentClick;
            // 
            // tabPage6
            // 
            tabPage6.Location = new Point(4, 29);
            tabPage6.Margin = new Padding(2);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(1542, 796);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Historial Correos";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            tabPage7.Location = new Point(4, 29);
            tabPage7.Margin = new Padding(2);
            tabPage7.Name = "tabPage7";
            tabPage7.Size = new Size(1542, 796);
            tabPage7.TabIndex = 6;
            tabPage7.Text = "Carnet";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            tabPage8.Location = new Point(4, 29);
            tabPage8.Margin = new Padding(2);
            tabPage8.Name = "tabPage8";
            tabPage8.Size = new Size(1542, 796);
            tabPage8.TabIndex = 7;
            tabPage8.Text = "Registro Interno";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // cpAsignarEmpleo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1554, 882);
            Controls.Add(materialTabControl1);
            DrawerTabControl = materialTabControl1;
            Margin = new Padding(2);
            Name = "cpAsignarEmpleo";
            Padding = new Padding(2, 51, 2, 2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Asignar Oferta";
            materialTabControl1.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmpresas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPostulantes).EndInit();
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
        private DataGridView dgvPostulantes;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtBuscarID;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtBuscarDNI;
        private DataGridView dgvEmpresas;
        private MaterialSkin.Controls.MaterialButton btnBuscarID;
        private ComboBox cmbFiltroBusqueda;
        private MaterialSkin.Controls.MaterialComboBox cmbFiltroEmpresa;
        private MaterialSkin.Controls.MaterialButton btnBuscar2;
        private MaterialSkin.Controls.MaterialComboBox cmbFiltroArea;
        private MaterialSkin.Controls.MaterialButton btnAsignar;
        private MaterialSkin.Controls.MaterialComboBox cmbNuevo;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}