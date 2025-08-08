using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CpDatos
{
    public class AsignacionDA
    {
        // Cadena de conexión a la base de datos.
        private string connectionString = "Server=.;Database=Ofertalaboral; Integrated Security=true; trustServerCertificate=True;";

      
        public async Task<DataTable> ObtenerHistorialConDetalleAsync()
        {
            DataTable dataTable = new DataTable();
            string sql = @"
                SELECT
                    A.Id AS IdAsignacion,
                    -- Se selecciona solo la columna Nombre, que es la correcta en la tabla Persona.
                    P.Nombre AS NombrePostulante, 
                    -- Se usa 'Puesto' en lugar de 'NombrePuesto' para que coincida con tu tabla Oferta.
                    O.Puesto AS PuestoOferta,
                    E.Nombre AS NombreEmpresa,
                    A.FechaAsignacion
                FROM
                    Asignacion AS A
                JOIN
                    Persona AS P ON A.PersonaId = P.Id
                JOIN
                    Oferta AS O ON A.OfertaId = O.Id
                JOIN
                    Empresa AS E ON O.EmpresaId = E.Id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Se abre la conexión de forma asíncrona.
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // El método Fill no tiene una versión asíncrona,
                            // por lo que se ejecuta en un hilo de fondo.
                            await Task.Run(() => adapter.Fill(dataTable));
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Manejo específico de errores de SQL.
                Console.WriteLine("Error de SQL al obtener el historial de asignaciones: " + sqlEx.Message);
                throw; // Vuelve a lanzar la excepción.
            }
            catch (Exception ex)
            {
                // Manejo general de errores.
                Console.WriteLine("Error al obtener el historial de asignaciones: " + ex.Message);
                throw; // Vuelve a lanzar la excepción.
            }

            return dataTable;
        }
    }
}