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
        }

        private async void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice de la pestaña actualmente seleccionada
            int selectedIndex = materialTabControl1.SelectedIndex;

            // Si se selecciona la pestaña 0 (Menu) y no estamos ya en Menu
            if (selectedIndex == 0 && !(this is Menu))
            {
                var f = new Menu();   // Crear nueva instancia del formulario Menu
                this.Hide();          // Ocultar cpOfertas
                f.Show();             // Mostrar Menu
                await Task.Delay(300);
                this.Dispose();       // Liberar cpOfertas
            }

            // Si se selecciona la pestaña 1 (cpOfertas) y ya estamos aquí
            else if (selectedIndex == 1 && this is cpOfertas)
            {
                return; // No hacer nada, ya estás en cpOfertas
            }

            // Si se selecciona la pestaña 2 (cpEmpresa) y no estamos ya en cpEmpresa
            else if (selectedIndex == 2 && !(this is cpEmpresa))
            {
                var f = new cpEmpresa();  // Crear instancia de cpEmpresa
                this.Hide();              // Ocultar cpOfertas
                f.Show();                 // Mostrar cpEmpresa
                await Task.Delay(300);
                this.Dispose();           // Liberar cpOfertas
            }

            // Si se selecciona la pestaña 3 (cpPostulante) y no estamos ya en cpPostulante
            else if (selectedIndex == 3 && !(this is cpPostulante))
            {
                var f = new cpPostulante();  // Crear instancia de cpPostulante
                this.Hide();                 // Ocultar cpOfertas
                f.Show();                    // Mostrar cpPostulante
                await Task.Delay(300);
                this.Dispose();              // Liberar cpOfertas
            }
        }
    }
}
