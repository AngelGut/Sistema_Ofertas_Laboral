using CapaNegocio;
using CpNegocio.Empresas_y_Postulantes;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpPresentacion
{
    public partial class cpRegistro : MaterialForm
    {
        public cpRegistro()
        {
            InitializeComponent();
            materialTabControl1.SelectedIndex = 7;
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


        // Guardar el nuevo usuario
        // Guardar el nuevo usuario
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



        // Limpiar los campos del formulario
        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtCorreo.Clear();
            txtContraseña.Clear();
            cmbRol.SelectedIndex = 0;  // Restablecer el ComboBox al primer valor
        }

        // Cancelar el registro y regresar al menú
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
    }
}
