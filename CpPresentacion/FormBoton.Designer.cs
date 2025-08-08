namespace CpPresentacion
{
    partial class FormBoton
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
            swthHabilitar = new MaterialSkin.Controls.MaterialSwitch();
            SuspendLayout();
            // 
            // swthHabilitar
            // 
            swthHabilitar.AutoSize = true;
            swthHabilitar.Depth = 0;
            swthHabilitar.Location = new Point(27, 108);
            swthHabilitar.Margin = new Padding(0);
            swthHabilitar.MouseLocation = new Point(-1, -1);
            swthHabilitar.MouseState = MaterialSkin.MouseState.HOVER;
            swthHabilitar.Name = "swthHabilitar";
            swthHabilitar.Ripple = true;
            swthHabilitar.Size = new Size(174, 37);
            swthHabilitar.TabIndex = 0;
            swthHabilitar.Text = "Habilitar Edicion";
            swthHabilitar.UseVisualStyleBackColor = true;
            // 
            // FormBoton
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(226, 245);
            ControlBox = false;
            Controls.Add(swthHabilitar);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormBoton";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialSwitch swthHabilitar;
    }
}