namespace CpPresentacion
{
    partial class frmModoVisualizacion
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
            label1 = new Label();
            btnVer = new MaterialSkin.Controls.MaterialButton();
            btnEditar = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(58, 146);
            label1.Name = "label1";
            label1.Size = new Size(663, 54);
            label1.TabIndex = 1;
            label1.Text = "¿Cómo deseas abrir el formulario?";
            // 
            // btnVer
            // 
            btnVer.AutoSize = false;
            btnVer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnVer.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnVer.Depth = 0;
            btnVer.HighEmphasis = true;
            btnVer.Icon = null;
            btnVer.Location = new Point(158, 345);
            btnVer.Margin = new Padding(4, 6, 4, 6);
            btnVer.MouseState = MaterialSkin.MouseState.HOVER;
            btnVer.Name = "btnVer";
            btnVer.NoAccentTextColor = Color.Empty;
            btnVer.Size = new Size(237, 54);
            btnVer.TabIndex = 2;
            btnVer.Text = "Ver";
            btnVer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnVer.UseAccentColor = false;
            btnVer.UseVisualStyleBackColor = true;
            btnVer.Click += btnVer_Click;
            // 
            // btnEditar
            // 
            btnEditar.AutoSize = false;
            btnEditar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEditar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEditar.Depth = 0;
            btnEditar.HighEmphasis = true;
            btnEditar.Icon = null;
            btnEditar.Location = new Point(403, 345);
            btnEditar.Margin = new Padding(4, 6, 4, 6);
            btnEditar.MouseState = MaterialSkin.MouseState.HOVER;
            btnEditar.Name = "btnEditar";
            btnEditar.NoAccentTextColor = Color.Empty;
            btnEditar.Size = new Size(237, 54);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEditar.UseAccentColor = false;
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // frmModoVisualizacion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEditar);
            Controls.Add(btnVer);
            Controls.Add(label1);
            Name = "frmModoVisualizacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmModoVisualizacion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private MaterialSkin.Controls.MaterialButton btnVer;
        private MaterialSkin.Controls.MaterialButton btnEditar;
    }
}