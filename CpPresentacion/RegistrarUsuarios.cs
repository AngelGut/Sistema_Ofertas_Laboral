using CapaNegocio;
using CpNegocio.Empresas_y_Postulantes;
using CpNegocio.ServiciosCorreo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpPresentacion
{
    public partial class RegistrarUsuarios : Form
    {
        public RegistrarUsuarios()
        {
            InitializeComponent();
        }

        // En el evento btnRegistrar_Click del formulario FormRegistro
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string usuarioNombre = txtUsuario.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string clave = txtContraseña.Text.Trim();
            string rol = cmbRol.SelectedItem?.ToString() ?? "";

            // Validaciones
            if (string.IsNullOrEmpty(usuarioNombre) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(clave) || string.IsNullOrEmpty(rol))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            // Crear el objeto Usuario
            var usuario = new Usuario
            {
                UsuarioNombre = usuarioNombre,
                Correo = correo,
                Clave = clave, // La contraseña no está encriptada aún
                Rol = rol
            };

            // Llamar al método de la capa de negocio para registrar el usuario
            var negocio = new UsuarioNegocio();
            bool registrado = negocio.RegistrarUsuario(usuario);  // Llamamos al método de registro

            if (registrado)
            {
                MessageBox.Show("Usuario registrado exitosamente.");

                // Enviar el correo de bienvenida
                EnviarCorreoBienvenida(correo, usuarioNombre, clave);

                // Ocultar el formulario de registro (no cerrarlo)
                this.Hide();  // Esto oculta el formulario de registro

                // Crear y mostrar el formulario Menu
                Menu menuForm = new Menu();
                menuForm.Show();  // Mostrar el formulario Menu
            }
            else
            {
                MessageBox.Show("Hubo un error al registrar el usuario.");
            }
        }


        private void EnviarCorreoBienvenida(string correo, string usuarioNombre, string clave)
        {
            // Crear el mensaje de correo
            string asunto = "Bienvenido a nuestro sistema de Ofertas Laborales";
            string cuerpo = $"Hola {usuarioNombre},<br><br>" +
                            $"Gracias por registrarte en nuestro sistema. A continuación te proporcionamos tu información de acceso:<br>" +
                            $"<b>Usuario:</b> {usuarioNombre}<br>" +
                            $"<b>Contraseña:</b> {clave}<br><br>" +
                            $"¡Disfruta de los servicios!";

            // Usar la clase ServiciosCorreo para enviar el mensaje
            var correoServicio = new ServiciosCorreo(
                "ofertaslaboralesuce@gmail.com",    // Remitente
                "xskfnxncewwumili",                 // Contraseña del remitente
                "smtp.gmail.com",                   // Servidor SMTP
                587,                                // Puerto SMTP
                true                                // SSL
            );

            // Enviar el correo
            bool enviado = correoServicio.EnviarCorreo(asunto, cuerpo, new List<string> { correo });

            if (enviado)
            {
                MessageBox.Show("Correo de bienvenida enviado al usuario.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Hubo un error al enviar el correo de bienvenida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario de registro
            this.Close();

            // Crear una nueva instancia del formulario Menu
            Menu menuForm = new Menu();

            // Mostrar el formulario Menu
            menuForm.Show();
        }

        private void RegistrarUsuarios_Load(object sender, EventArgs e)
        {
            // Cargar los roles disponibles en el ComboBox
            cmbRol.Items.Add("Administrador");
            cmbRol.Items.Add("Usuario");
            cmbRol.SelectedIndex = 0; // Seleccionar el primer rol por defecto
            txtUsuario.MaxLength = 20;
            txtContraseña.MaxLength = 20;
        }
    }
}
