using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpPresentacion.Asistencia
{
    public static class ReadOnlyExtensions
    {
        public static void SetReadOnly(this IReadOnlyContainer rc, bool readOnly)
            => ControlHelper.SetReadOnlyRecursive(rc.Container, readOnly);
    }
}
