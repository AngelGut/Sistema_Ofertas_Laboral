using CpNegocio.Empresas_y_Postulantes;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using CpNegocio.servicio;
using CpNegocio.servicios;
using CpNegocio.Oferta;

namespace CpPresentacion
{
    public partial class cpAsignarEmpleo : MaterialForm
    {
        private DataTable tablaPostulantes;
        private DataTable tablaEmpresas;

        // Variables para IDs seleccionados
        private int idPostulanteSeleccionado = -1;
        private int idOfertaSeleccionada = -1;

        public cpAsignarEmpleo()
        {
            InitializeComponent();
            materialTabControl1.SelectedIndex = 4;

            // Configuración inicial de MaterialSkin
            var materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Configuración de estilo para DataGridViews
            dgvPostulantes.EnableHeadersVisualStyles = false;
            dgvPostulantes.RowsDefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvEmpresas.EnableHeadersVisualStyles = false;
            dgvEmpresas.RowsDefaultCellStyle.SelectionBackColor = Color.LightBlue;

            CargarCombos();

            // Asignar eventos
            this.Load += new EventHandler(cpAsignarEmpleo_Load);

            // Eventos para filtros de Empresas
            btnBuscar2.Click += btnBuscar2_Click;
            cmbFiltroArea.SelectedIndexChanged += cmbFiltroArea_SelectedIndexChanged;
            txtBuscarID.KeyPress += txtBuscarID_KeyPress;

            // Evento Click del botón para filtrar postulantes
            btnBuscarID.Click += btnBuscarID_Click;

            // Se asigna el evento KeyPress al txtBuscarDNI
            txtBuscarDNI.KeyPress += txtBuscarDNI_KeyPress;

            // Se modifica cmbFiltroEmpresa para que solo tenga la opción "ID Oferta".
            cmbFiltroEmpresa.Items.Clear();
            cmbFiltroEmpresa.Items.Add("ID Oferta");
            cmbFiltroEmpresa.SelectedIndex = 0; // Se selecciona por defecto la única opción.

            // Limitar entrada a dígitos en los textboxes manuales (opcional)
            txboxIdPersona.KeyPress += (s, ev) =>
            {
                if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar)) ev.Handled = true;
            };
            texboxIdOferta.KeyPress += (s, ev) =>
            {
                if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar)) ev.Handled = true;
            };
        }

        private void CargarCombos()
        {
            // Cargar cmbFiltroArea con todas las áreas laborales
            cmbFiltroArea.Items.Clear();
            cmbFiltroArea.Items.Add("Todas");
            foreach (var area in AreaLaboralProvider.GetAll())
            {
                cmbFiltroArea.Items.Add(area);
            }
            cmbFiltroArea.SelectedIndex = 0;

            // Cargar cmbNuevo para el filtro de postulantes
            cmbNuevo.Items.Clear();
            cmbNuevo.Items.Add("Todas");
            cmbNuevo.Items.Add("ID");
            cmbNuevo.Items.Add("Dni");
            cmbNuevo.Items.Add("Nombre");
            cmbNuevo.SelectedIndex = 0;
        }

        
        /// Método de carga del formulario. Inicia la carga de datos.
        
        private void cpAsignarEmpleo_Load(object sender, EventArgs e)
        {
            CargarOfertas();
            MostrarPostulantes();
        }

        
        /// Carga los datos de las ofertas de empleo en el DataGridView de empresas.
      
        private void CargarOfertas()
        {
            try
            {
                var negocioOferta = new NOferta();
                tablaEmpresas = negocioOferta.ObtenerOfertas();
                dgvEmpresas.DataSource = tablaEmpresas;

                if (tablaEmpresas.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron ofertas de empleo para mostrar. Por favor, asegúrate de haber registrado ofertas y empresas en las secciones correspondientes.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Actualización de los encabezados de las columnas.
                if (dgvEmpresas.Columns.Contains("NombreEmpresa")) dgvEmpresas.Columns["NombreEmpresa"].HeaderText = "Empresa";
                if (dgvEmpresas.Columns.Contains("NombrePuesto")) dgvEmpresas.Columns["NombrePuesto"].HeaderText = "Puesto";
                if (dgvEmpresas.Columns.Contains("Area")) dgvEmpresas.Columns["Area"].HeaderText = "Área Laboral";
                if (dgvEmpresas.Columns.Contains("Tipo")) dgvEmpresas.Columns["Tipo"].HeaderText = "Tipo"; // <-- SE ASEGURA DE QUE SE MUESTRE EL TIPO
                if (dgvEmpresas.Columns.Contains("Descripcion")) dgvEmpresas.Columns["Descripcion"].HeaderText = "Descripción";
                if (dgvEmpresas.Columns.Contains("Creditos")) dgvEmpresas.Columns["Creditos"].HeaderText = "Créditos";
                if (dgvEmpresas.Columns.Contains("Salario")) dgvEmpresas.Columns["Salario"].HeaderText = "Salario"; // <-- AGREGADO PARA CLARIDAD

                // Oculta las columnas que no son necesarias
                if (dgvEmpresas.Columns.Contains("EmpresaId")) dgvEmpresas.Columns["EmpresaId"].Visible = false;
                if (dgvEmpresas.Columns.Contains("RNC")) dgvEmpresas.Columns["RNC"].Visible = false;
                if (dgvEmpresas.Columns.Contains("Descripcion")) dgvEmpresas.Columns["Descripcion"].Visible = false;
                if (dgvEmpresas.Columns.Contains("Requisitos")) dgvEmpresas.Columns["Requisitos"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las ofertas: " + ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarPostulantes()
        {
            var negocioPostulante = new NPostulante();
            tablaPostulantes = negocioPostulante.Mostrar();
            dgvPostulantes.DataSource = tablaPostulantes;
        }

        
        /// Filtra los postulantes según el criterio seleccionado en cmbNuevo.
       
        private void FiltrarPostulantes(string texto)
        {
            if (tablaPostulantes == null) return;
            string filtroSeleccionado = cmbNuevo.SelectedItem?.ToString();

            // Si la opción es "Todas" o el texto está vacío, se muestran todos los postulantes.
            if (filtroSeleccionado == "Todas" || string.IsNullOrWhiteSpace(texto))
            {
                dgvPostulantes.DataSource = tablaPostulantes;
                return;
            }

            DataView vista = new DataView(tablaPostulantes);
            string filtro = "";
            switch (filtroSeleccionado)
            {
                case "ID":
                    filtro = $"Convert(Id, 'System.String') LIKE '%{texto}%'";
                    break;
                case "Dni":
                    filtro = $"Dni LIKE '%{texto}%'";
                    break;
                case "Nombre":
                    filtro = $"Nombre LIKE '%{texto}%'";
                    break;
            }

            vista.RowFilter = filtro;
            dgvPostulantes.DataSource = vista;

            // Se muestra un mensaje si no se encuentran resultados
            if (vista.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados para la búsqueda.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPostulantes.DataSource = tablaPostulantes; // Vuelve a mostrar todos los postulantes
            }
        }

        
        /// Aplica los filtros de Área e ID de Oferta en el DataGridView de empresas.
        
        private void AplicarFiltrosEmpresas()
        {
            if (tablaEmpresas == null) return;

            DataView vista = new DataView(tablaEmpresas);
            string filtroFinal = "";

            // Lógica para el filtro de área (si se selecciona algo diferente a "Todas")
            string areaSeleccionada = cmbFiltroArea.SelectedItem?.ToString();
            if (areaSeleccionada != "Todas")
            {
                filtroFinal = $"Area = '{areaSeleccionada.Replace("'", "''")}'";
            }

            // Lógica para el filtro por ID de Oferta
            string textoBusqueda = txtBuscarID.Text.Trim();
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                // Se agrega un "AND" si ya existe un filtro de área
                if (!string.IsNullOrEmpty(filtroFinal))
                {
                    filtroFinal += " AND ";
                }
                // Se filtra por el ID de la oferta
                filtroFinal += $"Convert(idOferta, 'System.String') LIKE '%{textoBusqueda}%'";
            }

            // Aplicar el filtro final si no está vacío
            if (!string.IsNullOrEmpty(filtroFinal))
            {
                vista.RowFilter = filtroFinal;
            }
            else
            {
                // Si no hay filtros, mostrar todos los datos.
                vista.RowFilter = string.Empty;
            }

            dgvEmpresas.DataSource = vista;

            if (vista.Count == 0 && (!string.IsNullOrEmpty(filtroFinal)))
            {
                MessageBox.Show("No se encontraron resultados con los filtros aplicados.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvEmpresas.DataSource = tablaEmpresas;
            }
        }

        
        /// Maneja el evento KeyPress para permitir solo números en el txtBuscarID.
        
        private void txtBuscarID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite dígitos y la tecla de Backspace (para borrar).
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si la tecla no es un número ni una tecla de control, se cancela la entrada.
                e.Handled = true;
            }
        }

        // Maneja el evento KeyPress para permitir solo números en txtBuscarDNI si se elige la opción "ID"
        private void txtBuscarDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Obtener la opción seleccionada en el ComboBox
            string filtroSeleccionado = cmbNuevo.SelectedItem?.ToString();

            // Solo aplicar el filtro si la opción es "ID"
            if (filtroSeleccionado == "ID")
            {
                // Solo permite dígitos y la tecla de Backspace (para borrar).
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        // Eventos
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            // 1) Intentar leer ID de los TextBox si el usuario los escribió manualmente
            int personaIdManual, ofertaIdManual;

            // Si hay texto en txboxIdPersona y es un int válido, se usa (tiene prioridad)
            if (!string.IsNullOrWhiteSpace(txboxIdPersona.Text) && int.TryParse(txboxIdPersona.Text, out personaIdManual))
                idPostulanteSeleccionado = personaIdManual;

            // Si hay texto en txboxIdOferta y es un int válido, se usa (tiene prioridad)
            if (!string.IsNullOrWhiteSpace(texboxIdOferta.Text) && int.TryParse(texboxIdOferta.Text, out ofertaIdManual))
                idOfertaSeleccionada = ofertaIdManual;

            // 2) Validaciones simples
            if (idPostulanteSeleccionado <= 0)
            {
                MessageBox.Show("Por favor, selecciona un postulante del listado o escribe un ID válido en 'txboxIdPersona'.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (idOfertaSeleccionada <= 0)
            {
                MessageBox.Show("Por favor, selecciona una oferta del listado o escribe un ID válido en 'txboxIdOferta'.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3) Llamar al servicio de asignación
            var asignacionServicio = new AsignacionServicio();
            try
            {
                // Si tienes usuario logueado, pásalo; si no, omite el parámetro (sobrecarga)
                // Ejemplo con usuario opcional: asignacionServicio.AsignarOfertaAPersona(idPostulanteSeleccionado, idOfertaSeleccionada, usuarioId);
                asignacionServicio.AsignarOfertaAPersona(idPostulanteSeleccionado, idOfertaSeleccionada);

                MessageBox.Show(
                    $"Asignación OK.\nPersonaId: {idPostulanteSeleccionado}\nOfertaId: {idOfertaSeleccionada}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpieza de estado (opcional)
                // idPostulanteSeleccionado = -1;
                // idOfertaSeleccionada = -1;
                // txboxIdPersona.Clear();
                // txboxIdOferta.Clear();
            }
            catch (InvalidOperationException ex)
            {
                // Mensajes de negocio mapeados en el repositorio (duplicado, FK, etc.)
                MessageBox.Show(ex.Message, "No se pudo asignar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al asignar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            AplicarFiltrosEmpresas();
        }

        private void cmbFiltroArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltrosEmpresas();
        }

        // Maneja el clic del botón para filtrar postulantes
        private void btnBuscarID_Click(object sender, EventArgs e)
        {
            // Llama a la función de filtrado con el texto del TextBox.
            FiltrarPostulantes(txtBuscarDNI.Text.Trim());
        }

       
        /// Maneja el evento CellClick para dgvPostulantes, confirma la selección y guarda el ID.
        
        private void dgvPostulantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvPostulantes.Rows[e.RowIndex];

            // Intenta leer el ID por nombre de columna; si no, prueba conversión
            if (row.Cells["Id"]?.Value is int id)
                idPostulanteSeleccionado = id;
            else
                int.TryParse(row.Cells["Id"]?.Value?.ToString(), out idPostulanteSeleccionado);

            // Refleja en el TextBox
            txboxIdPersona.Text = idPostulanteSeleccionado > 0 ? idPostulanteSeleccionado.ToString() : string.Empty;

            var nombrePostulante = row.Cells["Nombre"]?.Value?.ToString() ?? string.Empty;

            if (idPostulanteSeleccionado > 0)
                MessageBox.Show($"Postulante seleccionado: {nombrePostulante} (ID: {idPostulanteSeleccionado})",
                    "Selección Confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo leer el Id del postulante de la fila seleccionada.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        
        /// Maneja el evento CellClick para dgvEmpresas, confirma la selección y guarda el ID.
        
        private void dgvEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvEmpresas.Rows[e.RowIndex];

            if (row.Cells["IdOferta"]?.Value is int id)
                idOfertaSeleccionada = id;
            else
                int.TryParse(row.Cells["IdOferta"]?.Value?.ToString(), out idOfertaSeleccionada);

            texboxIdOferta.Text = idOfertaSeleccionada > 0 ? idOfertaSeleccionada.ToString() : string.Empty;

            var nombrePuesto = row.Cells["NombrePuesto"]?.Value?.ToString() ?? string.Empty;

            if (idOfertaSeleccionada > 0)
                MessageBox.Show($"Oferta seleccionada: {nombrePuesto} (ID: {idOfertaSeleccionada})",
                    "Selección Confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo leer el Id de la oferta de la fila seleccionada.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cmbNuevo_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtBuscarDNI_TextChanged(object sender, EventArgs e) { }

        // Métodos vacíos
        private void dgvEmpresas_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvPostulantes_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void cmbFiltroBusqueda_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtBuscarDNI_Click(object sender, EventArgs e) { }
        private void txtBuscarID_Click(object sender, EventArgs e) { }
        private void tabPage3_Click(object sender, EventArgs e) { }
        private void btnBuscar_Click(object sender, EventArgs e) { }

        // Lógica de navegación
        private async void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            await NavegarA(materialTabControl1.SelectedIndex);
        }

        private async System.Threading.Tasks.Task NavegarA(int idx)
        {
            Form destino = idx switch
            {
                0 => Application.OpenForms.OfType<Menu>().FirstOrDefault() ?? new Menu(),
                1 => this is cpOfertas ? this : new cpOfertas(),
                2 => this is cpEmpresa ? this : new cpEmpresa(),
                3 => this is cpPostulante ? this : new cpPostulante(),
                4 => this is cpAsignarEmpleo ? this : new cpAsignarEmpleo(),
                5 => this is cpHistorialMensajes ? this : new cpHistorialMensajes(),
                6 => this is Carnet ? this : new Carnet(),
                7 => this is cpRegistro ? this : new cpRegistro(),
                _ => null
            };

            if (destino == null || destino == this) return;

            destino.Show();

            if (this is Menu)
                this.Hide();
            else
                this.Dispose();

            await System.Threading.Tasks.Task.Delay(180);
        }
    }
}
