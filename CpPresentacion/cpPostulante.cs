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

            //TODO: Llamar al método de personalización del DataGridView
            PersonalizarDataGridView();


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
            // Establecer valores predeterminados para el control chkExtranjero
            if (chkExtranjero.Checked)
            {
                // Si el checkbox está marcado, configurar como pasaporte
                TxtDni.MaxLength = 50; // Para pasaporte
                TxtDni.Clear();  // Limpiar el campo
                lblDniPlaceholder.Text = "Pasaporte Extranjero"; // Texto del placeholder
            }
            else
            {
                // Si el checkbox no está marcado, configurar como cédula
                TxtDni.MaxLength = 9;  // Limitar a 9 caracteres para la cédula
                lblDniPlaceholder.Text = "Cédula nacional";  // Texto del placeholder
            }

            // Hacer visible el "placeholder"
            lblDniPlaceholder.Visible = true;

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos estén llenos
                if (string.IsNullOrWhiteSpace(TxtNombre.Text) ||
                    string.IsNullOrWhiteSpace(TxtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(TxtCorreo.Text) ||
                    string.IsNullOrWhiteSpace(TxtDireccion.Text) ||
                    string.IsNullOrWhiteSpace(TxtDni.Text))  // Verificar que DNI no esté vacío
                {
                    MessageBox.Show("Todos los campos son obligatorios. Por favor, complete la información.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Leer valores
                string nombre = TxtNombre.Text.Trim();
                string telefono = TxtTelefono.Text.Trim();
                string correo = TxtCorreo.Text.Trim();
                string direccion = TxtDireccion.Text.Trim();
                string dni = TxtDni.Text.Trim();

                // Validación del teléfono con la librería libphonenumber
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

                // Validación de DNI
                if (chkExtranjero.Checked)
                {
                    // Si es extranjero, no validamos el formato del DNI (permitimos texto libre)
                    if (dni.Length < 3) // Solo para asegurarse de que el campo no esté vacío
                    {
                        MessageBox.Show("Por favor, ingrese un pasaporte válido.", "DNI/Pasaporte inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    // Si no es extranjero, validamos la cédula (11 dígitos)
                    if (!Regex.IsMatch(dni, @"^\d{11}$"))
                    {
                        MessageBox.Show("La cédula debe ser de 11 dígitos.", "Cédula inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Validación de correo
                if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Ingrese un correo electrónico válido (ejemplo@dominio.com).", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear el objeto Persona
                var persona = new Persona(nombre, telefono, correo, direccion, dni);  // No se pasa TipoPersona

                // Guardar en la base de datos
                var servicio = new CpNegocio.servicios.MetodosPersona(persona);
                servicio.Registrar();

                // Mostrar mensaje de éxito
                MessageBox.Show("Postulante registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos
                TxtNombre.Clear();
                TxtTelefono.Clear();
                TxtCorreo.Clear();
                TxtDireccion.Clear();
                TxtDni.Clear();
                chkExtranjero.Checked = false;  // Desmarcar "Extranjero" después del registro

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar al postulante: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CargarPersonas();  // Refrescar la lista de personas
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

        private void chkExtranjero_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExtranjero.Checked)
            {
                // Si el usuario es extranjero, no limitamos la longitud ni el formato del DNI
                TxtDni.MaxLength = 50; // O lo que creas conveniente para un pasaporte
                TxtDni.Clear();  // Limpiar el campo

                // Cambiar el texto del Label como el placeholder
                lblDniPlaceholder.Text = "Pasaporte Extranjero";
                lblDniPlaceholder.Visible = true;  // Mostrar el "placeholder"
            }
            else
            {
                // Si no es extranjero, validamos la cédula, y restringimos la longitud
                TxtDni.MaxLength = 9; // Limitar a 9 caracteres para la cédula
                lblDniPlaceholder.Text = "Cédula nacional"; // Texto placeholder de cédula
                lblDniPlaceholder.Visible = true;  // Mostrar el "placeholder"
            }

        }

        private void TxtDni_Enter(object sender, EventArgs e)
        {
            // Si el TextBox tiene texto, ocultamos el Label (placeholder)
            if (!string.IsNullOrWhiteSpace(TxtDni.Text))
            {
                lblDniPlaceholder.Visible = false;
            }

        }

        private void TxtDni_Leave(object sender, EventArgs e)
        {
            // Si el TextBox está vacío, mostramos el Label como placeholder
            if (string.IsNullOrWhiteSpace(TxtDni.Text))
            {
                lblDniPlaceholder.Visible = true;
            }

        }

        private void PersonalizarDataGridView()
        {
            // Cambiar el color de fondo general del DataGridView
            DgvPersonas.BackgroundColor = Color.FromArgb(240, 248, 255); // Azul muy suave, estilo "Azure"

            // Personalizar el color de los encabezados de las columnas
            DgvPersonas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204); // Azul oscuro
            DgvPersonas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DgvPersonas.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            DgvPersonas.ColumnHeadersHeight = 40;

            // Cambiar el color de las filas
            DgvPersonas.RowsDefaultCellStyle.BackColor = Color.White;
            DgvPersonas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 255); // Azul suave en filas alternas
            DgvPersonas.RowsDefaultCellStyle.ForeColor = Color.Black;

            // Cambiar el color del borde del DataGridView
            DgvPersonas.BorderStyle = BorderStyle.FixedSingle;
            DgvPersonas.GridColor = Color.FromArgb(200, 200, 200); // Gris claro para las líneas de la cuadrícula

            // Personalizar las celdas
            DgvPersonas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204); // Azul oscuro cuando se selecciona
            DgvPersonas.DefaultCellStyle.SelectionForeColor = Color.White; // Texto blanco cuando se selecciona

            // Personalizar las celdas al pasar el ratón (Hover)
            DgvPersonas.CellMouseEnter += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DgvPersonas.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(173, 216, 230); // Azul claro cuando el mouse pasa
                }
            };

            DgvPersonas.CellMouseLeave += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DgvPersonas.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White; // Vuelve a blanco
                }
            };

            // Personalizar la fuente de las celdas
            DgvPersonas.DefaultCellStyle.Font = new Font("Arial", 9);

            // Personalizar las filas de la cabecera al ser seleccionadas
            DgvPersonas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvPersonas.MultiSelect = false;

            // Ajustar el tamaño de las columnas automáticamente según el contenido
            DgvPersonas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}
