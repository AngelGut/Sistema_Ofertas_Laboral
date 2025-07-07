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

namespace CpPresentacion
{
    public partial class cpEmpresa : MaterialForm // <<== ¡Cambiado a MaterialForm!
    {
        public cpEmpresa()
        {
            InitializeComponent();

            // Establece el tab activo que corresponde a este formulario
            materialTabControl1.SelectedIndex = 2;

            // Mejora visual: habilitar doble búfer para reducir parpadeos
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // Asociar evento KeyPress para bloquear letras y espacios en los campos numéricos
            TxtTelefono.KeyPress += SoloNumeros_KeyPress;
            TxtRnc.KeyPress += SoloNumeros_KeyPress;


            CargarEmpresas();
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
                f.Show();                 // Mostrar cpOfertas

                await Task.Delay(300);    // Espera para suavizar
                this.Dispose();           // Liberar cpEmpresa
            }

            // Si se selecciona la pestaña 3 (cpPostulante) y no estamos ya en cpPostulante
            else if (selectedIndex == 3 && !(this is cpPostulante))
            {
                var f = new cpPostulante();  // Crear nueva instancia del formulario cpPostulante
                f.Show();                    // Mostrar el formulario

                await Task.Delay(300);       // Espera breve
                this.Dispose();              // Liberar cpEmpresa
            }

            // Si se selecciona la pestaña 2 (cpEmpresa), no se hace nada porque ya estamos aquí
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
            string rncTexto = TxtRnc.Text.Trim(); // Obtenemos el texto del TextBox

            // Validar que solo contenga dígitos
            if (!rncTexto.All(char.IsDigit))
            {
                MessageBox.Show("Favor ingresar solo números en el RNC, sin guiones ni símbolos.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Llamamos al método que verifica existencia por RNC
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
