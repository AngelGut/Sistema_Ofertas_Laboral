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

namespace CpPresentacion
{
    public partial class cpAsignarEmpleo : MaterialForm
    {
        private DataTable tablaPostulantes;
        private int idPostulanteSeleccionado = -1;
        private int idEmpresaSeleccionada = -1;


        public cpAsignarEmpleo()
        {
            InitializeComponent();
            materialTabControl1.SelectedIndex = 4;
            this.Load += frmEmpleo_Load;
            cmbFiltroBusqueda.Items.Clear();
            cmbFiltroBusqueda.Items.Add("ID");
            cmbFiltroBusqueda.Items.Add("Cédula");
            cmbFiltroBusqueda.SelectedIndex = 0;
            cmbFiltroBusqueda.SelectedIndexChanged += cmbFiltroBusqueda_SelectedIndexChanged;

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

        private void MostrarEmpresas()
        {
            var negocioEmpresa = new NEmpresa();
            dgvEmpresas.DataSource = negocioEmpresa.Mostrar();
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
                MessageBox.Show("Por favor, selecciona un filtro: ID o Cédula.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string opcion = cmbFiltroBusqueda.SelectedItem.ToString();
            DataView vista = new DataView(tablaPostulantes);

            string filtro = opcion switch
            {
                "ID" => $"Convert(Id, 'System.String') = '{texto}'",
                "Cédula" => $"Cedula LIKE '%{texto}%'",
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
                MessageBox.Show("Por favor, selecciona un filtro: ID o Cédula.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string opcion = cmbFiltroBusqueda.SelectedItem.ToString();
            DataView vista = new DataView(tablaPostulantes);

            string filtro = opcion switch
            {
                "ID" => $"Convert(Id, 'System.String') = '{texto}'",
                "Cédula" => $"Cedula LIKE '%{texto}%'",
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
                // Busca exacto o parcial en ID (puedes ajustar para exacto si querés)
                filtro = $"Convert(Id, 'System.String') LIKE '%{texto}%'";
            }
            else if (filtroSeleccionado == "Cédula")
            {
                // Busca texto parcial en Cédula
                filtro = $"Cedula LIKE '%{texto}%'";
            }
            else
            {
                // Si no hay selección válida, no filtrar o filtrar en ambas
                filtro = $"Convert(Id, 'System.String') LIKE '%{texto}%' OR Cedula LIKE '%{texto}%'";
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
                cedulaPostulanteSeleccionado = dgvPostulantes.Rows[e.RowIndex].Cells["Cedula"].Value.ToString();

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
