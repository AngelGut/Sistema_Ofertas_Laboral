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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            cmbFiltroBusqueda = new ComboBox();
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
            tabPage5.Controls.Add(cmbFiltroBusqueda);
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
            // cmbFiltroBusqueda
            // 
            cmbFiltroBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroBusqueda.FormattingEnabled = true;
            cmbFiltroBusqueda.Location = new Point(37, 383);
            cmbFiltroBusqueda.Name = "cmbFiltroBusqueda";
            cmbFiltroBusqueda.Size = new Size(151, 28);
            cmbFiltroBusqueda.TabIndex = 5;
            // 
            // btnBuscarID
            // 
            btnBuscarID.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBuscarID.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBuscarID.Depth = 0;
            btnBuscarID.HighEmphasis = true;
            btnBuscarID.Icon = null;
            btnBuscarID.Location = new Point(345, 466);
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
            txtBuscarID.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBuscarID.HidePromptOnLeave = false;
            txtBuscarID.HideSelection = true;
            txtBuscarID.InsertKeyMode = InsertKeyMode.Default;
            txtBuscarID.LeadingIcon = null;
            txtBuscarID.Location = new Point(717, 417);
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
            txtBuscarID.Text = "materialMaskedTextBox2";
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
            txtBuscarDNI.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBuscarDNI.HidePromptOnLeave = false;
            txtBuscarDNI.HideSelection = true;
            txtBuscarDNI.InsertKeyMode = InsertKeyMode.Default;
            txtBuscarDNI.LeadingIcon = null;
            txtBuscarDNI.Location = new Point(24, 466);
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(192, 0, 192);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvEmpresas.DefaultCellStyle = dataGridViewCellStyle1;
            dgvEmpresas.Location = new Point(635, 38);
            dgvEmpresas.Name = "dgvEmpresas";
            dgvEmpresas.ReadOnly = true;
            dgvEmpresas.RowHeadersWidth = 51;
            dgvEmpresas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpresas.Size = new Size(565, 294);
            dgvEmpresas.TabIndex = 1;
            dgvEmpresas.CellContentClick += dgvEmpresas_CellContentClick;
            // 
            // dgvPostulantes
            // 
            dgvPostulantes.AllowUserToAddRows = false;
            dgvPostulantes.AllowUserToDeleteRows = false;
            dgvPostulantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(192, 0, 192);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPostulantes.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPostulantes.Location = new Point(24, 38);
            dgvPostulantes.Name = "dgvPostulantes";
            dgvPostulantes.ReadOnly = true;
            dgvPostulantes.RowHeadersWidth = 51;
            dgvPostulantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPostulantes.Size = new Size(527, 294);
            dgvPostulantes.TabIndex = 0;
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
    }
}