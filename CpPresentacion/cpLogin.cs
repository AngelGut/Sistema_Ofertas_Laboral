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
        private bool showPassword = false;
        private UsuarioNegocio negocio;
        public cpLogin()
        {
            InitializeComponent();
            negocio = new UsuarioNegocio();
            this.KeyPreview = true;  // Asegura que el formulario capture las teclas
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        // TODO: Asegurarse de que los controles como los TextBox y los Labels estén correctamente en el formulario y que sus eventos estén conectados.
        private void cpLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.MaxLength = 20;
            txtClave.MaxLength = 20;
        }

        // Método: btnRecuperarClave_Click
        // Descripción: Permite recuperar la contraseña del usuario y actualizarla en la base de datos.
        private async void btnRecuperarClave_Click(object sender, EventArgs e)
        {
            try
            {
                // Paso 1: Obtener el correo y la nueva contraseña del usuario
                string correo = Microsoft.VisualBasic.Interaction.InputBox("Ingrese su correo electrónico:", "Recuperar contraseña");

                // Paso 2: Validar si el correo no está vacío
                if (string.IsNullOrWhiteSpace(correo))
                {
                    MessageBox.Show("Debe ingresar un correo válido.");
                    return;
                }

                // Paso 3: Pedir la nueva contraseña al usuario
                string nuevaClave = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la nueva contraseña:", "Nueva contraseña");

                // Paso 4: Validar si la nueva contraseña no está vacía
                if (string.IsNullOrWhiteSpace(nuevaClave))
                {
                    MessageBox.Show("Debe ingresar una contraseña válida.");
                    return;
                }

                // Paso 5: Llamar a la capa de negocios para procesar la recuperación
                var negocio = new UsuarioNegocio();
                bool resultado = await negocio.RecuperarClaveAsync(correo, nuevaClave);

                // Mostrar mensaje de éxito
                MessageBox.Show("Contraseña actualizada y enviada al correo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                // Mensajes de validación o errores específicos
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Mensajes de error general
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Método: btnIngresar_Click
        // Descripción: Verifica las credenciales del usuario y, si son correctas, muestra el menú principal.
        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Aseguramos que el Label de Cargando sea visible
                lblCargando.Visible = true;  // Asegúrate de que el Label de "Cargando..." sea visible
                this.Cursor = Cursors.WaitCursor;  // Cambiar el cursor para indicar espera

                // Forzar la actualización de la interfaz de usuario antes de continuar
                Application.DoEvents();  // Actualiza la UI para mostrar el indicador de carga

                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
                {
                    MessageBox.Show("Por favor, ingrese tanto el usuario como la clave.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Llamar al método de login asíncrono
                bool loginExitoso = await negocio.LoginAsync(txtUsuario.Text.Trim(), txtClave.Text.Trim());

                if (loginExitoso)
                {
                    MessageBox.Show("¡Bienvenido al sistema!", "Acceso Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Crear una nueva instancia del formulario Menu sin pasar el rol
                    Menu menuForm = new Menu();
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
                // Manejo de errores en caso de excepciones durante el login
                MessageBox.Show("Error al realizar login: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ocultar el indicador de espera
                lblCargando.Visible = false;  // Ocultar el Label de "Cargando..." después de la operación
                this.Cursor = Cursors.Default;  // Restaurar el cursor original
            }
        }


        // Método: pbCerrar_Click
        // Descripción: Cierra la aplicación cuando se hace clic en el botón de cerrar.
        private void pbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        // Método: pbMinimizar_Click
        // Descripción: Minimiza la ventana de la aplicación cuando se hace clic en el botón de minimizar.
        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; 
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

        // Método: pbPassword_Click
        // Descripción: Permite mostrar u ocultar la contraseña en el campo `txtClave` al hacer clic en el ícono del ojo.
        private void pbPassword_Click(object sender, EventArgs e)
        {
            showPassword = !showPassword;  // Cambia el estado de visibilidad de la contraseña
            if (showPassword)
            {
                txtClave.PasswordChar = '\0';  // Muestra la contraseña
                pbPassword.Image = Properties.Resources.OjoAbierto; // Cambia el ícono a "ojo cerrado"
            }
            else
            {
                txtClave.PasswordChar = '*';  // Oculta la contraseña
                pbPassword.Image = Properties.Resources.OjoCerrado; // Cambia el ícono a "ojo abierto"
            }
        }

        // Método: cpLogin_KeyDown
        // Descripción: Detecta cuando se presiona la tecla Enter para ejecutar el login sin necesidad de hacer clic en el botón.
        private void cpLogin_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica si se presionó la tecla Enter
            if (e.KeyCode == Keys.Enter)
            {
                btnIngresar_Click(sender, e);  // Llama al evento del botón de login
            }
        }
    }
}
