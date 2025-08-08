using CapaNegocio;
using CpNegocio.Empresas_y_Postulantes;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CpPresentacion.Asistencia;

namespace CpPresentacion
{
    public partial class cpRegistro : MaterialForm, IReadOnlyContainer
    {
        public Control Container => this;
        private FormBoton _formBoton;       // switch flotante

        public cpRegistro()
        {
            InitializeComponent();
            materialTabControl1.SelectedIndex = 7;

            // 1) Arrancar bloqueado (modo Ver)
            this.SetReadOnly(true);

            // 2) Mini-form para decidir estado inicial
            bool startInEdit = false;
            using (var dlg = new frmModoVisualizacion())
            {
                if (dlg.ShowDialog() == DialogResult.OK &&
                    dlg.Resultado == frmModoVisualizacion.ResultadoSeleccion.Editar)
                {
                    startInEdit = true;
                }
            }

            // 3) Aplicar estado inicial
            this.SetReadOnly(!startInEdit);

            // 4) Abrir switch flotante (siempre activo)
            AbrirFormBoton(startInEdit);

            // 5) Cerrar el flotante cuando se cierre este form
            this.FormClosed += (s, e) =>
            {
                if (_formBoton != null && !_formBoton.IsDisposed) _formBoton.Close();
                _formBoton = null;
            };
        }

        private async void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            await NavegarA(materialTabControl1.SelectedIndex);
        }

        private async Task NavegarA(int idx)
        {
            Form destino = idx switch
            {
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

            if (destino == null || destino == this) return;

            destino.Show();

            if (this is Menu)
                this.Hide();     // se mantiene en memoria
            else
                this.Dispose();  // libera recursos

            destino.BringToFront();
            destino.Activate();
        }


        // TODO: Guardar el nuevo usuario
        private async void btnGuardar_Click(object sender, EventArgs e)
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
            if (await negocio.CorreoExisteAsync(correo))
            {
                MessageBox.Show("El correo ya está registrado. Por favor, ingrese otro correo.");
                return; // Si el correo ya está registrado, no continuamos
            }

            // Verificar si el nombre de usuario ya está registrado
            if (await negocio.ExisteUsuarioAsync(usuarioNombre))
            {
                MessageBox.Show("El nombre de usuario ya está registrado. Por favor, elija otro nombre de usuario.");
                return; // Si el usuario ya existe, no continuamos
            }

            // Crear el objeto Usuario
            var usuario = new Usuario
            {
                UsuarioNombre = usuarioNombre,
                Correo = correo,
                Clave = clave, // La clave es la que el usuario escribe
                Rol = rol
            };

            // Llamar al método de la capa de negocio para registrar el usuario
            bool registrado = await negocio.RegistrarUsuarioAsync(usuario); // Usamos el método asíncrono

            if (registrado)
            {
                MessageBox.Show("Usuario registrado exitosamente.");
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Hubo un error al registrar el usuario.");
            }
        }



        // TODO: Limpiar los campos del formulario
        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtCorreo.Clear();
            txtContraseña.Clear();
            cmbRol.SelectedIndex = 0;  // Restablecer el ComboBox al primer valor
        }

        // TODO: Cancelar el registro y regresar al menú
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();  // Oculta el formulario de registro

            // Crear una nueva instancia del formulario Menu
            Menu menuForm = new Menu();

            // Mostrar el formulario Menu
            menuForm.Show();
        }

        // Cargar los roles y establecer valores predeterminados
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

        // TODO: Evitar caracteres especiales en el campo 'Usuario'
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Bloquear el carácter
            MessageBox.Show("No se permiten caracteres especiales en el campo 'Usuario'.",
                            "Carácter inválido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
        }

        private void AbrirFormBoton(bool startInEdit)
        {
            if (_formBoton != null && !_formBoton.IsDisposed) return;

            _formBoton = new FormBoton(this, startInEdit)
            {
                StartPosition = FormStartPosition.Manual,
                TopMost = true
            };

            void Reposicionar()
            {
                if (_formBoton == null || _formBoton.IsDisposed) return;

                // Posición del form en pantalla
                var p = this.PointToScreen(Point.Empty);

                // AFUERA, pegado al borde derecho y centrado vertical
                int x = p.X + this.Width;
                int y = p.Y + (this.Height - _formBoton.Height) / 2;

                // Mantener visible en el mismo monitor
                var wa = Screen.FromControl(this).WorkingArea;
                x = Math.Min(Math.Max(x, wa.Left), wa.Right - _formBoton.Width);
                y = Math.Min(Math.Max(y, wa.Top), wa.Bottom - _formBoton.Height);

                _formBoton.Location = new Point(x, y);
            }

            Reposicionar();
            this.Move += (s, e) => Reposicionar();
            this.Resize += (s, e) => Reposicionar();

            _formBoton.FormClosed += (s, e) => _formBoton = null;
            _formBoton.Show(this);
        }
    }
}
