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

        public static bool VerificarCredenciales(string usuario, string clave)
        {
            using var conn = ObtenerConexion();
            conn.Open();

            // Recuperamos el usuario y la clave desde la base de datos
            string query = "SELECT Usuario, Clave FROM Usuarios WHERE Usuario = @usuario";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@usuario", usuario);

            using var reader = cmd.ExecuteReader();

            // Si hay datos que coinciden con el usuario ingresado
            if (reader.Read())
            {
                // Recuperar los valores de la base de datos
                string usuarioDB = reader["Usuario"].ToString();
                string claveDB = reader["Clave"].ToString();

                // Comparar el usuario y la clave con String.Compare para ser sensibles a mayúsculas y minúsculas
                bool usuarioValido = String.Compare(usuario, usuarioDB, StringComparison.Ordinal) == 0;
                bool claveValida = String.Compare(clave, claveDB, StringComparison.Ordinal) == 0;

                // Retornar true si ambos son válidos
                return usuarioValido && claveValida;
            }

            // Si no se encuentra el usuario
            return false;
        }


        public static bool ExisteCorreo(string correo)
        {
            using (var conn = OfertaDatos.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Correo = @correo";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@correo", correo);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public static bool InsertarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection conn = OfertaDatos.ObtenerConexion())
                {
                    conn.Open();
                    string query = "INSERT INTO Usuarios (Usuario, Clave, Correo, Rol) VALUES (@Usuario, @Clave, @Correo, @Rol)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Usuario", usuario.UsuarioNombre);
                    cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                    cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@Rol", usuario.Rol);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Retorna true si se insertaron registros
                }
            }
            catch (Exception)
            {
                return false; // En caso de error
            }
        }

        public static bool ComprobarCorreo(string correo)
        {
            try
            {
                using (SqlConnection conn = OfertaDatos.ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE Correo = @Correo";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // Retorna true si ya existe el correo
                }
            }
            catch (Exception)
            {
                return false; // En caso de error
            }
        }

        public static bool CambiarClave(string correo, string nuevaClave)
        {
            using (var conn = OfertaDatos.ObtenerConexion())  // Usando OfertaDatos.ObtenerConexion() para la conexión
            {
                conn.Open();
                string query = "UPDATE Usuarios SET Clave = @clave WHERE Correo = @correo";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@clave", nuevaClave);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    return cmd.ExecuteNonQuery() > 0;  // Retorna true si la contraseña fue actualizada
                }
            }
        }


    }
}