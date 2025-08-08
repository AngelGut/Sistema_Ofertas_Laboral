using CapaDatos;
using CpNegocio.Empresas_y_Postulantes;
using CpNegocio.ServiciosCorreo;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class UsuarioNegocio
    {
        // Verificar las credenciales de usuario de forma asíncrona
        public async Task<bool> LoginAsync(string usuario, string clave)
        {
            return await DatosUsuario.VerificarCredencialesAsync(usuario, clave);
        }

        // Cambiar la clave del usuario de forma asíncrona
        public async Task<bool> CambiarClaveAsync(string correo, string nuevaClave)
        {
            return await DatosUsuario.CambiarClaveAsync(correo, nuevaClave);
        }

        // Verificar si un correo ya está registrado de forma asíncrona
        public async Task<bool> CorreoExisteAsync(string correo)
        {
            return await DatosUsuario.ExisteCorreoAsync(correo);
        }

        // Recuperar la clave del usuario de forma asíncrona
        public async Task<bool> RecuperarClaveAsync(string correo, string nuevaClave)
        {
            // Paso 1: Validar si el correo existe
            if (string.IsNullOrWhiteSpace(correo))
            {
                throw new ArgumentException("Debe ingresar un correo válido.");
            }

            if (!await DatosUsuario.ExisteCorreoAsync(correo))
            {
                throw new ArgumentException("El correo no está registrado en el sistema.");
            }

            // Paso 2: Actualizar la contraseña
            bool actualizado = await DatosUsuario.CambiarClaveAsync(correo, nuevaClave);
            if (!actualizado)
            {
                throw new Exception("No se pudo actualizar la contraseña.");
            }

            // Paso 3: Enviar correo con la nueva contraseña
            var correoServicio = new ServiciosCorreo(
                "ofertaslaboralesuce@gmail.com",    // Remitente
                "xskfnxncewwumili",                 // Contraseña del remitente
                "smtp.gmail.com",                   // Servidor SMTP
                587,                                // Puerto SMTP
                true                                // SSL
            );

            string asunto = "Confirmación de cambio de contraseña";
            string cuerpo = $"Hola,<br>Tu contraseña ha sido cambiada exitosamente.<br><b>Nueva contraseña:</b> {nuevaClave}";
            bool enviado = await correoServicio.EnviarCorreoAsync(asunto, cuerpo, new List<string> { correo });

            if (!enviado)
            {
                throw new Exception("Contraseña actualizada, pero no se pudo enviar el correo.");
            }

            return true;
        }

        // Registrar un nuevo usuario de forma asíncrona
        public async Task<bool> RegistrarUsuarioAsync(Usuario usuario)
        {
            // Aquí va la lógica para registrar el usuario en la base de datos
            bool registrado = await DatosUsuario.InsertarUsuarioAsync(usuario);
            if (!registrado)
            {
                return false;
            }

            // Enviar el correo de bienvenida
            bool correoEnviado = await EnviarCorreoBienvenidaAsync(usuario.Correo, usuario.UsuarioNombre, usuario.Clave);

            return correoEnviado;
        }

        public async Task<bool> ExisteUsuarioAsync(string usuarioNombre)
        {
            return await DatosUsuario.ExisteUsuarioAsync(usuarioNombre);  // Llamada asíncrona a DatosUsuario para verificar si el usuario ya existe
        }


        // Método para enviar correo de bienvenida
        private async Task<bool> EnviarCorreoBienvenidaAsync(string correo, string usuarioNombre, string clave)
        {
            string asunto = "Bienvenido a nuestro sistema de Ofertas Laborales";
            string cuerpo = $"Hola {usuarioNombre},<br><br>" +
                            $"Gracias por registrarte en nuestro sistema. A continuación te proporcionamos tu información de acceso:<br>" +
                            $"<b>Usuario:</b> {usuarioNombre}<br>" +
                            $"<b>Contraseña:</b> {clave}<br><br>" +
                            $"¡Disfruta de los servicios!";

            var correoServicio = new ServiciosCorreo(
                "ofertaslaboralesuce@gmail.com",    // Remitente
                "xskfnxncewwumili",                 // Contraseña del remitente
                "smtp.gmail.com",                   // Servidor SMTP
                587,                                // Puerto SMTP
                true                                // SSL
            );

            bool enviado = await correoServicio.EnviarCorreoAsync(asunto, cuerpo, new List<string> { correo });

            return enviado;
        }
        
        
    }
}
