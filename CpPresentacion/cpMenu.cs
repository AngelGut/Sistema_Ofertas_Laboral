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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CpPresentacion
{
    public partial class Menu : MaterialForm // <<== ¡Cambiado a MaterialForm!
    {
        private string rolUsuario;
        public Menu()
        {
            InitializeComponent();
            

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Bloquea redimensionamiento

            // Establece el tab activo que corresponde a este formulario
            materialTabControl1.SelectedIndex = 0;

            // Mejora visual: habilitar doble búfer para reducir parpadeos
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
            
           
        }

 

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private async void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = materialTabControl1.SelectedIndex;

            if (selectedIndex == 1)  // Ofertas
            {
                // Verifica si el formulario cpOfertas ya está abierto
                if (!Application.OpenForms.Cast<Form>().Any(f => f.Name == "cpOfertas"))
                {
                    var f = new cpOfertas();  // Crear una nueva instancia del formulario cpOfertas
                    this.Hide();               // Ocultar el formulario actual
                    f.Show();                  // Mostrar cpOfertas
                    await Task.Delay(300);     // Pausa breve, si es necesario
                }
            }
            else if (selectedIndex == 2)  // Empresa
            {
                // Verifica si el formulario cpEmpresa ya está abierto
                if (!Application.OpenForms.Cast<Form>().Any(f => f.Name == "cpEmpresa"))
                {
                    var f = new cpEmpresa();  // Crear una nueva instancia del formulario cpEmpresa
                    this.Hide();               // Ocultar el formulario actual
                    f.Show();                  // Mostrar cpEmpresa
                    await Task.Delay(300);     // Pausa breve, si es necesario
                }
            }
            else if (selectedIndex == 3)  // Postulante
            {
                // Verifica si el formulario cpPostulante ya está abierto
                if (!Application.OpenForms.Cast<Form>().Any(f => f.Name == "cpPostulante"))
                {
                    var f = new cpPostulante();  // Crear una nueva instancia del formulario cpPostulante
                    this.Hide();                  // Ocultar el formulario actual
                    f.Show();                     // Mostrar cpPostulante
                    await Task.Delay(300);        // Pausa breve, si es necesario
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Estás seguro de que quieres salir?", "Confirmar salida",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {

                Application.Exit();
            }
        }
    }
}
