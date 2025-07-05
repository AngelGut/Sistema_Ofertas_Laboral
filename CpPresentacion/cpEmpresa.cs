using MaterialSkin.Controls;
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
    public partial class cpEmpresa : MaterialForm // <<== ¡Cambiado a MaterialForm!
    {
        public cpEmpresa()
        {
            InitializeComponent();
        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = materialTabControl1.SelectedIndex;

            
            if (selectedIndex == 0)
            {
                new Menu().Show(); //Menu
            }

            // Cambia de formulario según la pestaña seleccionada
            if (selectedIndex == 1) // Ofertas
            {
                new cpOfertas().Show();
            }
            //mues
            else if (selectedIndex == 2) // Empresas
                return;

            else if (selectedIndex == 3) // Postulantes
            {
                new cpPostulante().Show();
            }


            // Opcional: ocultar el formulario actual para que solo quede uno visible
            this.Hide();
        }
    }
}
