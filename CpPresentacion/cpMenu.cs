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
        public Menu(string rol)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Bloquea redimensionamiento

            // Establece el tab activo que corresponde a este formulario
            materialTabControl1.SelectedIndex = 0;

            // Mejora visual: habilitar doble búfer para reducir parpadeos
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.rolUsuario = rolUsuario;
            ConfigurarMenuPorRol();
            rolUsuario = rol;
        }

        private void ConfigurarMenuPorRol()
        {
            if (rolUsuario == "Admin")
            {
                // Habilitar todas las pestañas para el Admin
                materialTabControl1.TabPages[1].Enabled = true;  // cpOfertas
                materialTabControl1.TabPages[2].Enabled = true;  // cpEmpresa
                materialTabControl1.TabPages[3].Enabled = true;  // cpPostulante
            }
            else if (rolUsuario == "Usuario")
            {
                // Para el usuario normal, deshabilitamos opciones avanzadas
                materialTabControl1.TabPages[2].Enabled = false;  // cpEmpresa (deshabilitado)
                materialTabControl1.TabPages[3].Enabled = false;  // cpPostulante (deshabilitado)
            }
        }


        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        //Este método debe marcarse como async para poder usar 'await Task.Delay(...)'
        private async void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = materialTabControl1.SelectedIndex;

            // Si se selecciona cpOfertas (índice 1) y no estamos ya en cpOfertas
            if (selectedIndex == 1 && !(this is cpOfertas))
            {
                if (rolUsuario == "Admin")
                {
                    var f = new cpOfertas(rolUsuario);  // Crear formulario cpOfertas
                    this.Hide();                         // Ocultar Menu (NO se cierra)
                    f.Show();                            // Mostrar cpOfertas

                    await Task.Delay(300);  // Espera breve para transición fluida
                }
                else
                {
                    MessageBox.Show("Acceso denegado. Solo los administradores pueden acceder a esta sección.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    materialTabControl1.SelectedIndex = 0;  // Volver a la pestaña de inicio (Menu)
                }
            }

            // Si se selecciona cpEmpresa (índice 2) y no estamos ya en cpEmpresa
            else if (selectedIndex == 2 && !(this is cpEmpresa))
            {
                if (rolUsuario == "Admin")
                {
                    var f = new cpEmpresa(rolUsuario);  // Crear formulario cpEmpresa
                    this.Hide();                         // Ocultar Menu
                    f.Show();                            // Mostrar cpEmpresa

                    await Task.Delay(300);
                }
                else
                {
                    MessageBox.Show("Acceso denegado. Solo los administradores pueden acceder a esta sección.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    materialTabControl1.SelectedIndex = 0;  // Volver a la pestaña de inicio (Menu)
                }
            }

            // Si se selecciona cpPostulante (índice 3) y no estamos ya en cpPostulante
            else if (selectedIndex == 3 && !(this is cpPostulante))
            {
                var f = new cpPostulante(rolUsuario);  // Crear formulario cpPostulante
                this.Hide();                            // Ocultar Menu
                f.Show();                               // Mostrar cpPostulante

                await Task.Delay(300);
            }

            // Si se selecciona el índice 0 (Menu), no se hace nada, ya estamos aquí
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
