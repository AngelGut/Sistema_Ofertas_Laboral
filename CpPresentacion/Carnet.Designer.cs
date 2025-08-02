namespace CpPresentacion
{
    partial class Carnet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Carnet));
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            tabPage7 = new TabPage();
            panelTarjeta = new Panel();
            picLogo = new PictureBox();
            picFoto = new PictureBox();
            txtPosicion = new MaterialSkin.Controls.MaterialMaskedTextBox();
            txtTelefono = new MaterialSkin.Controls.MaterialMaskedTextBox();
            txtNombre = new MaterialSkin.Controls.MaterialMaskedTextBox();
            btnVistaPrevia = new MaterialSkin.Controls.MaterialButton();
            btnCargarFoto = new MaterialSkin.Controls.MaterialButton();
            btnGuardarTargeta = new MaterialSkin.Controls.MaterialButton();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPage8 = new TabPage();
            materialTabControl1.SuspendLayout();
            tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picFoto).BeginInit();
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
            materialTabControl1.Location = new Point(3, 64);
            materialTabControl1.Margin = new Padding(2);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(913, 507);
            materialTabControl1.TabIndex = 0;
            materialTabControl1.SelectedIndexChanged += materialTabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2);
            tabPage1.Size = new Size(1364, 649);
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
            tabPage2.Size = new Size(1364, 649);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ofertas Laborales";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 29);
            tabPage3.Margin = new Padding(2);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1364, 649);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Empresas";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 29);
            tabPage4.Margin = new Padding(2);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1364, 649);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Postulantes";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 29);
            tabPage5.Margin = new Padding(2);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1364, 649);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Asignar Oferta";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Location = new Point(4, 29);
            tabPage6.Margin = new Padding(2);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(1364, 649);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Historial Correos";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            tabPage7.Controls.Add(panelTarjeta);
            tabPage7.Controls.Add(picLogo);
            tabPage7.Controls.Add(picFoto);
            tabPage7.Controls.Add(txtPosicion);
            tabPage7.Controls.Add(txtTelefono);
            tabPage7.Controls.Add(txtNombre);
            tabPage7.Controls.Add(btnVistaPrevia);
            tabPage7.Controls.Add(btnCargarFoto);
            tabPage7.Controls.Add(btnGuardarTargeta);
            tabPage7.Controls.Add(label3);
            tabPage7.Controls.Add(label2);
            tabPage7.Controls.Add(label1);
            tabPage7.Location = new Point(4, 29);
            tabPage7.Margin = new Padding(2);
            tabPage7.Name = "tabPage7";
            tabPage7.Size = new Size(905, 474);
            tabPage7.TabIndex = 6;
            tabPage7.Text = "Carnet";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // panelTarjeta
            // 
            panelTarjeta.Location = new Point(619, 25);
            panelTarjeta.Name = "panelTarjeta";
            panelTarjeta.Size = new Size(268, 343);
            panelTarjeta.TabIndex = 11;
            panelTarjeta.Paint += panelTarjeta_Paint;
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(415, 254);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(140, 114);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 10;
            picLogo.TabStop = false;
            picLogo.Visible = false;
            // 
            // picFoto
            // 
            picFoto.Location = new Point(402, 27);
            picFoto.Name = "picFoto";
            picFoto.Size = new Size(190, 184);
            picFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            picFoto.TabIndex = 9;
            picFoto.TabStop = false;
            // 
            // txtPosicion
            // 
            txtPosicion.AllowPromptAsInput = true;
            txtPosicion.AnimateReadOnly = false;
            txtPosicion.AsciiOnly = false;
            txtPosicion.BackgroundImageLayout = ImageLayout.None;
            txtPosicion.BeepOnError = false;
            txtPosicion.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtPosicion.Depth = 0;
            txtPosicion.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPosicion.HidePromptOnLeave = false;
            txtPosicion.HideSelection = true;
            txtPosicion.InsertKeyMode = InsertKeyMode.Default;
            txtPosicion.LeadingIcon = null;
            txtPosicion.Location = new Point(154, 225);
            txtPosicion.Mask = "";
            txtPosicion.MaxLength = 32767;
            txtPosicion.MouseState = MaterialSkin.MouseState.OUT;
            txtPosicion.Name = "txtPosicion";
            txtPosicion.PasswordChar = '\0';
            txtPosicion.PrefixSuffixText = null;
            txtPosicion.PromptChar = '_';
            txtPosicion.ReadOnly = false;
            txtPosicion.RejectInputOnFirstFailure = false;
            txtPosicion.ResetOnPrompt = true;
            txtPosicion.ResetOnSpace = true;
            txtPosicion.RightToLeft = RightToLeft.No;
            txtPosicion.SelectedText = "";
            txtPosicion.SelectionLength = 0;
            txtPosicion.SelectionStart = 0;
            txtPosicion.ShortcutsEnabled = true;
            txtPosicion.Size = new Size(219, 48);
            txtPosicion.SkipLiterals = true;
            txtPosicion.TabIndex = 8;
            txtPosicion.TabStop = false;
            txtPosicion.TextAlign = HorizontalAlignment.Left;
            txtPosicion.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtPosicion.TrailingIcon = null;
            txtPosicion.UseSystemPasswordChar = false;
            txtPosicion.ValidatingType = null;
            // 
            // txtTelefono
            // 
            txtTelefono.AllowPromptAsInput = true;
            txtTelefono.AnimateReadOnly = false;
            txtTelefono.AsciiOnly = false;
            txtTelefono.BackgroundImageLayout = ImageLayout.None;
            txtTelefono.BeepOnError = false;
            txtTelefono.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtTelefono.Depth = 0;
            txtTelefono.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTelefono.HidePromptOnLeave = false;
            txtTelefono.HideSelection = true;
            txtTelefono.InsertKeyMode = InsertKeyMode.Default;
            txtTelefono.LeadingIcon = null;
            txtTelefono.Location = new Point(154, 118);
            txtTelefono.Mask = "";
            txtTelefono.MaxLength = 32767;
            txtTelefono.MouseState = MaterialSkin.MouseState.OUT;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PasswordChar = '\0';
            txtTelefono.PrefixSuffixText = null;
            txtTelefono.PromptChar = '_';
            txtTelefono.ReadOnly = false;
            txtTelefono.RejectInputOnFirstFailure = false;
            txtTelefono.ResetOnPrompt = true;
            txtTelefono.ResetOnSpace = true;
            txtTelefono.RightToLeft = RightToLeft.No;
            txtTelefono.SelectedText = "";
            txtTelefono.SelectionLength = 0;
            txtTelefono.SelectionStart = 0;
            txtTelefono.ShortcutsEnabled = true;
            txtTelefono.Size = new Size(219, 48);
            txtTelefono.SkipLiterals = true;
            txtTelefono.TabIndex = 7;
            txtTelefono.TabStop = false;
            txtTelefono.TextAlign = HorizontalAlignment.Left;
            txtTelefono.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtTelefono.TrailingIcon = null;
            txtTelefono.UseSystemPasswordChar = false;
            txtTelefono.ValidatingType = null;
            // 
            // txtNombre
            // 
            txtNombre.AllowPromptAsInput = true;
            txtNombre.AnimateReadOnly = false;
            txtNombre.AsciiOnly = false;
            txtNombre.BackgroundImageLayout = ImageLayout.None;
            txtNombre.BeepOnError = false;
            txtNombre.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtNombre.Depth = 0;
            txtNombre.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNombre.HidePromptOnLeave = false;
            txtNombre.HideSelection = true;
            txtNombre.InsertKeyMode = InsertKeyMode.Default;
            txtNombre.LeadingIcon = null;
            txtNombre.Location = new Point(154, 27);
            txtNombre.Mask = "";
            txtNombre.MaxLength = 32767;
            txtNombre.MouseState = MaterialSkin.MouseState.OUT;
            txtNombre.Name = "txtNombre";
            txtNombre.PasswordChar = '\0';
            txtNombre.PrefixSuffixText = null;
            txtNombre.PromptChar = '_';
            txtNombre.ReadOnly = false;
            txtNombre.RejectInputOnFirstFailure = false;
            txtNombre.ResetOnPrompt = true;
            txtNombre.ResetOnSpace = true;
            txtNombre.RightToLeft = RightToLeft.No;
            txtNombre.SelectedText = "";
            txtNombre.SelectionLength = 0;
            txtNombre.SelectionStart = 0;
            txtNombre.ShortcutsEnabled = true;
            txtNombre.Size = new Size(219, 48);
            txtNombre.SkipLiterals = true;
            txtNombre.TabIndex = 6;
            txtNombre.TabStop = false;
            txtNombre.TextAlign = HorizontalAlignment.Left;
            txtNombre.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtNombre.TrailingIcon = null;
            txtNombre.UseSystemPasswordChar = false;
            txtNombre.ValidatingType = null;
            // 
            // btnVistaPrevia
            // 
            btnVistaPrevia.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnVistaPrevia.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnVistaPrevia.Depth = 0;
            btnVistaPrevia.HighEmphasis = true;
            btnVistaPrevia.Icon = null;
            btnVistaPrevia.Location = new Point(224, 332);
            btnVistaPrevia.Margin = new Padding(4, 6, 4, 6);
            btnVistaPrevia.MouseState = MaterialSkin.MouseState.HOVER;
            btnVistaPrevia.Name = "btnVistaPrevia";
            btnVistaPrevia.NoAccentTextColor = Color.Empty;
            btnVistaPrevia.Size = new Size(116, 36);
            btnVistaPrevia.TabIndex = 5;
            btnVistaPrevia.Text = "Vista previa";
            btnVistaPrevia.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnVistaPrevia.UseAccentColor = false;
            btnVistaPrevia.UseVisualStyleBackColor = true;
            btnVistaPrevia.Click += btnVistaPrevia_Click;
            // 
            // btnCargarFoto
            // 
            btnCargarFoto.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCargarFoto.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCargarFoto.Depth = 0;
            btnCargarFoto.HighEmphasis = true;
            btnCargarFoto.Icon = null;
            btnCargarFoto.Location = new Point(31, 332);
            btnCargarFoto.Margin = new Padding(4, 6, 4, 6);
            btnCargarFoto.MouseState = MaterialSkin.MouseState.HOVER;
            btnCargarFoto.Name = "btnCargarFoto";
            btnCargarFoto.NoAccentTextColor = Color.Empty;
            btnCargarFoto.Size = new Size(120, 36);
            btnCargarFoto.TabIndex = 4;
            btnCargarFoto.Text = "Cargar foto";
            btnCargarFoto.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCargarFoto.UseAccentColor = false;
            btnCargarFoto.UseVisualStyleBackColor = true;
            btnCargarFoto.Click += btnCargarFoto_Click;
            // 
            // btnGuardarTargeta
            // 
            btnGuardarTargeta.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGuardarTargeta.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGuardarTargeta.Depth = 0;
            btnGuardarTargeta.HighEmphasis = true;
            btnGuardarTargeta.Icon = null;
            btnGuardarTargeta.Location = new Point(111, 410);
            btnGuardarTargeta.Margin = new Padding(4, 6, 4, 6);
            btnGuardarTargeta.MouseState = MaterialSkin.MouseState.HOVER;
            btnGuardarTargeta.Name = "btnGuardarTargeta";
            btnGuardarTargeta.NoAccentTextColor = Color.Empty;
            btnGuardarTargeta.Size = new Size(157, 36);
            btnGuardarTargeta.TabIndex = 3;
            btnGuardarTargeta.Text = "Guardar Targeta ";
            btnGuardarTargeta.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGuardarTargeta.UseAccentColor = false;
            btnGuardarTargeta.UseVisualStyleBackColor = true;
            btnGuardarTargeta.Click += btnGuardarTargeta_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(31, 245);
            label3.Name = "label3";
            label3.Size = new Size(84, 28);
            label3.TabIndex = 2;
            label3.Text = "Posicion";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 138);
            label2.Name = "label2";
            label2.Size = new Size(86, 28);
            label2.TabIndex = 1;
            label2.Text = "Telefono";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(29, 47);
            label1.Name = "label1";
            label1.Size = new Size(85, 28);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // tabPage8
            // 
            tabPage8.Location = new Point(4, 29);
            tabPage8.Margin = new Padding(2);
            tabPage8.Name = "tabPage8";
            tabPage8.Size = new Size(1364, 649);
            tabPage8.TabIndex = 7;
            tabPage8.Text = "Registro Interno";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // Carnet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 574);
            Controls.Add(materialTabControl1);
            DrawerTabControl = materialTabControl1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Carnet";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Carnet";
            materialTabControl1.ResumeLayout(false);
            tabPage7.ResumeLayout(false);
            tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picFoto).EndInit();
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
        private MaterialSkin.Controls.MaterialMaskedTextBox txtPosicion;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtTelefono;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtNombre;
        private MaterialSkin.Controls.MaterialButton btnVistaPrevia;
        private MaterialSkin.Controls.MaterialButton btnCargarFoto;
        private MaterialSkin.Controls.MaterialButton btnGuardarTargeta;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panelTarjeta;
        private PictureBox picLogo;
        private PictureBox picFoto;
    }
}