using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oferta.Oferta;

namespace Pasantia.Oferta
{
    public class Pasantia : Oferta
    {
        public int? Creditos { get; set; }

        public Pasantia()
        {
            Tipo = "Pasantia";
        }
    }
}
