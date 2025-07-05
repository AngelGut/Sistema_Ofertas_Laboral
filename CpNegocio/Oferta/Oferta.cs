using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio.Oferta
{
    public abstract class Oferta
    {
        // ID de la oferta (clave primaria en la base de datos)
        public int Id { get; set; }

        // ID de la empresa que publica la oferta (clave foránea)
        public int EmpresaId { get; set; }

        // Datos comunes a toda oferta
        public string Puesto { get; set; }
        public string Tipo { get; protected set; }
        public string Descripcion { get; set; }
        public string Requisitos { get; set; }

        protected Oferta()
        {
            Tipo = "Oferta"; // valor por defecto
        }
    }
}

