using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oferta.Oferta
{
    public abstract class Oferta
    {
        public string NombreCompania { get; set; }
        public string Puesto { get; set; }
        public string Tipo { get; protected set; }
        public string Descripcion { get; set; }
        public string Requisitos { get; set; }

        protected Oferta()
        {
            Tipo = "Oferta"; // valor base
        }
    }

}
