using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace CpNegocio.servicios
{
    public class MetodosHistorial
    {
        // Cadena de conexión a la base de datos
        private string conexion = "Server=.;Database=Ofertalaboral; Integrated Security=true; TrustServerCertificate=True;";


        //Obtiene el historial de asignaciones filtrado por nombre, DNI, correo o puesto.
        public DataTable ObtenerHistorialAsignaciones(string filtro)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();// Abrir conexión a la base de datos

                string query = @"
                SELECT 
                    a.Id AS [ID Asignación],
                    p.Nombre AS [Nombre Persona],
                    p.Cedula,
                    p.Dni,
                    o.Puesto,
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

                // Adaptador para llenar el DataTable con los datos obtenidos
                //TODO: Manejar posibles excepciones en la consulta SQL con try-catch.
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                // Retornar la tabla con los resultados
                return tabla;
            }
        }
    }
}


