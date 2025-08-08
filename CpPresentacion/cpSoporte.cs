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
    public partial class cpSoporte : MaterialForm
    {
        public cpSoporte()
        {
            InitializeComponent();
        }
        private void MostrarDesarrollador(string nombre, Image foto, string redSocial)
        {
            lblNombre.Text = nombre;
            lblRedSocial.Text = "Red social: " + redSocial;
            picPerfil.Image = foto;
        }
        private void cpSoporte_Load(object sender, EventArgs e)
        {

        }

        private void btnAngel_Click(object sender, EventArgs e)
        {
            MostrarDesarrollador("Angel David", Properties.Resources.angel, "@angel_david");
        }

        private void materialCard4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialCard4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnElian_Click(object sender, EventArgs e)
        {
            MostrarDesarrollador("Elian Nicolas", Properties.Resources.elian, "@elian.dev");

        }

        private void btnLuis_Click(object sender, EventArgs e)
        {
            MostrarDesarrollador("Luis Bravo", Properties.Resources.luis, "@luisbravo");

        }

        private void btnJeifferson_Click(object sender, EventArgs e)
        {
            MostrarDesarrollador("Jeifferson David", Properties.Resources.jeifferson, "@jeiff.dev");

        }

        private void btnBraylin_Click(object sender, EventArgs e)
        {
            MostrarDesarrollador("Braylin Jaques", Properties.Resources.braylin, "@braylin.j");

        }

        private void btnRonald_Click(object sender, EventArgs e)
        {
            MostrarDesarrollador("Ronald Reyes", Properties.Resources.ronald, "@ronald_reyes");

        }

        private void S_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
    }
}
