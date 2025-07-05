using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace CpPresentacion
{
    public partial class Menu : MaterialForm // <<== ¡Cambiado a MaterialForm!
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (materialTabControl1.SelectedIndex)
            {
                case 0: // Ofertas
                    new cpOfertas().Show();
                    this.Hide(); // Opcional: oculta el menú actual
                    break;
                case 1: // Empresas
                    new cpEmpresa().Show();
                    this.Hide();
                    break;
                case 2: // Postulantes
                    new cpPostulante().Show();
                    this.Hide();
                    break;
            }
        }
    }
}
