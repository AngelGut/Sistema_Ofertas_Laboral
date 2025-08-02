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
            await NavegarA(materialTabControl1.SelectedIndex);
        }

        private async Task NavegarA(int idx)
        {
            // A) ¿A qué ventana ir?
            Form destino = idx switch
            {
                0 => Application.OpenForms.OfType<Menu>()
                                          .FirstOrDefault() ?? new Menu(),

                // Evitamos duplicar instancias si ya estamos ahí
                1 => this is cpOfertas ? this : new cpOfertas(),
                2 => this is cpEmpresa ? this : new cpEmpresa(),
                3 => this is cpPostulante ? this : new cpPostulante(),
                4 => this is cpAsignarEmpleo ? this : new cpAsignarEmpleo(),
                5 => this is cpHistorialMensajes ? this : new cpHistorialMensajes(),
                6 => this is Carnet ? this : new Carnet(),
                7 => this is cpRegistro ? this : new cpRegistro(),
                _ => null
            };

            // B) Si ya estamos en el destino, no hacemos nada
            if (destino == null || destino == this) return;

            // C) Mostrar el nuevo formulario
            destino.Show();

            // D) Menu nunca se cierra; los demás se liberan
            if (this is Menu)
                this.Hide();     // se mantiene en memoria
            else
                this.Dispose();  // libera recursos

            await Task.Delay(180); // Pausa opcional, transición suave
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

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarUsuarios registrarForm = new RegistrarUsuarios();

            // Mostrar el formulario de registro
            registrarForm.Show();

            // Si quieres ocultar el formulario actual (Menu) mientras está abierto el formulario de registro
            this.Hide();
        }
    }
}
