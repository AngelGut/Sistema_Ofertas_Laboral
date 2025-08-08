using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio.Empresas_y_Postulantes
{
    //TODO: Clase que representa un elemento de combo para mostrar ofertas de empleo
    public class OfertaListadoDto
    {
        public int Id { get; set; }
        public string Empresa { get; set; } = string.Empty;
        public string Puesto { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Requisitos { get; set; } = string.Empty;
        public int? Salario { get; set; }  // Empleo Fijo
        public int? Creditos { get; set; } // Pasantía
        public string Estado { get; set; }
        public string Area { get; set; }
    }
}
