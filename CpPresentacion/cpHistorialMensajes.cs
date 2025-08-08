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

            // 🔹Configurar el DataGridView para que no permita edición y tenga formato adecuado
            ConfigurarDataGridView();

            // 🔹 Asociar el evento de clic en fila al método que muestra los detalles del mensaje
            dgvHistorial.CellClick += dgvHistorial_CellClick;
        }

        // 🔹 Evento que se ejecuta al cargar el formulario
        private void cpHistorialMensajes_Load(object sender, EventArgs e)
        {
            CargarHistorial(); // Cargar historial desde la base de datos
        }

        // 🔹 Maneja el cambio de pestañas en el tabControl y navega entre formularios
        private async void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            await NavegarA(materialTabControl1.SelectedIndex);
        }

        // 🔹 Método de navegación entre formularios (animado)
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

            await Task.Delay(180); // Pequeña pausa para animación/transición
        }

        // 🔹 Cargar historial general de asignaciones desde la base de datos
        private void CargarHistorial()
        {
            try
            {
                string filtro = txtBuscar.Text.Trim(); // Captura el filtro de búsqueda

                using (SqlConnection conn = OfertaDatos.ObtenerConexion())
                {
                    conn.Open();

                    string query = @"
                        SELECT a.Id AS [ID Asignación],
                               p.Nombre AS [Nombre Persona],
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

        // 🔹 Configurar comportamiento visual del DataGridView
        private void ConfigurarDataGridView()
        {
            dgvHistorial.ReadOnly = true;
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.MultiSelect = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 🎨 Colores modernos con armonía
            dgvHistorial.BackgroundColor = Color.White;
            dgvHistorial.GridColor = Color.FromArgb(200, 200, 200); // líneas sutiles

            // 🎨 Colores de filas alternas
            dgvHistorial.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 255);

            // 🎨 Encabezado azul oscuro con texto blanco
            dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 53, 73);
            dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHistorial.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvHistorial.EnableHeadersVisualStyles = false;

            // 🎨 Filas normales
            dgvHistorial.DefaultCellStyle.BackColor = Color.White;
            dgvHistorial.DefaultCellStyle.ForeColor = Color.Black;
            dgvHistorial.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // 🎨 Selección
            dgvHistorial.DefaultCellStyle.SelectionBackColor = Color.FromArgb(72, 133, 237);
            dgvHistorial.DefaultCellStyle.SelectionForeColor = Color.White;

            // 🎨 Bordes
            dgvHistorial.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistorial.RowHeadersVisible = false; // Oculta la columna de los encabezados laterales
        }


        // 🔹 Botón de búsqueda con filtro
        private void mbtnBuscar_Click(object sender, EventArgs e)
        {
            CargarHistorial(); // Aplica el filtro ingresado
        }

        // 🔹 Botón para limpiar el filtro de búsqueda
        private void mbtnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = ""; // Limpia el texto
            CargarHistorial();   // Recarga el historial completo
        }

        // 🔹 Mostrar mensaje detallado al hacer clic sobre una fila del DataGridView
        private void dgvHistorial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Validar que no se haga clic en el encabezado
            {
                // Obtener el ID de la asignación seleccionada
                int idAsignacion = Convert.ToInt32(dgvHistorial.Rows[e.RowIndex].Cells["ID Asignación"].Value);

                try
                {
                    using (SqlConnection conn = OfertaDatos.ObtenerConexion())
                    {
                        conn.Open();

                        string query = @"
                            SELECT 
                                p.Nombre AS Nombre,
                                o.Puesto,
                                o.Area,
                                o.Descripcion,
                                o.Requisitos,
                                o.Salario
                            FROM Asignacion a
                            INNER JOIN Persona p ON a.PersonaId = p.Id
                            INNER JOIN Oferta o ON a.OfertaId = o.Id
                            WHERE a.Id = @IdAsignacion";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@IdAsignacion", idAsignacion);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            // Recuperar valores desde el lector
                            string nombre = reader["Nombre"].ToString();
                            string puesto = reader["Puesto"].ToString();
                            string area = reader["Area"].ToString();
                            string descripcion = reader["Descripcion"].ToString();
                            string requisitos = reader["Requisitos"].ToString();
                            string salario = reader["Salario"].ToString();

                            // Construir el mensaje para mostrar
                            string mensaje = $@"
                                Hola {nombre},
                                ¡Enhorabuena! Has sido asignado/a a la oferta: {puesto}.

                                Resumen de la oferta:
                                • Puesto: {puesto}
                                • Área: {area}
                                • Salario: ${salario}

                                Descripción:
                                {descripcion}

                                Requisitos:
                                {requisitos}

                                — Equipo EmpleaTech
                            ";

                            // Mostrar en el TextBox o RichTextBox
                            txtDetalleMensaje.Text = mensaje;
                        }

                        reader.Close(); // Cerrar lector
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar detalles del mensaje:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
