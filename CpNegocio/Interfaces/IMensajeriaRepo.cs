using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio.Interfaces
{
    //TODO: Interfaz que define los métodos para interactuar con el repositorio de mensajería
    public interface IMensajeriaRepositorio
    {
        //TODO: Método para enviar un mensaje a un destinatario específico
        void EnviarMensaje(string destinatario, string asunto, string cuerpo);
    }
}
