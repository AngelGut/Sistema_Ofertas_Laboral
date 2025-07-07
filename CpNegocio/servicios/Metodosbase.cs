using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.CompilerServices;

namespace CpNegocio.servicios
{
    public class MetodosBase
    {
        public virtual void Registrar()
        {
            Console.WriteLine("Registro genérico.");
        }

        public virtual void Eliminar()
        {
            Console.WriteLine("Eliminación genérica.");
        }

        // Eso se guarda en un DataTable y lo puedes usar para llenar un DataGridView
        public virtual DataTable Buscar()
        {
            Console.WriteLine("Mostrando entidad.");
            return new DataTable();
        }
    }
}
