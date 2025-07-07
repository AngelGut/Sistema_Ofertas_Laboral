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

            // Lógica para ocultar los campos de Salario y Créditos al inicio
            TxtSalario.Visible = false; // Ocultar TextBox de Salario
            TxtCreditos.Visible = false; // Ocultar TextBox de Créditos

            if (CboxTipoOferta.Items.Count > 0)
            {
                CboxTipoOferta.SelectedIndex = 0; // Seleccionar el primer elemento por defecto
            }
        }

        private async void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice de la pestaña seleccionada por el usuario
            int selectedIndex = materialTabControl1.SelectedIndex;

            // Si se selecciona la pestaña 0 (Menu) y no estamos ya en Menu
            if (selectedIndex == 0 && !(this is Menu))
            {
                var f = new Menu();   // Crear una nueva instancia del formulario Menu
                f.Show();             // Mostrar el formulario Menu

                await Task.Delay(300); // Espera breve para suavizar
                this.Dispose();        // Liberar el formulario secundario actual

            }


            // Si se selecciona la pestaña 2 (cpEmpresa) y no estamos ya en cpEmpresa
            else if (selectedIndex == 2 && !(this is cpEmpresa))
            {
                var f = new cpEmpresa();  // Crear nueva instancia del formulario cpEmpresa
                f.Show();                 // Mostrar el formulario cpEmpresa

                await Task.Delay(300);    // Espera para suavizar la transición
                this.Dispose();           // Liberar el formulario cpOfertas
            }

            // Si se selecciona la pestaña 3 (cpPostulante) y no estamos ya en cpPostulante
            else if (selectedIndex == 3 && !(this is cpPostulante))
            {
                var f = new cpPostulante();  // Crear nueva instancia del formulario cpPostulante
                f.Show();                    // Mostrar el formulario

                await Task.Delay(300);       // Espera breve
                this.Dispose();              // Liberar cpOfertas
            }

            // Si se selecciona la pestaña 1 (cpOfertas), no se hace nada porque ya estamos aquí
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

        }
    }
}
