using CpPresentacion.Asistencia;
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
    public partial class FormBoton : MaterialForm
    {
        private readonly IReadOnlyContainer _target;   // formulario a controlar
        public FormBoton(IReadOnlyContainer target)
        {
            InitializeComponent();
            {
                _target = target;
                InitializeComponent();     // generado por el diseñador

                // Conecta el evento del switch
                swthHabilitar.CheckedChanged += swthHabilitar_CheckedChanged;
            }
        }
        private void swthHabilitar_CheckedChanged(object sender, EventArgs e)
        {
            bool editar = swthHabilitar.Checked;   // true = editar
            _target.SetReadOnly(!editar);          // helper recursivo
        }
    }
}
