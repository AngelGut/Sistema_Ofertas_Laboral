namespace CpPresentacion
{
    partial class cpEmpresa
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
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            BtnActualizar = new MaterialSkin.Controls.MaterialButton();
            BtnRegistrar = new MaterialSkin.Controls.MaterialButton();
            DgvEmpresas = new DataGridView();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            BtnValidar = new MaterialSkin.Controls.MaterialButton();
            TxtCorreo = new MaterialSkin.Controls.MaterialMaskedTextBox();
            LblCorreo = new MaterialSkin.Controls.MaterialLabel();
            TxtDireccion = new MaterialSkin.Controls.MaterialMaskedTextBox();
            LblDireccion = new MaterialSkin.Controls.MaterialLabel();
            TxtTelefono = new MaterialSkin.Controls.MaterialMaskedTextBox();
            LblTelefono = new MaterialSkin.Controls.MaterialLabel();
            TxtRnc = new MaterialSkin.Controls.MaterialMaskedTextBox();
            LblRnc = new MaterialSkin.Controls.MaterialLabel();
            TxtNombreCompania = new MaterialSkin.Controls.MaterialMaskedTextBox();
            lblNombreCompania = new MaterialSkin.Controls.MaterialLabel();
            tabPage4 = new TabPage();
            materialTabControl1.SuspendLayout();
            tabPage3.SuspendLayout();
            materialCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvEmpresas).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Controls.Add(tabPage3);
            materialTabControl1.Controls.Add(tabPage4);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.Location = new Point(2, 38);
            materialTabControl1.Margin = new Padding(2, 2, 2, 2);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1326, 608);
            materialTabControl1.TabIndex = 0;
            materialTabControl1.SelectedIndexChanged += materialTabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(2, 2, 2, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2, 2, 2, 2);
            tabPage1.Size = new Size(1318, 580);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Menu";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(2, 2, 2, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2, 2, 2, 2);
            tabPage2.Size = new Size(1318, 580);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ofertas laborales";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(materialCard2);
            tabPage3.Controls.Add(DgvEmpresas);
            tabPage3.Controls.Add(materialCard1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(2, 2, 2, 2);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1318, 580);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Empresas";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(BtnActualizar);
            materialCard2.Controls.Add(BtnRegistrar);
            materialCard2.Depth = 0;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(378, 396);
            materialCard2.Margin = new Padding(10, 8, 10, 8);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(10, 8, 10, 8);
            materialCard2.Size = new Size(410, 90);
            materialCard2.TabIndex = 2;
            // 
            // BtnActualizar
            // 
            BtnActualizar.AutoSize = false;
            BtnActualizar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnActualizar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnActualizar.Depth = 0;
            BtnActualizar.HighEmphasis = true;
            BtnActualizar.Icon = null;
            BtnActualizar.Location = new Point(231, 31);
            BtnActualizar.Margin = new Padding(3, 4, 3, 4);
            BtnActualizar.MouseState = MaterialSkin.MouseState.HOVER;
            BtnActualizar.Name = "BtnActualizar";
            BtnActualizar.NoAccentTextColor = Color.Empty;
            BtnActualizar.Size = new Size(166, 32);
            BtnActualizar.TabIndex = 1;
            BtnActualizar.Text = "Actualizar";
            BtnActualizar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            BtnActualizar.UseAccentColor = false;
            BtnActualizar.UseVisualStyleBackColor = true;
            BtnActualizar.Click += BtnActualizar_Click;
            // 
            // BtnRegistrar
            // 
            BtnRegistrar.AutoSize = false;
            BtnRegistrar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnRegistrar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnRegistrar.Depth = 0;
            BtnRegistrar.HighEmphasis = true;
            BtnRegistrar.Icon = null;
            BtnRegistrar.Location = new Point(13, 31);
            BtnRegistrar.Margin = new Padding(3, 4, 3, 4);
            BtnRegistrar.MouseState = MaterialSkin.MouseState.HOVER;
            BtnRegistrar.Name = "BtnRegistrar";
            BtnRegistrar.NoAccentTextColor = Color.Empty;
            BtnRegistrar.Size = new Size(166, 32);
            BtnRegistrar.TabIndex = 0;
            BtnRegistrar.Text = "Registrar";
            BtnRegistrar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            BtnRegistrar.UseAccentColor = false;
            BtnRegistrar.UseVisualStyleBackColor = true;
            BtnRegistrar.Click += BtnRegistrar_Click;
            // 
            // DgvEmpresas
            // 
            DgvEmpresas.AllowUserToAddRows = false;
            DgvEmpresas.AllowUserToDeleteRows = false;
            DgvEmpresas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvEmpresas.Location = new Point(378, 8);
            DgvEmpresas.Margin = new Padding(2, 2, 2, 2);
            DgvEmpresas.MultiSelect = false;
            DgvEmpresas.Name = "DgvEmpresas";
            DgvEmpresas.ReadOnly = true;
            DgvEmpresas.RowHeadersWidth = 62;
            DgvEmpresas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvEmpresas.Size = new Size(910, 328);
            DgvEmpresas.TabIndex = 1;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(BtnValidar);
            materialCard1.Controls.Add(TxtCorreo);
            materialCard1.Controls.Add(LblCorreo);
            materialCard1.Controls.Add(TxtDireccion);
            materialCard1.Controls.Add(LblDireccion);
            materialCard1.Controls.Add(TxtTelefono);
            materialCard1.Controls.Add(LblTelefono);
            materialCard1.Controls.Add(TxtRnc);
            materialCard1.Controls.Add(LblRnc);
            materialCard1.Controls.Add(TxtNombreCompania);
            materialCard1.Controls.Add(lblNombreCompania);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(10, 8);
            materialCard1.Margin = new Padding(10, 8, 10, 8);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(10, 8, 10, 8);
            materialCard1.Size = new Size(342, 568);
            materialCard1.TabIndex = 0;
            // 
            // BtnValidar
            // 
            BtnValidar.AutoSize = false;
            BtnValidar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnValidar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnValidar.Depth = 0;
            BtnValidar.HighEmphasis = true;
            BtnValidar.Icon = null;
            BtnValidar.Location = new Point(248, 90);
            BtnValidar.Margin = new Padding(3, 4, 3, 4);
            BtnValidar.MouseState = MaterialSkin.MouseState.HOVER;
            BtnValidar.Name = "BtnValidar";
            BtnValidar.NoAccentTextColor = Color.Empty;
            BtnValidar.Size = new Size(87, 32);
            BtnValidar.TabIndex = 10;
            BtnValidar.Text = "Validar";
            BtnValidar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            BtnValidar.UseAccentColor = false;
            BtnValidar.UseVisualStyleBackColor = true;
            BtnValidar.Click += BtnValidar_Click;
            // 
            // TxtCorreo
            // 
            TxtCorreo.AllowPromptAsInput = true;
            TxtCorreo.AnimateReadOnly = false;
            TxtCorreo.AsciiOnly = false;
            TxtCorreo.BackgroundImageLayout = ImageLayout.None;
            TxtCorreo.BeepOnError = false;
            TxtCorreo.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            TxtCorreo.Depth = 0;
            TxtCorreo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TxtCorreo.HidePromptOnLeave = false;
            TxtCorreo.HideSelection = true;
            TxtCorreo.InsertKeyMode = InsertKeyMode.Default;
            TxtCorreo.LeadingIcon = null;
            TxtCorreo.Location = new Point(12, 329);
            TxtCorreo.Margin = new Padding(2, 2, 2, 2);
            TxtCorreo.Mask = "";
            TxtCorreo.MaxLength = 32767;
            TxtCorreo.MouseState = MaterialSkin.MouseState.OUT;
            TxtCorreo.Name = "TxtCorreo";
            TxtCorreo.PasswordChar = '\0';
            TxtCorreo.PrefixSuffixText = null;
            TxtCorreo.PromptChar = '_';
            TxtCorreo.ReadOnly = false;
            TxtCorreo.RejectInputOnFirstFailure = false;
            TxtCorreo.ResetOnPrompt = true;
            TxtCorreo.ResetOnSpace = true;
            TxtCorreo.RightToLeft = RightToLeft.No;
            TxtCorreo.SelectedText = "";
            TxtCorreo.SelectionLength = 0;
            TxtCorreo.SelectionStart = 0;
            TxtCorreo.ShortcutsEnabled = true;
            TxtCorreo.Size = new Size(262, 48);
            TxtCorreo.SkipLiterals = true;
            TxtCorreo.TabIndex = 9;
            TxtCorreo.TabStop = false;
            TxtCorreo.TextAlign = HorizontalAlignment.Left;
            TxtCorreo.TextMaskFormat = MaskFormat.IncludeLiterals;
            TxtCorreo.TrailingIcon = null;
            TxtCorreo.UseSystemPasswordChar = false;
            TxtCorreo.ValidatingType = null;
            // 
            // LblCorreo
            // 
            LblCorreo.AutoSize = true;
            LblCorreo.Depth = 0;
            LblCorreo.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            LblCorreo.Location = new Point(12, 304);
            LblCorreo.Margin = new Padding(2, 0, 2, 0);
            LblCorreo.MouseState = MaterialSkin.MouseState.HOVER;
            LblCorreo.Name = "LblCorreo";
            LblCorreo.Size = new Size(129, 19);
            LblCorreo.TabIndex = 8;
            LblCorreo.Text = "Correo Electronico";
            // 
            // TxtDireccion
            // 
            TxtDireccion.AllowPromptAsInput = true;
            TxtDireccion.AnimateReadOnly = false;
            TxtDireccion.AsciiOnly = false;
            TxtDireccion.BackgroundImageLayout = ImageLayout.None;
            TxtDireccion.BeepOnError = false;
            TxtDireccion.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            TxtDireccion.Depth = 0;
            TxtDireccion.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TxtDireccion.HidePromptOnLeave = false;
            TxtDireccion.HideSelection = true;
            TxtDireccion.InsertKeyMode = InsertKeyMode.Default;
            TxtDireccion.LeadingIcon = null;
            TxtDireccion.Location = new Point(12, 245);
            TxtDireccion.Margin = new Padding(2, 2, 2, 2);
            TxtDireccion.Mask = "";
            TxtDireccion.MaxLength = 32767;
            TxtDireccion.MouseState = MaterialSkin.MouseState.OUT;
            TxtDireccion.Name = "TxtDireccion";
            TxtDireccion.PasswordChar = '\0';
            TxtDireccion.PrefixSuffixText = null;
            TxtDireccion.PromptChar = '_';
            TxtDireccion.ReadOnly = false;
            TxtDireccion.RejectInputOnFirstFailure = false;
            TxtDireccion.ResetOnPrompt = true;
            TxtDireccion.ResetOnSpace = true;
            TxtDireccion.RightToLeft = RightToLeft.No;
            TxtDireccion.SelectedText = "";
            TxtDireccion.SelectionLength = 0;
            TxtDireccion.SelectionStart = 0;
            TxtDireccion.ShortcutsEnabled = true;
            TxtDireccion.Size = new Size(262, 48);
            TxtDireccion.SkipLiterals = true;
            TxtDireccion.TabIndex = 7;
            TxtDireccion.TabStop = false;
            TxtDireccion.TextAlign = HorizontalAlignment.Left;
            TxtDireccion.TextMaskFormat = MaskFormat.IncludeLiterals;
            TxtDireccion.TrailingIcon = null;
            TxtDireccion.UseSystemPasswordChar = false;
            TxtDireccion.ValidatingType = null;
            // 
            // LblDireccion
            // 
            LblDireccion.AutoSize = true;
            LblDireccion.Depth = 0;
            LblDireccion.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            LblDireccion.Location = new Point(12, 232);
            LblDireccion.Margin = new Padding(2, 0, 2, 0);
            LblDireccion.MouseState = MaterialSkin.MouseState.HOVER;
            LblDireccion.Name = "LblDireccion";
            LblDireccion.Size = new Size(67, 19);
            LblDireccion.TabIndex = 6;
            LblDireccion.Text = "Direccion";
            // 
            // TxtTelefono
            // 
            TxtTelefono.AllowPromptAsInput = true;
            TxtTelefono.AnimateReadOnly = false;
            TxtTelefono.AsciiOnly = false;
            TxtTelefono.BackgroundImageLayout = ImageLayout.None;
            TxtTelefono.BeepOnError = false;
            TxtTelefono.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            TxtTelefono.Depth = 0;
            TxtTelefono.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TxtTelefono.HidePromptOnLeave = false;
            TxtTelefono.HideSelection = true;
            TxtTelefono.InsertKeyMode = InsertKeyMode.Default;
            TxtTelefono.LeadingIcon = null;
            TxtTelefono.Location = new Point(12, 171);
            TxtTelefono.Margin = new Padding(2, 2, 2, 2);
            TxtTelefono.Mask = "";
            TxtTelefono.MaxLength = 32767;
            TxtTelefono.MouseState = MaterialSkin.MouseState.OUT;
            TxtTelefono.Name = "TxtTelefono";
            TxtTelefono.PasswordChar = '\0';
            TxtTelefono.PrefixSuffixText = null;
            TxtTelefono.PromptChar = '_';
            TxtTelefono.ReadOnly = false;
            TxtTelefono.RejectInputOnFirstFailure = false;
            TxtTelefono.ResetOnPrompt = true;
            TxtTelefono.ResetOnSpace = true;
            TxtTelefono.RightToLeft = RightToLeft.No;
            TxtTelefono.SelectedText = "";
            TxtTelefono.SelectionLength = 0;
            TxtTelefono.SelectionStart = 0;
            TxtTelefono.ShortcutsEnabled = true;
            TxtTelefono.Size = new Size(262, 48);
            TxtTelefono.SkipLiterals = true;
            TxtTelefono.TabIndex = 5;
            TxtTelefono.TabStop = false;
            TxtTelefono.TextAlign = HorizontalAlignment.Left;
            TxtTelefono.TextMaskFormat = MaskFormat.IncludeLiterals;
            TxtTelefono.TrailingIcon = null;
            TxtTelefono.UseSystemPasswordChar = false;
            TxtTelefono.ValidatingType = null;
            // 
            // LblTelefono
            // 
            LblTelefono.AutoSize = true;
            LblTelefono.Depth = 0;
            LblTelefono.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            LblTelefono.Location = new Point(12, 158);
            LblTelefono.Margin = new Padding(2, 0, 2, 0);
            LblTelefono.MouseState = MaterialSkin.MouseState.HOVER;
            LblTelefono.Name = "LblTelefono";
            LblTelefono.Size = new Size(64, 19);
            LblTelefono.TabIndex = 4;
            LblTelefono.Text = "Telefono";
            // 
            // TxtRnc
            // 
            TxtRnc.AllowPromptAsInput = true;
            TxtRnc.AnimateReadOnly = false;
            TxtRnc.AsciiOnly = false;
            TxtRnc.BackgroundImageLayout = ImageLayout.None;
            TxtRnc.BeepOnError = false;
            TxtRnc.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            TxtRnc.Depth = 0;
            TxtRnc.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TxtRnc.HidePromptOnLeave = false;
            TxtRnc.HideSelection = true;
            TxtRnc.InsertKeyMode = InsertKeyMode.Default;
            TxtRnc.LeadingIcon = null;
            TxtRnc.Location = new Point(12, 94);
            TxtRnc.Margin = new Padding(2, 2, 2, 2);
            TxtRnc.Mask = "";
            TxtRnc.MaxLength = 32767;
            TxtRnc.MouseState = MaterialSkin.MouseState.OUT;
            TxtRnc.Name = "TxtRnc";
            TxtRnc.PasswordChar = '\0';
            TxtRnc.PrefixSuffixText = null;
            TxtRnc.PromptChar = '_';
            TxtRnc.ReadOnly = false;
            TxtRnc.RejectInputOnFirstFailure = false;
            TxtRnc.ResetOnPrompt = true;
            TxtRnc.ResetOnSpace = true;
            TxtRnc.RightToLeft = RightToLeft.No;
            TxtRnc.SelectedText = "";
            TxtRnc.SelectionLength = 0;
            TxtRnc.SelectionStart = 0;
            TxtRnc.ShortcutsEnabled = true;
            TxtRnc.Size = new Size(224, 48);
            TxtRnc.SkipLiterals = true;
            TxtRnc.TabIndex = 3;
            TxtRnc.TabStop = false;
            TxtRnc.TextAlign = HorizontalAlignment.Left;
            TxtRnc.TextMaskFormat = MaskFormat.IncludeLiterals;
            TxtRnc.TrailingIcon = null;
            TxtRnc.UseSystemPasswordChar = false;
            TxtRnc.ValidatingType = null;
            TxtRnc.KeyPress += TxtRnc_KeyPress;
            // 
            // LblRnc
            // 
            LblRnc.AutoSize = true;
            LblRnc.Depth = 0;
            LblRnc.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            LblRnc.Location = new Point(12, 80);
            LblRnc.Margin = new Padding(2, 0, 2, 0);
            LblRnc.MouseState = MaterialSkin.MouseState.HOVER;
            LblRnc.Name = "LblRnc";
            LblRnc.Size = new Size(28, 19);
            LblRnc.TabIndex = 2;
            LblRnc.Text = "Rnc";
            // 
            // TxtNombreCompania
            // 
            TxtNombreCompania.AllowPromptAsInput = true;
            TxtNombreCompania.AnimateReadOnly = false;
            TxtNombreCompania.AsciiOnly = false;
            TxtNombreCompania.BackgroundImageLayout = ImageLayout.None;
            TxtNombreCompania.BeepOnError = false;
            TxtNombreCompania.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            TxtNombreCompania.Depth = 0;
            TxtNombreCompania.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TxtNombreCompania.HidePromptOnLeave = false;
            TxtNombreCompania.HideSelection = true;
            TxtNombreCompania.InsertKeyMode = InsertKeyMode.Default;
            TxtNombreCompania.LeadingIcon = null;
            TxtNombreCompania.Location = new Point(12, 22);
            TxtNombreCompania.Margin = new Padding(2, 2, 2, 2);
            TxtNombreCompania.Mask = "";
            TxtNombreCompania.MaxLength = 32767;
            TxtNombreCompania.MouseState = MaterialSkin.MouseState.OUT;
            TxtNombreCompania.Name = "TxtNombreCompania";
            TxtNombreCompania.PasswordChar = '\0';
            TxtNombreCompania.PrefixSuffixText = null;
            TxtNombreCompania.PromptChar = '_';
            TxtNombreCompania.ReadOnly = false;
            TxtNombreCompania.RejectInputOnFirstFailure = false;
            TxtNombreCompania.ResetOnPrompt = true;
            TxtNombreCompania.ResetOnSpace = true;
            TxtNombreCompania.RightToLeft = RightToLeft.No;
            TxtNombreCompania.SelectedText = "";
            TxtNombreCompania.SelectionLength = 0;
            TxtNombreCompania.SelectionStart = 0;
            TxtNombreCompania.ShortcutsEnabled = true;
            TxtNombreCompania.Size = new Size(262, 48);
            TxtNombreCompania.SkipLiterals = true;
            TxtNombreCompania.TabIndex = 1;
            TxtNombreCompania.TabStop = false;
            TxtNombreCompania.TextAlign = HorizontalAlignment.Left;
            TxtNombreCompania.TextMaskFormat = MaskFormat.IncludeLiterals;
            TxtNombreCompania.TrailingIcon = null;
            TxtNombreCompania.UseSystemPasswordChar = false;
            TxtNombreCompania.ValidatingType = null;
            // 
            // lblNombreCompania
            // 
            lblNombreCompania.AutoSize = true;
            lblNombreCompania.Depth = 0;
            lblNombreCompania.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNombreCompania.Location = new Point(12, 8);
            lblNombreCompania.Margin = new Padding(2, 0, 2, 0);
            lblNombreCompania.MouseState = MaterialSkin.MouseState.HOVER;
            lblNombreCompania.Name = "lblNombreCompania";
            lblNombreCompania.Size = new Size(161, 19);
            lblNombreCompania.TabIndex = 0;
            lblNombreCompania.Text = "Nombre de la Empresa";
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Margin = new Padding(2, 2, 2, 2);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1318, 580);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Postulantes";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // cpEmpresa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1330, 648);
            Controls.Add(materialTabControl1);
            DrawerTabControl = materialTabControl1;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "cpEmpresa";
            Padding = new Padding(2, 38, 2, 2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Empresas";
            materialTabControl1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            materialCard2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvEmpresas).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialLabel lblNombreCompania;
        private MaterialSkin.Controls.MaterialLabel LblRnc;
        private MaterialSkin.Controls.MaterialMaskedTextBox TxtRnc;
        private MaterialSkin.Controls.MaterialLabel LblTelefono;
        private MaterialSkin.Controls.MaterialLabel LblCorreo;
        private MaterialSkin.Controls.MaterialMaskedTextBox TxtDireccion;
        private MaterialSkin.Controls.MaterialLabel LblDireccion;
        private MaterialSkin.Controls.MaterialMaskedTextBox TxtTelefono;
        private MaterialSkin.Controls.MaterialButton BtnValidar;
        private MaterialSkin.Controls.MaterialMaskedTextBox TxtCorreo;
        private DataGridView DgvEmpresas;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private MaterialSkin.Controls.MaterialButton BtnActualizar;
        private MaterialSkin.Controls.MaterialButton BtnRegistrar;
        private MaterialSkin.Controls.MaterialMaskedTextBox TxtNombreCompania;
    }
}