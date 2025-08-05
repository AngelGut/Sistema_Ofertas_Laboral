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
        public enum ResultadoSeleccion { Ver, Editar, Cancelar }

        public ResultadoSeleccion Resultado { get; private set; } = ResultadoSeleccion.Cancelar;

        public frmModoVisualizacion()
        {
            InitializeComponent();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            Resultado = ResultadoSeleccion.Ver;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Resultado = ResultadoSeleccion.Editar;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Resultado = ResultadoSeleccion.Cancelar;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
