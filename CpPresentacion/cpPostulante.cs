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

            // Mejora visual: habilitar doble búfer para reducir parpadeos
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        private async void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice de la pestaña seleccionada
            int selectedIndex = materialTabControl1.SelectedIndex;

            // Si se selecciona la pestaña 0 (Menu) y no estamos ya en Menu
            if (selectedIndex == 0 && !(this is Menu))
            {
                var f = new Menu();   // Crear una nueva instancia del formulario Menu
                f.Show();             // Mostrar el formulario Menu

                await Task.Delay(300); // Espera breve para suavizar
                this.Dispose();        // Liberar el formulario secundario actual

            }


            // Si se selecciona la pestaña 1 (cpOfertas) y no estamos ya en cpOfertas
            else if (selectedIndex == 1 && !(this is cpOfertas))
            {
                var f = new cpOfertas();  // Crear nueva instancia del formulario cpOfertas
                f.Show();                 // Mostrar el formulario

                await Task.Delay(300);    // Espera para transición
                this.Dispose();           // Liberar cpPostulante
            }

            // Si se selecciona la pestaña 2 (cpEmpresa) y no estamos ya en cpEmpresa
            else if (selectedIndex == 2 && !(this is cpEmpresa))
            {
                var f = new cpEmpresa();  // Crear nueva instancia del formulario cpEmpresa
                f.Show();                 // Mostrar el formulario

                await Task.Delay(300);    // Espera breve
                this.Dispose();           // Liberar cpPostulante
            }

            // Si se selecciona la pestaña 3 (cpPostulante), no se hace nada porque ya estamos aquí
        }
    }
}
