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
            //Metodo de personalizacion del datagridview
            PersonalizarDataGridView();
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
                           p.Dni,
                           p.Correo,
                           o.Puesto,
                           e.Nombre AS [Empresa],
                           a.FechaAsignacion
                    FROM Asignacion a
                    JOIN Persona p ON a.PersonaId = p.Id
                    JOIN Oferta o ON a.OfertaId = o.Id
                    JOIN Empresa e ON o.EmpresaId = e.Id
                    WHERE p.Nombre LIKE @filtro OR p.Dni LIKE @filtro OR p.Correo LIKE @filtro OR o.Puesto LIKE @filtro
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
            string filtro = txtBuscar.Text.Trim();
            CargarHistorial(); // Recarga el historial con el filtro

            if (int.TryParse(filtro, out int idBuscado))
            {
                foreach (DataGridViewRow fila in dgvHistorial.Rows)
                {
                    if (Convert.ToInt32(fila.Cells["ID"].Value) == idBuscado)
                    {
                        fila.Selected = true;
                        dgvHistorial.CurrentCell = fila.Cells[0];

                        try
                        {
                            using (SqlConnection conn = OfertaDatos.ObtenerConexion())
                            {
                                conn.Open();
                                string query = @"
                            SELECT p.Nombre, o.Puesto, o.Area, o.Descripcion, o.Requisitos, o.Salario
                            FROM Asignacion a
                            INNER JOIN Persona p ON a.PersonaId = p.Id
                            INNER JOIN Oferta o ON a.OfertaId = o.Id
                            WHERE a.Id = @IdAsignacion";

                                SqlCommand cmd = new SqlCommand(query, conn);
                                cmd.Parameters.AddWithValue("@IdAsignacion", idBuscado);

                                SqlDataReader reader = cmd.ExecuteReader();
                                if (reader.Read())
                                {
                                    string mensaje = $@"
                                        Hola {reader["Nombre"]},
                                        ¡Enhorabuena! Has sido asignado/a a la oferta: {reader["Puesto"]}.

                                        Resumen de la oferta:
                                        • Puesto: {reader["Puesto"]}
                                        • Área: {reader["Area"]}
                                        • Salario: ${reader["Salario"]}

                                        Descripción:
                                        {reader["Descripcion"]}

                                        Requisitos:
                                        {reader["Requisitos"]}

                                        — Equipo EmpleaTech";

                                    txtResumenCorreo.Text = mensaje;
                                }

                                reader.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al mostrar detalles: " + ex.Message);
                        }

                        break;
                    }
                }
            }
        }
        private void mbtnLimpiar_Click(object sender, EventArgs e)
        { 
            // Limpiar el campo de búsqueda
            txtBuscar.Text = string.Empty;

            // Limpiar el contenido del resumen del correo
            txtResumenCorreo.Clear();

            // Limpiar la selección en el DataGridView
            dgvHistorial.ClearSelection();

            // Recargar el historial completo sin filtros
            CargarHistorial();
        }

        private void PersonalizarDataGridView()
        {
            // Cambiar el color de fondo general del DataGridView
            dgvHistorial.BackgroundColor = Color.FromArgb(240, 248, 255); // Azul muy suave, estilo "Azure"

            // Personalizar el color de los encabezados de las columnas
            dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204); // Azul oscuro
            dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHistorial.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgvHistorial.ColumnHeadersHeight = 40;

            // Cambiar el color de las filas
            dgvHistorial.RowsDefaultCellStyle.BackColor = Color.White;
            dgvHistorial.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 255); // Azul suave en filas alternas
            dgvHistorial.RowsDefaultCellStyle.ForeColor = Color.Black;

            // Cambiar el color del borde del DataGridView
            dgvHistorial.BorderStyle = BorderStyle.FixedSingle;
            dgvHistorial.GridColor = Color.FromArgb(200, 200, 200); // Gris claro para las líneas de la cuadrícula

            // Personalizar las celdas
            dgvHistorial.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204); // Azul oscuro cuando se selecciona
            dgvHistorial.DefaultCellStyle.SelectionForeColor = Color.White; // Texto blanco cuando se selecciona

            // Personalizar las celdas al pasar el ratón (Hover)
            dgvHistorial.CellMouseEnter += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    dgvHistorial.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(173, 216, 230); // Azul claro cuando el mouse pasa
                }
            };

            dgvHistorial.CellMouseLeave += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    dgvHistorial.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White; // Vuelve a blanco
                }
            };

            // Personalizar la fuente de las celdas
            dgvHistorial.DefaultCellStyle.Font = new Font("Arial", 9);

            // Personalizar las filas de la cabecera al ser seleccionadas
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.MultiSelect = false;

            // Ajustar el tamaño de las columnas automáticamente según el contenido
            dgvHistorial.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}
