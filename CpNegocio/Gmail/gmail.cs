using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using CpNegocio;

namespace CpNegocio.Gmail
{
    //TODO: Clase que representa un servicio de mensajería para enviar correos electrónicos a través de Gmail la cual hereda de la clase Mensaje
    public class GmailService : Mensaje
    {
        //Estas son las Propiedades estáticas para almacenar las credenciales de Gmail
        private static string _senderEmail;
        private static string _applicationPassword;

        
        public string Asunto { get; set; } = string.Empty;

        //TODO: Método estático para cargar las credenciales de Gmail desde un archivo de configuración (.json)
        public static void GuardarCredenciales()
        {
            try
            {
                //Aqui se Carga la configuración desde un archivo JSON llamado "credentials.json"
                var config = Configuracion.Cargar();
                _senderEmail = config.GmailSenderEmail;
                _applicationPassword = config.GmailApplicationPassword;
            }
            catch (FileNotFoundException ex)
            {
                throw new InvalidOperationException("No se pudo cargar la configuración de Gmail. Asegúrate de que el archivo 'credentials.json' exista y esté configurado para copiarse siempre.", ex);
            }
        }

        //Esta es la Propiedad para acceder al contenido del mensaje
        public string CuerpoMensaje
        {
            get => Contenido;
            set => Contenido = value;
        }

        //Configuramos un Constructor por defecto
        public override bool Validar()
        {
            //Validamos que el destinatario, asunto y cuerpo del mensaje no estén vacíos o nulos
            if (string.IsNullOrWhiteSpace(Destinatario) || string.IsNullOrWhiteSpace(Asunto) || string.IsNullOrWhiteSpace(CuerpoMensaje))
            {
                throw new Exception("El destinatario, el asunto y el cuerpo del mensaje no pueden estar vacíos.");
            }

            try
            {
                //TValidar el formato del correo electrónico del destinatario
                new MailAddress(Destinatario.Trim());
            }
            catch
            {
                throw new Exception("El formato del correo electrónico del destinatario no es válido.");
            }

            //Validar que el asunto y el cuerpo del mensaje no superen los límites de caracteres
            if (Asunto.Length > 255)
            {
                throw new Exception("El asunto no puede superar los 255 caracteres.");
            }

            if (CuerpoMensaje.Length > 5000)
            {
                throw new Exception("El cuerpo del mensaje no puede superar los 5000 caracteres.");
            }

            return true;
        }

        //TODO: Método para enviar el mensaje a través de Gmail
        public override async Task Enviar()
        {
            if (string.IsNullOrEmpty(_senderEmail) || string.IsNullOrEmpty(_applicationPassword))
            {
                throw new InvalidOperationException("Las credenciales de Gmail no se han configurado. Llama a Gmail.GuardarCredenciales() al inicio de la aplicación.");
            }
            //Validar el mensaje antes de enviarlo
            MailMessage message = null;
            try
            {
                
                MailAddress addressFrom = new MailAddress(_senderEmail, "Sistema de Asignación");
                MailAddress addressTo = new MailAddress(this.Destinatario.Trim());
                message = new MailMessage(addressFrom, addressTo);

                message.Subject = this.Asunto;
                message.Body = this.CuerpoMensaje;
                message.IsBodyHtml = false;
                //Configurar el mensaje para que sea enviado como texto plano
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_senderEmail, _applicationPassword); //Credenciales de la cuenta de Gmail

                await client.SendMailAsync(message);
            }
            catch (SmtpException ex)
            {
                throw new Exception($"Error SMTP al enviar Gmail: {ex.StatusCode} - {ex.Message}\nAsegúrate de que las credenciales sean válidas.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error al enviar el Gmail: {ex.Message}", ex);
            }
            finally
            {
                //Aseguramos que el mensaje se libere de recursos
                message?.Dispose();
            }
        }
    }
}
