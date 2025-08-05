    using CpNegocio.Empresas_y_Postulantes;
    using CpNegocio;
    using MaterialSkin.Controls;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;
    using MaterialSkin;
    using CpNegocio.Oferta;
    using System.Configuration; 
    using Microsoft.Data.SqlClient;
    using CpNegocio.servicios;
    using CpNegocio.Interfaces;

    namespace CpPresentacion
    {
        public partial class cpAsignarEmpleo : MaterialForm
        {
            private DataTable tablaPostulantes;
            
            private int idEmpresaSeleccionada = -1;
            private DataTable tablaEmpresas;

        // Variables para almacenar los IDs de las filas seleccionadas
        private int idPostulanteSeleccionado = -1;
        private int idOfertaSeleccionada = -1;
        private int idUsuarioQueAsigna = 1; // Asume un valor por defecto. Deberás obtenerlo del usuario que ha iniciado sesión.
        private void cmbNuevo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarPostulantes(txtBuscarDNI.Text.Trim());
        }
        private void cpAsignarEmpleo_Load(object sender, EventArgs e)
            {
            MostrarEmpresas();
            MostrarPostulantes();
            }




        public cpAsignarEmpleo()
            {
                InitializeComponent();
                materialTabControl1.SelectedIndex = 4;
                this.Load += frmEmpleo_Load;
                
            // Cargar áreas en cmbFiltroArea
            cmbFiltroArea.Items.Clear();
            cmbFiltroArea.Items.Add("Todas"); 
            foreach (var area in AreaLaboralProvider.GetAll())
            {
                cmbFiltroArea.Items.Add(area);
            }
            cmbFiltroArea.SelectedIndex = 0;

            // Configurar el nuevo ComboBox para el filtro de postulantes
            cmbNuevo.Items.Clear();
            cmbNuevo.Items.Add("ID");
            cmbNuevo.Items.Add("Dni");
            cmbNuevo.Items.Add("Nombre");
            cmbNuevo.SelectedIndex = 0; // Seleccionar el primer ítem por defecto
            cmbNuevo.SelectedIndexChanged += cmbNuevo_SelectedIndexChanged;


            this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                // Aplica solo color al seleccionar fila
                dgvPostulantes.EnableHeadersVisualStyles = false;
                dgvPostulantes.RowHeadersDefaultCellStyle.BackColor = Color.White;
                dgvPostulantes.RowsDefaultCellStyle.BackColor = Color.White;
                dgvPostulantes.RowsDefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dgvPostulantes.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
                dgvEmpresas.EnableHeadersVisualStyles = false;
                dgvEmpresas.RowHeadersDefaultCellStyle.BackColor = Color.White;
                dgvEmpresas.RowsDefaultCellStyle.BackColor = Color.White;
                dgvEmpresas.RowsDefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dgvEmpresas.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

                var materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
                materialSkinManager.AddFormToManage(this);
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

                cmbFiltroEmpresa.Items.Clear();
            cmbFiltroEmpresa.Items.Add("Todas");
            cmbFiltroEmpresa.Items.Add("ID");
                cmbFiltroEmpresa.Items.Add("Nombre");
                cmbFiltroEmpresa.Items.Add("RNC");
                

            cmbFiltroEmpresa.SelectedIndex = 0;

                btnBuscar2.Click += btnBuscar2_Click;

                // Cargar áreas en cmbFiltroArea
                cmbFiltroArea.Items.Clear();
                foreach (var area in AreaLaboralProvider.GetAll())
                {
                    cmbFiltroArea.Items.Add(area);
                }
                cmbFiltroArea.SelectedIndex = -1;
            }

            /* Evento Load para inicializar datos */
            private void frmEmpleo_Load(object sender, EventArgs e)
            {
                MostrarPostulantes();
                MostrarEmpresas();
            }

            private void MostrarPostulantes()
            {
                var negocioPostulante = new NPostulante();
                tablaPostulantes = negocioPostulante.Mostrar();
                dgvPostulantes.DataSource = tablaPostulantes;
            }

            private void BuscarPostulantePorID(string id)
            {
                var negocioPostulante = new NPostulante();
                dgvPostulantes.DataSource = negocioPostulante.BuscarPorID(id);
            }

            private void BuscarPostulantePorDNI(string dni)
            {
                var negocioPostulante = new NPostulante();
                dgvPostulantes.DataSource = negocioPostulante.BuscarPorDNI(dni);
            }

        public void MostrarEmpresas()
        {
            var negocioEmpresa = new NEmpresa();
            // Llama al nuevo método para obtener los datos completos
            tablaEmpresas = negocioEmpresa.ObtenerEmpresasConArea();
            dgvEmpresas.DataSource = tablaEmpresas;
        }



        private void btnBuscar_Click(object sender, EventArgs e)
            {
                string texto = txtBuscarDNI.Text.Trim();
                if (string.IsNullOrEmpty(texto))
                {
                    dgvPostulantes.DataSource = tablaPostulantes;
                    return;
                }

                if (cmbFiltroBusqueda.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un filtro: ID o DNI.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string opcion = cmbFiltroBusqueda.SelectedItem.ToString();
                DataView vista = new DataView(tablaPostulantes);

                string filtro = opcion switch
                {
                    "ID" => $"Convert(Id, 'System.String') = '{texto}'",
                    "Dni" => $"Cedula LIKE '%{texto}%'",
                    _ => ""
                };

                if (string.IsNullOrEmpty(filtro))
                {
                    MessageBox.Show("Filtro inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                vista.RowFilter = filtro;
                dgvPostulantes.DataSource = vista;

                // ✅ Verificamos si la vista está vacía DESPUÉS de aplicar el filtro
                if (vista.Count == 0)
                {
                    MessageBox.Show($"No se encontró ningún postulante con {opcion}: {texto}", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvPostulantes.DataSource = tablaPostulantes; // (opcional) restaurar lista completa
                }
            }



            private void btnBuscarID_Click(object sender, EventArgs e)
            {
            string texto = txtBuscarDNI.Text;

            // ➡️ Aquí es donde se valida y se muestra la alerta si el campo está vacío.
            if (string.IsNullOrWhiteSpace(texto))
            {
                MessageBox.Show("Por favor, introduce un valor para realizar la búsqueda.", "Campo de búsqueda vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Salimos del método para que no se ejecute el resto del código.
                return;
            }

            // Si el campo tiene texto, llamamos a la función de filtrado.
            FiltrarPostulantes(texto);

            






                if (string.IsNullOrEmpty(texto))
                {
                    dgvPostulantes.DataSource = tablaPostulantes;
                    return;
                }

                if (cmbNuevo.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un filtro: ID o Dni.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string opcion = cmbNuevo.SelectedItem.ToString();
                DataView vista = new DataView(tablaPostulantes);

                string filtro = opcion switch
                {
                    "ID" => $"Convert(Id, 'System.String') = '{texto}'",
                    "Dni" => $"Dni LIKE '%{texto}%'",
                    "Nombre" => $"Nombre LIKE '%{texto}%'",
                    _ => ""
                };

            

                if (string.IsNullOrEmpty(filtro))
                {
                    MessageBox.Show("Filtro inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                vista.RowFilter = filtro;
                dgvPostulantes.DataSource = vista;

                if (vista.Count == 0)
                {
                    MessageBox.Show($"No se encontró ningún postulante con {opcion}.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvPostulantes.DataSource = tablaPostulantes;
                }
            }





            private void txtBuscarDNI_TextChanged(object sender, EventArgs e)
            {
                FiltrarPostulantes(txtBuscarDNI.Text.Trim());
            }


        private void FiltrarPostulantes(string texto)
        {

            
            if (tablaPostulantes == null) return;

            // Si el texto de búsqueda está vacío, mostramos la tabla completa.
            if (string.IsNullOrWhiteSpace(texto))
            {
                dgvPostulantes.DataSource = tablaPostulantes;
                return;
            }

            DataView vista = new DataView(tablaPostulantes);
            string filtro = "";
            string filtroSeleccionado = cmbNuevo.SelectedItem?.ToString();

            // Lógica para aplicar el filtro según la opción seleccionada.
            if (filtroSeleccionado == "ID")
            {
                filtro = $"Convert(Id, 'System.String') LIKE '%{texto}%'";
            }
            else if (filtroSeleccionado == "Dni")
            {
                filtro = $"Dni LIKE '%{texto}%'";
            }
            else if (filtroSeleccionado == "Nombre")
            {
                filtro = $"Nombre LIKE '%{texto}%'";
            }
            else
            {
                // En caso de que no se haya seleccionado un filtro, busca en todos los campos.
                filtro = $"Convert(Id, 'System.String') LIKE '%{texto}%' OR Dni LIKE '%{texto}%' OR Nombre LIKE '%{texto}%'";
            }

            // Aplica el filtro a la vista de datos.
            vista.RowFilter = filtro;
            dgvPostulantes.DataSource = vista;

            // --- Aquí está la clave para la alerta ---
            // Si la vista está vacía después de aplicar el filtro, mostramos el mensaje.
            if (vista.Count == 0)
            {
                MessageBox.Show($"No se encontraron postulantes con ese '{filtroSeleccionado}' que coincidan con '{texto}'.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Opcional: restaurar el DataGridView para que muestre todos los postulantes.
                dgvPostulantes.DataSource = tablaPostulantes;
            }
        }

        private string cedulaPostulanteSeleccionado;
            private string correoEmpresaSeleccionada;

            private void cmbFiltroBusqueda_SelectedIndexChanged(object sender, EventArgs e)
            {
                FiltrarPostulantes(txtBuscarDNI.Text.Trim());
            }

        private void AplicarFiltrosEmpresas()
        {
            if (tablaEmpresas == null) return;

            DataView vista = new DataView(tablaEmpresas);
            string filtroGeneral = "";
            string filtroArea = "";

            // Lógica para el filtro de área
            if (cmbFiltroArea.SelectedItem?.ToString() != "Todas")
            {
                filtroArea = $"Area = '{cmbFiltroArea.SelectedItem?.ToString().Replace("'", "''")}'";
            }

            // Lógica para el filtro general (ID, Nombre, RNC)
            string textoBusqueda = txtBuscarID.Text.Trim();
            string filtroSeleccionado = cmbFiltroEmpresa.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                switch (filtroSeleccionado)
                {
                    case "ID":
                        filtroGeneral = $"Convert(Id, 'System.String') LIKE '%{textoBusqueda}%'";
                        break;
                    case "Nombre":
                        filtroGeneral = $"Nombre LIKE '%{textoBusqueda}%'";
                        break;
                    case "RNC":
                        filtroGeneral = $"RNC LIKE '%{textoBusqueda}%'";
                        break;
                    case "Todas":
                        filtroGeneral = $"Nombre LIKE '%{textoBusqueda}%' OR RNC LIKE '%{textoBusqueda}%' OR Convert(Id, 'System.String') LIKE '%{textoBusqueda}%'";
                        break;
                }
            }

            // Combina ambos filtros
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

            if (vista.Count == 0 && (!string.IsNullOrEmpty(filtroFinal)))
            {
                MessageBox.Show("No se encontraron resultados con los filtros aplicados.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvEmpresas.DataSource = tablaEmpresas;
            }
        }





        private void cmbFiltroArea_SelectedIndexChanged(object sender, EventArgs e)
            {
                AplicarFiltrosEmpresas();
            }



          private void btnBuscar2_Click(object sender, EventArgs e)
          {
            AplicarFiltrosEmpresas();
          }






            private void txtBuscarDNI_Click(object sender, EventArgs e)
            {
                // Código opcional al hacer click en el TextBox
            }

            private void txtBuscarID_Click(object sender, EventArgs e)
            {
                // Código opcional al hacer click en el TextBox
            }

            private void tabPage3_Click(object sender, EventArgs e)
            {
                // Evento de clic en la pestaña 3 (si aplica)
            }

            /* Manejo del cambio de pestañas */
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



            private void dgvPostulantes_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                  // Obtener la cédula del postulante seleccionado
                  idPostulanteSeleccionado = Convert.ToInt32(dgvPostulantes.Rows[e.RowIndex].Cells["Id"].Value);
                  MessageBox.Show("Postulante seleccionado ID: " + idPostulanteSeleccionado);
                }
            }

            private void dgvEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
            {
              if (e.RowIndex >= 0)
              {
                // Obtén el valor de la columna "OfertaId" de la fila seleccionada
                idOfertaSeleccionada = Convert.ToInt32(dgvEmpresas.Rows[e.RowIndex].Cells["OfertaId"].Value);
                MessageBox.Show("Oferta seleccionada ID: " + idOfertaSeleccionada);
              }


            }
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (idPostulanteSeleccionado == -1)
            {
                MessageBox.Show("Por favor, selecciona un postulante de la tabla de la izquierda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idOfertaSeleccionada == -1)
            {
                MessageBox.Show("Por favor, selecciona una oferta de la tabla de la derecha.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Server=.;Database=OfertaLaboral;Integrated Security=true;TrustServerCertificate=True;";
            string query = @"
        INSERT INTO Asignacion (PersonaId, OfertaId) 
        VALUES (@personaId, @ofertaId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@personaId", idPostulanteSeleccionado);
                command.Parameters.AddWithValue("@ofertaId", idOfertaSeleccionada);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Asignación realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        idPostulanteSeleccionado = -1;
                        idOfertaSeleccionada = -1;

                        // Opcional: limpiar selección visual o refrescar tablas
                    }
                    else
                    {
                        MessageBox.Show("No se pudo realizar la asignación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // violación UNIQUE (PersonaId, OfertaId)
                    {
                        MessageBox.Show("Esta asignación ya existe y no puede duplicarse.", "Duplicado detectado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Error de base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // En tu archivo cpAsignarEmpleo.cs
        private void dgvEmpresas_CellContentClick(object sender, DataGridViewCellEventArgs e)
             {
               // Lógica para manejar el clic en la celda de dgvEmpresas
               // Si no tienes lógica, puedes dejarlo vacío por ahora.
             }
          private void dgvPostulantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
          {
            // Lógica para manejar el clic en la celda de dgvEmpresas
            // Si no tienes lógica, puedes dejarlo vacío por ahora.
          }


         /// ya estamos mas cerca


        }
    }
