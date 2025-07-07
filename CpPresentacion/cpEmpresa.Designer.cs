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
            tabPage4 = new TabPage();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            lblNombreCompania = new MaterialSkin.Controls.MaterialLabel();
            TxtNombreCompania = new MaterialSkin.Controls.MaterialMaskedTextBox();
            materialTabControl1.SuspendLayout();
            tabPage3.SuspendLayout();
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
            materialTabControl1.Location = new Point(3, 64);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1894, 1013);
            materialTabControl1.TabIndex = 0;
            materialTabControl1.SelectedIndexChanged += materialTabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1886, 975);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Menu";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1886, 975);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ofertas laborales";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(materialCard1);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1886, 975);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Empresas";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 34);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1886, 975);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Postulantes";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(TxtNombreCompania);
            materialCard1.Controls.Add(lblNombreCompania);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(14, 14);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(488, 947);
            materialCard1.TabIndex = 0;
            // 
            // lblNombreCompania
            // 
            lblNombreCompania.AutoSize = true;
            lblNombreCompania.Depth = 0;
            lblNombreCompania.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNombreCompania.Location = new Point(17, 14);
            lblNombreCompania.MouseState = MaterialSkin.MouseState.HOVER;
            lblNombreCompania.Name = "lblNombreCompania";
            lblNombreCompania.Size = new Size(161, 19);
            lblNombreCompania.TabIndex = 0;
            lblNombreCompania.Text = "Nombre de la Empresa";
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
            TxtNombreCompania.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TxtNombreCompania.HidePromptOnLeave = false;
            TxtNombreCompania.HideSelection = true;
            TxtNombreCompania.InsertKeyMode = InsertKeyMode.Default;
            TxtNombreCompania.LeadingIcon = null;
            TxtNombreCompania.Location = new Point(17, 50);
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
            TxtNombreCompania.Size = new Size(375, 48);
            TxtNombreCompania.SkipLiterals = true;
            TxtNombreCompania.TabIndex = 1;
            TxtNombreCompania.TabStop = false;
            TxtNombreCompania.TextAlign = HorizontalAlignment.Left;
            TxtNombreCompania.TextMaskFormat = MaskFormat.IncludeLiterals;
            TxtNombreCompania.TrailingIcon = null;
            TxtNombreCompania.UseSystemPasswordChar = false;
            TxtNombreCompania.ValidatingType = null;
            // 
            // cpEmpresa
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1900, 1080);
            Controls.Add(materialTabControl1);
            DrawerTabControl = materialTabControl1;
            Name = "cpEmpresa";
            Text = "Empresas";
            materialTabControl1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
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
        private MaterialSkin.Controls.MaterialMaskedTextBox TxtNombreCompania;
    }
}