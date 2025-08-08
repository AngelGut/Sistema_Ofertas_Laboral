namespace CpPresentacion
{
    partial class cpHistorialMensajes
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
            DgvPersonas = new DataGridView();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            BtnActualizar = new MaterialSkin.Controls.MaterialButton();
            BtnRegistrar = new MaterialSkin.Controls.MaterialButton();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            CboxOfertas = new ComboBox();
            LblSelecOferta = new MaterialSkin.Controls.MaterialLabel();
            LblDireccion = new Label();
            TxtDireccion = new MaterialSkin.Controls.MaterialMaskedTextBox();
            TxtCorreo = new MaterialSkin.Controls.MaterialMaskedTextBox();
            BtnValidar = new MaterialSkin.Controls.MaterialButton();
            LblCorreo = new MaterialSkin.Controls.MaterialLabel();
            TxtTelefono = new MaterialSkin.Controls.MaterialMaskedTextBox();
            LblTelefono = new MaterialSkin.Controls.MaterialLabel();
            TxtDni = new MaterialSkin.Controls.MaterialMaskedTextBox();
            LblDni = new MaterialSkin.Controls.MaterialLabel();
            TxtNombre = new MaterialSkin.Controls.MaterialMaskedTextBox();
            LblNombrePersona = new MaterialSkin.Controls.MaterialLabel();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            lblDetalles = new Label();
            txtResumenCorreo = new TextBox();
            dgvHistorial = new DataGridView();
            materialCard4 = new MaterialSkin.Controls.MaterialCard();
            txtBuscar = new TextBox();
            mbtnLimpiar = new MaterialSkin.Controls.MaterialButton();
            mbtnBuscar = new MaterialSkin.Controls.MaterialButton();
            label2 = new Label();
            tabPage7 = new TabPage();
            tabPage8 = new TabPage();
            tabPage9 = new TabPage();
            materialTabControl1.SuspendLayout();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvPersonas).BeginInit();
            materialCard2.SuspendLayout();
            materialCard1.SuspendLayout();
            tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            materialCard4.SuspendLayout();
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
            materialTabControl1.Location = new Point(3, 48);
            materialTabControl1.Margin = new Padding(2);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(816, 672);
            materialTabControl1.TabIndex = 1;
            materialTabControl1.SelectedIndexChanged += materialTabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2);
            tabPage1.Size = new Size(808, 644);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Menu";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2);
            tabPage2.Size = new Size(808, 644);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ofertas Laborales";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(2);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(808, 644);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Empresas";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(DgvPersonas);
            tabPage4.Controls.Add(materialCard2);
            tabPage4.Controls.Add(materialCard1);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Margin = new Padding(2);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(808, 644);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Postulantes";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // DgvPersonas
            // 
            DgvPersonas.AllowUserToAddRows = false;
            DgvPersonas.AllowUserToDeleteRows = false;
            DgvPersonas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvPersonas.Location = new Point(411, 8);
            DgvPersonas.Margin = new Padding(2);
            DgvPersonas.MultiSelect = false;
            DgvPersonas.Name = "DgvPersonas";
            DgvPersonas.ReadOnly = true;
            DgvPersonas.RowHeadersWidth = 62;
            DgvPersonas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvPersonas.Size = new Size(874, 305);
            DgvPersonas.TabIndex = 11;
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(BtnActualizar);
            materialCard2.Controls.Add(BtnRegistrar);
            materialCard2.Depth = 0;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(582, 374);
            materialCard2.Margin = new Padding(10, 8, 10, 8);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(10, 8, 10, 8);
            materialCard2.Size = new Size(457, 56);
            materialCard2.TabIndex = 10;
            // 
            // BtnActualizar
            // 
            BtnActualizar.AutoSize = false;
            BtnActualizar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnActualizar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnActualizar.Depth = 0;
            BtnActualizar.HighEmphasis = true;
            BtnActualizar.Icon = null;
            BtnActualizar.Location = new Point(278, 12);
            BtnActualizar.Margin = new Padding(3, 4, 3, 4);
            BtnActualizar.MouseState = MaterialSkin.MouseState.HOVER;
            BtnActualizar.Name = "BtnActualizar";
            BtnActualizar.NoAccentTextColor = Color.Empty;
            BtnActualizar.Size = new Size(166, 32);
            BtnActualizar.TabIndex = 9;
            BtnActualizar.Text = "Actualizar";
            BtnActualizar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            BtnActualizar.UseAccentColor = false;
            BtnActualizar.UseVisualStyleBackColor = true;
            // 
            // BtnRegistrar
            // 
            BtnRegistrar.AutoSize = false;
            BtnRegistrar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnRegistrar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnRegistrar.Depth = 0;
            BtnRegistrar.HighEmphasis = true;
            BtnRegistrar.Icon = null;
            BtnRegistrar.Location = new Point(12, 12);
            BtnRegistrar.Margin = new Padding(3, 4, 3, 4);
            BtnRegistrar.MouseState = MaterialSkin.MouseState.HOVER;
            BtnRegistrar.Name = "BtnRegistrar";
            BtnRegistrar.NoAccentTextColor = Color.Empty;
            BtnRegistrar.Size = new Size(166, 32);
            BtnRegistrar.TabIndex = 8;
            BtnRegistrar.Text = "Registrar";
            BtnRegistrar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            BtnRegistrar.UseAccentColor = false;
            BtnRegistrar.UseVisualStyleBackColor = true;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(CboxOfertas);
            materialCard1.Controls.Add(LblSelecOferta);
            materialCard1.Controls.Add(LblDireccion);
            materialCard1.Controls.Add(TxtDireccion);
            materialCard1.Controls.Add(TxtCorreo);
            materialCard1.Controls.Add(BtnValidar);
            materialCard1.Controls.Add(LblCorreo);
            materialCard1.Controls.Add(TxtTelefono);
            materialCard1.Controls.Add(LblTelefono);
            materialCard1.Controls.Add(TxtDni);
            materialCard1.Controls.Add(LblDni);
            materialCard1.Controls.Add(TxtNombre);
            materialCard1.Controls.Add(LblNombrePersona);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(10, 8);
            materialCard1.Margin = new Padding(10, 8, 10, 8);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(10, 8, 10, 8);
            materialCard1.Size = new Size(370, 523);
            materialCard1.TabIndex = 1;
            // 
            // CboxOfertas
            // 
            CboxOfertas.DropDownStyle = ComboBoxStyle.DropDownList;
            CboxOfertas.FormattingEnabled = true;
            CboxOfertas.Location = new Point(12, 365);
            CboxOfertas.Margin = new Padding(2);
            CboxOfertas.Name = "CboxOfertas";
            CboxOfertas.Size = new Size(128, 23);
            CboxOfertas.TabIndex = 11;
            // 
            // LblSelecOferta
            // 
            LblSelecOferta.AutoSize = true;
            LblSelecOferta.Depth = 0;
            LblSelecOferta.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            LblSelecOferta.Location = new Point(10, 347);
            LblSelecOferta.Margin = new Padding(2, 0, 2, 0);
            LblSelecOferta.MouseState = MaterialSkin.MouseState.HOVER;
            LblSelecOferta.Name = "LblSelecOferta";
            LblSelecOferta.Size = new Size(201, 19);
            LblSelecOferta.TabIndex = 10;
            LblSelecOferta.Text = "Selecciona la Oferta Laboral";
            // 
            // LblDireccion
            // 
            LblDireccion.AutoSize = true;
            LblDireccion.Location = new Point(10, 259);
            LblDireccion.Margin = new Padding(2, 0, 2, 0);
            LblDireccion.Name = "LblDireccion";
            LblDireccion.Size = new Size(57, 15);
            LblDireccion.TabIndex = 9;
            LblDireccion.Text = "Direccion";
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
            TxtDireccion.Location = new Point(12, 292);
            TxtDireccion.Margin = new Padding(2);
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
            TxtDireccion.TabIndex = 8;
            TxtDireccion.TabStop = false;
            TxtDireccion.TextAlign = HorizontalAlignment.Left;
            TxtDireccion.TextMaskFormat = MaskFormat.IncludeLiterals;
            TxtDireccion.TrailingIcon = null;
            TxtDireccion.UseSystemPasswordChar = false;
            TxtDireccion.ValidatingType = null;
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
            TxtCorreo.Location = new Point(12, 208);
            TxtCorreo.Margin = new Padding(2);
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
            TxtCorreo.TabIndex = 7;
            TxtCorreo.TabStop = false;
            TxtCorreo.TextAlign = HorizontalAlignment.Left;
            TxtCorreo.TextMaskFormat = MaskFormat.IncludeLiterals;
            TxtCorreo.TrailingIcon = null;
            TxtCorreo.UseSystemPasswordChar = false;
            TxtCorreo.ValidatingType = null;
            // 
            // BtnValidar
            // 
            BtnValidar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnValidar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnValidar.Depth = 0;
            BtnValidar.HighEmphasis = true;
            BtnValidar.Icon = null;
            BtnValidar.Location = new Point(289, 82);
            BtnValidar.Margin = new Padding(3, 4, 3, 4);
            BtnValidar.MouseState = MaterialSkin.MouseState.HOVER;
            BtnValidar.Name = "BtnValidar";
            BtnValidar.NoAccentTextColor = Color.Empty;
            BtnValidar.Size = new Size(81, 36);
            BtnValidar.TabIndex = 7;
            BtnValidar.Text = "Validar";
            BtnValidar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            BtnValidar.UseAccentColor = false;
            BtnValidar.UseVisualStyleBackColor = true;
            // 
            // LblCorreo
            // 
            LblCorreo.AutoSize = true;
            LblCorreo.Depth = 0;
            LblCorreo.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            LblCorreo.Location = new Point(10, 194);
            LblCorreo.Margin = new Padding(2, 0, 2, 0);
            LblCorreo.MouseState = MaterialSkin.MouseState.HOVER;
            LblCorreo.Name = "LblCorreo";
            LblCorreo.Size = new Size(129, 19);
            LblCorreo.TabIndex = 6;
            LblCorreo.Text = "Correo Electronico";
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
            TxtTelefono.Location = new Point(12, 146);
            TxtTelefono.Margin = new Padding(2);
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
            LblTelefono.Location = new Point(10, 130);
            LblTelefono.Margin = new Padding(2, 0, 2, 0);
            LblTelefono.MouseState = MaterialSkin.MouseState.HOVER;
            LblTelefono.Name = "LblTelefono";
            LblTelefono.Size = new Size(64, 19);
            LblTelefono.TabIndex = 4;
            LblTelefono.Text = "Telefono";
            // 
            // TxtDni
            // 
            TxtDni.AllowPromptAsInput = true;
            TxtDni.AnimateReadOnly = false;
            TxtDni.AsciiOnly = false;
            TxtDni.BackgroundImageLayout = ImageLayout.None;
            TxtDni.BeepOnError = false;
            TxtDni.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            TxtDni.Depth = 0;
            TxtDni.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TxtDni.HidePromptOnLeave = false;
            TxtDni.HideSelection = true;
            TxtDni.InsertKeyMode = InsertKeyMode.Default;
            TxtDni.LeadingIcon = null;
            TxtDni.Location = new Point(12, 84);
            TxtDni.Margin = new Padding(2);
            TxtDni.Mask = "";
            TxtDni.MaxLength = 32767;
            TxtDni.MouseState = MaterialSkin.MouseState.OUT;
            TxtDni.Name = "TxtDni";
            TxtDni.PasswordChar = '\0';
            TxtDni.PrefixSuffixText = null;
            TxtDni.PromptChar = '_';
            TxtDni.ReadOnly = false;
            TxtDni.RejectInputOnFirstFailure = false;
            TxtDni.ResetOnPrompt = true;
            TxtDni.ResetOnSpace = true;
            TxtDni.RightToLeft = RightToLeft.No;
            TxtDni.SelectedText = "";
            TxtDni.SelectionLength = 0;
            TxtDni.SelectionStart = 0;
            TxtDni.ShortcutsEnabled = true;
            TxtDni.Size = new Size(262, 48);
            TxtDni.SkipLiterals = true;
            TxtDni.TabIndex = 3;
            TxtDni.TabStop = false;
            TxtDni.TextAlign = HorizontalAlignment.Left;
            TxtDni.TextMaskFormat = MaskFormat.IncludeLiterals;
            TxtDni.TrailingIcon = null;
            TxtDni.UseSystemPasswordChar = false;
            TxtDni.ValidatingType = null;
            // 
            // LblDni
            // 
            LblDni.AutoSize = true;
            LblDni.Depth = 0;
            LblDni.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            LblDni.Location = new Point(10, 68);
            LblDni.Margin = new Padding(2, 0, 2, 0);
            LblDni.MouseState = MaterialSkin.MouseState.HOVER;
            LblDni.Name = "LblDni";
            LblDni.Size = new Size(139, 19);
            LblDni.TabIndex = 2;
            LblDni.Text = "Cedula o Pasaporte";
            // 
            // TxtNombre
            // 
            TxtNombre.AllowPromptAsInput = true;
            TxtNombre.AnimateReadOnly = false;
            TxtNombre.AsciiOnly = false;
            TxtNombre.BackgroundImageLayout = ImageLayout.None;
            TxtNombre.BeepOnError = false;
            TxtNombre.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            TxtNombre.Depth = 0;
            TxtNombre.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TxtNombre.HidePromptOnLeave = false;
            TxtNombre.HideSelection = true;
            TxtNombre.InsertKeyMode = InsertKeyMode.Default;
            TxtNombre.LeadingIcon = null;
            TxtNombre.Location = new Point(12, 27);
            TxtNombre.Margin = new Padding(2);
            TxtNombre.Mask = "";
            TxtNombre.MaxLength = 32767;
            TxtNombre.MouseState = MaterialSkin.MouseState.OUT;
            TxtNombre.Name = "TxtNombre";
            TxtNombre.PasswordChar = '\0';
            TxtNombre.PrefixSuffixText = null;
            TxtNombre.PromptChar = '_';
            TxtNombre.ReadOnly = false;
            TxtNombre.RejectInputOnFirstFailure = false;
            TxtNombre.ResetOnPrompt = true;
            TxtNombre.ResetOnSpace = true;
            TxtNombre.RightToLeft = RightToLeft.No;
            TxtNombre.SelectedText = "";
            TxtNombre.SelectionLength = 0;
            TxtNombre.SelectionStart = 0;
            TxtNombre.ShortcutsEnabled = true;
            TxtNombre.Size = new Size(262, 48);
            TxtNombre.SkipLiterals = true;
            TxtNombre.TabIndex = 1;
            TxtNombre.TabStop = false;
            TxtNombre.TextAlign = HorizontalAlignment.Left;
            TxtNombre.TextMaskFormat = MaskFormat.IncludeLiterals;
            TxtNombre.TrailingIcon = null;
            TxtNombre.UseSystemPasswordChar = false;
            TxtNombre.ValidatingType = null;
            // 
            // LblNombrePersona
            // 
            LblNombrePersona.AutoSize = true;
            LblNombrePersona.Depth = 0;
            LblNombrePersona.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            LblNombrePersona.Location = new Point(10, 6);
            LblNombrePersona.Margin = new Padding(2, 0, 2, 0);
            LblNombrePersona.MouseState = MaterialSkin.MouseState.HOVER;
            LblNombrePersona.Name = "LblNombrePersona";
            LblNombrePersona.Size = new Size(57, 19);
            LblNombrePersona.TabIndex = 0;
            LblNombrePersona.Text = "Nombre";
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 24);
            tabPage5.Margin = new Padding(3, 2, 3, 2);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(808, 644);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Asignar Oferta";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(lblDetalles);
            tabPage6.Controls.Add(txtResumenCorreo);
            tabPage6.Controls.Add(dgvHistorial);
            tabPage6.Controls.Add(materialCard4);
            tabPage6.Location = new Point(4, 24);
            tabPage6.Margin = new Padding(2);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(808, 644);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Historial Correos";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // lblDetalles
            // 
            lblDetalles.AutoSize = true;
            lblDetalles.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDetalles.Location = new Point(23, 361);
            lblDetalles.Name = "lblDetalles";
            lblDetalles.Size = new Size(298, 19);
            lblDetalles.TabIndex = 8;
            lblDetalles.Text = "Detalles del correo enviado al destinatario:";
            // 
            // txtResumenCorreo
            // 
            txtResumenCorreo.Location = new Point(18, 383);
            txtResumenCorreo.Multiline = true;
            txtResumenCorreo.Name = "txtResumenCorreo";
            txtResumenCorreo.ReadOnly = true;
            txtResumenCorreo.ScrollBars = ScrollBars.Vertical;
            txtResumenCorreo.Size = new Size(782, 233);
            txtResumenCorreo.TabIndex = 7;
            // 
            // dgvHistorial
            // 
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(15, 118);
            dgvHistorial.Margin = new Padding(3, 2, 3, 2);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.RowHeadersWidth = 51;
            dgvHistorial.Size = new Size(784, 220);
            dgvHistorial.TabIndex = 1;
            // 
            // materialCard4
            // 
            materialCard4.BackColor = Color.FromArgb(255, 255, 255);
            materialCard4.Controls.Add(txtBuscar);
            materialCard4.Controls.Add(mbtnLimpiar);
            materialCard4.Controls.Add(mbtnBuscar);
            materialCard4.Controls.Add(label2);
            materialCard4.Depth = 0;
            materialCard4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard4.Location = new Point(158, 10);
            materialCard4.Margin = new Padding(12, 10, 12, 10);
            materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard4.Name = "materialCard4";
            materialCard4.Padding = new Padding(12, 10, 12, 10);
            materialCard4.Size = new Size(473, 95);
            materialCard4.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(97, 35);
            txtBuscar.Margin = new Padding(3, 2, 3, 2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(273, 23);
            txtBuscar.TabIndex = 3;
            // 
            // mbtnLimpiar
            // 
            mbtnLimpiar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mbtnLimpiar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            mbtnLimpiar.Depth = 0;
            mbtnLimpiar.HighEmphasis = true;
            mbtnLimpiar.Icon = null;
            mbtnLimpiar.Location = new Point(375, 32);
            mbtnLimpiar.Margin = new Padding(4);
            mbtnLimpiar.MouseState = MaterialSkin.MouseState.HOVER;
            mbtnLimpiar.Name = "mbtnLimpiar";
            mbtnLimpiar.NoAccentTextColor = Color.Empty;
            mbtnLimpiar.Size = new Size(79, 36);
            mbtnLimpiar.TabIndex = 2;
            mbtnLimpiar.Text = "Limpiar";
            mbtnLimpiar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            mbtnLimpiar.UseAccentColor = false;
            mbtnLimpiar.UseVisualStyleBackColor = true;
            mbtnLimpiar.Click += mbtnLimpiar_Click;
            // 
            // mbtnBuscar
            // 
            mbtnBuscar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mbtnBuscar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            mbtnBuscar.Depth = 0;
            mbtnBuscar.HighEmphasis = true;
            mbtnBuscar.Icon = null;
            mbtnBuscar.Location = new Point(13, 32);
            mbtnBuscar.Margin = new Padding(4);
            mbtnBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            mbtnBuscar.Name = "mbtnBuscar";
            mbtnBuscar.NoAccentTextColor = Color.Empty;
            mbtnBuscar.Size = new Size(77, 36);
            mbtnBuscar.TabIndex = 1;
            mbtnBuscar.Text = "Buscar";
            mbtnBuscar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            mbtnBuscar.UseAccentColor = false;
            mbtnBuscar.UseVisualStyleBackColor = true;
            mbtnBuscar.Click += mbtnBuscar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(127, 10);
            label2.Name = "label2";
            label2.Size = new Size(217, 19);
            label2.TabIndex = 1;
            label2.Text = "Buscar Por Nombre, ID, Correo";
            // 
            // tabPage7
            // 
            tabPage7.Location = new Point(4, 24);
            tabPage7.Margin = new Padding(2);
            tabPage7.Name = "tabPage7";
            tabPage7.Size = new Size(808, 644);
            tabPage7.TabIndex = 6;
            tabPage7.Text = "Carnet";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            tabPage8.Location = new Point(4, 24);
            tabPage8.Margin = new Padding(2);
            tabPage8.Name = "tabPage8";
            tabPage8.Size = new Size(808, 644);
            tabPage8.TabIndex = 7;
            tabPage8.Text = "Registro Interno";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            tabPage9.Location = new Point(4, 24);
            tabPage9.Margin = new Padding(2);
            tabPage9.Name = "tabPage9";
            tabPage9.Size = new Size(808, 644);
            tabPage9.TabIndex = 8;
            tabPage9.Text = "Historial Postulaciones";
            tabPage9.UseVisualStyleBackColor = true;
            // 
            // cpHistorialMensajes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 722);
            Controls.Add(materialTabControl1);
            DrawerTabControl = materialTabControl1;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "cpHistorialMensajes";
            Padding = new Padding(3, 48, 3, 2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historial Mensajes";
            Load += cpHistorialMensajes_Load;
            materialTabControl1.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvPersonas).EndInit();
            materialCard2.ResumeLayout(false);
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            tabPage6.ResumeLayout(false);
            tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            materialCard4.ResumeLayout(false);
            materialCard4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private DataGridView DgvPersonas;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private MaterialSkin.Controls.MaterialButton BtnActualizar;
        private MaterialSkin.Controls.MaterialButton BtnRegistrar;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private ComboBox CboxOfertas;
        private MaterialSkin.Controls.MaterialLabel LblSelecOferta;
        private Label LblDireccion;
        private MaterialSkin.Controls.MaterialMaskedTextBox TxtDireccion;
        private MaterialSkin.Controls.MaterialMaskedTextBox TxtCorreo;
        private MaterialSkin.Controls.MaterialButton BtnValidar;
        private MaterialSkin.Controls.MaterialLabel LblCorreo;
        private MaterialSkin.Controls.MaterialMaskedTextBox TxtTelefono;
        private MaterialSkin.Controls.MaterialLabel LblTelefono;
        private MaterialSkin.Controls.MaterialMaskedTextBox TxtDni;
        private MaterialSkin.Controls.MaterialLabel LblDni;
        private MaterialSkin.Controls.MaterialMaskedTextBox TxtNombre;
        private MaterialSkin.Controls.MaterialLabel LblNombrePersona;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private MaterialSkin.Controls.MaterialCard materialCard4;
        private Label label2;
        private MaterialSkin.Controls.MaterialButton mbtnBuscar;
        private Label lblDetalles;
        private TextBox txtResumenCorreo;
        private DataGridView dgvHistorial;
        private MaterialSkin.Controls.MaterialButton mbtnLimpiar;
        private TextBox txtBuscar;
        private TabPage tabPage9;
    }
}