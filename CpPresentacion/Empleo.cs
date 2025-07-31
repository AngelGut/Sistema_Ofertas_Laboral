using CpNegocio.Empresas_y_Postulantes;
using CpNegocio.Empresas_y_Postulantes;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Windows.Forms;
using CpNegocio;

namespace CpPresentacion
{
    public partial class Empleo : MaterialForm
    {
        public Empleo()
        {
            InitializeComponent();
            this.Load += frmEmpleo_Load;
        }

        private void frmEmpleo_Load(object sender, EventArgs e)
        {
            MostrarPostulantes();
            MostrarEmpresas();
        }

        private void MostrarPostulantes()
        {
            var negocioPostulante = new NPostulante();
            dgvPostulantes.DataSource = negocioPostulante.Mostrar();
        }

        private void BuscarPostulantePorID(string id)
        {
            var negocioPostulante = new NPostulante();
            dgvPostulantes.DataSource = negocioPostulante.BuscarPorID(id);
        }

        private void BuscarPostulantePorDNI(string dni)
        {
            var negocioPostulante = new NPostulante();
            dgvPostulantes.DataSource = negocioPostulante.BuscarPorDNI(dni);
        }

        private void MostrarEmpresas()
        {
            var negocioEmpresa = new NEmpresa();
            dgvEmpresas.DataSource = negocioEmpresa.Mostrar();
        }

        private void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            string dni = txtBuscarDNI.Text.Trim();
            if (string.IsNullOrEmpty(dni))
                MostrarPostulantes();
            else
                BuscarPostulantePorDNI(dni);
        }

        private void btnBuscarID_Click(object sender, EventArgs e)
        {
            string id = txtBuscarID.Text.Trim();
            if (string.IsNullOrEmpty(id))
                MostrarPostulantes();
            else
                BuscarPostulantePorID(id);
        }
        private void txtBuscarDNI_Click(object sender, EventArgs e)
        {
            // Tu código si quieres hacer algo cuando haces click en el textbox
        }

        private void txtBuscarID_Click(object sender, EventArgs e)
        {
            // Tu código si quieres hacer algo cuando haces click en el textbox
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            // Aquí puede estar vacío si no haces nada en ese evento.
        }


    }

}
