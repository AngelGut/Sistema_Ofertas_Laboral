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

        private void mtbtnAngel_Click(object sender, EventArgs e)
        {
            MostrarDesarrollador("Angel David", Properties.Resources.angel, "GitHub: AngelGut\n" +
                "Instagram: @angeldavid_gutierrez18\n" +
                "Linkedin.com/in/angel-david-gutierrez-contreras");
        }

        private void materialCard4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialCard4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void mtbtnElian_Click(object sender, EventArgs e)
        {
            MostrarDesarrollador("Elian Nicolas", Properties.Resources.elian, "GitHub: Eliancmercedes\n" +
                "Instagram: @https._elian\n" +
                "Linkedin.com/in/eliancamino/");

        }

        private void mtbtnLuis_Click(object sender, EventArgs e)
        {
            MostrarDesarrollador("Luis Bravo", Properties.Resources.luis, "GitHub: luisbravobello\n" +
                "Instagram: @alejandro_bravo27\n" +
                "Linkedin.com/in/luis-alejandro-bravo-bello");

        }

        private void mtbtnJeiferson_Click(object sender, EventArgs e)
        {
            MostrarDesarrollador("Jeiferson David", Properties.Resources.jeifferson, "GitHub: NEW-Jeiferson\n" +
         "Instagram: @jd.a.v.i.d.zpz\n" +
         "Linkedin.com/in/jeiferson-d-paez");

        }

        private void mtbtnBrailyn_Click(object sender, EventArgs e)
        { 
            MostrarDesarrollador("Braylin Jaques", Properties.Resources.braylin, "GitHub: Brailyn1905\n" +
         "Instagram: @brailyn.jaquez.3\n" +
         "LinkedIn.com/in/brailyn-ramirez");

        }

        private void mtbtnRonald_Click(object sender, EventArgs e)
        {
            MostrarDesarrollador("Ronald Reyes", Properties.Resources.ronald, "GitHub: RonaldReyes27\n" +
                "Instagram: @reyesronaldalberto\n" +
                "Linkedin.com/in/ronaldr15");

        }

        private void S_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

    
    }
}
