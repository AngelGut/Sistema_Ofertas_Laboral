using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio.Interfaces
{
    public interface IMensajeriaRepositorio
    {
        void EnviarMensaje(string destinatario, string asunto, string cuerpo);
    }
}
