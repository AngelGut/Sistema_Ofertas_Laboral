using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio
{
    //TODO: Clase abstracta Mensaje que define la estructura básica de un mensaje
    public abstract class Mensaje
    {
        public int Id { get; set; }
        public string Contenido { get; set; } = string.Empty;
        public string Destinatario { get; set; } = string.Empty;
        public DateTime FechaEnvio { get; set; } = DateTime.Now;

        //TODO: Metodo que valida el mensaje, debe ser implementado por las clases derivadas (en este caso solo en GmailService)
        public abstract bool Validar();
        //TODO: Método que envía el mensaje, debe ser implementado por las clases derivadas (en este caso solo en GmailService)
        public abstract Task Enviar();
    }
}
