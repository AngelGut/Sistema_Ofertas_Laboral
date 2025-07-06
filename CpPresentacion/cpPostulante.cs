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
    public partial class cpPostulante : MaterialForm
    {
        public cpPostulante()
        {
            InitializeComponent();

            // Establece el tab activo que corresponde a este formulario
            materialTabControl1.SelectedIndex = 3;
        }

        private async void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice de la pestaña actualmente seleccionada
            int selectedIndex = materialTabControl1.SelectedIndex;

            // Si se selecciona la pestaña 0 (que representa el formulario Menu)
            if (selectedIndex == 0 && !(this is Menu))
            {
                var f = new Menu();  // Crear nueva instancia del formulario Menu
                f.Show();            // Mostrar el formulario Menu

                await Task.Delay(500); // Esperar brevemente para asegurar transición fluida
                this.Dispose();        // Liberar recursos del formulario actual (cpOfertas, etc.)
            }

            // Si se selecciona la pestaña 1 (cpOfertas)
            else if (selectedIndex == 1 && !(this is cpOfertas))
            {
                var f = new cpOfertas();  // Crear instancia de cpOfertas
                f.Show();                 // Mostrar el formulario

                await Task.Delay(500);    // Esperar brevemente
                this.Dispose();           // Liberar este formulario actual
            }

            // Si se selecciona la pestaña 2 (cpEmpresa)
            else if (selectedIndex == 2 && !(this is cpEmpresa))
            {
                var f = new cpEmpresa();  // Crear instancia de cpEmpresa
                f.Show();                 // Mostrar el formulario

                await Task.Delay(500);    // Esperar
                this.Dispose();           // Liberar este formulario
            }

            // Si se selecciona la pestaña 3 (cpPostulante)
            else if (selectedIndex == 3 && !(this is cpPostulante))
            {
                var f = new cpPostulante();  // Crear instancia de cpPostulante
                f.Show();                    // Mostrar el formulario

                await Task.Delay(500);       // Esperar
                this.Dispose();              // Liberar este formulario
            }
        }
    }
}
