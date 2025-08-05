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
using CpNegocio.Entidades;
using System.Text.RegularExpressions;
using CpNegocio;
using CpNegocio.servicios;

namespace CpPresentacion
{
    public partial class cpEmpresa : MaterialForm // <<== ¡Cambiado a MaterialForm!
    {

        public cpEmpresa()
        {
            InitializeComponent();

            // Establece el tab activo que corresponde a este formulario
            materialTabControl1.SelectedIndex = 2;

            /* ---- Pestaña activa de “Empresas” (0-Menú, 1-Ofertas, 2-Empresas …) ---- */
            materialTabControl1.SelectedIndex = 2;

            /* ---- Mejoras visuales / validaciones originales ---- */
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // Asociar evento KeyPress para bloquear letras y espacios en los campos numéricos
            TxtTelefono.KeyPress += SoloNumeros_KeyPress;
            TxtRnc.KeyPress += SoloNumeros_KeyPress;


            CargarEmpresas();
        }


        //TODO: navegacion
        /* ══════════════════════  N A V E G A C I Ó N  ═════════════════════ */

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




        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validar que ningún campo esté vacío
                if (string.IsNullOrWhiteSpace(TxtNombreCompania.Text) ||
                    string.IsNullOrWhiteSpace(TxtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(TxtCorreo.Text) ||
                    string.IsNullOrWhiteSpace(TxtDireccion.Text) ||
                    string.IsNullOrWhiteSpace(TxtRnc.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios. Por favor, complete la información.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Leer datos desde los TextBox
                string nombre = TxtNombreCompania.Text.Trim();
                string telefono = TxtTelefono.Text.Trim().Replace(" ", ""); // ❌ quitar espacios
                string correo = TxtCorreo.Text.Trim();
                string direccion = TxtDireccion.Text.Trim();
                string rncTexto = TxtRnc.Text.Trim().Replace(" ", ""); // ❌ quitar espacios

                // 3. Validar que el RNC contenga solo dígitos (sin espacios ni símbolos)
                if (!rncTexto.All(char.IsDigit))
                {
                    MessageBox.Show("El RNC debe contener solo números, sin espacios ni símbolos.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. Validar teléfono: solo números
                if (!telefono.All(char.IsDigit))
                {
                    TxtTelefono.BackColor = Color.MistyRose;
                    MessageBox.Show("El teléfono debe contener solo números, sin espacios ni letras.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 5. Validar que el correo tenga un formato correcto con expresión regular
                if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    TxtCorreo.BackColor = Color.MistyRose;
                    MessageBox.Show("Ingrese un correo electrónico válido (ejemplo@dominio.com).", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 6. Crear el objeto empresa usando el constructor con RNC tipo string
                CnEmpresa empresa = new CnEmpresa(nombre, telefono, correo, direccion, rncTexto);

                // 7. Instanciar el servicio y registrar la empresa
                CpNegocio.servicios.CnMetodosEmpresa servicio = new CpNegocio.servicios.CnMetodosEmpresa(empresa);
                servicio.Registrar();

                // 8. Mostrar mensaje de éxito
                MessageBox.Show("Empresa registrada correctamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 9. Limpiar los campos del formulario
                TxtNombreCompania.Clear();
                TxtTelefono.Clear();
                TxtCorreo.Clear();
                TxtDireccion.Clear();
                TxtRnc.Clear();

                // 10. (Opcional) Refrescar el DataGridView si lo deseas
                CargarEmpresas();
            }
            catch (Exception ex)
            {
                // 11. Mostrar cualquier error durante el proceso
                MessageBox.Show("Error al registrar la empresa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnValidar_Click(object sender, EventArgs e)
        {
            string rncTexto = TxtRnc.Text.Trim(); // El TextBox del RNC

            // Validar que no esté vacío
            if (string.IsNullOrWhiteSpace(rncTexto))
            {
                MessageBox.Show("Por favor, ingrese un RNC.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Llamar al método que recibe string directamente
                bool existe = CpNegocio.servicios.CnMetodosEmpresa.EmpresaYaExiste(rncTexto);

                if (existe)
                {
                    MessageBox.Show("Este RNC ya está registrado.", "RNC Ocupado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("El RNC está disponible.", "RNC Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar el RNC: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarEmpresas()
        {
            try
            {
                // Creamos una instancia de CnMetodosEmpresa con cualquier objeto empresa (puede ser vacío)
                var servicio = new CpNegocio.servicios.CnMetodosEmpresa(new CnEmpresa());

                // Llenamos la tabla desde la base de datos
                DataTable tabla = servicio.Buscar();

                // Asignamos la tabla al DataGridView
                DgvEmpresas.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empresas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarEmpresas(); // Recarga los datos desde la base de datos
        }

        private void TxtRnc_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir dígitos, teclas de control (como Backspace) y bloquear todo lo demás
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquear letras, símbolos y espacio
            }

            // Bloquear espacio explícitamente (aunque ya está cubierto arriba)
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        
    }
}
