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
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;
    using MaterialSkin;
    using CpNegocio.Oferta;
using System.Configuration;
using Microsoft.Data.SqlClient;

    namespace CpPresentacion
    {
        public partial class cpAsignarEmpleo : MaterialForm
        {
            private DataTable tablaPostulantes;
            private int idPostulanteSeleccionado = -1;
            private int idEmpresaSeleccionada = -1;
            private DataTable tablaEmpresas;
            private void cpAsignarEmpleo_Load(object sender, EventArgs e)
            {
            MostrarEmpresas();
            }




        public cpAsignarEmpleo()
            {
                InitializeComponent();
                materialTabControl1.SelectedIndex = 4;
                this.Load += frmEmpleo_Load;
                cmbFiltroBusqueda.Items.Clear();
                cmbFiltroBusqueda.Items.Add("ID");
                cmbFiltroBusqueda.Items.Add("Dni");
                cmbFiltroBusqueda.Items.Add("Nombre");
            // Cargar áreas en cmbFiltroArea
            cmbFiltroArea.Items.Clear();
            cmbFiltroArea.Items.Add("Todas"); 
            foreach (var area in AreaLaboralProvider.GetAll())
            {
                cmbFiltroArea.Items.Add(area);
            }
            cmbFiltroArea.SelectedIndex = 0;

            cmbFiltroBusqueda.SelectedIndex = 0;
                cmbFiltroBusqueda.SelectedIndexChanged += cmbFiltroBusqueda_SelectedIndexChanged;
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






                if (string.IsNullOrEmpty(texto))
                {
                    dgvPostulantes.DataSource = tablaPostulantes;
                    return;
                }

                if (cmbFiltroBusqueda.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un filtro: ID o Dni.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string opcion = cmbFiltroBusqueda.SelectedItem.ToString();
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

                if (string.IsNullOrWhiteSpace(texto))
                {
                    dgvPostulantes.DataSource = tablaPostulantes;
                    return;
                }

                DataView vista = new DataView(tablaPostulantes);
                string filtro = "";

                string filtroSeleccionado = cmbFiltroBusqueda.SelectedItem?.ToString();

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
                    filtro = $"Convert(Id, 'System.String') LIKE '%{texto}%' OR Dni LIKE '%{texto}%' OR Nombre LIKE '%{texto}%'";
                }

                vista.RowFilter = filtro;
                dgvPostulantes.DataSource = vista;
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

            private void dgvPostulantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                    // Obtener la cédula del postulante seleccionado
                    cedulaPostulanteSeleccionado = dgvPostulantes.Rows[e.RowIndex].Cells["Dni"].Value.ToString();

                }
            }

            private void dgvEmpresas_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                    // Obtener el correo de la empresa seleccionada
                    correoEmpresaSeleccionada = dgvEmpresas.Rows[e.RowIndex].Cells["Correo"].Value.ToString();

                }

                 
            }

        /* ── Aquí puedes seguir agregando más lógica propia ── */
    }
    }
