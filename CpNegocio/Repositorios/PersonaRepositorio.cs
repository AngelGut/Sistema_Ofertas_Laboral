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
    public class PersonaRepositorio : IPersonaRepositorio
    {
        public Persona ObtenerPersonaPorCedula(string cedula)
        {
            using (SqlConnection connection = OfertaDatos.ObtenerConexion())
            {
                connection.Open();
                string query = "SELECT Id, Nombre, Dni, Correo, Telefono, Direccion FROM Persona WHERE Dni = @Dni";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Dni", cedula);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Persona
                            {
                                Id = (int)reader["Id"],
                                Nombre = reader["Nombre"].ToString(),
                                Dni = reader["Dni"].ToString(),
                                Correo = reader["Correo"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Direccion = reader["Direccion"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public Persona ObtenerPersonaPorId(int id)
        {
            using (SqlConnection connection = OfertaDatos.ObtenerConexion())
            {
                connection.Open();
                string query = "SELECT Id, Dni, Nombre, Correo, Telefono, Direccion FROM Persona WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Persona
                            {
                                Id = (int)reader["Id"],
                                Dni = reader["Dni"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Correo = reader["Correo"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Direccion = reader["Direccion"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Persona> ObtenerPersonasPorArea(string area)
        {
            List<Persona> personas = new List<Persona>();
            using (SqlConnection connection = OfertaDatos.ObtenerConexion())
            {
                connection.Open();
                string query = @"SELECT DISTINCT p.Id, p.Nombre, p.Dni, p.Correo, p.Telefono, p.Direccion FROM Persona p INNER JOIN Asignacion a ON p.Id = a.IdPersona INNER JOIN Oferta o ON a.IdOferta = o.Id WHERE o.Area = @Area";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Area", area);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            personas.Add(new Persona
                            {
                                Id = (int)reader["Id"],
                                Nombre = reader["Nombre"].ToString(),
                                Dni = reader["Dni"].ToString(),
                                Correo = reader["Correo"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Direccion = reader["Direccion"].ToString()
                            });
                        }
                    }
                }
            }
            return personas;
        }
    }
}
