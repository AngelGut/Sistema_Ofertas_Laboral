using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio.Interfaces
{
    public interface IAsignacionRepositorio
    {
        void AsignarPersonaAOferta(int idPersona, int idOferta);
    }
}
