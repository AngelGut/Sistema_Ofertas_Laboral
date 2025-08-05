using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpPresentacion.Asistencia
{
    public static class ControlHelper
    {
        public static void SetReadOnlyRecursive(Control parent, bool readOnly)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBoxBase tb)
                    tb.ReadOnly = readOnly;
                else if (c is Button || c is ComboBox || c is CheckBox || c is RadioButton)
                    c.Enabled = !readOnly;

                if (c.HasChildren)
                    SetReadOnlyRecursive(c, readOnly);
            }
        }
    }
}
