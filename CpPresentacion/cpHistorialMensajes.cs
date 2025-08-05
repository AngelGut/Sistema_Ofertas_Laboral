using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using Capa_Datos;

namespace CpPresentacion
{
    public partial class cpHistorialMensajes : MaterialForm
    {
        public cpHistorialMensajes()
        {
            InitializeComponent();
            materialTabControl1.SelectedIndex = 5;

            // Configurar el DataGridView para que sea solo lectura
            ConfigurarDataGridView();
        }

        private void cpHistorialMensajes_Load(object sender, EventArgs e)
        {
            CargarHistorial(); // Cargar historial al iniciar
        }

        private async void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            await NavegarA(materialTabControl1.SelectedIndex);
        }

        private async Task NavegarA(int idx)
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
                8 => this is cpHistorialPostulaciones ? this : new cpHistorialPostulaciones(),
                _ => null
            };

            if (destino == null || destino == this) return;

            destino.Show();

            if (this is Menu)
                this.Hide();
            else
                this.Dispose();

            await Task.Delay(180);
        }

        // 🔹 Cargar historial desde base de datos
        private void CargarHistorial()
        {
            try
            {
                string filtro = txtBuscar.Text.Trim();

                using (SqlConnection conn = OfertaDatos.ObtenerConexion())
                {
                    conn.Open();

                    string query = @"
                    SELECT a.Id AS [ID],
                           p.Nombre AS [Nombre],
                           p.DNI,
                           p.Correo,
                           o.Puesto,
                           e.Nombre AS [Empresa],
                           a.FechaAsignacion
                    FROM Asignacion a
                    JOIN Persona p ON a.PersonaId = p.Id
                    JOIN Oferta o ON a.OfertaId = o.Id
                    JOIN Empresa e ON o.EmpresaId = e.Id
                    WHERE p.Nombre LIKE @filtro OR p.Cedula LIKE @filtro OR p.Correo LIKE @filtro OR o.Puesto LIKE @filtro
                    ORDER BY a.FechaAsignacion DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                    SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    dgvHistorial.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Configuración del DataGridView
        private void ConfigurarDataGridView()
        {
            dgvHistorial.ReadOnly = true;
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.MultiSelect = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // 🔹 Evento del botón de búsqueda
        private void mbtnBuscar_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void mbtnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";            // Limpia el TextBox
            CargarHistorial();              // Vuelve a cargar todo el historial sin filtro
        }
    }
}
