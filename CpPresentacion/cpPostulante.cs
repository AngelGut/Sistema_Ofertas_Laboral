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
            materialTabControl5.SelectedIndex = 3;

            // Mejora visual: habilitar doble búfer para reducir parpadeos
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // Asociar validaciones a los TextBox
            TxtTelefono.KeyPress += SoloNumeros_KeyPress;
            TxtDni.KeyPress += SoloLetrasYNumeros_KeyPress;

            CargarPersonas(); // <-- aquí lo puedes invocar también
            CargarOfertas(); // Llama al método que llenará el ComboBox con las ofertas
            
        }




        private async void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice de la pestaña seleccionada
            int selectedIndex = materialTabControl5.SelectedIndex;

            // Si se selecciona la pestaña 0 (Menu) y no estamos ya en Menu
            if (selectedIndex == 0 && !(this is Menu))
            {
                var f = new Menu();  // Crear una nueva instancia del formulario Menu sin rol
                f.Show();            // Mostrar el formulario Menu

                await Task.Delay(300);  // Espera breve para suavizar
                this.Dispose();         // Liberar el formulario actual
            }
            // Si se selecciona la pestaña 1 (cpOfertas) y no estamos ya en cpOfertas
            else if (selectedIndex == 1 && !(this is cpOfertas))
            {
                var f = new cpOfertas();  // Crear nueva instancia del formulario cpOfertas sin rol
                f.Show();                  // Mostrar el formulario
                await Task.Delay(300);     // Espera para transición
                this.Dispose();            // Liberar el formulario actual
            }
            // Si se selecciona la pestaña 2 (cpEmpresa) y no estamos ya en cpEmpresa
            else if (selectedIndex == 2 && !(this is cpEmpresa))
            {
                var f = new cpEmpresa();  // Crear nueva instancia del formulario cpEmpresa sin rol
                f.Show();                 // Mostrar el formulario
                await Task.Delay(300);    // Espera breve
                this.Dispose();           // Liberar el formulario actual
            }
            // Si se selecciona la pestaña 3 (cpPostulante) y no estamos ya en cpPostulante
            else if (selectedIndex == 3 && !(this is cpPostulante))
            {
                var f = new cpPostulante();  // Crear nueva instancia del formulario cpPostulante sin rol
                f.Show();                    // Mostrar el formulario
                await Task.Delay(300);       // Espera breve
                this.Dispose();              // Liberar el formulario actual
            }
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

                // ✅ Validar que se haya seleccionado una oferta
                if (CboxOfertas.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar una oferta para el postulante.", "Falta oferta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                int ofertaId = (int)CboxOfertas.SelectedValue;
                var persona = new Persona(nombre, telefono, correo, direccion, dni, ofertaId);

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

            CargarPersonas(); // Refrescar el DataGridView con los nuevos datos
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
                // Llamada al método que verifica si el DNI ya está registrado en la base de datos
                bool existe = CpNegocio.servicios.MetodosPersona.PersonaYaExiste(dniTexto);

                // Si el DNI ya está registrado, mostramos un mensaje de advertencia
                if (existe)
                {
                    MessageBox.Show("Este DNI ya está registrado.", "DNI Ocupado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                // Si el DNI no está registrado, mostramos un mensaje de éxito
                else
                {
                    MessageBox.Show("El DNI está disponible.", "DNI Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Si ocurre un error en la consulta, mostramos el mensaje de error
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
                var persona = new Persona();
                var servicio = new CpNegocio.servicios.MetodosPersona(persona);
                DataTable tabla = servicio.Buscar();

                DgvPersonas.DataSource = tabla;

                // Ocultar columnas no necesarias
                if (DgvPersonas.Columns.Contains("Id"))
                    DgvPersonas.Columns["Id"].Visible = false;

                if (DgvPersonas.Columns.Contains("OfertaId"))
                    DgvPersonas.Columns["OfertaId"].Visible = false;

                // Cambiar encabezados para hacerlo más claro
                if (DgvPersonas.Columns.Contains("NombreOferta"))
                    DgvPersonas.Columns["NombreOferta"].HeaderText = "Oferta asignada";

                if (DgvPersonas.Columns.Contains("Nombre"))
                    DgvPersonas.Columns["Nombre"].HeaderText = "Nombre";

                if (DgvPersonas.Columns.Contains("Cedula"))
                    DgvPersonas.Columns["Cedula"].HeaderText = "Cédula";

                if (DgvPersonas.Columns.Contains("Telefono"))
                    DgvPersonas.Columns["Telefono"].HeaderText = "Teléfono";

                if (DgvPersonas.Columns.Contains("Correo"))
                    DgvPersonas.Columns["Correo"].HeaderText = "Correo";

                if (DgvPersonas.Columns.Contains("Direccion"))
                    DgvPersonas.Columns["Direccion"].HeaderText = "Dirección";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar personas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, teclas de control (como backspace) y espacio
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Bloquea la tecla
                MessageBox.Show("Solo se permiten letras en este campo.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarOfertas()
        {
            try
            {
                var servicio = new CpNegocio.servicios.MetodosOferta();
                var lista = servicio.ObtenerTodas();

                CboxOfertas.DataSource = lista;
                CboxOfertas.DisplayMember = "Puesto";  // Muestra el nombre del puesto
                CboxOfertas.ValueMember = "Id";        // Guarda el ID de la oferta internamente
                CboxOfertas.SelectedIndex = -1;        // No seleccionar nada por defecto
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las ofertas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }
    }
}
