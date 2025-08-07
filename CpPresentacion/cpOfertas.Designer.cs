namespace CpPresentacion
{
    partial class cpOfertas
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
            materialCard3 = new MaterialSkin.Controls.MaterialCard();
            BtnOcupada = new MaterialSkin.Controls.MaterialButton();
            BtnEliminar = new MaterialSkin.Controls.MaterialButton();
            BtnMostrar = new MaterialSkin.Controls.MaterialButton();
            BtnRegistrar = new MaterialSkin.Controls.MaterialButton();
            materialCard4 = new MaterialSkin.Controls.MaterialCard();
            cmbArea = new MaterialSkin.Controls.MaterialComboBox();
            lblArea = new MaterialSkin.Controls.MaterialLabel();
            CboxEmpresas = new ComboBox();
            CboxTipoOferta = new ComboBox();
            TxtRequisitos = new MaterialSkin.Controls.MaterialMaskedTextBox();
            lblRequisitos = new MaterialSkin.Controls.MaterialLabel();
            TxtCreditos = new MaterialSkin.Controls.MaterialMaskedTextBox();
            TxtSalario = new MaterialSkin.Controls.MaterialMaskedTextBox();
            TxtDescripcion = new MaterialSkin.Controls.MaterialMaskedTextBox();
            TxtPuesto = new MaterialSkin.Controls.MaterialMaskedTextBox();
            LblCreditos = new MaterialSkin.Controls.MaterialLabel();
            LblSalario = new MaterialSkin.Controls.MaterialLabel();
            LblDescripcion = new MaterialSkin.Controls.MaterialLabel();
            LblPuesto = new MaterialSkin.Controls.MaterialLabel();
            LblTIpoOferta = new MaterialSkin.Controls.MaterialLabel();
            LblNombreCompania = new MaterialSkin.Controls.MaterialLabel();
            DGridOferta = new DataGridView();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            tabPage7 = new TabPage();
            tabPage8 = new TabPage();
            tabPage9 = new TabPage();
            txtFiltro = new MaterialSkin.Controls.MaterialMaskedTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            btnBuscar = new MaterialSkin.Controls.MaterialButton();
            cmbFiltro = new MaterialSkin.Controls.MaterialComboBox();
            materialTabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            materialCard3.SuspendLayout();
            materialCard4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGridOferta).BeginInit();
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
            materialTabControl1.Margin = new Padding(2, 2, 2, 2);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1326, 798);
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
            tabPage2.Controls.Add(materialCard3);
            tabPage2.Controls.Add(materialCard4);
            tabPage2.Controls.Add(DGridOferta);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(2, 2, 2, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2, 2, 2, 2);
            tabPage2.Size = new Size(1318, 770);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ofertas Laborales";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // materialCard3
            // 
            materialCard3.BackColor = Color.FromArgb(255, 255, 255);
            materialCard3.Controls.Add(btnBuscar);
            materialCard3.Controls.Add(BtnOcupada);
            materialCard3.Controls.Add(BtnEliminar);
            materialCard3.Controls.Add(BtnMostrar);
            materialCard3.Controls.Add(BtnRegistrar);
            materialCard3.Depth = 0;
            materialCard3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard3.Location = new Point(323, 377);
            materialCard3.Margin = new Padding(10, 8, 10, 8);
            materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard3.Name = "materialCard3";
            materialCard3.Padding = new Padding(10, 8, 10, 8);
            materialCard3.Size = new Size(985, 103);
            materialCard3.TabIndex = 5;
            // 
            // BtnOcupada
            // 
            BtnOcupada.AutoSize = false;
            BtnOcupada.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnOcupada.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnOcupada.Depth = 0;
            BtnOcupada.HighEmphasis = true;
            BtnOcupada.Icon = null;
            BtnOcupada.Location = new Point(586, 35);
            BtnOcupada.Margin = new Padding(3, 4, 3, 4);
            BtnOcupada.MouseState = MaterialSkin.MouseState.HOVER;
            BtnOcupada.Name = "BtnOcupada";
            BtnOcupada.NoAccentTextColor = Color.Empty;
            BtnOcupada.Size = new Size(166, 32);
            BtnOcupada.TabIndex = 3;
            BtnOcupada.Text = "Marcar como Ocupada";
            BtnOcupada.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            BtnOcupada.UseAccentColor = false;
            BtnOcupada.UseVisualStyleBackColor = true;
            BtnOcupada.Click += BtnOcupada_Click;
            // 
            // BtnEliminar
            // 
            BtnEliminar.AutoSize = false;
            BtnEliminar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnEliminar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnEliminar.Depth = 0;
            BtnEliminar.HighEmphasis = true;
            BtnEliminar.Icon = null;
            BtnEliminar.Location = new Point(392, 35);
            BtnEliminar.Margin = new Padding(3, 4, 3, 4);
            BtnEliminar.MouseState = MaterialSkin.MouseState.HOVER;
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.NoAccentTextColor = Color.Empty;
            BtnEliminar.Size = new Size(166, 32);
            BtnEliminar.TabIndex = 2;
            BtnEliminar.Text = "Eliminar";
            BtnEliminar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            BtnEliminar.UseAccentColor = false;
            BtnEliminar.UseVisualStyleBackColor = true;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // BtnMostrar
            // 
            BtnMostrar.AutoSize = false;
            BtnMostrar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnMostrar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnMostrar.Depth = 0;
            BtnMostrar.HighEmphasis = true;
            BtnMostrar.Icon = null;
            BtnMostrar.Location = new Point(205, 35);
            BtnMostrar.Margin = new Padding(3, 4, 3, 4);
            BtnMostrar.MouseState = MaterialSkin.MouseState.HOVER;
            BtnMostrar.Name = "BtnMostrar";
            BtnMostrar.NoAccentTextColor = Color.Empty;
            BtnMostrar.Size = new Size(166, 32);
            BtnMostrar.TabIndex = 1;
            BtnMostrar.Text = "Mostrar";
            BtnMostrar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            BtnMostrar.UseAccentColor = false;
            BtnMostrar.UseVisualStyleBackColor = true;
            BtnMostrar.Click += BtnMostrar_Click;
            // 
            // BtnRegistrar
            // 
            BtnRegistrar.AutoSize = false;
            BtnRegistrar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnRegistrar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnRegistrar.Depth = 0;
            BtnRegistrar.HighEmphasis = true;
            BtnRegistrar.Icon = null;
            BtnRegistrar.Location = new Point(13, 35);
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
            // materialCard4
            // 
            materialCard4.BackColor = Color.FromArgb(255, 255, 255);
            materialCard4.Controls.Add(txtFiltro);
            materialCard4.Controls.Add(cmbFiltro);
            materialCard4.Controls.Add(materialLabel1);
            materialCard4.Controls.Add(cmbArea);
            materialCard4.Controls.Add(lblArea);
            materialCard4.Controls.Add(CboxEmpresas);
            materialCard4.Controls.Add(CboxTipoOferta);
            materialCard4.Controls.Add(TxtRequisitos);
            materialCard4.Controls.Add(lblRequisitos);
            materialCard4.Controls.Add(TxtCreditos);
            materialCard4.Controls.Add(TxtSalario);
            materialCard4.Controls.Add(TxtDescripcion);
            materialCard4.Controls.Add(TxtPuesto);
            materialCard4.Controls.Add(LblCreditos);
            materialCard4.Controls.Add(LblSalario);
            materialCard4.Controls.Add(LblDescripcion);
            materialCard4.Controls.Add(LblPuesto);
            materialCard4.Controls.Add(LblTIpoOferta);
            materialCard4.Controls.Add(LblNombreCompania);
            materialCard4.Depth = 0;
            materialCard4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard4.Location = new Point(18, 16);
            materialCard4.Margin = new Padding(10, 8, 10, 8);
            materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard4.Name = "materialCard4";
            materialCard4.Padding = new Padding(10, 8, 10, 8);
            materialCard4.Size = new Size(294, 712);
            materialCard4.TabIndex = 4;
            // 
            // cmbArea
            // 
            cmbArea.AutoResize = false;
            cmbArea.BackColor = Color.FromArgb(255, 255, 255);
            cmbArea.Depth = 0;
            cmbArea.DrawMode = DrawMode.OwnerDrawVariable;
            cmbArea.DropDownHeight = 174;
            cmbArea.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbArea.DropDownWidth = 121;
            cmbArea.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbArea.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbArea.FormattingEnabled = true;
            cmbArea.IntegralHeight = false;
            cmbArea.ItemHeight = 43;
            cmbArea.Location = new Point(12, 148);
            cmbArea.Margin = new Padding(2, 2, 2, 2);
            cmbArea.MaxDropDownItems = 4;
            cmbArea.MouseState = MaterialSkin.MouseState.OUT;
            cmbArea.Name = "cmbArea";
            cmbArea.Size = new Size(264, 49);
            cmbArea.StartIndex = 0;
            cmbArea.TabIndex = 17;
            // 
            // lblArea
            // 
            lblArea.AutoSize = true;
            lblArea.Depth = 0;
            lblArea.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblArea.Location = new Point(12, 127);
            lblArea.Margin = new Padding(2, 0, 2, 0);
            lblArea.MouseState = MaterialSkin.MouseState.HOVER;
            lblArea.Name = "lblArea";
            lblArea.Size = new Size(33, 19);
            lblArea.TabIndex = 16;
            lblArea.Text = "Area";
            // 
            // CboxEmpresas
            // 
            CboxEmpresas.DropDownStyle = ComboBoxStyle.DropDownList;
            CboxEmpresas.FormattingEnabled = true;
            CboxEmpresas.Location = new Point(12, 26);
            CboxEmpresas.Margin = new Padding(2, 2, 2, 2);
            CboxEmpresas.Name = "CboxEmpresas";
            CboxEmpresas.Size = new Size(129, 23);
            CboxEmpresas.TabIndex = 15;
            // 
            // CboxTipoOferta
            // 
            CboxTipoOferta.DropDownStyle = ComboBoxStyle.DropDownList;
            CboxTipoOferta.FormattingEnabled = true;
            CboxTipoOferta.Items.AddRange(new object[] { "Oferta", "Empleo Fijo", "Pasantia" });
            CboxTipoOferta.Location = new Point(12, 91);
            CboxTipoOferta.Margin = new Padding(2, 2, 2, 2);
            CboxTipoOferta.Name = "CboxTipoOferta";
            CboxTipoOferta.Size = new Size(129, 23);
            CboxTipoOferta.TabIndex = 14;
            CboxTipoOferta.SelectedIndexChanged += CboxTipoOferta_SelectedIndexChanged;
            // 
            // TxtRequisitos
            // 
            TxtRequisitos.AllowPromptAsInput = true;
            TxtRequisitos.AnimateReadOnly = false;
            TxtRequisitos.AsciiOnly = false;
            TxtRequisitos.BackgroundImageLayout = ImageLayout.None;
            TxtRequisitos.BeepOnError = false;
            TxtRequisitos.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            TxtRequisitos.Depth = 0;
            TxtRequisitos.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TxtRequisitos.HidePromptOnLeave = false;
            TxtRequisitos.HideSelection = true;
            TxtRequisitos.InsertKeyMode = InsertKeyMode.Default;
            TxtRequisitos.LeadingIcon = null;
            TxtRequisitos.Location = new Point(12, 368);
            TxtRequisitos.Margin = new Padding(2, 2, 2, 2);
            TxtRequisitos.Mask = "";
            TxtRequisitos.MaxLength = 32767;
            TxtRequisitos.MouseState = MaterialSkin.MouseState.OUT;
            TxtRequisitos.Name = "TxtRequisitos";
            TxtRequisitos.PasswordChar = '\0';
            TxtRequisitos.PrefixSuffixText = null;
            TxtRequisitos.PromptChar = '_';
            TxtRequisitos.ReadOnly = false;
            TxtRequisitos.RejectInputOnFirstFailure = false;
            TxtRequisitos.ResetOnPrompt = true;
            TxtRequisitos.ResetOnSpace = true;
            TxtRequisitos.RightToLeft = RightToLeft.No;
            TxtRequisitos.SelectedText = "";
            TxtRequisitos.SelectionLength = 0;
            TxtRequisitos.SelectionStart = 0;
            TxtRequisitos.ShortcutsEnabled = true;
            TxtRequisitos.Size = new Size(262, 48);
            TxtRequisitos.SkipLiterals = true;
            TxtRequisitos.TabIndex = 13;
            TxtRequisitos.TabStop = false;
            TxtRequisitos.TextAlign = HorizontalAlignment.Left;
            TxtRequisitos.TextMaskFormat = MaskFormat.IncludeLiterals;
            TxtRequisitos.TrailingIcon = null;
            TxtRequisitos.UseSystemPasswordChar = false;
            TxtRequisitos.ValidatingType = null;
            // 
            // lblRequisitos
            // 
            lblRequisitos.AutoSize = true;
            lblRequisitos.Depth = 0;
            lblRequisitos.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblRequisitos.Location = new Point(12, 346);
            lblRequisitos.Margin = new Padding(2, 0, 2, 0);
            lblRequisitos.MouseState = MaterialSkin.MouseState.HOVER;
            lblRequisitos.Name = "lblRequisitos";
            lblRequisitos.Size = new Size(75, 19);
            lblRequisitos.TabIndex = 12;
            lblRequisitos.Text = "Requisitos";
            // 
            // TxtCreditos
            // 
            TxtCreditos.AllowPromptAsInput = true;
            TxtCreditos.AnimateReadOnly = false;
            TxtCreditos.AsciiOnly = false;
            TxtCreditos.BackgroundImageLayout = ImageLayout.None;
            TxtCreditos.BeepOnError = false;
            TxtCreditos.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            TxtCreditos.Depth = 0;
            TxtCreditos.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TxtCreditos.HidePromptOnLeave = false;
            TxtCreditos.HideSelection = true;
            TxtCreditos.InsertKeyMode = InsertKeyMode.Default;
            TxtCreditos.LeadingIcon = null;
            TxtCreditos.Location = new Point(14, 510);
            TxtCreditos.Margin = new Padding(2, 2, 2, 2);
            TxtCreditos.Mask = "";
            TxtCreditos.MaxLength = 32767;
            TxtCreditos.MouseState = MaterialSkin.MouseState.OUT;
            TxtCreditos.Name = "TxtCreditos";
            TxtCreditos.PasswordChar = '\0';
            TxtCreditos.PrefixSuffixText = null;
            TxtCreditos.PromptChar = '_';
            TxtCreditos.ReadOnly = false;
            TxtCreditos.RejectInputOnFirstFailure = false;
            TxtCreditos.ResetOnPrompt = true;
            TxtCreditos.ResetOnSpace = true;
            TxtCreditos.RightToLeft = RightToLeft.No;
            TxtCreditos.SelectedText = "";
            TxtCreditos.SelectionLength = 0;
            TxtCreditos.SelectionStart = 0;
            TxtCreditos.ShortcutsEnabled = true;
            TxtCreditos.Size = new Size(262, 48);
            TxtCreditos.SkipLiterals = true;
            TxtCreditos.TabIndex = 10;
            TxtCreditos.TabStop = false;
            TxtCreditos.TextAlign = HorizontalAlignment.Left;
            TxtCreditos.TextMaskFormat = MaskFormat.IncludeLiterals;
            TxtCreditos.TrailingIcon = null;
            TxtCreditos.UseSystemPasswordChar = false;
            TxtCreditos.ValidatingType = null;
            TxtCreditos.KeyPress += TxtCreditos_KeyPress;
            // 
            // TxtSalario
            // 
            TxtSalario.AllowPromptAsInput = true;
            TxtSalario.AnimateReadOnly = false;
            TxtSalario.AsciiOnly = false;
            TxtSalario.BackgroundImageLayout = ImageLayout.None;
            TxtSalario.BeepOnError = false;
            TxtSalario.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            TxtSalario.Depth = 0;
            TxtSalario.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TxtSalario.HidePromptOnLeave = false;
            TxtSalario.HideSelection = true;
            TxtSalario.InsertKeyMode = InsertKeyMode.Default;
            TxtSalario.LeadingIcon = null;
            TxtSalario.Location = new Point(12, 435);
            TxtSalario.Margin = new Padding(2, 2, 2, 2);
            TxtSalario.Mask = "";
            TxtSalario.MaxLength = 32767;
            TxtSalario.MouseState = MaterialSkin.MouseState.OUT;
            TxtSalario.Name = "TxtSalario";
            TxtSalario.PasswordChar = '\0';
            TxtSalario.PrefixSuffixText = null;
            TxtSalario.PromptChar = '_';
            TxtSalario.ReadOnly = false;
            TxtSalario.RejectInputOnFirstFailure = false;
            TxtSalario.ResetOnPrompt = true;
            TxtSalario.ResetOnSpace = true;
            TxtSalario.RightToLeft = RightToLeft.No;
            TxtSalario.SelectedText = "";
            TxtSalario.SelectionLength = 0;
            TxtSalario.SelectionStart = 0;
            TxtSalario.ShortcutsEnabled = true;
            TxtSalario.Size = new Size(262, 48);
            TxtSalario.SkipLiterals = true;
            TxtSalario.TabIndex = 9;
            TxtSalario.TabStop = false;
            TxtSalario.TextAlign = HorizontalAlignment.Left;
            TxtSalario.TextMaskFormat = MaskFormat.IncludeLiterals;
            TxtSalario.TrailingIcon = null;
            TxtSalario.UseSystemPasswordChar = false;
            TxtSalario.ValidatingType = null;
            TxtSalario.KeyPress += TxtSalario_KeyPress;
            // 
            // TxtDescripcion
            // 
            TxtDescripcion.AllowPromptAsInput = true;
            TxtDescripcion.AnimateReadOnly = false;
            TxtDescripcion.AsciiOnly = false;
            TxtDescripcion.BackgroundImageLayout = ImageLayout.None;
            TxtDescripcion.BeepOnError = false;
            TxtDescripcion.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            TxtDescripcion.Depth = 0;
            TxtDescripcion.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TxtDescripcion.HidePromptOnLeave = false;
            TxtDescripcion.HideSelection = true;
            TxtDescripcion.InsertKeyMode = InsertKeyMode.Default;
            TxtDescripcion.LeadingIcon = null;
            TxtDescripcion.Location = new Point(12, 298);
            TxtDescripcion.Margin = new Padding(2, 2, 2, 2);
            TxtDescripcion.Mask = "";
            TxtDescripcion.MaxLength = 32767;
            TxtDescripcion.MouseState = MaterialSkin.MouseState.OUT;
            TxtDescripcion.Name = "TxtDescripcion";
            TxtDescripcion.PasswordChar = '\0';
            TxtDescripcion.PrefixSuffixText = null;
            TxtDescripcion.PromptChar = '_';
            TxtDescripcion.ReadOnly = false;
            TxtDescripcion.RejectInputOnFirstFailure = false;
            TxtDescripcion.ResetOnPrompt = true;
            TxtDescripcion.ResetOnSpace = true;
            TxtDescripcion.RightToLeft = RightToLeft.No;
            TxtDescripcion.SelectedText = "";
            TxtDescripcion.SelectionLength = 0;
            TxtDescripcion.SelectionStart = 0;
            TxtDescripcion.ShortcutsEnabled = true;
            TxtDescripcion.Size = new Size(262, 48);
            TxtDescripcion.SkipLiterals = true;
            TxtDescripcion.TabIndex = 8;
            TxtDescripcion.TabStop = false;
            TxtDescripcion.TextAlign = HorizontalAlignment.Left;
            TxtDescripcion.TextMaskFormat = MaskFormat.IncludeLiterals;
            TxtDescripcion.TrailingIcon = null;
            TxtDescripcion.UseSystemPasswordChar = false;
            TxtDescripcion.ValidatingType = null;
            // 
            // TxtPuesto
            // 
            TxtPuesto.AllowPromptAsInput = true;
            TxtPuesto.AnimateReadOnly = false;
            TxtPuesto.AsciiOnly = false;
            TxtPuesto.BackgroundImageLayout = ImageLayout.None;
            TxtPuesto.BeepOnError = false;
            TxtPuesto.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            TxtPuesto.Depth = 0;
            TxtPuesto.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TxtPuesto.HidePromptOnLeave = false;
            TxtPuesto.HideSelection = true;
            TxtPuesto.InsertKeyMode = InsertKeyMode.Default;
            TxtPuesto.LeadingIcon = null;
            TxtPuesto.Location = new Point(12, 222);
            TxtPuesto.Margin = new Padding(2, 2, 2, 2);
            TxtPuesto.Mask = "";
            TxtPuesto.MaxLength = 32767;
            TxtPuesto.MouseState = MaterialSkin.MouseState.OUT;
            TxtPuesto.Name = "TxtPuesto";
            TxtPuesto.PasswordChar = '\0';
            TxtPuesto.PrefixSuffixText = null;
            TxtPuesto.PromptChar = '_';
            TxtPuesto.ReadOnly = false;
            TxtPuesto.RejectInputOnFirstFailure = false;
            TxtPuesto.ResetOnPrompt = true;
            TxtPuesto.ResetOnSpace = true;
            TxtPuesto.RightToLeft = RightToLeft.No;
            TxtPuesto.SelectedText = "";
            TxtPuesto.SelectionLength = 0;
            TxtPuesto.SelectionStart = 0;
            TxtPuesto.ShortcutsEnabled = true;
            TxtPuesto.Size = new Size(262, 48);
            TxtPuesto.SkipLiterals = true;
            TxtPuesto.TabIndex = 7;
            TxtPuesto.TabStop = false;
            TxtPuesto.TextAlign = HorizontalAlignment.Left;
            TxtPuesto.TextMaskFormat = MaskFormat.IncludeLiterals;
            TxtPuesto.TrailingIcon = null;
            TxtPuesto.UseSystemPasswordChar = false;
            TxtPuesto.ValidatingType = null;
            // 
            // LblCreditos
            // 
            LblCreditos.AutoSize = true;
            LblCreditos.Depth = 0;
            LblCreditos.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            LblCreditos.Location = new Point(12, 485);
            LblCreditos.Margin = new Padding(2, 0, 2, 0);
            LblCreditos.MouseState = MaterialSkin.MouseState.HOVER;
            LblCreditos.Name = "LblCreditos";
            LblCreditos.Size = new Size(59, 19);
            LblCreditos.TabIndex = 6;
            LblCreditos.Text = "Creditos";
            // 
            // LblSalario
            // 
            LblSalario.AutoSize = true;
            LblSalario.Depth = 0;
            LblSalario.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            LblSalario.Location = new Point(14, 414);
            LblSalario.Margin = new Padding(2, 0, 2, 0);
            LblSalario.MouseState = MaterialSkin.MouseState.HOVER;
            LblSalario.Name = "LblSalario";
            LblSalario.Size = new Size(51, 19);
            LblSalario.TabIndex = 5;
            LblSalario.Text = "Salario";
            // 
            // LblDescripcion
            // 
            LblDescripcion.AutoSize = true;
            LblDescripcion.Depth = 0;
            LblDescripcion.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            LblDescripcion.Location = new Point(12, 277);
            LblDescripcion.Margin = new Padding(2, 0, 2, 0);
            LblDescripcion.MouseState = MaterialSkin.MouseState.HOVER;
            LblDescripcion.Name = "LblDescripcion";
            LblDescripcion.Size = new Size(84, 19);
            LblDescripcion.TabIndex = 4;
            LblDescripcion.Text = "Descripcion";
            // 
            // LblPuesto
            // 
            LblPuesto.AutoSize = true;
            LblPuesto.Depth = 0;
            LblPuesto.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            LblPuesto.Location = new Point(12, 201);
            LblPuesto.Margin = new Padding(2, 0, 2, 0);
            LblPuesto.MouseState = MaterialSkin.MouseState.HOVER;
            LblPuesto.Name = "LblPuesto";
            LblPuesto.Size = new Size(50, 19);
            LblPuesto.TabIndex = 3;
            LblPuesto.Text = "Puesto";
            // 
            // LblTIpoOferta
            // 
            LblTIpoOferta.AutoSize = true;
            LblTIpoOferta.Depth = 0;
            LblTIpoOferta.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            LblTIpoOferta.Location = new Point(12, 66);
            LblTIpoOferta.Margin = new Padding(2, 0, 2, 0);
            LblTIpoOferta.MouseState = MaterialSkin.MouseState.HOVER;
            LblTIpoOferta.Name = "LblTIpoOferta";
            LblTIpoOferta.Size = new Size(102, 19);
            LblTIpoOferta.TabIndex = 2;
            LblTIpoOferta.Text = "Tipo de Oferta";
            // 
            // LblNombreCompania
            // 
            LblNombreCompania.AutoSize = true;
            LblNombreCompania.Depth = 0;
            LblNombreCompania.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            LblNombreCompania.Location = new Point(12, 4);
            LblNombreCompania.Margin = new Padding(2, 0, 2, 0);
            LblNombreCompania.MouseState = MaterialSkin.MouseState.HOVER;
            LblNombreCompania.Name = "LblNombreCompania";
            LblNombreCompania.Size = new Size(155, 19);
            LblNombreCompania.TabIndex = 0;
            LblNombreCompania.Text = "Nombre de Compañia";
            // 
            // DGridOferta
            // 
            DGridOferta.AllowUserToAddRows = false;
            DGridOferta.AllowUserToDeleteRows = false;
            DGridOferta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGridOferta.Location = new Point(323, 16);
            DGridOferta.Margin = new Padding(2, 2, 2, 2);
            DGridOferta.MultiSelect = false;
            DGridOferta.Name = "DGridOferta";
            DGridOferta.ReadOnly = true;
            DGridOferta.RowHeadersWidth = 62;
            DGridOferta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGridOferta.Size = new Size(980, 313);
            DGridOferta.TabIndex = 3;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(2, 2, 2, 2);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1318, 580);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Empresas";
            tabPage3.UseVisualStyleBackColor = true;
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
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 24);
            tabPage5.Margin = new Padding(2, 2, 2, 2);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1318, 580);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Asignar Oferta";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Location = new Point(4, 24);
            tabPage6.Margin = new Padding(2, 2, 2, 2);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(1318, 580);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Historial Correos";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            tabPage7.Location = new Point(4, 24);
            tabPage7.Margin = new Padding(2, 2, 2, 2);
            tabPage7.Name = "tabPage7";
            tabPage7.Size = new Size(1318, 580);
            tabPage7.TabIndex = 6;
            tabPage7.Text = "Carnet";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            tabPage8.Location = new Point(4, 24);
            tabPage8.Margin = new Padding(2, 2, 2, 2);
            tabPage8.Name = "tabPage8";
            tabPage8.Size = new Size(1318, 580);
            tabPage8.TabIndex = 7;
            tabPage8.Text = "Registro Interno";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            tabPage9.Location = new Point(4, 24);
            tabPage9.Margin = new Padding(2, 2, 2, 2);
            tabPage9.Name = "tabPage9";
            tabPage9.Size = new Size(1318, 580);
            tabPage9.TabIndex = 8;
            tabPage9.Text = "Historial Postulaciones";
            tabPage9.UseVisualStyleBackColor = true;
            // 
            // txtFiltro
            // 
            txtFiltro.AllowPromptAsInput = true;
            txtFiltro.AnimateReadOnly = false;
            txtFiltro.AsciiOnly = false;
            txtFiltro.BackgroundImageLayout = ImageLayout.None;
            txtFiltro.BeepOnError = false;
            txtFiltro.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtFiltro.Depth = 0;
            txtFiltro.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtFiltro.HidePromptOnLeave = false;
            txtFiltro.HideSelection = true;
            txtFiltro.InsertKeyMode = InsertKeyMode.Default;
            txtFiltro.LeadingIcon = null;
            txtFiltro.Location = new Point(12, 654);
            txtFiltro.Margin = new Padding(2);
            txtFiltro.Mask = "";
            txtFiltro.MaxLength = 32767;
            txtFiltro.MouseState = MaterialSkin.MouseState.OUT;
            txtFiltro.Name = "txtFiltro";
            txtFiltro.PasswordChar = '\0';
            txtFiltro.PrefixSuffixText = null;
            txtFiltro.PromptChar = '_';
            txtFiltro.ReadOnly = false;
            txtFiltro.RejectInputOnFirstFailure = false;
            txtFiltro.ResetOnPrompt = true;
            txtFiltro.ResetOnSpace = true;
            txtFiltro.RightToLeft = RightToLeft.No;
            txtFiltro.SelectedText = "";
            txtFiltro.SelectionLength = 0;
            txtFiltro.SelectionStart = 0;
            txtFiltro.ShortcutsEnabled = true;
            txtFiltro.Size = new Size(262, 48);
            txtFiltro.SkipLiterals = true;
            txtFiltro.TabIndex = 18;
            txtFiltro.TabStop = false;
            txtFiltro.TextAlign = HorizontalAlignment.Left;
            txtFiltro.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtFiltro.TrailingIcon = null;
            txtFiltro.UseSystemPasswordChar = false;
            txtFiltro.ValidatingType = null;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(14, 564);
            materialLabel1.Margin = new Padding(2, 0, 2, 0);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(72, 19);
            materialLabel1.TabIndex = 19;
            materialLabel1.Text = "Busqueda";
            // 
            // btnBuscar
            // 
            btnBuscar.AutoSize = false;
            btnBuscar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBuscar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBuscar.Depth = 0;
            btnBuscar.HighEmphasis = true;
            btnBuscar.Icon = null;
            btnBuscar.Location = new Point(791, 35);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            btnBuscar.Name = "btnBuscar";
            btnBuscar.NoAccentTextColor = Color.Empty;
            btnBuscar.Size = new Size(166, 32);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "Buscar";
            btnBuscar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBuscar.UseAccentColor = false;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // cmbFiltro
            // 
            cmbFiltro.AutoResize = false;
            cmbFiltro.BackColor = Color.FromArgb(255, 255, 255);
            cmbFiltro.Depth = 0;
            cmbFiltro.DrawMode = DrawMode.OwnerDrawVariable;
            cmbFiltro.DropDownHeight = 174;
            cmbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltro.DropDownWidth = 121;
            cmbFiltro.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbFiltro.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbFiltro.FormattingEnabled = true;
            cmbFiltro.IntegralHeight = false;
            cmbFiltro.ItemHeight = 43;
            cmbFiltro.Location = new Point(14, 585);
            cmbFiltro.Margin = new Padding(3, 2, 3, 2);
            cmbFiltro.MaxDropDownItems = 4;
            cmbFiltro.MouseState = MaterialSkin.MouseState.OUT;
            cmbFiltro.Name = "cmbFiltro";
            cmbFiltro.Size = new Size(153, 49);
            cmbFiltro.StartIndex = 0;
            cmbFiltro.TabIndex = 16;
            // 
            // cpOfertas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1330, 838);
            Controls.Add(materialTabControl1);
            DrawerTabControl = materialTabControl1;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "cpOfertas";
            Padding = new Padding(2, 38, 2, 2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ofertas Laborales";
            materialTabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            materialCard3.ResumeLayout(false);
            materialCard4.ResumeLayout(false);
            materialCard4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGridOferta).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private MaterialSkin.Controls.MaterialCard materialCard3;
        private MaterialSkin.Controls.MaterialCard materialCard4;
        private MaterialSkin.Controls.MaterialMaskedTextBox TxtRequisitos;
        private MaterialSkin.Controls.MaterialLabel lblRequisitos;
        private MaterialSkin.Controls.MaterialMaskedTextBox TxtCreditos;
        private MaterialSkin.Controls.MaterialMaskedTextBox TxtSalario;
        private MaterialSkin.Controls.MaterialMaskedTextBox TxtDescripcion;
        private MaterialSkin.Controls.MaterialMaskedTextBox TxtPuesto;
        private MaterialSkin.Controls.MaterialLabel LblCreditos;
        private MaterialSkin.Controls.MaterialLabel LblSalario;
        private MaterialSkin.Controls.MaterialLabel LblDescripcion;
        private MaterialSkin.Controls.MaterialLabel LblPuesto;
        private MaterialSkin.Controls.MaterialLabel LblTIpoOferta;
        private MaterialSkin.Controls.MaterialLabel LblNombreCompania;
        private DataGridView DGridOferta;
        private MaterialSkin.Controls.MaterialButton BtnEliminar;
        private MaterialSkin.Controls.MaterialButton BtnMostrar;
        private MaterialSkin.Controls.MaterialButton BtnRegistrar;
        private ComboBox CboxTipoOferta;
        private ComboBox CboxEmpresas;
        private MaterialSkin.Controls.MaterialButton BtnOcupada;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private MaterialSkin.Controls.MaterialComboBox cmbArea;
        private MaterialSkin.Controls.MaterialLabel lblArea;
        private TabPage tabPage9;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtFiltro;
        private MaterialSkin.Controls.MaterialButton btnBuscar;
        private MaterialSkin.Controls.MaterialComboBox cmbFiltro;
    }
}