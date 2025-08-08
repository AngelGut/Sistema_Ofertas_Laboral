using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CpNegocio.Entidades;

namespace CpNegocio.Interfaces
{
    public interface IEmpresaRepositorio
    {
        //TODO: Método para obtener una empresa por su RNC
        CnEmpresa ObtenerEmpresaPorRnc(string rnc);

        //TODO: Método para obtener una empresa por su ID
        CnEmpresa ObtenerEmpresaPorId(int id);
    }
}
