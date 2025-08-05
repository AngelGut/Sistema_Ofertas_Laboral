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

namespace CpPresentacion
{
    public partial class frmModoVisualizacion : MaterialForm
    {
        public enum ResultadoSeleccion { Ver, Editar }
        public ResultadoSeleccion Resultado { get; private set; } = ResultadoSeleccion.Ver;

        public frmModoVisualizacion()
        {
            InitializeComponent();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            Resultado = ResultadoSeleccion.Ver;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Resultado = ResultadoSeleccion.Editar;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Resultado = ResultadoSeleccion.Cancelar;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
