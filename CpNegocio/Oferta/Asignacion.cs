using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio.Oferta
{
    //TODO: Clase que representa una asignación de una persona a una oferta
    public class Asignacion
    {
        public int Id { get; set; }
        public int OfertaId { get; set; }
        public int PersonaId { get; set; }
    }
}
