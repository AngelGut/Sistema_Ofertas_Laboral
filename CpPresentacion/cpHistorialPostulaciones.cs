using MaterialSkin.Controls;
using CpNegocio.Empresas_y_Postulantes;
using CpNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpPresentacion
{
    public partial class cpHistorialPostulaciones : MaterialForm
    {
        public cpHistorialPostulaciones()
        {
            InitializeComponent();

            // Establece el tab activo que corresponde a este formulario
            materialTabControl1.SelectedIndex = 8;
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

        // Método para cargar el historial de postulaciones
        private void CargarHistorialPostulaciones(int personaId)
        {
            var negocio = new PostulacionesNegocio();  // Instancia de la capa de negocios
            var postulaciones = negocio.ObtenerHistorialPostulaciones(personaId); // Obtener postulaciones

            // Verifica que se estén obteniendo datos
            if (postulaciones != null && postulaciones.Count > 0)
            {
                // Convertir la lista de postulaciones a un DataTable
                DataTable dt = ConvertirADataTable(postulaciones);

                // Asignar el DataTable al DataGridView
                dgvHistorialPostulaciones.DataSource = dt;
                dgvHistorialPostulaciones.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            else
            {
                MessageBox.Show("No se encontraron postulaciones para este ID.");
            }
        }

        private DataTable ConvertirADataTable(System.Collections.Generic.List<Postulacion> postulaciones)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("AsignacionId");
            dt.Columns.Add("PersonaId");
            dt.Columns.Add("NombrePersona");
            dt.Columns.Add("OfertaId");
            dt.Columns.Add("Puesto");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Requisitos");
            dt.Columns.Add("Salario");
            dt.Columns.Add("Creditos");
            dt.Columns.Add("Area");
            dt.Columns.Add("Ocupada");

            // Llenar el DataTable con los datos de las postulaciones
            foreach (var postulacion in postulaciones)
            {
                dt.Rows.Add(postulacion.AsignacionId, postulacion.PersonaId, postulacion.NombrePersona, postulacion.OfertaId,
                            postulacion.Puesto, postulacion.Tipo, postulacion.Descripcion, postulacion.Requisitos,
                            postulacion.Salario, postulacion.Creditos, postulacion.Area, postulacion.Ocupada);
            }

            return dt;
        }

        private void cpHistorialPostulaciones_Load(object sender, EventArgs e)
        {
            CargarHistorialPostulaciones(1);

            // Cargar los ComboBox
            CargarComboBoxes();
            CargarPuestos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Validar que el personaId sea un número
            if (int.TryParse(txtPersonaId.Text, out int personaId))
            {
                // Llamar al método para cargar el historial de postulaciones
                CargarHistorialPostulaciones(personaId);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID válido de persona.");
            }
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPersonaId.Clear();
            dgvHistorialPostulaciones.DataSource = null;
        }

        private void cmbTipoOferta_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoOfertaSeleccionado = cmbTipoOferta.SelectedItem?.ToString();
            var negocio = new PostulacionesNegocio();
            var postulaciones = negocio.ObtenerHistorialPostulacionesFiltradasPorTipoOferta(1, tipoOfertaSeleccionado); // Aquí '1' es el personaId de ejemplo.

            DataTable dt = ConvertirADataTable(postulaciones);
            dgvHistorialPostulaciones.DataSource = dt;
        }


        private void cmbPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string puestoSeleccionado = cmbPuesto.SelectedItem?.ToString();
            var negocio = new PostulacionesNegocio();
            var postulaciones = negocio.ObtenerHistorialPostulacionesFiltradasPorPuesto(1, puestoSeleccionado); // Aquí '1' es el personaId de ejemplo.

            DataTable dt = ConvertirADataTable(postulaciones);
            dgvHistorialPostulaciones.DataSource = dt;
        }


        private void CargarComboBoxes()
        {
            // Ejemplo: Llenar cmbTipoOferta con los tipos de oferta disponibles
            cmbTipoOferta.Items.Add("Empleo Fijo");
            cmbTipoOferta.Items.Add("Pasantia");
            // Aquí podrías cargar los valores desde la base de datos si lo deseas

        }

        private void CargarPuestos()
        {
            try
            {
                var negocio = new PostulacionesNegocio();  // Instancia de la capa de negocios
                var puestos = negocio.ObtenerPuestos(); // Obtener los puestos desde la base de datos

                cmbPuesto.Items.Clear();  // Limpiar los elementos anteriores (si los hay)

                // Agregar los puestos al ComboBox
                foreach (var puesto in puestos)
                {
                    cmbPuesto.Items.Add(puesto);
                }

                // Si hay elementos, seleccionar el primero por defecto
                if (cmbPuesto.Items.Count > 0)
                    cmbPuesto.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los puestos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
