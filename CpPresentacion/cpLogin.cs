using CapaDatos;
using CapaNegocio;
using CpNegocio.ServiciosCorreo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpPresentacion
{
    public partial class cpLogin : Form
    {

        private UsuarioNegocio negocio;
        public cpLogin()
        {
            InitializeComponent();
            negocio = new UsuarioNegocio();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void cpLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.MaxLength = 20; // Establece el máximo de caracteres para el campo de usuario
            txtClave.MaxLength = 20;
        }

        private void btnRecuperarClave_Click(object sender, EventArgs e)
        {
            string correo = Microsoft.VisualBasic.Interaction.InputBox("Ingrese su correo electrónico:", "Recuperar contraseña");

            if (string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("Debe ingresar un correo válido.");
                return;
            }

            // Verificar si el correo existe en la base de datos
            if (!DatosUsuario.ExisteCorreo(correo))
            {
                MessageBox.Show("El correo no está registrado en el sistema.");
                return;
            }

            // Pedir la nueva contraseña al usuario
            string nuevaClave = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la nueva contraseña:", "Nueva contraseña");

            if (string.IsNullOrWhiteSpace(nuevaClave))
            {
                MessageBox.Show("Debe ingresar una contraseña válida.");
                return;
            }

            // Actualizar la contraseña en la base de datos
            bool actualizado = DatosUsuario.CambiarClave(correo, nuevaClave);

            if (actualizado)
            {
                // Enviar correo con la nueva contraseña
                var correoServicio = new ServiciosCorreo(
                    "ofertaslaboralesuce@gmail.com",    // Remitente
                    "xskfnxncewwumili",                 // Contraseña del remitente
                    "smtp.gmail.com",                   // Servidor SMTP
                    587,                                // Puerto
                    true                                // SSL
                );

                string asunto = "Confirmación de cambio de contraseña";
                string cuerpo = $"Hola,<br>Tu contraseña ha sido cambiada exitosamente.<br><b>Nueva contraseña:</b> {nuevaClave}";

                bool enviado = correoServicio.EnviarCorreo(asunto, cuerpo, new List<string> { correo });

                if (enviado)
                {
                    MessageBox.Show("Contraseña actualizada y enviada al correo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Contraseña actualizada, pero no se pudo enviar el correo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string rol = "";

            try
            {
                if (negocio.Login(txtUsuario.Text.Trim(), txtClave.Text.Trim(), ref rol))
                {
                    MessageBox.Show("Bienvenido al sistema");
                    Menu menuForm = new Menu(rol);
                    menuForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o clave incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar login: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }




        private void pbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra la aplicación al hacer clic en el botón de cerrar
        }

        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // Minimiza la ventana al hacer clic en el botón de minimizar
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtClave_Enter(object sender, EventArgs e)
        {
            // Si el campo tiene el texto por defecto, lo eliminamos y configuramos para que sea oculto
            if (txtClave.Text == "CONTRASEÑA")
            {
                txtClave.Text = "";
                txtClave.ForeColor = Color.Black;  // Cambiar color del texto a blanco
                txtClave.UseSystemPasswordChar = true;  // Ocultar la contraseña (asteriscos)
            }
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            if (txtClave.Text == "")
            {
                txtClave.Text = "CONTRASEÑA";
                txtClave.ForeColor = Color.Black;  // Color de texto por defecto
                txtClave.UseSystemPasswordChar = false; // No ocultar la contraseña
            }
        }

        private void cpLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
