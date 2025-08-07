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

            // Cargar áreas en cmbFiltroArea
            CargarCombos();

            // Asignar eventos
            this.Load += new EventHandler(cpAsignarEmpleo_Load);
            cmbNuevo.SelectedIndexChanged += cmbNuevo_SelectedIndexChanged;
            btnBuscar2.Click += btnBuscar2_Click;
            cmbFiltroArea.SelectedIndexChanged += cmbFiltroArea_SelectedIndexChanged;
        }

        /// <summary>
        /// Método de carga del formulario. Inicia la carga de datos.
        /// </summary>
        private void cpAsignarEmpleo_Load(object sender, EventArgs e)
        {
            // Solo se debe llamar a un método para cargar cada DataGridView.
            // Esto evita redundancias y posibles conflictos.
            CargarOfertas();
            MostrarPostulantes();
        }

        /// <summary>
        /// Carga los datos de las ofertas de empleo en el DataGridView de empresas.
        /// </summary>
        private void CargarOfertas()
        {
            try
            {
                // Se crea una instancia de la clase de negocio para ofertas.
                // Esta es la llamada correcta a tu capa de negocio.
                var negocioOferta = new NOferta();

                // Se obtienen los datos de las ofertas desde la capa de negocio.
                tablaEmpresas = negocioOferta.ObtenerOfertas();

                // Se asigna la tabla de datos como fuente del DataGridView.
                dgvEmpresas.DataSource = tablaEmpresas;

                // Si la tabla de empresas está vacía, mostramos un mensaje de advertencia.
                if (tablaEmpresas.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron ofertas de empleo para mostrar. Por favor, asegúrate de haber registrado ofertas y empresas en las secciones correspondientes.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Configurar los encabezados de las columnas para que sean más legibles.
                if (dgvEmpresas.Columns.Contains("NombreEmpresa")) dgvEmpresas.Columns["NombreEmpresa"].HeaderText = "Empresa";
                if (dgvEmpresas.Columns.Contains("puesto")) dgvEmpresas.Columns["puesto"].HeaderText = "Puesto";
                if (dgvEmpresas.Columns.Contains("area")) dgvEmpresas.Columns["area"].HeaderText = "Área Laboral";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las ofertas: " + ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // El resto de los métodos del formulario se mantienen igual, pero los he reorganizado
        // y renombrado para mejorar la legibilidad. He eliminado tu método local 'ObtenerOfertas'
        // ya que el formulario no debería tener lógica de base de datos.

        private void CargarCombos()
        {
            // Limpiar y cargar cmbFiltroArea
            cmbFiltroArea.Items.Clear();
            cmbFiltroArea.Items.Add("Todas");
            foreach (var area in AreaLaboralProvider.GetAll())
            {
                cmbFiltroArea.Items.Add(area);
            }
            cmbFiltroArea.SelectedIndex = 0;

            // Limpiar y cargar cmbNuevo para el filtro de postulantes
            cmbNuevo.Items.Clear();
            cmbNuevo.Items.Add("ID");
            cmbNuevo.Items.Add("Dni");
            cmbNuevo.Items.Add("Nombre");
            cmbNuevo.SelectedIndex = 0;

            // Limpiar y cargar cmbFiltroEmpresa
            cmbFiltroEmpresa.Items.Clear();
            cmbFiltroEmpresa.Items.Add("Todas");
            cmbFiltroEmpresa.Items.Add("ID");
            cmbFiltroEmpresa.Items.Add("Nombre");
            cmbFiltroEmpresa.Items.Add("RNC");
            cmbFiltroEmpresa.SelectedIndex = 0;
        }

        private void MostrarPostulantes()
        {
            var negocioPostulante = new NPostulante();
            tablaPostulantes = negocioPostulante.Mostrar();
            dgvPostulantes.DataSource = tablaPostulantes;
        }

        private void FiltrarPostulantes(string texto)
        {
            if (tablaPostulantes == null) return;
            string filtroSeleccionado = cmbNuevo.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(texto) || string.IsNullOrEmpty(filtroSeleccionado))
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
                    filtro = $"Cedula LIKE '%{texto}%'";
                    break;
                case "Nombre":
                    filtro = $"Nombre LIKE '%{texto}%'";
                    break;
            }

            vista.RowFilter = filtro;
            dgvPostulantes.DataSource = vista;
        }

        private void AplicarFiltrosEmpresas()
        {
            if (tablaEmpresas == null) return;

            DataView vista = new DataView(tablaEmpresas);
            string filtroGeneral = "";
            string filtroArea = "";

            if (cmbFiltroArea.SelectedItem?.ToString() != "Todas")
            {
                filtroArea = $"Area = '{cmbFiltroArea.SelectedItem?.ToString().Replace("'", "''")}'";
            }

            string textoBusqueda = txtBuscarID.Text.Trim();
            string filtroSeleccionado = cmbFiltroEmpresa.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                switch (filtroSeleccionado)
                {
                    case "ID":
                        filtroGeneral = $"Convert(idEmpresa, 'System.String') LIKE '%{textoBusqueda}%'";
                        break;
                    case "Nombre":
                        filtroGeneral = $"NombreEmpresa LIKE '%{textoBusqueda}%'";
                        break;
                    case "RNC":
                        filtroGeneral = $"rnc LIKE '%{textoBusqueda}%'";
                        break;
                    case "Todas":
                        filtroGeneral = $"NombreEmpresa LIKE '%{textoBusqueda}%' OR rnc LIKE '%{textoBusqueda}%' OR Convert(idEmpresa, 'System.String') LIKE '%{textoBusqueda}%'";
                        break;
                }
            }

            string filtroFinal = "";
            if (!string.IsNullOrEmpty(filtroArea) && !string.IsNullOrEmpty(filtroGeneral))
            {
                filtroFinal = $"{filtroArea} AND ({filtroGeneral})";
            }
            else if (!string.IsNullOrEmpty(filtroArea))
            {
                filtroFinal = filtroArea;
            }
            else if (!string.IsNullOrEmpty(filtroGeneral))
            {
                filtroFinal = filtroGeneral;
            }

            vista.RowFilter = filtroFinal;
            dgvEmpresas.DataSource = vista;

            if (vista.Count == 0 && !string.IsNullOrEmpty(filtroFinal))
            {
                MessageBox.Show("No se encontraron resultados con los filtros aplicados.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvEmpresas.DataSource = tablaEmpresas;
            }
        }

        // Eventos
        private void cmbNuevo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarPostulantes(txtBuscarDNI.Text.Trim());
        }

        private void dgvEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idOfertaSeleccionada = Convert.ToInt32(dgvEmpresas.Rows[e.RowIndex].Cells["idOferta"].Value);
                MessageBox.Show("Oferta seleccionada ID: " + idOfertaSeleccionada);
            }
        }

        private void dgvPostulantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idPostulanteSeleccionado = Convert.ToInt32(dgvPostulantes.Rows[e.RowIndex].Cells["Id"].Value);
                MessageBox.Show("Postulante seleccionado ID: " + idPostulanteSeleccionado);
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (idPostulanteSeleccionado == -1)
            {
                MessageBox.Show("Por favor, selecciona un postulante.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idOfertaSeleccionada == -1)
            {
                MessageBox.Show("Por favor, selecciona una oferta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AsignacionServicio asignacionServicio = new AsignacionServicio();
            try
            {
                asignacionServicio.AsignarOfertaAPersona(idPostulanteSeleccionado, idOfertaSeleccionada);
                MessageBox.Show("Asignación realizada y notificaciones enviadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idPostulanteSeleccionado = -1;
                idOfertaSeleccionada = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al asignar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Métodos vacíos y eventos no utilizados que he dejado como referencia pero que podrías eliminar
        private void dgvEmpresas_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvPostulantes_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void cmbFiltroBusqueda_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtBuscarDNI_TextChanged(object sender, EventArgs e) { FiltrarPostulantes(txtBuscarDNI.Text.Trim()); }
        private void txtBuscarDNI_Click(object sender, EventArgs e) { }
        private void txtBuscarID_Click(object sender, EventArgs e) { }
        private void tabPage3_Click(object sender, EventArgs e) { }
        private void btnBuscarID_Click(object sender, EventArgs e) { }
        private void btnBuscar_Click(object sender, EventArgs e) { }

        // Aquí termina la refactorización. La navegación se ha dejado como estaba.
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
            //Jeiferson si jode loco
        }
    }
}
