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
    public class MensajeriaRepo : IMensajeriaRepositorio
    {
        public void EnviarMensaje(string destinatario, string asunto, string cuerpo)
        {
            using (var mensaje = new MailMessage())
            {
                mensaje.From = new MailAddress("opempleatech@gmail.com", "EmpleaTech");
                mensaje.To.Add(destinatario);
                mensaje.Subject = asunto;
                mensaje.Body = cuerpo;

                // 🔹 Esto permite que el contenido sea interpretado como HTML
                mensaje.IsBodyHtml = true;

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(
                        "opempleatech@gmail.com",
                        "vkwmsjwquzzduzys" // sin espacios
                    );
                    smtp.EnableSsl = true;
                    smtp.Send(mensaje);
                }
            }
        }
    }
}
