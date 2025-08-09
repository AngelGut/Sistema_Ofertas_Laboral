using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio.Interfaces
{
    //TODO: Interfaz que define los métodos para interactuar con el repositorio de asignaciones
    public interface IAsignacionRepositorio
    {
        //TODO: Método para obtener una lista de ofertas asignadas a una persona
        void AsignarPersonaAOferta(int idPersona, int idOferta);
    }
}
