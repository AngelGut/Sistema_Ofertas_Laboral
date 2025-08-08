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
        // TODO: Esto se asegura de que las validaciones de entrada (correo, contraseña) estén implementadas adecuadamente.
        // Verificar que las operaciones asíncronas sean eficientes y que se manejen correctamente las excepciones.
        // Considerar agregar una capa de caché para optimizar la consulta de existencia de usuarios y correos repetidos.

        // Método: LoginAsync
        // Descripción: Verifica las credenciales de usuario de manera asíncrona.
        public async Task<bool> LoginAsync(string usuario, string clave)
        {
            return await DatosUsuario.VerificarCredencialesAsync(usuario, clave);
        }


        // Método: CambiarClaveAsync
        // Descripción: Permite cambiar la clave de un usuario de manera asíncrona.
        public async Task<bool> CambiarClaveAsync(string correo, string nuevaClave)
        {
            return await DatosUsuario.CambiarClaveAsync(correo, nuevaClave);
        }

        // Método: CorreoExisteAsync
        // Descripción: Verifica si un correo ya está registrado en el sistema de manera asíncrona.
        public async Task<bool> CorreoExisteAsync(string correo)
        {
            return await DatosUsuario.ExisteCorreoAsync(correo);
        }

        // Método: RecuperarClaveAsync
        // Descripción: Recupera la clave de un usuario y la actualiza en la base de datos, enviando un correo con la nueva clave.
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

        // Método: RegistrarUsuarioAsync
        // Descripción: Registra un nuevo usuario de manera asíncrona y envía un correo de bienvenida.
        public async Task<bool> RegistrarUsuarioAsync(Usuario usuario)
        {
            // Esto se encarga de  registrar el usuario en la base de datos
            bool registrado = await DatosUsuario.InsertarUsuarioAsync(usuario);
            if (!registrado)
            {
                return false;
            }

            // Enviar el correo de bienvenida
            bool correoEnviado = await EnviarCorreoBienvenidaAsync(usuario.Correo, usuario.UsuarioNombre, usuario.Clave);

            return correoEnviado;
        }

        // Método: ExisteUsuarioAsync
        // Descripción: Verifica si un nombre de usuario ya está registrado en el sistema de manera asíncrona.
        public async Task<bool> ExisteUsuarioAsync(string usuarioNombre)
        {
            return await DatosUsuario.ExisteUsuarioAsync(usuarioNombre);  
        }

        // Método: EnviarCorreoBienvenidaAsync
        // Descripción: Envia un correo de bienvenida con la información del nuevo usuario.
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
