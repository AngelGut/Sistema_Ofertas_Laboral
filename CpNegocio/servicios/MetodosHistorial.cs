using System.Data;
using Microsoft.Data.SqlClient;

namespace CpNegocio.servicios
{
    public class MetodosHistorial
    {
        private string conexion = "Server=.;Database=Ofertalaboral; Integrated Security=true; TrustServerCertificate=True;";

        public DataTable ObtenerHistorialAsignaciones(string filtro)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        a.Id AS [ID Asignación],
                        p.Nombre AS [Nombre Persona],
                        p.Dni,
                        p.Correo,
                        o.Puesto,
                        o.Area,
                        o.Descripcion,
                        o.Requisitos,
                        o.Salario,
                        e.Nombre AS [Empresa],
                        a.FechaAsignacion
                    FROM Asignacion a
                    JOIN Persona p ON a.PersonaId = p.Id
                    JOIN Oferta o ON a.OfertaId = o.Id
                    JOIN Empresa e ON o.EmpresaId = e.Id
                    WHERE p.Nombre LIKE @filtro OR p.Dni LIKE @filtro OR p.Correo LIKE @filtro OR o.Puesto LIKE @filtro
                    ORDER BY a.FechaAsignacion DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                return tabla;
            }
        }
    }
}
