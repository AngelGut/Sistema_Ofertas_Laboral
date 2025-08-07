using CapaNegocio;
using CpNegocio.Empresas_y_Postulantes;
using CpNegocio.ServiciosCorreo;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CpPresentacion.Asistencia;   // contiene IReadOnlyContainer y las extensiones

namespace CpPresentacion
{
    public partial class cpRegistro : MaterialForm, IReadOnlyContainer
    {
        public Control Container => this;
        private FormBoton paleta;

        public cpRegistro()
        {
            InitializeComponent();

            materialTabControl1.SelectedIndex = 7;

            // ── 1) Mostrar modal Ver / Editar ───────────────────────────────
            bool editarModo = false;                           // valor por defecto
            using (var dlg = new frmModoVisualizacion())
            {
                if (dlg.ShowDialog() == DialogResult.OK &&
                    dlg.Resultado == frmModoVisualizacion.ResultadoSeleccion.Editar)
                {
                    editarModo = true;                         // eligió Editar
                }
            }

            // ── 2) Aplicar estado inicial al formulario ─────────────────────
            this.SetReadOnly(!editarModo);                    // true = bloquear

            // ── 3) Crear paleta flotante y sincronizar switch ───────────────
            paleta = new FormBoton(this, editarModo)          // ← pasa estado
            {
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                StartPosition = FormStartPosition.Manual,
                TopMost = true,
                ShowInTaskbar = false
            };
            PositionPaleta();
            paleta.Show(this);

            // Reposicionar si mueves / redimensionas
            LocationChanged += (s, e) => PositionPaleta();
            SizeChanged += (s, e) => PositionPaleta();
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
                // Siempre nueva instancia de Menu
                0 => new Menu(),
                1 => this is cpOfertas ? this : new cpOfertas(),
                2 => this is cpEmpresa ? this : new cpEmpresa(),
                3 => this is cpPostulante ? this : new cpPostulante(),
                4 => this is cpAsignarEmpleo ? this : new cpAsignarEmpleo(),
                5 => this is cpHistorialMensajes ? this : new cpHistorialMensajes(),
                6 => this is Carnet ? this : new Carnet(),
                7 => this is cpRegistro ? this : new cpRegistro(),
                8 => this is cpHistorialPostulaciones ? this : new cpHistorialPostulaciones(),
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

            // Asegurarnos de que la UI repinte inmediatamente:
            destino.BringToFront();
            destino.Activate();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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

            // Verificar si el correo ya está registrado
            var negocio = new UsuarioNegocio();
            if (negocio.CorreoExiste(correo))
            {
                MessageBox.Show("El correo ya está registrado. Por favor, ingrese otro correo.");
                return; // Si el correo ya está registrado, no continuamos
            }

            // Verificar si el nombre de usuario ya está registrado
            if (negocio.ExisteUsuario(usuarioNombre))
            {
                MessageBox.Show("El nombre de usuario ya está registrado. Por favor, elija otro nombre de usuario.");
                return; // Si el usuario ya existe, no continuamos
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
            bool registrado = negocio.RegistrarUsuario(usuario);

            if (registrado)
            {
                MessageBox.Show("Usuario registrado exitosamente.");

                // Enviar el correo con la nueva cuenta
                EnviarCorreoBienvenida(correo, usuarioNombre, clave);
                
                // Limpiar los campos de texto
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Hubo un error al registrar el usuario.");
            }
        }

        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtCorreo.Clear();
            txtContraseña.Clear();
            cmbRol.SelectedIndex = 0;  // Restablecer el ComboBox al primer valor (puedes cambiar esto si prefieres otro valor por defecto)
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
            this.Hide();  // Oculta el formulario RegistrarUsuarios

            // Crear una nueva instancia del formulario Menu
            Menu menuForm = new Menu();

            // Mostrar el formulario Menu
            menuForm.Show(); 
        }

        private void cpRegistro_Load(object sender, EventArgs e)
        {
            // Cargar los roles disponibles en el ComboBox
            cmbRol.Items.Add("Administrador");
            cmbRol.Items.Add("Usuario");

            // Establecer el primer rol como seleccionado por defecto
            cmbRol.SelectedIndex = 0;  // Puedes cambiar el índice si prefieres otro rol seleccionado

            // Establecer la longitud máxima para los campos de texto
            txtUsuario.MaxLength = 20;
            txtContraseña.MaxLength = 20;
        }

        private void PositionPaleta()
            => paleta.Location = new Point(Right + 10, Top);
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            paleta?.Close();
            base.OnFormClosing(e);
        }
    }
}
