using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio.Oferta
{
    public class Pasantia : CnOferta
    {
        // Propiedad específica para pasantía
        public int? Creditos { get; set; }

        public Pasantia()
        {
            Tipo = "Pasantia"; // Debe coincidir con el ComboBox
        }
    }
}
