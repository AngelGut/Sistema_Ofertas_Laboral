using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio.Base
{
    public class EntidadBase
    {
        public virtual void Registrar()
        {
            Console.WriteLine("Registro genérico.");
        }

        public virtual void Eliminar()
        {
            Console.WriteLine("Eliminación genérica.");
        }

        public virtual void Mostrar()
        {
            Console.WriteLine("Mostrando entidad.");
        }
    }

}
