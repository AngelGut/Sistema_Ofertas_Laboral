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

        // startInEdit indica el estado inicial del switch
        public FormBoton(IReadOnlyContainer target, bool startInEdit)
        {
            InitializeComponent();
            {
                _target = target;

                // Estado inicial del switch (según lo elegido en frmModoVisualizacion)
                swthHabilitar.Checked = startInEdit;

                // 🔸 siempre habilitado para que el usuario pueda cambiarlo
                swthHabilitar.Enabled = true;

                // Aplica el estado inicial al formulario (editable = ON)
                _target.SetReadOnly(!startInEdit);

                // Cambios posteriores del usuario
                swthHabilitar.CheckedChanged += swthHabilitar_CheckedChanged;
            }
        }

        // ON  = editar   → desbloquear
        // OFF = solo ver → bloquear
        private void swthHabilitar_CheckedChanged(object sender, EventArgs e)
        {
            bool editar = swthHabilitar.Checked;
            _target.SetReadOnly(!editar);
        }
    }
}
