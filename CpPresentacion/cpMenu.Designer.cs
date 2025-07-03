namespace CpPresentacion
{
    partial class cpMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnOferta = new MaterialSkin.Controls.MaterialButton();
            BtnPostulaciones = new MaterialSkin.Controls.MaterialButton();
            BtnSalir = new MaterialSkin.Controls.MaterialButton();
            BtnUsuario = new MaterialSkin.Controls.MaterialButton();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            LblMenuPrincipal = new MaterialSkin.Controls.MaterialLabel();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnOferta
            // 
            BtnOferta.AutoSize = false;
            BtnOferta.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnOferta.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnOferta.Depth = 0;
            BtnOferta.HighEmphasis = true;
            BtnOferta.Icon = null;
            BtnOferta.Location = new Point(72, 109);
            BtnOferta.Margin = new Padding(4, 6, 4, 6);
            BtnOferta.MouseState = MaterialSkin.MouseState.HOVER;
            BtnOferta.Name = "BtnOferta";
            BtnOferta.NoAccentTextColor = Color.Empty;
            BtnOferta.Size = new Size(170, 36);
            BtnOferta.TabIndex = 0;
            BtnOferta.Text = "Ofertas Laborales";
            BtnOferta.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            BtnOferta.UseAccentColor = false;
            BtnOferta.UseVisualStyleBackColor = true;
            // 
            // BtnPostulaciones
            // 
            BtnPostulaciones.AutoSize = false;
            BtnPostulaciones.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnPostulaciones.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnPostulaciones.Depth = 0;
            BtnPostulaciones.HighEmphasis = true;
            BtnPostulaciones.Icon = null;
            BtnPostulaciones.Location = new Point(403, 190);
            BtnPostulaciones.Margin = new Padding(4, 6, 4, 6);
            BtnPostulaciones.MouseState = MaterialSkin.MouseState.HOVER;
            BtnPostulaciones.Name = "BtnPostulaciones";
            BtnPostulaciones.NoAccentTextColor = Color.Empty;
            BtnPostulaciones.Size = new Size(170, 36);
            BtnPostulaciones.TabIndex = 1;
            BtnPostulaciones.Text = "Postulaciones";
            BtnPostulaciones.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            BtnPostulaciones.UseAccentColor = false;
            BtnPostulaciones.UseVisualStyleBackColor = true;
            // 
            // BtnSalir
            // 
            BtnSalir.AutoSize = false;
            BtnSalir.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnSalir.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnSalir.Depth = 0;
            BtnSalir.HighEmphasis = true;
            BtnSalir.Icon = null;
            BtnSalir.Location = new Point(72, 190);
            BtnSalir.Margin = new Padding(4, 6, 4, 6);
            BtnSalir.MouseState = MaterialSkin.MouseState.HOVER;
            BtnSalir.Name = "BtnSalir";
            BtnSalir.NoAccentTextColor = Color.Empty;
            BtnSalir.Size = new Size(170, 36);
            BtnSalir.TabIndex = 2;
            BtnSalir.Text = "Salir";
            BtnSalir.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            BtnSalir.UseAccentColor = false;
            BtnSalir.UseVisualStyleBackColor = true;
            // 
            // BtnUsuario
            // 
            BtnUsuario.AutoSize = false;
            BtnUsuario.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnUsuario.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BtnUsuario.Depth = 0;
            BtnUsuario.HighEmphasis = true;
            BtnUsuario.Icon = null;
            BtnUsuario.Location = new Point(403, 109);
            BtnUsuario.Margin = new Padding(4, 6, 4, 6);
            BtnUsuario.MouseState = MaterialSkin.MouseState.HOVER;
            BtnUsuario.Name = "BtnUsuario";
            BtnUsuario.NoAccentTextColor = Color.Empty;
            BtnUsuario.Size = new Size(170, 36);
            BtnUsuario.TabIndex = 3;
            BtnUsuario.Text = "Usuarios";
            BtnUsuario.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            BtnUsuario.UseAccentColor = false;
            BtnUsuario.UseVisualStyleBackColor = true;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(LblMenuPrincipal);
            materialCard1.Controls.Add(BtnOferta);
            materialCard1.Controls.Add(BtnPostulaciones);
            materialCard1.Controls.Add(BtnUsuario);
            materialCard1.Controls.Add(BtnSalir);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(146, 355);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(664, 257);
            materialCard1.TabIndex = 4;
            // 
            // LblMenuPrincipal
            // 
            LblMenuPrincipal.AutoSize = true;
            LblMenuPrincipal.Depth = 0;
            LblMenuPrincipal.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            LblMenuPrincipal.Location = new Point(274, 36);
            LblMenuPrincipal.MouseState = MaterialSkin.MouseState.HOVER;
            LblMenuPrincipal.Name = "LblMenuPrincipal";
            LblMenuPrincipal.Size = new Size(107, 19);
            LblMenuPrincipal.TabIndex = 4;
            LblMenuPrincipal.Text = "Menu Principal";
            // 
            // cpMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1025, 677);
            Controls.Add(materialCard1);
            Name = "cpMenu";
            Text = "Inicio";
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton BtnOferta;
        private MaterialSkin.Controls.MaterialButton BtnPostulaciones;
        private MaterialSkin.Controls.MaterialButton BtnSalir;
        private MaterialSkin.Controls.MaterialButton BtnUsuario;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialLabel LblMenuPrincipal;
    }
}
