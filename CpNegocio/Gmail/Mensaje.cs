using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio
{
    public abstract class Mensaje
    {
        public int Id { get; set; }
        public string Contenido { get; set; } = string.Empty;
        public string Destinatario { get; set; } = string.Empty;
        public DateTime FechaEnvio { get; set; } = DateTime.Now;

        //TODO: Métodos abstractos que deben ser implementados por las clases que hereden de esta
        public abstract bool Validar();
        public abstract Task Enviar();
    }
}
