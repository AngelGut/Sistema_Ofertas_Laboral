using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CpNegocio.ServiciosCorreo
{
    public class ServiciosCorreo
    {
        private SmtpClient smtpClient;
        private string senderMail;
        private string senderPassword;
        private string host;
        private int port;
        private bool ssl;

        // Constructor que recibe las configuraciones del correo
        public ServiciosCorreo(string correo, string clave, string servidor, int puerto, bool usarSSL)
        {
            senderMail = correo;
            senderPassword = clave;
            host = servidor;
            port = puerto;
            ssl = usarSSL;

            InicializarSmtpClient();
        }

        // Configuración del cliente SMTP
        private void InicializarSmtpClient()
        {
            smtpClient = new SmtpClient
            {
                Credentials = new NetworkCredential(senderMail, senderPassword),
                Host = host,
                Port = port,
                EnableSsl = ssl
            };
        }

        // Método asíncrono para enviar el correo
        public async Task<bool> EnviarCorreoAsync(string asunto, string cuerpo, List<string> destinatarios)
        {
            try
            {
                // Usamos 'using' para asegurar la liberación de recursos automáticamente
                using (var mensaje = new MailMessage())
                {
                    mensaje.From = new MailAddress(senderMail);
                    mensaje.Subject = asunto;
                    mensaje.Body = cuerpo;
                    mensaje.IsBodyHtml = true;

                    foreach (string correoDestino in destinatarios)
                    {
                        mensaje.To.Add(correoDestino);
                    }

                    // Enviar el mensaje de manera asíncrona
                    await smtpClient.SendMailAsync(mensaje);  // Asíncrono
                    return true;
                }
            }
            catch (SmtpException smtpEx)
            {
                // Error relacionado con el cliente SMTP
                Console.WriteLine("Error de SMTP: " + smtpEx.Message);
            }
            catch (Exception ex)
            {
                // Error general
                Console.WriteLine("Error al enviar correo: " + ex.Message);
            }

            return false; // Retorna false en caso de error
        }
    }
}
