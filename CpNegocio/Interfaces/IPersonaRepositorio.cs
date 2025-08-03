using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CpNegocio.Entidades;

namespace CpNegocio.Interfaces
{
    //TODO: Interfaz que define los métodos para interactuar con el repositorio de personas
    public interface IPersonaRepositorio
    {
        //TODO: Un método encargado de obtener una persona por su cédula
        Persona ObtenerPersonaPorCedula(string cedula);

        //TODO: Un método encargado de obtener una persona por su ID
        Persona ObtenerPersonaPorId(int id);

        //TODO: Un método para obtener una lista de personas (ej. con un filtro)
        List<Persona> ObtenerPersonasPorArea(string area);

        //TODO: Un método para actualizar el 'OfertaId' de una persona
        void ActualizarOfertaIdPersona(int idPersona, int idOferta);
    }
}
