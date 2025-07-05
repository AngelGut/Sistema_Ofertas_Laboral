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
    public partial class cpPostulante : MaterialForm
    {
        public cpPostulante()
        {
            InitializeComponent();
        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = materialTabControl1.SelectedIndex;

            // Si estamos en la pestaña de inicio (menú principal), no hacemos nada
            if (selectedIndex == 0)
            {
                new Menu().Show();
            }

            // Cambia de formulario según la pestaña seleccionada
            if (selectedIndex == 1) // Ofertas
            {
                new cpOfertas().Show();
            }
            else if (selectedIndex == 2) // Empresas
            {
                new cpEmpresa().Show();
            }
            else if (selectedIndex == 3) // Postulantes
                return;


            // Opcional: ocultar el formulario actual para que solo quede uno visible
            this.Hide();
        }
    }
}
