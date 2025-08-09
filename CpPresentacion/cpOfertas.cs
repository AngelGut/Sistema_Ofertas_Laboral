using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Datos;
using CpNegocio.Oferta;
using CpNegocio.servicios;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CpPresentacion.Asistencia;   // contiene IReadOnlyContainer y las extensiones
using System.Media;
using System.Drawing;                  // por Point
using CpPresentacion.Asistencia;       // por IReadOnlyContainer y SetReadOnly
using CpNegocio.Empresas_y_Postulantes; // aquí vive OfertaListadoDto



namespace CpPresentacion
{
    public partial class cpOfertas : MaterialForm, IReadOnlyContainer
    {
        public Control Container => this;
        private FormBoton _formBoton; // switch flotante

        public cpOfertas()
        {
            InitializeComponent();

            materialTabControl1.SelectedIndex = 1;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // Config inicial
            var empresas = new MetodosCargarEmpresa().ObtenerEmpresas();
            CboxEmpresas.DataSource = empresas;
            TxtSalario.Visible = false;
            TxtCreditos.Visible = false;
            if (CboxTipoOferta.Items.Count > 0)
                CboxTipoOferta.SelectedIndex = 0;

            CargarOfertas();
            CargarEmpresas();
            PopulateAreas();

            // 🔹 Bloquear de inicio
            this.SetReadOnly(true);

            // 🔹 Mostrar mini-form y decidir estado inicial
            bool startInEdit = false;
            using (var dlg = new frmModoVisualizacion())
            {
                if (dlg.ShowDialog() == DialogResult.OK &&
                    dlg.Resultado == frmModoVisualizacion.ResultadoSeleccion.Editar)
                {
                    startInEdit = true;
                }
            }

            // 🔹 Aplicar estado inicial
            this.SetReadOnly(!startInEdit);

            // 🔹 Abrir el switch flotante (siempre activo)
            AbrirFormBoton(startInEdit);

            // 🔹 Asegurar que si el form se cierra, se cierre también el flotante
            this.FormClosed += (s, e) =>
            {
                if (_formBoton != null && !_formBoton.IsDisposed) _formBoton.Close();
                _formBoton = null;
            };

            // Llenar el ComboBox con las opciones para filtrar
            cmbFiltro.Items.Add("Id Oferta");      //  ← ESTA línea (ahora dice "Id")
            cmbFiltro.Items.Add("Puesto");
            cmbFiltro.SelectedIndex = 0;

            PersonalizarDataGridView();

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





        private void materialLabel4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void CboxTipoOferta_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoSeleccionado = CboxTipoOferta.SelectedItem.ToString();

            // Oculta todos los campos específicos primero, para resetear la visibilidad
            TxtSalario.Visible = false; // Ocultar TextBox de Salario
            TxtCreditos.Visible = false; // Ocultar TextBox de Créditos

            // Muestra los campos específicos según el tipo de oferta seleccionado
            if (tipoSeleccionado == "Empleo Fijo")
            {
                TxtSalario.Visible = true; // Mostrar TextBox de Salario
            }
            else if (tipoSeleccionado == "Pasantia")
            {
                TxtCreditos.Visible = true; // Mostrar TextBox de Créditos
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔹 Validar campos de texto obligatorios
                if (string.IsNullOrWhiteSpace(TxtPuesto.Text))
                {
                    MessageBox.Show("El campo 'Puesto' no puede estar vacío.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtPuesto.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(TxtDescripcion.Text))
                {
                    MessageBox.Show("El campo 'Descripción' no puede estar vacío.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtDescripcion.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(TxtRequisitos.Text))
                {
                    MessageBox.Show("El campo 'Requisitos' no puede estar vacío.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtRequisitos.Focus();
                    return;
                }

                // 🔹 Si es Empleo Fijo, salario obligatorio
                if (CboxTipoOferta.SelectedItem?.ToString() == "Empleo Fijo" &&
                    string.IsNullOrWhiteSpace(TxtSalario.Text))
                {
                    MessageBox.Show("Debe ingresar el salario para la oferta de empleo fijo.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtSalario.Focus();
                    return;
                }

                // 🔹 Si es Pasantía, créditos obligatorios
                if (CboxTipoOferta.SelectedItem?.ToString() == "Pasantia" &&
                    string.IsNullOrWhiteSpace(TxtCreditos.Text))
                {
                    MessageBox.Show("Debe ingresar los créditos para la pasantía.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtCreditos.Focus();
                    return;
                }

                // 🔹 Validar ComboBox Empresa
                if (CboxEmpresas.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar una empresa antes de registrar la oferta.", "Empresa requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Validar ComboBox Tipo de Oferta
                if (CboxTipoOferta.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de oferta.", "Tipo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (CboxEmpresas.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar una empresa antes de registrar la oferta.", "Empresa requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (CboxTipoOferta.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de oferta.", "Tipo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tipo = CboxTipoOferta.SelectedItem.ToString();
                int empresaId = ((CpNegocio.Entidades.EmpresaComboItem)CboxEmpresas.SelectedItem).Id;
                string puesto = TxtPuesto.Text;
                string descripcion = TxtDescripcion.Text;
                string requisitos = TxtRequisitos.Text;
                string area = cmbArea.SelectedItem?.ToString() ?? "";

                int salario = 0;
                int creditos = 0;

                if (tipo == "Empleo Fijo")
                {
                    if (!int.TryParse(TxtSalario.Text, out salario))
                    {
                        MessageBox.Show("Salario inválido.");
                        return;
                    }
                }
                else if (tipo == "Pasantia")
                {
                    if (!int.TryParse(TxtCreditos.Text, out creditos))
                    {
                        MessageBox.Show("Créditos inválidos.");
                        return;
                    }
                }

                // Registrar usando el método unificado
                var metodosOferta = new MetodosOferta();
                metodosOferta.RegistrarOferta(
                    empresaId,
                    puesto,
                    tipo,
                    descripcion,
                    requisitos,
                    salario,
                    creditos,
                    area,
                    false
                );

                MessageBox.Show("Oferta registrada con éxito.");
                CargarOfertas();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar la oferta:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //clase auxiliar para mostrar nombre pero guardar el ID:
        public class EmpresaComboItem
        {
            public int Id { get; set; }
            public string Nombre { get; set; }

            public override string ToString()
            {
                return Nombre;
            }
        }

        //Método para cargar empresas desde la base
        private void CargarEmpresas()
        {
            var metodoEmpresa = new MetodosCargarEmpresa();
            var lista = metodoEmpresa.ObtenerEmpresas();

            // Usar DataSource directamente
            CboxEmpresas.DataSource = lista;
            CboxEmpresas.DisplayMember = "Nombre"; // qué se ve en el ComboBox
            CboxEmpresas.ValueMember = "Id";       // qué valor representa internamente

            if (CboxEmpresas.Items.Count > 0)
                CboxEmpresas.SelectedIndex = 0;
        }

        private List<OfertaListadoDto> _ofertas;
        private DataTable _ofertasDt;

        // Método para cargar ofertas en el DataGridView
        private void CargarOfertas()
        {
            var metodo = new MetodosOferta();
            _ofertas = metodo.ObtenerOfertas();    // ← List<OfertaListadoDto>
            DGridOferta.AutoGenerateColumns = true;
            DGridOferta.DataSource = _ofertas;     // ← siempre mismo esquema
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            CargarOfertas();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Validar que haya al menos una fila seleccionada
            if (DGridOferta.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una oferta para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmar con el usuario
            var confirm = MessageBox.Show("¿Está seguro que desea eliminar esta oferta?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            // Obtener el ID de la oferta seleccionada
            int ofertaId = Convert.ToInt32(DGridOferta.SelectedRows[0].Cells["Id"].Value);

            try
            {
                // Ejecutar la eliminación desde la base de datos
                using (SqlConnection conn = Capa_Datos.OfertaDatos.ObtenerConexion())
                {
                    conn.Open();
                    string query = "DELETE FROM Oferta WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", ofertaId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Oferta eliminada correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar el DataGrid
                CargarOfertas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la oferta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquear la tecla si no es número ni tecla de control (como Backspace)
            }
        }

        private void TxtCreditos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquear la tecla si no es número ni tecla de control (como Backspace)
            }
        }

        private void LimpiarCampos()
        {
            CboxEmpresas.SelectedIndex = 0; // o -1 si quieres que quede en blanco
            CboxTipoOferta.SelectedIndex = 0;

            TxtPuesto.Text = string.Empty;
            TxtDescripcion.Text = string.Empty;
            TxtRequisitos.Text = string.Empty;
            TxtSalario.Text = string.Empty;
            TxtCreditos.Text = string.Empty;
        }

        private void BtnOcupada_Click(object sender, EventArgs e)
        {
            // Asegurarse de que hay una fila seleccionada
            if (DGridOferta.SelectedRows.Count > 0)
            {
                // Obtener el ID de la oferta seleccionada
                int ofertaId = Convert.ToInt32(DGridOferta.SelectedRows[0].Cells["Id"].Value);

                // Ejecutar actualización en la base de datos
                using (SqlConnection conn = OfertaDatos.ObtenerConexion())
                {
                    conn.Open();
                    string query = "UPDATE Oferta SET Ocupada = 1 WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", ofertaId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Oferta marcada como ocupada.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar la tabla con las ofertas actualizadas
                CargarOfertas();
            }
            else
            {
                MessageBox.Show("Selecciona una oferta primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void PopulateAreas()
        {
            cmbArea.DataSource = AreaLaboralProvider.GetAll();
            cmbArea.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbArea.SelectedIndex = 0;
        }

        private void TxtPuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!EsPermitido(e.KeyChar))
            {
                e.Handled = true;
                // MessageBox opcional (no recomendado en KeyPress)
            }
        }

        private void TxtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!EsPermitido(e.KeyChar))
            {
                e.Handled = true;
                // MessageBox opcional (no recomendado en KeyPress)
            }
        }

        private void TxtRequisitos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!EsPermitido(e.KeyChar))
            {
                e.Handled = true;
                // MessageBox opcional (no recomendado en KeyPress)
            }
        }

        private void AbrirFormBoton(bool startInEdit)
        {
            // Evita duplicados
            if (_formBoton != null && !_formBoton.IsDisposed) return;

            _formBoton = new FormBoton(this, startInEdit)
            {
                StartPosition = FormStartPosition.Manual,
                TopMost = true
            };

            void Reposicionar()
            {
                if (_formBoton == null || _formBoton.IsDisposed) return;

                // Coordenadas del formulario principal en pantalla
                var p = this.PointToScreen(Point.Empty);

                // Lo posicionamos afuera, al lado derecho
                int x = p.X + this.Width; // comienza justo al borde derecho
                int y = p.Y + (this.Height - _formBoton.Height) / 2; // centrado verticalmente

                _formBoton.Location = new Point(x, y);
            }

            // Posicionar ahora y re-posicionar al mover o redimensionar
            Reposicionar();
            this.Move += (s, e) => Reposicionar();
            this.Resize += (s, e) => Reposicionar();

            // Limpiar referencia al cerrarse
            _formBoton.FormClosed += (s, e) => _formBoton = null;

            // Mostrar como ventana hija/propietaria
            _formBoton.Show(this);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarOfertas();
        }

        private void FiltrarOfertas()
        {
            if (_ofertas == null) { CargarOfertas(); if (_ofertas == null) return; }

            string filtroSel = cmbFiltro.SelectedItem?.ToString() ?? "";
            string texto = txtBusqueda.Text.Trim();

            if (string.IsNullOrEmpty(texto))
            {
                DGridOferta.DataSource = _ofertas;
                return;
            }

            IEnumerable<OfertaListadoDto> q = _ofertas;

            if (filtroSel == "Id Oferta" && int.TryParse(texto, out int idOferta))
                q = q.Where(o => o.Id == idOferta);

            else if (filtroSel == "Puesto")
                q = q.Where(o => o.Puesto?.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0);

            else if (filtroSel == "Empresa")
                q = q.Where(o => o.Empresa?.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0);

            else if (filtroSel == "Área") // ver nota más abajo
                q = q.Where(o => o.Area?.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0);

            DGridOferta.DataSource = q.ToList();
        }

        private static string EscapeForRowFilter(string value)
        {
            // Escapa caracteres problemáticos para DataColumn.Expression / RowFilter
            if (value == null) return "";
            return value.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");
        }



        private static bool EsPermitido(char ch)
        {
            // Permite control (Backspace, etc.), letra, dígito, espacio y estos signos comunes:
            if (char.IsControl(ch) || char.IsLetterOrDigit(ch) || ch == ' ')
                return true;

            char[] permitidos = { '.', ',', '-', '_', '(', ')', '/', '#', '&', '+', ':', ';', '"', '\'', '@' };
            return permitidos.Contains(ch);
        }

        private void PersonalizarDataGridView()
        {
            // Cambiar el color de fondo general del DataGridView
            DGridOferta.BackgroundColor = Color.FromArgb(240, 248, 255); // Azul muy suave, estilo "Azure"

            // Personalizar el color de los encabezados de las columnas
            DGridOferta.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204); // Azul oscuro
            DGridOferta.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DGridOferta.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            DGridOferta.ColumnHeadersHeight = 40;

            // Cambiar el color de las filas
            DGridOferta.RowsDefaultCellStyle.BackColor = Color.White;
            DGridOferta.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 255); // Azul suave en filas alternas
            DGridOferta.RowsDefaultCellStyle.ForeColor = Color.Black;

            // Cambiar el color del borde del DataGridView
            DGridOferta.BorderStyle = BorderStyle.FixedSingle;
            DGridOferta.GridColor = Color.FromArgb(200, 200, 200); // Gris claro para las líneas de la cuadrícula

            // Personalizar las celdas
            DGridOferta.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204); // Azul oscuro cuando se selecciona
            DGridOferta.DefaultCellStyle.SelectionForeColor = Color.White; // Texto blanco cuando se selecciona

            // Personalizar las celdas al pasar el ratón (Hover)
            DGridOferta.CellMouseEnter += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DGridOferta.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(173, 216, 230); // Azul claro cuando el mouse pasa
                }
            };

            DGridOferta.CellMouseLeave += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DGridOferta.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White; // Vuelve a blanco
                }
            };

            // Personalizar la fuente de las celdas
            DGridOferta.DefaultCellStyle.Font = new Font("Arial", 9);

            // Personalizar las filas de la cabecera al ser seleccionadas
            DGridOferta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGridOferta.MultiSelect = false;

            // Ajustar el tamaño de las columnas automáticamente según el contenido
            DGridOferta.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

    }

}
