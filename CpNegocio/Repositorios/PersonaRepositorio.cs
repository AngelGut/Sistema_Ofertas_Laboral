using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using CpNegocio.Entidades;
using CpNegocio.Interfaces;
using Microsoft.Data.SqlClient;


namespace CpNegocio.Repositorios
{
    //TODO: Implementar la interfaz IPersonaRepositorio para la clase PersonaRepositorio
    public class PersonaRepositorio : IPersonaRepositorio
    {
        //TODO: Implementar los métodos de la interfaz IPersonaRepositorio
        public Persona ObtenerPersonaPorCedula(string cedula)
        {
            //TODO: Implementar la lógica para obtener una persona por su cédula
            using (SqlConnection connection = OfertaDatos.ObtenerConexion())
            {
                //TODO: Abrir la conexión a la base de datos
                connection.Open();
                string query = "SELECT Id, Nombre, Dni, Correo, Telefono, Direccion, OfertaId FROM Persona WHERE Dni = @Dni";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Dni", cedula);

                    //TODO: Ejecutar la consulta y leer los resultados
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //TODO: Crear una instancia de Persona y asignar los valores leídos
                            return new Persona
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Dni = reader.GetString(2),
                                Correo = reader.GetString(3),
                                Telefono = reader.GetString(4),
                                Direccion = reader.GetString(5),
                                OfertaId = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6)
                            };
                        }
                    }
                }
            }
            return null;
        }

        //TODO: Implementa la lógica SQL para obtener una persona por su ID
        public Persona ObtenerPersonaPorId(int id)
        {
            using (SqlConnection connection = OfertaDatos.ObtenerConexion())
            {
                connection.Open();
                //TODO: Esta consulta SQL obtiene una persona específica por su ID
                string query = "SELECT Id, Nombre, Dni, Correo, Telefono, Direccion, OfertaId FROM Persona WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Persona
                            {
                                //TODO: Crear una instancia de Persona y asignar los valores leídos
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Dni = reader.GetString(2),
                                Correo = reader.GetString(3),
                                Telefono = reader.GetString(4),
                                Direccion = reader.GetString(5),
                                OfertaId = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6)
                            };
                        }
                    }
                }
            }
            return null;
        }

        //TODO: Implementa la lógica SQL para obtener personas por área
        public List<Persona> ObtenerPersonasPorArea(string area)
        {
            List<Persona> personas = new List<Persona>();
            using (SqlConnection connection = OfertaDatos.ObtenerConexion())
            {
                connection.Open();
                //TODO:esta consulta SQL es para obtener a todas las personas que ya han sido asignadas a una oferta específica basándose en el área de la oferta
                string query = "SELECT p.Id, p.Nombre, p.Dni, p.Correo, p.Telefono, p.Direccion, p.OfertaId FROM Persona p INNER JOIN Oferta o ON p.OfertaId = o.Id WHERE o.Area = @Area AND p.OfertaId IS NOT NULL";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Area", area);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            personas.Add(new Persona
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Dni = reader.GetString(2),
                                Correo = reader.GetString(3),
                                Telefono = reader.GetString(4),
                                Direccion = reader.GetString(5),
                                OfertaId = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6)
                            });
                        }
                    }
                }
            }
            return personas;
        }

        //TODO: Implementa la lógica SQL para actualizar OfertaId de una persona
        public void ActualizarOfertaIdPersona(int idPersona, int idOferta)
        {
            using (SqlConnection connection = OfertaDatos.ObtenerConexion())
            {
                connection.Open();
                //TODO: Esta consulta SQL actualiza el campo OfertaId de la tabla Persona para una persona específica
                string query = "UPDATE Persona SET OfertaId = @IdOferta WHERE Id = @IdPersona";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdOferta", idOferta);
                    command.Parameters.AddWithValue("@IdPersona", idPersona);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
