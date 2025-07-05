
namespace Sistema_Ofertas_Laboral
{
    partial class cpMenu
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
            this.materialDrawer1 = new MaterialSkin.Controls.MaterialDrawer();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();

            this.materialTabControl1.SuspendLayout();
            this.SuspendLayout();

            // 
            // materialDrawer1
            // 
            this.materialDrawer1.AutoHide = false;
            this.materialDrawer1.BackgroundWithAccent = false;
            this.materialDrawer1.BaseTabControl = this.materialTabControl1;
            this.materialDrawer1.Depth = 0;
            this.materialDrawer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialDrawer1.IndicatorWidth = 0;
            this.materialDrawer1.IsOpen = true;
            this.materialDrawer1.Location = new System.Drawing.Point(0, 0);
            this.materialDrawer1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDrawer1.Name = "materialDrawer1";
            this.materialDrawer1.ShowIconsWhenHidden = false;
            this.materialDrawer1.Size = new System.Drawing.Size(240, 500);
            this.materialDrawer1.TabIndex = 0;
            this.materialDrawer1.UseColors = true;

            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Controls.Add(this.tabPage3);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(240, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(600, 400);
            this.materialTabControl1.TabIndex = 1;
            this.materialTabControl1.SelectedIndexChanged += new System.EventHandler(this.materialTabControl1_SelectedIndexChanged);

            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(592, 374);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Empresas";
            this.tabPage1.UseVisualStyleBackColor = true;

            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(592, 374);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Postulantes";
            this.tabPage2.UseVisualStyleBackColor = true;

            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(592, 374);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ofertas";
            this.tabPage3.UseVisualStyleBackColor = true;

            // 
            // cpMenu
            // 
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialDrawer1);
            this.Name = "cpMenu";
            this.Text = "Menú Principal";
            this.Load += new System.EventHandler(this.cpMenu_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialDrawer materialDrawer1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
    }
}
