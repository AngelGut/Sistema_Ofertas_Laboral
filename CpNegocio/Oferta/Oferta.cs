using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio.Oferta
{
    //TODO: Classe abstracta
    public abstract class CnOferta
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
        public string TipoContrato { get; set; }
        public string Area { get; set; }

        protected CnOferta()
        {
            Tipo = "Oferta"; // valor por defecto
        }
    }
}

