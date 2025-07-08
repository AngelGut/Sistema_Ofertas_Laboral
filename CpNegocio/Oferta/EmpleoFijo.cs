using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CpNegocio.Oferta
{
    public class EmpleoFijo : CnOferta
    {
        // Propiedad específica para empleo fijo
        public int? Salario { get; set; }

        public EmpleoFijo()
        {
            Tipo = "Empleo Fijo"; // Debe coincidir con el valor del ComboBox
        }
    }
}
