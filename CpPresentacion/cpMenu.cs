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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CpPresentacion
{
    public partial class Menu : MaterialForm // <<== ¡Cambiado a MaterialForm!
    {
        public Menu()
        {
            InitializeComponent();

            // Establece el tab activo que corresponde a este formulario
            materialTabControl1.SelectedIndex = 0;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        //Este método debe marcarse como async para poder usar 'await Task.Delay(...)'
        private async void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice de la pestaña actualmente seleccionada
            int selectedIndex = materialTabControl1.SelectedIndex;

            // Si se selecciona la pestaña con índice 1 (que corresponde a cpOfertas)
            // y el formulario actual NO es cpOfertas, entonces procedemos a abrirlo
            if (selectedIndex == 1 && !(this is cpOfertas))
            {
                var f = new cpOfertas(); // Crear una nueva instancia del formulario cpOfertas
                f.Show();                // Mostrar ese formulario

                this.Hide();             // Ocultar el formulario actual (Menu), sin cerrarlo

                await Task.Delay(1000);  // Esperar 1 segundo (opcional, puede omitirse)
            }
            // Si se selecciona la pestaña 2 (cpEmpresa) y no estamos ya en ese formulario
            else if (selectedIndex == 2 && !(this is cpEmpresa))
            {
                var f = new cpEmpresa(); // Crear instancia del formulario cpEmpresa
                f.Show();                // Mostrar el formulario

                this.Hide();             // Ocultar el formulario Menu
                await Task.Delay(1000);  // Espera opcional
            }
            // Si se selecciona la pestaña 3 (cpPostulante) y no estamos ya en ese formulario
            else if (selectedIndex == 3 && !(this is cpPostulante))
            {
                var f = new cpPostulante(); // Crear instancia del formulario cpPostulante
                f.Show();                   // Mostrar el formulario

                this.Hide();                // Ocultar el formulario Menu
                await Task.Delay(1000);     // Espera opcional
            }

            // Nota: No se hace nada si se selecciona el índice 0 (Menu) ya que ya estamos en Menu.
        }
    }
}
