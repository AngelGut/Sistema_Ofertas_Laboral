using CapaDatos;
using CpNegocio.Empresas_y_Postulantes;
using CpNegocio.ServiciosCorreo;
using System;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class UsuarioNegocio
    {
        public bool Login(string usuario, string clave)
        {
            return DatosUsuario.VerificarCredenciales(usuario, clave);
        }

        public bool CambiarClave(string correo, string nuevaClave)
        {
            return DatosUsuario.CambiarClave(correo, nuevaClave);
        }

        public bool CorreoExiste(string correo)
        {
            return DatosUsuario.ExisteCorreo(correo);
        }

        public bool RecuperarClave(string correo)
        {
            if (!DatosUsuario.ExisteCorreo(correo))
                return false;

            // Genera una nueva clave de forma segura
            string nuevaClave = Guid.NewGuid().ToString().Substring(0, 6); // Puedes cambiar esto si quieres una clave diferente
            bool actualizada = DatosUsuario.CambiarClave(correo, nuevaClave);

            if (!actualizada)
                return false;

            // Enviar correo con la nueva clave
            var correoServicio = new ServiciosCorreo(
                "ofertaslaboralesuce@gmail.com",         // Remitente
                "xskfnxncewwumili",                    // Clave del remitente
                "smtp.gmail.com",                       // Servidor SMTP
                587,                                    // Puerto SMTP
                true                                    // SSL
            );

            string asunto = "Recuperación de contraseña";
            string cuerpo = $"<b>Tu nueva contraseña es:</b> {nuevaClave}";
            return correoServicio.EnviarCorreo(asunto, cuerpo, new List<string> { correo });
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            // Verificar si el correo ya está registrado
            if (CorreoYaRegistrado(usuario.Correo))
            {
                return false; // Si el correo ya está registrado, retorna falso
            }

            // Registrar el usuario en la base de datos
            return DatosUsuario.InsertarUsuario(usuario);  // Llamada a InsertarUsuario estática
        }

        private bool CorreoYaRegistrado(string correo)
        {
            return DatosUsuario.ComprobarCorreo(correo); // Llamada a ComprobarCorreo estática
        }

    }
}
