using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos; // Aquí está la clase OfertaDatos con la conexión
using CpNegocio.Entidades; // Aquí está la clase Persona
using Microsoft.Data.SqlClient; // Usamos SqlConnection y SqlCommand para manejar la base de datos

namespace CpNegocio.servicios
{
    //TODO: Herencia de MetodosBase para implementar los métodos de registrar, eliminar y buscar
    public class MetodosPersona : MetodosBase
    {
        // Variable privada que contiene la persona actual que se va a manejar
        private Persona persona;

        // Constructor que recibe una persona y la guarda en la variable privada
        public MetodosPersona(Persona p)
        {
            persona = p;
        }

        public static bool PersonaYaExiste(string dni)
        {
            using (SqlConnection conn = OfertaDatos.ObtenerConexion())
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM Persona WHERE Cedula = @Dni";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Dni", dni);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }


        // Método que guarda una nueva persona en la tabla Persona
        public override void Registrar()
        {
            try
            {
                // Se abre la conexión a la base de datos usando la clase OfertaDatos
                using (SqlConnection conn = OfertaDatos.ObtenerConexion())
                {
                    conn.Open();

                    // Validar si ya existe
                    if (PersonaYaExiste(conn, persona.Dni))
                    {
                        throw new Exception("Esta persona ya está registrada.");
                    }

                    // Sentencia SQL para insertar una nueva persona
                    string query = @"INSERT INTO Persona (Nombre, Telefono, Correo, Direccion, Cedula, OfertaId)
                 VALUES (@Nombre, @Telefono, @Correo, @Direccion, @Cedula, @OfertaId)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                        cmd.Parameters.AddWithValue("@Telefono", persona.Telefono);
                        cmd.Parameters.AddWithValue("@Correo", persona.Correo);
                        cmd.Parameters.AddWithValue("@Direccion", persona.Direccion);
                        cmd.Parameters.AddWithValue("@Cedula", persona.Dni);
                        cmd.Parameters.AddWithValue("@OfertaId", persona.OfertaId); // 👉 ESTA LÍNEA ES LA QUE AGREGAS

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Se lanza una excepción más clara en caso de error
                throw new Exception("Error al registrar la persona en la base de datos.", ex);
            }
        }

        // Método que elimina una persona de la base de datos según su cédula
        public override void Eliminar()
        {
            try
            {
                using (SqlConnection conn = OfertaDatos.ObtenerConexion())
                {
                    conn.Open();

                    // Consulta SQL para eliminar usando la cédula
                    string query = "DELETE FROM Persona WHERE Cedula = @Cedula";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", persona.Dni);
                        int filas = cmd.ExecuteNonQuery();

                        // Si no se afectó ninguna fila, informamos
                        if (filas == 0)
                        {
                            throw new Exception("No se encontró ninguna persona con esa cédula.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la persona de la base de datos.", ex);
            }
        }

        // Método que retorna todas las personas registradas en un DataTable
        public override DataTable Buscar()
        {
            try
            {
                using (SqlConnection conn = OfertaDatos.ObtenerConexion())
                {
                    conn.Open();

                    // Consulta con LEFT JOIN para mostrar el nombre del puesto
                    string query = @"
                    SELECT 
                        p.Id,
                        p.Nombre,
                        p.Cedula,
                        p.Telefono,
                        p.Correo,
                        p.Direccion,
                        o.Puesto AS NombreOferta
                    FROM Persona p
                    LEFT JOIN Oferta o ON p.OfertaId = o.Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable tabla = new DataTable();
                        tabla.Load(reader);
                        return tabla;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar los datos de personas.", ex);
            }
        }

        // Método auxiliar privado que verifica si una empresa ya está registrada
        private bool PersonaYaExiste(SqlConnection conn, string cedula)
        {
            string query = "SELECT COUNT(*) FROM Persona WHERE Cedula = @Cedula";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Cedula", cedula);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
