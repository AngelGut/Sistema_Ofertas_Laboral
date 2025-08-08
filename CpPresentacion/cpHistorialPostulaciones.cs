using CpNegocio;
using CpNegocio.servicios;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpPresentacion
{
    public partial class cpHistorialPostulaciones : MaterialForm
    {
        // La variable de clase para almacenar los datos de las asignaciones.
        private DataTable tablaPostulaciones;

        public cpHistorialPostulaciones()
        {
            InitializeComponent();
            materialTabControl1.SelectedIndex = 8;

            var materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Configuración del DataGridView, el nombre del control se mantiene como 'dgvHistorialPostulaciones'
            if (dgvHistorialPostulaciones != null)
            {
                dgvHistorialPostulaciones.EnableHeadersVisualStyles = false;
                dgvHistorialPostulaciones.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            }

            // Aquí se cargan los combos y el historial al cargar el formulario
            this.Load += new EventHandler(cpHistorialPostulaciones_Load);
        }

        private async void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            await NavegarA(materialTabControl1.SelectedIndex);
        }

        private async Task NavegarA(int idx)
        {
            
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
                this.Hide();      // se mantiene en memoria
            else
                this.Dispose();  // libera recursos

            // Asegurarnos de que la UI repinte inmediatamente:
            destino.BringToFront();
            destino.Activate();
        }

        private async void cpHistorialPostulaciones_Load(object sender, EventArgs e)
        {
            CargarCombos();
            await CargarHistorialPostulacionesAsync();
            
        }

        private void CargarCombos()
        {
            // Asegúrate de que el nombre del control sea 'cmbFiltro'
            if (cmbFiltro != null)
            {
                cmbFiltro.Items.Clear();
                cmbFiltro.Items.Add("Todos");
                cmbFiltro.Items.Add("Postulante");
                cmbFiltro.Items.Add("Puesto");
                cmbFiltro.SelectedIndex = 0;
            }
        }

        private void AplicarFiltro()
        {
            // Asegúrate de que la variable de clase 'tablaPostulaciones' no sea nula
            if (tablaPostulaciones == null) return;

            string criterio = cmbFiltro.SelectedItem?.ToString();
            string textoBusqueda = txtBusqueda.Text.Trim();

            if (criterio == "Todos" || string.IsNullOrWhiteSpace(textoBusqueda))
            {
                dgvHistorialPostulaciones.DataSource = tablaPostulaciones;
                return;
            }

            DataView vista = new DataView(tablaPostulaciones);
            string filtro = "";
            switch (criterio)
            {
                case "Postulante":
                    filtro = $"NombrePostulante LIKE '%{textoBusqueda}%'";
                    break;
                case "Puesto":
                    filtro = $"PuestoOferta LIKE '%{textoBusqueda}%'";
                    break;
            }

            vista.RowFilter = filtro;
            dgvHistorialPostulaciones.DataSource = vista;

            // Si no hay resultados, se muestra un mensaje de alerta y se restauran los datos
            if (vista.Count == 0 && !string.IsNullOrEmpty(filtro))
            {
                MessageBox.Show("No se encontraron resultados para la búsqueda.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvHistorialPostulaciones.DataSource = tablaPostulaciones;
            }
        }

        private async Task CargarHistorialPostulacionesAsync()
        {
            try
            {
                // Instancia de la capa de negocio para obtener los datos de las postulaciones.
                var negocioAsignacion = new NAsignacion();

                // Llamada asíncrona al método para obtener el historial de postulaciones con los detalles.
                // Este método debe devolver un DataTable con la información que se mostrará en el DataGridView.
                tablaPostulaciones = await negocioAsignacion.ObtenerHistorialConDetalleAsync();

                // Verifica si se obtuvieron datos. Si la tabla está vacía, muestra un mensaje.
                if (tablaPostulaciones == null || tablaPostulaciones.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron asignaciones para mostrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // No continuar si no hay datos.
                }

                // Asigna los datos al DataGridView. Asegúrate de que la propiedad DataSource esté correctamente vinculada.
                dgvHistorialPostulaciones.DataSource = tablaPostulaciones;

                // Configura los encabezados de las columnas, si las columnas existen en el DataTable.
                // Estas líneas son útiles para dar nombres personalizados a las columnas en el DataGridView.
                if (dgvHistorialPostulaciones.Columns.Contains("IdAsignacion"))
                    dgvHistorialPostulaciones.Columns["IdAsignacion"].HeaderText = "ID Asignación";
                if (dgvHistorialPostulaciones.Columns.Contains("NombrePostulante"))
                    dgvHistorialPostulaciones.Columns["NombrePostulante"].HeaderText = "Postulante";
                if (dgvHistorialPostulaciones.Columns.Contains("PuestoOferta"))
                    dgvHistorialPostulaciones.Columns["PuestoOferta"].HeaderText = "Puesto";
                if (dgvHistorialPostulaciones.Columns.Contains("NombreEmpresa"))
                    dgvHistorialPostulaciones.Columns["NombreEmpresa"].HeaderText = "Empresa";
                if (dgvHistorialPostulaciones.Columns.Contains("FechaAsignacion"))
                    dgvHistorialPostulaciones.Columns["FechaAsignacion"].HeaderText = "Fecha de Asignación";
            }
            catch (Exception ex)
            {
                // Si ocurre un error en la carga, muestra un mensaje de error con detalles.
                MessageBox.Show("Error al cargar el historial de postulaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Manejador del evento de clic para el botón de búsqueda
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        // Manejador del evento de clic para el botón de limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            cmbFiltro.SelectedIndex = 0;
            if (tablaPostulaciones != null)
            {
                dgvHistorialPostulaciones.DataSource = tablaPostulaciones;
            }
        }
    }
}