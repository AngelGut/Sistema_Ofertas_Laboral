using System;

namespace CpNegocio
{
    public class Postulacion
    {
        public int AsignacionId { get; set; }
        public int PersonaId { get; set; }
        public string NombrePersona { get; set; }
        public int OfertaId { get; set; }
        public string Puesto { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Requisitos { get; set; }
        public decimal Salario { get; set; }
        public int Creditos { get; set; }
        public string Area { get; set; }
        public bool Ocupada { get; set; }
    }
}

