using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio.Oferta
{
    //TODO: Interfaz que define los métodos para interactuar con el repositorio de ofertas
    public interface IOfertaRepositorio
    {
        //TODO: Este método devuelve una lista de ofertas disponibles
        List<CnOferta> ObtenerOfertasDisponibles();

        //TODO: Un método encargado de obtener una oferta por su ID
        CnOferta ObtenerOfertaPorId(int idOferta);
    }
}
