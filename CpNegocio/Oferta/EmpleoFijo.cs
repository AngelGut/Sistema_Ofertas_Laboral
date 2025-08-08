using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CpNegocio.Oferta
{
    //TODO: Clase que herada de CnOferta abstrata y representa una oferta de empleo fijo
    public class EmpleoFijo : CnOferta
    {
        // Propiedad específica para empleo fijo
        public int? Salario { get; set; }

        public EmpleoFijo()
        {
            Tipo = "EmpleoFijo"; // Debe coincidir con el valor del ComboBox
        }
    }
}
