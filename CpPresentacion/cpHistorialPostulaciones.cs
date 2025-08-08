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
        

       

        private void cpHistorialPostulaciones_Load(object sender, EventArgs e)
        {
            

            // Cargar los ComboBox
            CargarComboBoxes();
            CargarPuestos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPersonaId.Clear();
            dgvHistorialPostulaciones.DataSource = null;
        }

        private void cmbTipoOferta_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }


        private void cmbPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
            
        }


    }
}
