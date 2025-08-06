using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CpNegocio.Gmail;
using CpNegocio.Interfaces;

namespace CpNegocio
{
    public class MensajeriaRepo : IMensajeriaRepositorio
    {
        //TODO: Implementa la lógica para enviar mensajes utilizando GmailService
        public void EnviarMensaje(string destinatario, string asunto, string cuerpo)
        {
            try
            {
                //TODO: Validar los parámetros de entrada
                var gmail = new GmailService(); //TODO: Instancia del servicio de Gmail
                gmail.Destinatario = destinatario;
                gmail.Asunto = asunto;
                gmail.CuerpoMensaje = cuerpo;

                if (gmail.Validar())
                {
                    Task.Run(() => gmail.Enviar());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar correo: {ex.Message}");
            }
        }
    }
}
