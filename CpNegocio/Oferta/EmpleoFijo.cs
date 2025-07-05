using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CpNegocio.Oferta
{
    public class EmpleoFijo : Oferta
    {
        public int? Salario { get; set; }

        public EmpleoFijo()
        {
            Tipo = "EmpleoFijo";
        }
    }
}
