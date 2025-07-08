using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CpNegocio.Entidades;
using MaterialSkin.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CpNegocio.servicios;

namespace CpPresentacion
{
    public partial class cpPostulante : MaterialForm
    {
        public cpPostulante()
        {
            InitializeComponent();

            // Establece el tab activo que corresponde a este formulario
            materialTabControl1.SelectedIndex = 3;

            // Mejora visual: habilitar doble búfer para reducir parpadeos
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // Asociar validaciones a los TextBox
            TxtTelefono.KeyPress += SoloNumeros_KeyPress;
            TxtDni.KeyPress += SoloLetrasYNumeros_KeyPress;

            CargarPersonas(); // <-- aquí lo puedes invocar también
        }

        private async void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice de la pestaña seleccionada
            int selectedIndex = materialTabControl1.SelectedIndex;

            // Si se selecciona la pestaña 0 (Menu) y no estamos ya en Menu
            if (selectedIndex == 0 && !(this is Menu))
            {
                var f = new Menu();   // Crear una nueva instancia del formulario Menu
                f.Show();             // Mostrar el formulario Menu

                await Task.Delay(300); // Espera breve para suavizar
                this.Dispose();        // Liberar el formulario secundario actual

            }


            // Si se selecciona la pestaña 1 (cpOfertas) y no estamos ya en cpOfertas
            else if (selectedIndex == 1 && !(this is cpOfertas))
            {
                var f = new cpOfertas();  // Crear nueva instancia del formulario cpOfertas
                f.Show();                 // Mostrar el formulario

                await Task.Delay(300);    // Espera para transición
                this.Dispose();           // Liberar cpPostulante
            }

            // Si se selecciona la pestaña 2 (cpEmpresa) y no estamos ya en cpEmpresa
            else if (selectedIndex == 2 && !(this is cpEmpresa))
            {
                var f = new cpEmpresa();  // Crear nueva instancia del formulario cpEmpresa
                f.Show();                 // Mostrar el formulario

                await Task.Delay(300);    // Espera breve
                this.Dispose();           // Liberar cpPostulante
            }

            // Si se selecciona la pestaña 3 (cpPostulante), no se hace nada porque ya estamos aquí
        }

        private void cpPostulante_Load(object sender, EventArgs e)
        {

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validar que todos los campos estén llenos
                if (string.IsNullOrWhiteSpace(TxtNombre.Text) ||
                    string.IsNullOrWhiteSpace(TxtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(TxtCorreo.Text) ||
                    string.IsNullOrWhiteSpace(TxtDireccion.Text) ||
                    string.IsNullOrWhiteSpace(TxtDni.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios. Por favor, complete la información.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Leer valores
                string nombre = TxtNombre.Text.Trim();
                string telefono = TxtTelefono.Text.Trim();
                string correo = TxtCorreo.Text.Trim();
                string direccion = TxtDireccion.Text.Trim();
                string dni = TxtDni.Text.Trim();

                // 3. Validar que el teléfono contenga solo dígitos
                if (!telefono.All(char.IsDigit))
                {
                    TxtTelefono.BackColor = Color.MistyRose;
                    MessageBox.Show("El teléfono debe contener solo números, sin guiones, letras ni espacios.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. Validar que el DNI contenga solo letras o dígitos (ya se bloqueó con KeyPress, esto es solo doble validación)
                if (!dni.All(char.IsLetterOrDigit))
                {
                    TxtDni.BackColor = Color.MistyRose;
                    MessageBox.Show("El DNI solo puede contener letras y números, sin espacios ni símbolos.", "DNI inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 5. Validar correo
                if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    TxtCorreo.BackColor = Color.MistyRose;
                    MessageBox.Show("Ingrese un correo electrónico válido (ejemplo@dominio.com).", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 6. Crear objeto Persona (ajusta esto a tu clase real si se llama CnPersona o similar)
                var persona = new Persona(nombre, telefono, correo, direccion, dni);

                // 7. Guardar usando tu capa de negocio
                var servicio = new CpNegocio.servicios.MetodosPersona(persona);
                servicio.Registrar();

                // 8. Mostrar éxito
                MessageBox.Show("Postulante registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 9. Limpiar campos
                TxtNombre.Clear();
                TxtTelefono.Clear();
                TxtCorreo.Clear();
                TxtDireccion.Clear();
                TxtDni.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar al postulante: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarPersonas(); // recarga el DataGridView
        }

        private void BtnValidar_Click(object sender, EventArgs e)
        {
            string dniTexto = TxtDni.Text.Trim(); // El TextBox de la cédula/pasaporte

            // Validar que no esté vacío
            if (string.IsNullOrWhiteSpace(dniTexto))
            {
                MessageBox.Show("Por favor, ingrese un número de cédula o pasaporte.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool existe = CpNegocio.servicios.MetodosPersona.PersonaYaExiste(dniTexto);

                if (existe)
                {
                    MessageBox.Show("Este DNI ya está registrado.", "DNI Ocupado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("El DNI está disponible.", "DNI Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar el DNI: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Permite solo números y teclas de control (ej: backspace)
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquea letras, símbolos y espacios
            }
        }

        // Permite letras y números, pero bloquea espacios y símbolos
        private void SoloLetrasYNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquea cualquier carácter que no sea letra o número
            }
        }

        private void CargarPersonas()
        {
            try
            {
                // Ajusta la inicialización de MetodosPersona para incluir el parámetro requerido.
                var persona = new Persona(); // Crea una instancia de Persona con valores predeterminados o ajustados.
                var servicio = new CpNegocio.servicios.MetodosPersona(persona); // Pasa la instancia de Persona como argumento.

                DataTable tabla = servicio.Buscar(); // método que devuelve todas las personas
                DgvPersonas.DataSource = tabla;      // tu DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar personas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
