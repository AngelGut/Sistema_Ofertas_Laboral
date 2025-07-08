using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio.Oferta
{
    public class OfertaComboItem
    {
        public int Id { get; set; }
        public string Puesto { get; set; } = string.Empty;

        public override string ToString() => Puesto;
    }
}
