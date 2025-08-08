using CpNegocio;
using CpNegocio.Entidades;
using CpNegocio.servicios;
using CpPresentacion.Asistencia;   // contiene IReadOnlyContainer y las extensiones
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CpPresentacion
{
    public partial class cpEmpresa : MaterialForm, IReadOnlyContainer
    {
        public Control Container => this; // Implementación de la interfaz IReadOnlyContainer

        public cpEmpresa()
        {
            InitializeComponent();
            //Metodo de personalizacion del datagridview
            PersonalizarDataGridView();

            // Cargar países en el ComboBox
            CargarPaises();
            // Evento para formatear cuando cambia selección o número
            cmbPaises.SelectedIndexChanged += (s, e) => FormatearTelefono();
            TxtTelefono.TextChanged += (s, e) => FormatearTelefono();

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

            AsignarEventosDeValidacion();
            CargarFiltro();
            CargarEmpresas();
            txtBusqueda.KeyPress += TxtBusqueda_KeyPress;

            // Bloquear todos los controles recursivamente
            this.SetReadOnly(true);

            // Mostrar mini-form Ver/Editar
            using (var dlg = new frmModoVisualizacion())
            {
                if (dlg.ShowDialog() == DialogResult.OK &&
                    dlg.Resultado == frmModoVisualizacion.ResultadoSeleccion.Editar)
                {
                    // Desbloquear si eligió Editar
                    this.SetReadOnly(false);
                }
            }
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
                // Usar el número formateado with libphonenumber
                string telefono;
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
                string correo = TxtCorreo.Text.Trim();
                string direccion = TxtDireccion.Text.Trim();
                string rncTexto = TxtRnc.Text.Trim().Replace(" ", ""); // ❌ quitar espacios

                // 3. Validar que el RNC contenga solo dígitos (sin espacios ni símbolos)
                if (!rncTexto.All(char.IsDigit))
                {
                    MessageBox.Show("El RNC debe contener solo números, sin espacios ni símbolos.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        // Clase auxiliar para los países
        private class CountryItem
        {
            public string IsoCode { get; set; } // Código ISO, ej: "US", "DO"
            public string Name { get; set; } // Nombre visible
            public string DialCode { get; set; } // Código de marcación, ej: "+1"
            public string Display => $"{Name} ({DialCode})";
            public override string ToString() => Display;
        }

        private void CargarPaises()
        {
            var phoneUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();

            // Obtener todas las regiones soportadas y ordenarlas alfabéticamente
            var regiones = phoneUtil.GetSupportedRegions().OrderBy(iso => iso);

            // Crear lista filtrando los códigos ISO inválidos para RegionInfo
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
                    // Si el ISO no es válido (como "AC"), lo omitimos
                    return null;
                }
            })
            .Where(ci => ci != null)
            .OrderBy(ci => ci.Name)
            .ToList();

            // Enlazar la lista al ComboBox
            cmbPaises.DataSource = lista;
            cmbPaises.DisplayMember = "Display";   // mostrará "República Dominicana (+1)"
            cmbPaises.ValueMember = "IsoCode";
        }

        private void CargarFiltro()
        {
            cmbFiltro.Items.Clear();
            cmbFiltro.Items.Add("Id");
            cmbFiltro.Items.Add("Nombre");
            cmbFiltro.Items.Add("Rnc");
            cmbFiltro.SelectedIndex = 0; // Seleccionar el primer criterio por defecto
        }

        private void FormatearTelefono()
        {
            // Verifica que haya un país seleccionado
            if (cmbPaises.SelectedItem is not CountryItem cp)
                return;

            var phoneUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();

            try
            {
                // Intenta parsear el número con el ISO del país
                var parsed = phoneUtil.Parse(TxtTelefono.Text, cp.IsoCode);

                if (phoneUtil.IsValidNumber(parsed))
                {
                    // Si es válido, lo formatea al estilo internacional
                    string formateado = phoneUtil.Format(parsed, PhoneNumbers.PhoneNumberFormat.INTERNATIONAL);

                    // Cambia el fondo a blanco (válido)
                    TxtTelefono.BackColor = Color.White;

                    // Muestra el formato correcto como tooltip
                    System.Windows.Forms.ToolTip tooltip = new System.Windows.Forms.ToolTip();
                    tooltip.SetToolTip(TxtTelefono, formateado);
                }
                else
                {
                    // Número no válido → fondo rosado
                    TxtTelefono.BackColor = Color.MistyRose;
                }
            }
            catch
            {
                // Si falla el parseo → fondo rosado
                TxtTelefono.BackColor = Color.MistyRose;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = cmbFiltro.SelectedItem.ToString();  // Obtener el criterio seleccionado (Id, Nombre, Dni)
            string valorBusqueda = txtBusqueda.Text.Trim();  // Obtener el valor de búsqueda

            if (string.IsNullOrEmpty(valorBusqueda))
            {
                MessageBox.Show(
                    "Por favor, ingrese un valor para buscar. \n\n" +
                    "Recuerde que debe proporcionar un valor en el campo de búsqueda para poder filtrar la información.",
                    "Campo de búsqueda vacío",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Llamamos al método BuscarConFiltro con el criterio y el valor de búsqueda
                var persona = new Persona();
                var servicio = new CpNegocio.servicios.MetodosPersona(persona);

                // Llamamos al servicio con el filtro
                DataTable tablaFiltrada = servicio.BuscarConFiltro(criterio, valorBusqueda);

                // Asignamos la tabla filtrada al DataGridView
                DgvEmpresas.DataSource = tablaFiltrada;

                // Actualizamos los encabezados de las columnas
                ActualizarEncabezadosColumnas();
            }
            catch (FormatException ex)
            {
                // Si el valor de búsqueda no es válido para un número
                MessageBox.Show(
                    "El valor para la búsqueda del 'Id' debe ser un número entero. \n\n" +
                    "Por favor, ingrese un valor numérico válido para el campo 'Id'.",
                    "Error de formato en 'Id'",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                // Si ocurre un error con la base de datos
                MessageBox.Show(
                    "Hubo un problema al intentar conectar con la base de datos. \n\n" +
                    "Por favor, verifique la conexión o intente nuevamente más tarde.",
                    "Error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Captura cualquier otro error inesperado
                MessageBox.Show(
                    "Ocurrió un error inesperado mientras se realizaba la búsqueda: \n\n" +
                    ex.Message + "\n\n" +
                    "Por favor, contacte al administrador si el problema persiste.",
                    "Error al buscar personas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ActualizarEncabezadosColumnas()
        {
            if (DgvEmpresas.Columns.Contains("Id"))
                DgvEmpresas.Columns["Id"].HeaderText = "ID Empresa";

            if (DgvEmpresas.Columns.Contains("Nombre"))
                DgvEmpresas.Columns["Nombre"].HeaderText = "Nombre de la Empresa";

            if (DgvEmpresas.Columns.Contains("Rnc"))
                DgvEmpresas.Columns["Rnc"].HeaderText = "RNC";

            if (DgvEmpresas.Columns.Contains("Telefono"))
                DgvEmpresas.Columns["Telefono"].HeaderText = "Teléfono";

            if (DgvEmpresas.Columns.Contains("Direccion"))
                DgvEmpresas.Columns["Direccion"].HeaderText = "Dirección";

            if (DgvEmpresas.Columns.Contains("Correo"))
                DgvEmpresas.Columns["Correo"].HeaderText = "Correo";
        }

        private void AsignarEventosDeValidacion()
        {
            // Asegúrate de que el TextBox está bien referenciado
            txtBusqueda.KeyPress += TxtBusqueda_KeyPress;
        }

        private void TxtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificamos el filtro seleccionado
            string filtro = cmbFiltro.SelectedItem.ToString();

            // Si el filtro es "Id" o "Rnc", solo permitimos números
            if (filtro == "Id" || filtro == "Rnc")
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;  // Bloquea la entrada de caracteres no numéricos
                }
            }
            // Si el filtro es "Nombre", solo permitimos letras
            else if (filtro == "Nombre")
            {
                if (!Char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;  // Bloquea la entrada de caracteres no alfabéticos
                }
            }
        }

        private void TxtBusqueda_KeyPress_Numeros(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla Backspace
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;  // Evita que se ingrese un carácter no numérico
            }
        }

        private void TxtBusqueda_KeyPress_Letras(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras (sin distinguir mayúsculas/minúsculas) y la tecla Backspace
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;  // Evita que se ingrese un carácter no alfabético
            }
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Limpiar el texto para que no quede ningún valor previo
            txtBusqueda.Clear();

            // Asignamos el evento de validación correcto según el filtro seleccionado
            if (cmbFiltro.SelectedItem.ToString() == "Id" || cmbFiltro.SelectedItem.ToString() == "Rnc")
            {
                // Validar solo números
                txtBusqueda.KeyPress -= TxtBusqueda_KeyPress_Letras; // Eliminar validación de letras
                txtBusqueda.KeyPress += TxtBusqueda_KeyPress_Numeros; // Asignar validación solo números
            }
            else if (cmbFiltro.SelectedItem.ToString() == "Nombre")
            {
                // Validar solo letras
                txtBusqueda.KeyPress -= TxtBusqueda_KeyPress_Numeros; // Eliminar validación de números
                txtBusqueda.KeyPress += TxtBusqueda_KeyPress_Letras; // Asignar validación solo letras
            }
        }
        private void PersonalizarDataGridView()
        {
            // Cambiar el color de fondo general del DataGridView
            DgvEmpresas.BackgroundColor = Color.FromArgb(240, 248, 255); // Azul muy suave, estilo "Azure"

            // Personalizar el color de los encabezados de las columnas
            DgvEmpresas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204); // Azul oscuro
            DgvEmpresas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DgvEmpresas.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            DgvEmpresas.ColumnHeadersHeight = 40;

            // Cambiar el color de las filas
            DgvEmpresas.RowsDefaultCellStyle.BackColor = Color.White;
            DgvEmpresas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 255); // Azul suave en filas alternas
            DgvEmpresas.RowsDefaultCellStyle.ForeColor = Color.Black;

            // Cambiar el color del borde del DataGridView
            DgvEmpresas.BorderStyle = BorderStyle.FixedSingle;
            DgvEmpresas.GridColor = Color.FromArgb(200, 200, 200); // Gris claro para las líneas de la cuadrícula

            // Personalizar las celdas
            DgvEmpresas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204); // Azul oscuro cuando se selecciona
            DgvEmpresas.DefaultCellStyle.SelectionForeColor = Color.White; // Texto blanco cuando se selecciona

            // Personalizar las celdas al pasar el ratón (Hover)
            DgvEmpresas.CellMouseEnter += (sender, e) =>
                       {
                          if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                          {
                            DgvEmpresas.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(173, 216, 230); // Azul claro cuando el mouse pasa
                          }
                       };

            DgvEmpresas.CellMouseLeave += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DgvEmpresas.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White; // Vuelve a blanco
                }
            };

            // Personalizar la fuente de las celdas
            DgvEmpresas.DefaultCellStyle.Font = new Font("Arial", 9);

            // Personalizar las filas de la cabecera al ser seleccionadas
            DgvEmpresas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvEmpresas.MultiSelect = false;

            // Ajustar el tamaño de las columnas automáticamente según el contenido
            DgvEmpresas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

    }
}
