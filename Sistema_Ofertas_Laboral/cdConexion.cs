using System;
using Microsoft.Data.SqlClient;

namespace Capa_Datos
{
    public static class OfertaDatos
    {
        // Cadena de conexión a la base de datos
        // El static permite que la cadena de conexión sea compartida entre todas las instancias de la clase sin usar new
        private static string conexion = "Server=.;Database=Ofertalaboral; Integrated Security=true; trustServerCertificate=True;";

        // Método público que devuelve una conexión lista para usar
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(conexion);
        }
    }
}
