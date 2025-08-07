using Capa_Datos;
using CpNegocio.Empresas_y_Postulantes;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Net.Mail;

namespace CapaDatos
{
    public static class DatosUsuario
    {
        private static string cadena = "Server=. ;Database=Ofertalaboral;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion() => new SqlConnection(cadena);

        public static async Task<bool> VerificarCredencialesAsync(string usuario, string clave)
        {
            using var conn = ObtenerConexion();
            await conn.OpenAsync();  // Usar la versión asíncrona de Open()

            string query = "SELECT Usuario, Clave FROM Usuarios WHERE Usuario = @usuario";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@usuario", usuario);

            using var reader = await cmd.ExecuteReaderAsync();  // Usar la versión asíncrona de ExecuteReader()

            if (reader.Read())
            {
                string usuarioDB = reader["Usuario"].ToString();
                string claveDB = reader["Clave"].ToString();

                bool usuarioValido = string.Compare(usuario, usuarioDB, StringComparison.Ordinal) == 0;
                bool claveValida = string.Compare(clave, claveDB, StringComparison.Ordinal) == 0;

                return usuarioValido && claveValida;
            }

            return false;
        }


        public static async Task<bool> ExisteCorreoAsync(string correo)
        {
            using var conn = ObtenerConexion();
            await conn.OpenAsync();  // Usar la versión asíncrona de Open()

            string query = "SELECT COUNT(*) FROM Usuarios WHERE Correo = @correo";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@correo", correo);
            int count = (int)await cmd.ExecuteScalarAsync();  // Usar ExecuteScalarAsync

            return count > 0;
        }


        public static async Task<bool> ExisteUsuarioAsync(string usuarioNombre)
        {
            try
            {
                using (SqlConnection conn = ObtenerConexion())
                {
                    await conn.OpenAsync();  // Usar la versión asíncrona de Open()

                    string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuarioNombre);

                        // Usamos ExecuteScalarAsync para obtener el valor de la consulta
                        int count = (int)await cmd.ExecuteScalarAsync();  // Usar ExecuteScalarAsync
                        return count > 0; // Retorna true si ya existe el nombre de usuario
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar el nombre de usuario: " + ex.Message);
                return false; // En caso de error
            }
        }



        public static async Task<bool> InsertarUsuarioAsync(Usuario usuario)
        {
            try
            {
                using var conn = ObtenerConexion();
                await conn.OpenAsync();  // Usar la versión asíncrona de Open()

                string query = "INSERT INTO Usuarios (Usuario, Clave, Correo, Rol) VALUES (@Usuario, @Clave, @Correo, @Rol)";
                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Usuario", usuario.UsuarioNombre);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@Rol", usuario.Rol);

                int rowsAffected = await cmd.ExecuteNonQueryAsync();  // Usar ExecuteNonQueryAsync
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Log de error detallado
                Console.WriteLine("Error al insertar usuario: " + ex.Message);
                return false;
            }
        }


        public static async Task<bool> ComprobarCorreoAsync(string correo)
        {
            try
            {
                using var conn = ObtenerConexion();
                await conn.OpenAsync();  // Usar la versión asíncrona de Open()

                string query = "SELECT COUNT(*) FROM Usuarios WHERE Correo = @Correo";
                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Correo", correo);

                int count = (int)await cmd.ExecuteScalarAsync();  // Usar ExecuteScalarAsync
                return count > 0;
            }
            catch (Exception)
            {
                return false;  // En caso de error
            }
        }


        public static async Task<bool> CambiarClaveAsync(string correo, string nuevaClave)
        {
            using var conn = ObtenerConexion();
            await conn.OpenAsync();  // Usar la versión asíncrona de Open()

            string query = "UPDATE Usuarios SET Clave = @clave WHERE Correo = @correo";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@clave", nuevaClave);
            cmd.Parameters.AddWithValue("@correo", correo);

            int rowsAffected = await cmd.ExecuteNonQueryAsync();  // Usar ExecuteNonQueryAsync
            return rowsAffected > 0;
        }

        public static async Task<bool> CorreoYaRegistradoAsync(string correo)
        {
            using var conn = ObtenerConexion();
            await conn.OpenAsync();  // Usar la versión asíncrona de Open()

            string query = "SELECT COUNT(*) FROM Usuarios WHERE Correo = @correo";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@correo", correo);

            int count = (int)await cmd.ExecuteScalarAsync();  // Usar ExecuteScalarAsync
            return count > 0;
        }


    }
}