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

        // Método: ObtenerConexion
        // Descripción: Retorna una nueva conexión SQL utilizando la cadena de conexión configurada. Es usado por otros métodos para interactuar con la base de datos
        public static SqlConnection ObtenerConexion() => new SqlConnection(cadena);

        
        // TODO: Agregar validación de entrada para evitar inyecciones SQL o ataques de fuerza bruta.
        // Método: VerificarCredencialesAsync
        // Descripción: Verifica si el usuario y la clave coinciden en la base de datos de manera asíncrona
        public static async Task<bool> VerificarCredencialesAsync(string usuario, string clave)
        {
            try
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
            catch (Exception ex)
            {
                // Aquí puedes registrar o manejar el error
                Console.WriteLine("Error al verificar las credenciales: " + ex.Message);
                return false;
            }
        }



        // Método: ExisteCorreoAsync
        // Descripción: Verifica si el correo proporcionado ya existe en la base de datos. Se usa para evitar registros duplicados.
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

        // TODO: Considerar la implementación de un sistema para bloquear múltiples intentos de registro fallidos.
        // Método: ExisteUsuarioAsync
        // Descripción: Verifica si el nombre de usuario proporcionado ya existe en la base de datos.
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

        // TODO: Implementar un proceso de validación de datos
        // Método: InsertarUsuarioAsync
        // Descripción: Inserta un nuevo usuario en la base de datos de manera asíncrona.
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

        //Método: ComprobarCorreoAsync
        // Descripción: Verifica si el correo proporcionado ya está registrado en la base de datos.
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

        // Método: RegistrarUsuarioAsync
        // Descripción: Inserta un nuevo usuario en la base de datos de manera asíncrona. 
        public static async Task<bool> RegistrarUsuarioAsync(Usuario usuario)
        {
            try
            {
                using var conn = ObtenerConexion();
                await conn.OpenAsync();  // Usar la versión asíncrona de Open()

                string query = "INSERT INTO Usuarios (Usuario, Clave, Correo, Rol) VALUES (@Usuario, @Clave, @Correo, @Rol)";
                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Usuario", usuario.UsuarioNombre);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);  // Usar la contraseña tal como está
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

        // TODO: Asegurarse de que la nueva clave sea validada
        // Método: CambiarClaveAsync
        // Descripción: Permite cambiar la clave de un usuario dado su correo electrónico.

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
        
        // TODO: Asegurarse de que este método no permita manipulación de datos o inyecciones SQL.
        // Método: CorreoYaRegistradoAsync
        // Descripción: Verifica si el correo proporcionado ya está registrado en la base de datos.

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