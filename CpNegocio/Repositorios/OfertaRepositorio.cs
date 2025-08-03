using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CpNegocio.Oferta;

namespace CpNegocio.Repositorios
{
    
    public class OfertaRepositorio : IOfertaRepositorio
    {
        //TODO: Implementa la lógica SQL para obtener todas las ofertas sin una asignación
        public List<CnOferta> ObtenerOfertasDisponibles()
        {
            return new List<CnOferta>();
        }

        //TODO: Implementa la lógica SQL para obtener una oferta por su Id
        public CnOferta ObtenerOfertaPorId(int idOferta)
        {
            return null;
        }
    }
}
