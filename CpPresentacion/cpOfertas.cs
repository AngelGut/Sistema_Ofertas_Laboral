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

namespace CpPresentacion
{
    public partial class cpOfertas : MaterialForm // <<== ¡Cambiado a MaterialForm!
    {
      
        public cpOfertas()
        {
            InitializeComponent();
            
            // Establece el tab activo que corresponde a este formulario
            materialTabControl1.SelectedIndex = 1;

            // Mejora visual: habilitar doble búfer para reducir parpadeos
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            //Esto hará que se muestren los nombres de las empresas en el ComboBox
            var empresas = new MetodosCargarEmpresa().ObtenerEmpresas();
            CboxEmpresas.DataSource = empresas;

            // Lógica para ocultar los campos de Salario y Créditos al inicio
            TxtSalario.Visible = false; // Ocultar TextBox de Salario
            TxtCreditos.Visible = false; // Ocultar TextBox de Créditos

            // Si el ComboBox de tipo de oferta tiene al menos un elemento,
            // seleccionamos el primero por defecto para que no quede en blanco
            if (CboxTipoOferta.Items.Count > 0)
            {
                CboxTipoOferta.SelectedIndex = 0; // Seleccionar el primer elemento por defecto
            }

            CargarOfertas(); // Cargar ofertas al iniciar el formulario

            CargarEmpresas(); // Cargar empresas aquí

            
        }

        private async void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice de la pestaña seleccionada por el usuario
            int selectedIndex = materialTabControl1.SelectedIndex;

            // Llamar a la función común para abrir formularios
            await AbrirFormulario(selectedIndex);
        }

        private async Task AbrirFormulario(int selectedIndex)
        {
            Form formulario = null;

            // Seleccionar el formulario correspondiente según el índice de la pestaña
            switch (selectedIndex)
            {
                case 0:  // Menu
                    if (!(this is Menu))
                    {
                        formulario = new Menu();  // Crear nueva instancia de Menu
                    }
                    break;

                case 1:  // cpOfertas
                    if (!(this is cpOfertas))
                    {
                        formulario = new cpOfertas();  // Crear nueva instancia de cpOfertas
                    }
                    break;

                case 2:  // cpEmpresa
                    if (!(this is cpEmpresa))
                    {
                        formulario = new cpEmpresa();  // Crear nueva instancia de cpEmpresa
                    }
                    break;

                case 3:  // cpPostulante
                    if (!(this is cpPostulante))
                    {
                        formulario = new cpPostulante();  // Crear nueva instancia de cpPostulante
                    }
                    break;
            }

            // Si se ha seleccionado un formulario válido, mostrarlo
            if (formulario != null)
            {
                this.Hide();        // Ocultar el formulario actual
                formulario.Show();  // Mostrar el formulario seleccionado
                await Task.Delay(300); // Pausa breve, si es necesario
            }
            else
            {
                MessageBox.Show("Este formulario ya está abierto o no se puede acceder.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                materialTabControl1.SelectedIndex = 0;  // Regresar a la pestaña de inicio (Menu)
            }
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
                // Validar que se haya seleccionado una empresa
                if (CboxEmpresas.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar una empresa antes de registrar la oferta.", "Empresa requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que se haya seleccionado un tipo de oferta
                if (CboxTipoOferta.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de oferta.", "Tipo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener valores seleccionados
                string tipo = CboxTipoOferta.SelectedItem.ToString();
                int empresaId = ((CpNegocio.Entidades.EmpresaComboItem)CboxEmpresas.SelectedItem).Id;

                if (tipo == "Empleo Fijo")
                {
                    var empleo = new EmpleoFijo
                    {
                        EmpresaId = empresaId,
                        Puesto = TxtPuesto.Text,
                        Descripcion = TxtDescripcion.Text,
                        Requisitos = TxtRequisitos.Text,
                        Salario = int.TryParse(TxtSalario.Text, out int salario) ? salario : null
                    };

                    new MetodosEmpleoFijo().Registrar(empleo);
                    MessageBox.Show("Oferta de Empleo registrada con éxito.");
                }
                else if (tipo == "Pasantia")
                {
                    var pasantia = new Pasantia
                    {
                        EmpresaId = empresaId,
                        Puesto = TxtPuesto.Text,
                        Descripcion = TxtDescripcion.Text,
                        Requisitos = TxtRequisitos.Text,
                        Creditos = int.TryParse(TxtCreditos.Text, out int creditos) ? creditos : 0
                    };

                    new MetodosPasantia().Registrar(pasantia);
                    MessageBox.Show("Pasantía registrada con éxito.");
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un tipo de oferta válido.", "Tipo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Recargar tabla y limpiar
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

        //ya esta terminado
    }
}
