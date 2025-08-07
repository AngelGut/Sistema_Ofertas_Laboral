using System;
using Capa_Datos;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CpNegocio
{
    public class PostulacionesNegocio
    {
        private string connStr = "Server=.;Database=Ofertalaboral; Integrated Security=true; trustServerCertificate=True;";

        // Método para obtener el historial de postulaciones de una persona
        public List<Postulacion> ObtenerHistorialPostulaciones(int personaId)
        {
            string sql = @"
        SELECT
            a.Id AS AsignacionId,
            a.PersonaId,
            p.Nombre AS NombrePersona,
            a.OfertaId,
            o.Puesto,
            o.Tipo,
            o.Descripcion,
            o.Requisitos,
            o.Salario,
            o.Creditos,
            o.Area,
            o.Ocupada
        FROM Asignacion a
        JOIN Persona p ON a.PersonaId = p.Id
        JOIN Oferta o ON a.OfertaId = o.Id
        WHERE p.Id = @personaId
    ";

            var postulaciones = new List<Postulacion>();

            try
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@personaId", personaId);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            postulaciones.Add(new Postulacion
                            {
                                AsignacionId = reader.GetInt32(reader.GetOrdinal("AsignacionId")),
                                PersonaId = reader.GetInt32(reader.GetOrdinal("PersonaId")),
                                NombrePersona = reader.GetString(reader.GetOrdinal("NombrePersona")),
                                OfertaId = reader.GetInt32(reader.GetOrdinal("OfertaId")),
                                Puesto = reader.GetString(reader.GetOrdinal("Puesto")),
                                Tipo = reader.GetString(reader.GetOrdinal("Tipo")),
                                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                                Requisitos = reader.GetString(reader.GetOrdinal("Requisitos")),

                                // Manejar valores nulos o tipos incorrectos para Salario
                               Salario = reader.GetDecimal(reader.GetOrdinal("Salario")),

                                Creditos = reader.GetInt32(reader.GetOrdinal("Creditos")),
                                Area = reader.GetString(reader.GetOrdinal("Area")),
                                Ocupada = reader.GetBoolean(reader.GetOrdinal("Ocupada"))
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Manejo de errores SQL, puedes logear o lanzar una excepción personalizada
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                // Puedes también re-levantar la excepción si es necesario
                throw;
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                Console.WriteLine("Error general: " + ex.Message);
                throw;
            }

            return postulaciones;
        }




        public List<string> ObtenerPuestos()
        {
            // Lista para almacenar los puestos
            List<string> puestos = new List<string>();

            try
            {
                // Crear la conexión con la base de datos
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    // Abrir la conexión
                    connection.Open();

                    // Consulta SQL para obtener los puestos
                    string query = "SELECT Puesto FROM Oferta"; // Asegúrate de que el nombre de la tabla y la columna sean correctos

                    // Ejecutar la consulta
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Leer los resultados
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Recorrer los resultados y agregar los puestos a la lista
                            while (reader.Read())
                            {
                                // Suponiendo que la columna 'Puesto' es de tipo string
                                string puesto = reader.GetString(reader.GetOrdinal("Puesto"));
                                puestos.Add(puesto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de que ocurra un problema con la conexión o la consulta
                Console.WriteLine("Error al obtener los puestos: " + ex.Message);
            }

            // Retornar la lista de puestos
            return puestos;
        }

        // Método para obtener el historial de postulaciones filtradas por tipo de oferta
        public List<Postulacion> ObtenerHistorialPostulacionesFiltradasPorTipoOferta(int personaId, string tipoOferta)
        {
            string sql = @"
                SELECT
                    a.Id AS AsignacionId,
                    a.PersonaId,
                    p.Nombre AS NombrePersona,
                    a.OfertaId,
                    o.Puesto,
                    o.Tipo,
                    o.Descripcion,
                    o.Requisitos,
                    o.Salario,
                    o.Creditos,
                    o.Area,
                    o.Ocupada
                FROM Asignacion a
                JOIN Persona p ON a.PersonaId = p.Id
                JOIN Oferta o ON a.OfertaId = o.Id
                WHERE p.Id = @personaId AND o.Tipo = @tipoOferta
            ";

            var postulaciones = new List<Postulacion>();

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@personaId", personaId);
                cmd.Parameters.AddWithValue("@tipoOferta", tipoOferta);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        postulaciones.Add(new Postulacion
                        {
                            AsignacionId = reader.GetInt32(reader.GetOrdinal("AsignacionId")),
                            PersonaId = reader.GetInt32(reader.GetOrdinal("PersonaId")),
                            NombrePersona = reader.GetString(reader.GetOrdinal("NombrePersona")),
                            OfertaId = reader.GetInt32(reader.GetOrdinal("OfertaId")),
                            Puesto = reader.GetString(reader.GetOrdinal("Puesto")),
                            Tipo = reader.GetString(reader.GetOrdinal("Tipo")),
                            Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                            Requisitos = reader.GetString(reader.GetOrdinal("Requisitos")),
                            Salario = reader.GetDecimal(reader.GetOrdinal("Salario")),
                            Creditos = reader.GetInt32(reader.GetOrdinal("Creditos")),
                            Area = reader.GetString(reader.GetOrdinal("Area")),
                            Ocupada = reader.GetBoolean(reader.GetOrdinal("Ocupada"))
                        });
                    }
                }
            }

            return postulaciones;
        }

        // Método para obtener el historial de postulaciones filtradas por puesto
        public List<Postulacion> ObtenerHistorialPostulacionesFiltradasPorPuesto(int personaId, string puesto)
        {
            string sql = @"
                SELECT
                    a.Id AS AsignacionId,
                    a.PersonaId,
                    p.Nombre AS NombrePersona,
                    a.OfertaId,
                    o.Puesto,
                    o.Tipo,
                    o.Descripcion,
                    o.Requisitos,
                    o.Salario,
                    o.Creditos,
                    o.Area,
                    o.Ocupada
                FROM Asignacion a
                JOIN Persona p ON a.PersonaId = p.Id
                JOIN Oferta o ON a.OfertaId = o.Id
                WHERE p.Id = @personaId AND o.Puesto = @puesto
            ";

            var postulaciones = new List<Postulacion>();

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@personaId", personaId);
                cmd.Parameters.AddWithValue("@puesto", puesto);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        postulaciones.Add(new Postulacion
                        {
                            AsignacionId = reader.GetInt32(reader.GetOrdinal("AsignacionId")),
                            PersonaId = reader.GetInt32(reader.GetOrdinal("PersonaId")),
                            NombrePersona = reader.GetString(reader.GetOrdinal("NombrePersona")),
                            OfertaId = reader.GetInt32(reader.GetOrdinal("OfertaId")),
                            Puesto = reader.GetString(reader.GetOrdinal("Puesto")),
                            Tipo = reader.GetString(reader.GetOrdinal("Tipo")),
                            Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                            Requisitos = reader.GetString(reader.GetOrdinal("Requisitos")),
                            Salario = reader.GetDecimal(reader.GetOrdinal("Salario")),
                            Creditos = reader.GetInt32(reader.GetOrdinal("Creditos")),
                            Area = reader.GetString(reader.GetOrdinal("Area")),
                            Ocupada = reader.GetBoolean(reader.GetOrdinal("Ocupada"))
                        });
                    }
                }
            }

            return postulaciones;
        }
    }
}
