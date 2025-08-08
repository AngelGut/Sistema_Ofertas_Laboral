using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Datos;
using CpNegocio.Oferta;
using CpNegocio.servicios;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CpPresentacion.Asistencia;   // contiene IReadOnlyContainer y las extensiones
using System.Media;
using System.Drawing;                  // por Point
using CpPresentacion.Asistencia;       // por IReadOnlyContainer y SetReadOnly



namespace CpPresentacion
{
    public partial class cpOfertas : MaterialForm, IReadOnlyContainer
    {
        public Control Container => this;
        private FormBoton _formBoton; // switch flotante

        public cpOfertas()
        {
            InitializeComponent();

            materialTabControl1.SelectedIndex = 1;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // Config inicial
            var empresas = new MetodosCargarEmpresa().ObtenerEmpresas();
            CboxEmpresas.DataSource = empresas;
            TxtSalario.Visible = false;
            TxtCreditos.Visible = false;
            if (CboxTipoOferta.Items.Count > 0)
                CboxTipoOferta.SelectedIndex = 0;

            CargarOfertas();
            CargarEmpresas();
            PopulateAreas();

            // 🔹 Bloquear de inicio
            this.SetReadOnly(true);

            // 🔹 Mostrar mini-form y decidir estado inicial
            bool startInEdit = false;
            using (var dlg = new frmModoVisualizacion())
            {
                if (dlg.ShowDialog() == DialogResult.OK &&
                    dlg.Resultado == frmModoVisualizacion.ResultadoSeleccion.Editar)
                {
                    startInEdit = true;
                }
            }

            // 🔹 Aplicar estado inicial
            this.SetReadOnly(!startInEdit);

            // 🔹 Abrir el switch flotante (siempre activo)
            AbrirFormBoton(startInEdit);

            // 🔹 Asegurar que si el form se cierra, se cierre también el flotante
            this.FormClosed += (s, e) =>
            {
                if (_formBoton != null && !_formBoton.IsDisposed) _formBoton.Close();
                _formBoton = null;
            };

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





        private void materialLabel4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void CboxTipoOferta_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoSeleccionado = CboxTipoOferta.SelectedItem.ToString();

            // Oculta todos los campos específicos primero, para resetear la visibilidad
            TxtSalario.Visible = false; // Ocultar TextBox de Salario
            TxtCreditos.Visible = false; // Ocultar TextBox de Créditos

            // Muestra los campos específicos según el tipo de oferta seleccionado
            if (tipoSeleccionado == "Empleo Fijo")
            {
                TxtSalario.Visible = true; // Mostrar TextBox de Salario
            }
            else if (tipoSeleccionado == "Pasantia")
            {
                TxtCreditos.Visible = true; // Mostrar TextBox de Créditos
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CboxEmpresas.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar una empresa antes de registrar la oferta.", "Empresa requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (CboxTipoOferta.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de oferta.", "Tipo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tipo = CboxTipoOferta.SelectedItem.ToString();
                int empresaId = ((CpNegocio.Entidades.EmpresaComboItem)CboxEmpresas.SelectedItem).Id;
                string puesto = TxtPuesto.Text;
                string descripcion = TxtDescripcion.Text;
                string requisitos = TxtRequisitos.Text;
                string area = cmbArea.SelectedItem?.ToString() ?? "";

                int salario = 0;
                int creditos = 0;

                if (tipo == "Empleo Fijo")
                {
                    if (!int.TryParse(TxtSalario.Text, out salario))
                    {
                        MessageBox.Show("Salario inválido.");
                        return;
                    }
                }
                else if (tipo == "Pasantia")
                {
                    if (!int.TryParse(TxtCreditos.Text, out creditos))
                    {
                        MessageBox.Show("Créditos inválidos.");
                        return;
                    }
                }

                // Registrar usando el método unificado
                var metodosOferta = new MetodosOferta();
                metodosOferta.RegistrarOferta(
                    empresaId,
                    puesto,
                    tipo,
                    descripcion,
                    requisitos,
                    salario,
                    creditos,
                    area,
                    false
                );

                MessageBox.Show("Oferta registrada con éxito.");
                CargarOfertas();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar la oferta:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //clase auxiliar para mostrar nombre pero guardar el ID:
        public class EmpresaComboItem
        {
            public int Id { get; set; }
            public string Nombre { get; set; }

            public override string ToString()
            {
                return Nombre;
            }
        }

        //Método para cargar empresas desde la base
        private void CargarEmpresas()
        {
            var metodoEmpresa = new MetodosCargarEmpresa();
            var lista = metodoEmpresa.ObtenerEmpresas();

            // Usar DataSource directamente
            CboxEmpresas.DataSource = lista;
            CboxEmpresas.DisplayMember = "Nombre"; // qué se ve en el ComboBox
            CboxEmpresas.ValueMember = "Id";       // qué valor representa internamente

            if (CboxEmpresas.Items.Count > 0)
                CboxEmpresas.SelectedIndex = 0;
        }

        // Método para cargar ofertas en el DataGridView
        private void CargarOfertas()
        {
            var metodo = new MetodosOferta();
            var lista = metodo.ObtenerOfertas();

            DGridOferta.DataSource = lista;
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            CargarOfertas();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Validar que haya al menos una fila seleccionada
            if (DGridOferta.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una oferta para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmar con el usuario
            var confirm = MessageBox.Show("¿Está seguro que desea eliminar esta oferta?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            // Obtener el ID de la oferta seleccionada
            int ofertaId = Convert.ToInt32(DGridOferta.SelectedRows[0].Cells["Id"].Value);

            try
            {
                // Ejecutar la eliminación desde la base de datos
                using (SqlConnection conn = Capa_Datos.OfertaDatos.ObtenerConexion())
                {
                    conn.Open();
                    string query = "DELETE FROM Oferta WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", ofertaId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Oferta eliminada correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar el DataGrid
                CargarOfertas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la oferta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquear la tecla si no es número ni tecla de control (como Backspace)
            }
        }

        private void TxtCreditos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquear la tecla si no es número ni tecla de control (como Backspace)
            }
        }

        private void LimpiarCampos()
        {
            CboxEmpresas.SelectedIndex = 0; // o -1 si quieres que quede en blanco
            CboxTipoOferta.SelectedIndex = 0;

            TxtPuesto.Text = string.Empty;
            TxtDescripcion.Text = string.Empty;
            TxtRequisitos.Text = string.Empty;
            TxtSalario.Text = string.Empty;
            TxtCreditos.Text = string.Empty;
        }

        private void BtnOcupada_Click(object sender, EventArgs e)
        {
            // Asegurarse de que hay una fila seleccionada
            if (DGridOferta.SelectedRows.Count > 0)
            {
                // Obtener el ID de la oferta seleccionada
                int ofertaId = Convert.ToInt32(DGridOferta.SelectedRows[0].Cells["Id"].Value);

                // Ejecutar actualización en la base de datos
                using (SqlConnection conn = OfertaDatos.ObtenerConexion())
                {
                    conn.Open();
                    string query = "UPDATE Oferta SET Ocupada = 1 WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", ofertaId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Oferta marcada como ocupada.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar la tabla con las ofertas actualizadas
                CargarOfertas();
            }
            else
            {
                MessageBox.Show("Selecciona una oferta primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void PopulateAreas()
        {
            cmbArea.DataSource = AreaLaboralProvider.GetAll();
            cmbArea.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbArea.SelectedIndex = 0;
        }

        private void TxtPuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Bloquear el carácter
            MessageBox.Show("No se permiten caracteres especiales en el campo 'Puesto'.",
                            "Carácter inválido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
        }

        private void TxtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Bloquear el carácter
            MessageBox.Show("No se permiten caracteres especiales en el campo 'Descripcion'.",
                            "Carácter inválido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
        }

        private void TxtRequisitos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, números, espacio y teclas de control (como backspace)
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Bloquear el carácter
                MessageBox.Show("No se permiten caracteres especiales en el campo 'Requisitos'.",
                                "Carácter inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void AbrirFormBoton(bool startInEdit)
        {
            // Evita duplicados
            if (_formBoton != null && !_formBoton.IsDisposed) return;

            _formBoton = new FormBoton(this, startInEdit)
            {
                StartPosition = FormStartPosition.Manual,
                TopMost = true
            };

            void Reposicionar()
            {
                if (_formBoton == null || _formBoton.IsDisposed) return;

                // Coordenadas del formulario principal en pantalla
                var p = this.PointToScreen(Point.Empty);

                // Posición pegada al borde derecho y centrada verticalmente
                int x = p.X + this.Width - _formBoton.Width; // 0px de margen
                int y = p.Y + (this.Height - _formBoton.Height) / 2;

                _formBoton.Location = new Point(x, y);
            }

            // Posicionar ahora y re-posicionar al mover o redimensionar
            Reposicionar();
            this.Move += (s, e) => Reposicionar();
            this.Resize += (s, e) => Reposicionar();

            // Limpiar referencia al cerrarse
            _formBoton.FormClosed += (s, e) => _formBoton = null;

            // Mostrar como ventana hija/propietaria
            _formBoton.Show(this);
        }


    }

}
