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
        public async Task<bool> RecuperarClaveAsync(string correo)
        {
            if (!await DatosUsuario.ExisteCorreoAsync(correo))  // Verifica si el correo existe de forma asíncrona
                return false; // Si el correo no existe, retornamos false

            // Genera una nueva clave de forma segura
            string nuevaClave = GenerarNuevaClave(); // Usar un generador más seguro si es necesario
            bool actualizada = await DatosUsuario.CambiarClaveAsync(correo, nuevaClave);

            if (!actualizada)
                return false; // Si no se pudo actualizar la clave, retornamos false

            // Enviar correo con la nueva clave de forma asíncrona
            var correoServicio = new ServiciosCorreo(
                "ofertaslaboralesuce@gmail.com",         // Remitente
                "xskfnxncewwumili",                    // Clave del remitente
                "smtp.gmail.com",                       // Servidor SMTP
                587,                                    // Puerto SMTP
                true                                    // SSL
            );

            string asunto = "Recuperación de contraseña";
            string cuerpo = $"<b>Tu nueva contraseña es:</b> {nuevaClave}";
            return await correoServicio.EnviarCorreoAsync(asunto, cuerpo, new List<string> { correo });  // Enviar correo de forma asíncrona
        }

        // Registrar un nuevo usuario de forma asíncrona
        public async Task<bool> RegistrarUsuarioAsync(Usuario usuario)
        {
            try
            {
                // Verificar si el correo ya está registrado
                if (await DatosUsuario.ExisteCorreoAsync(usuario.Correo))  // Comprobar de forma asíncrona
                {
                    Console.WriteLine("Error: El correo '{0}' ya está registrado. Por favor, ingrese otro correo.", usuario.Correo);
                    return false; // Si el correo ya existe, retorna falso
                }

                // Verificar si el nombre de usuario ya está registrado de forma asíncrona
                if (await DatosUsuario.ExisteUsuarioAsync(usuario.UsuarioNombre))
                {
                    Console.WriteLine("Error: El nombre de usuario '{0}' ya está registrado. Por favor, elija otro nombre de usuario.", usuario.UsuarioNombre);
                    return false; // Si el nombre de usuario ya existe, retorna falso
                }

                bool registrado = await DatosUsuario.InsertarUsuarioAsync(usuario);  // Llamada asíncrona a InsertarUsuario

                if (!registrado)
                {
                    Console.WriteLine("Error: No se pudo registrar al usuario.");
                }
                else
                {
                    Console.WriteLine("Usuario registrado exitosamente con correo: {0}", usuario.Correo);
                }

                return registrado; // Retorna el resultado del registro
            }
            catch (SqlException sqlEx)
            {
                // Captura excepciones relacionadas con SQL
                Console.WriteLine("Error de base de datos: " + sqlEx.Message);
                return false;
            }
            catch (InvalidOperationException invOpEx)
            {
                // Captura excepciones relacionadas con la operación inválida
                Console.WriteLine("Operación inválida: " + invOpEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                // Captura cualquier otro tipo de excepción
                Console.WriteLine("Error inesperado al registrar el usuario: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> ExisteUsuarioAsync(string usuarioNombre)
        {
            return await DatosUsuario.ExisteUsuarioAsync(usuarioNombre);  // Llamada asíncrona a DatosUsuario para verificar si el usuario ya existe
        }

        // Función para generar una nueva clave (puedes mejorar la seguridad aquí si lo deseas)
        private string GenerarNuevaClave()
        {
            return Guid.NewGuid().ToString().Substring(0, 6); // Puedes cambiar esta lógica si quieres una clave más segura
        }
    }
}
