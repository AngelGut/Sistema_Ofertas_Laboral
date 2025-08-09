using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CpNegocio.Gmail;
using CpNegocio.Interfaces;
using System.Net;
using System.Net.Mail;
using CpNegocio.Interfaces;

namespace CpNegocio.Repositorios
{
    //TODO: Clase que implementa la interfaz de mensajería para enviar correos electrónicos
    public class MensajeriaRepo : IMensajeriaRepositorio
    {
        //TODO: Método para enviar un mensaje a un destinatario específico
        public void EnviarMensaje(string destinatario, string asunto, string cuerpo)
        {
            using (var mensaje = new MailMessage())
            {
                mensaje.From = new MailAddress("opempleatech@gmail.com", "EmpleaTech");
                mensaje.To.Add(destinatario);
                mensaje.Subject = asunto;
                mensaje.Body = cuerpo;

                //Configuramos el mensaje para que acepte formato HTML
                mensaje.IsBodyHtml = true;

                //Agregamos un encabezado para evitar que el mensaje sea marcado como spam
                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    //Configuramos el cliente SMTP con las credenciales de Gmail
                    smtp.Credentials = new NetworkCredential(
                        "opempleatech@gmail.com",
                        "vkwmsjwquzzduzys" 
                    );
                    smtp.EnableSsl = true;
                    smtp.Send(mensaje);
                }
            }
        }
    }
}
