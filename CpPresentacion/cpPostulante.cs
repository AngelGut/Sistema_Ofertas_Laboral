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
using CpPresentacion.Asistencia;   // contiene IReadOnlyContainer y las extensiones


namespace CpPresentacion
{
    public partial class cpPostulante : MaterialForm, IReadOnlyContainer
    {
        private FormBoton _formBoton;   // switch flotante
        public Control Container => this; // Implementación de la interfaz

        public cpPostulante()
        {
            InitializeComponent();

            CargarPaises();
            cmbPaises.SelectedIndexChanged += (s, e) => FormatearTelefono();
            TxtTelefono.TextChanged += (s, e) => FormatearTelefono();

            // Establece el tab activo que corresponde a este formulario
            materialTabControl1.SelectedIndex = 3;

            // Mejora visual: habilitar doble búfer para reducir parpadeos
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // Asociar validaciones a los TextBox
            TxtTelefono.KeyPress += SoloNumeros_KeyPress;
            TxtDni.KeyPress += SoloLetrasYNumeros_KeyPress;

            CargarPersonas(); // <-- aquí lo puedes invocar también

            // 1) Arrancar bloqueado
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

            // 5) Cerrar flotante cuando cierre este form
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

                // Validar número con libphonenumber
                var phoneUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
                if (cmbPaises.SelectedItem is CountryItem cp)
                {
                    try
                    {
                        var parsed = phoneUtil.Parse(TxtTelefono.Text, cp.IsoCode);
                        if (!phoneUtil.IsValidNumber(parsed))
                        {
                            MessageBox.Show("El número de teléfono no es válido para el país seleccionado.", "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        telefono = phoneUtil.Format(parsed, PhoneNumbers.PhoneNumberFormat.INTERNATIONAL);
                    }
                    catch
                    {
                        MessageBox.Show("No se pudo interpretar el número de teléfono.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un país para el número telefónico.", "País no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                if (DgvPersonas.Columns.Contains("Nombre"))
                    DgvPersonas.Columns["Nombre"].HeaderText = "Nombre";

                if (DgvPersonas.Columns.Contains("Dni"))
                    DgvPersonas.Columns["Dni"].HeaderText = "Cédula";

                if (DgvPersonas.Columns.Contains("Telefono"))
                    DgvPersonas.Columns["Telefono"].HeaderText = "Teléfono";

                if (DgvPersonas.Columns.Contains("Correo"))
                    DgvPersonas.Columns["Correo"].HeaderText = "Correo";

                if (DgvPersonas.Columns.Contains("Direccion"))
                    DgvPersonas.Columns["Direccion"].HeaderText = "Dirección";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar personas:\n" +
                    ex.Message +
                    "\n\nDetalle interno:\n" +
                    (ex.InnerException?.Message ?? "(sin detalle)"),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private class CountryItem
        {
            public string IsoCode { get; set; }
            public string Name { get; set; }
            public string DialCode { get; set; }
            public string Display => $"{Name} ({DialCode})";
            public override string ToString() => Display;
        }

        private void CargarPaises()
        {
            var phoneUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
            var regiones = phoneUtil.GetSupportedRegions().OrderBy(iso => iso);

            var lista = regiones.Select(iso =>
            {
                try
                {
                    var region = new System.Globalization.RegionInfo(iso);
                    int code = phoneUtil.GetCountryCodeForRegion(iso);
                    return new CountryItem
                    {
                        IsoCode = iso,
                        Name = region.NativeName,
                        DialCode = "+" + code.ToString()
                    };
                }
                catch
                {
                    return null;
                }
            })
            .Where(ci => ci != null)
            .OrderBy(ci => ci.Name)
            .ToList();

            cmbPaises.DataSource = lista;
            cmbPaises.DisplayMember = "Display";
            cmbPaises.ValueMember = "IsoCode";
        }

        private void FormatearTelefono()
        {
            if (cmbPaises.SelectedItem is not CountryItem cp)
                return;

            var phoneUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();

            try
            {
                var parsed = phoneUtil.Parse(TxtTelefono.Text, cp.IsoCode);

                if (phoneUtil.IsValidNumber(parsed))
                {
                    string formateado = phoneUtil.Format(parsed, PhoneNumbers.PhoneNumberFormat.INTERNATIONAL);
                    TxtTelefono.BackColor = Color.White;
                    System.Windows.Forms.ToolTip tooltip = new System.Windows.Forms.ToolTip();
                    tooltip.SetToolTip(TxtTelefono, formateado);
                }
                else
                {
                    TxtTelefono.BackColor = Color.MistyRose;
                }
            }
            catch
            {
                TxtTelefono.BackColor = Color.MistyRose;
            }
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

                // Origen del form en pantalla
                var p = this.PointToScreen(Point.Empty);

                // AFUERA al lado derecho, centrado vertical
                int x = p.X + this.Width;
                int y = p.Y + (this.Height - _formBoton.Height) / 2;

                // Mantener visible en el monitor del form (evita que se “corte”)
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
