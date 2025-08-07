using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using CpNegocio.Oferta;
using Microsoft.Data.SqlClient;

namespace CpNegocio.Repositorios
{
    public class OfertaRepositorio : IOfertaRepositorio
    {
        public List<CnOferta> ObtenerOfertasDisponibles()
        {
            List<CnOferta> ofertas = new List<CnOferta>();
            using (SqlConnection connection = OfertaDatos.ObtenerConexion())
            {
                connection.Open();
                string query = @"SELECT Id, EmpresaId, Puesto, Tipo, Descripcion, Requisitos, Salario, Creditos, Area
                                 FROM Oferta
                                 WHERE Ocupada = 0";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Obtenemos el tipo de la base de datos de manera segura
                            string tipoContrato = reader["Tipo"].ToString();

                            if (tipoContrato == "EmpleoFijo")
                            {
                                ofertas.Add(new EmpleoFijo
                                {
                                    Id = (int)reader["Id"],
                                    EmpresaId = (int)reader["EmpresaId"],
                                    Puesto = reader["Puesto"].ToString(),
                                    Tipo = tipoContrato,
                                    Descripcion = reader["Descripcion"].ToString(),
                                    Requisitos = reader["Requisitos"].ToString(),
                                    Salario = reader["Salario"] as int? ?? 0,
                                    Area = reader["Area"].ToString()
                                });
                            }
                            else if (tipoContrato == "Pasantia")
                            {
                                ofertas.Add(new Pasantia
                                {
                                    Id = (int)reader["Id"],
                                    EmpresaId = (int)reader["EmpresaId"],
                                    Puesto = reader["Puesto"].ToString(),
                                    Tipo = tipoContrato,
                                    Descripcion = reader["Descripcion"].ToString(),
                                    Requisitos = reader["Requisitos"].ToString(),
                                    Creditos = reader["Creditos"] as int? ?? 0,
                                    Area = reader["Area"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return ofertas;
        }

        public CnOferta ObtenerOfertaPorId(int idOferta)
        {
            using (SqlConnection connection = OfertaDatos.ObtenerConexion())
            {
                connection.Open();
                string query = "SELECT Id, EmpresaId, Puesto, Tipo, Descripcion, Requisitos, Salario, Creditos, Area FROM Oferta WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", idOferta);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string tipo = reader["Tipo"].ToString();

                            if (tipo == "EmpleoFijo")
                            {
                                return new EmpleoFijo
                                {
                                    Id = (int)reader["Id"],
                                    EmpresaId = (int)reader["EmpresaId"],
                                    Puesto = reader["Puesto"].ToString(),
                                    Tipo = tipo,
                                    Descripcion = reader["Descripcion"].ToString(),
                                    Requisitos = reader["Requisitos"].ToString(),
                                    Salario = reader["Salario"] as int? ?? 0,
                                    Area = reader["Area"].ToString()
                                };
                            }
                            else if (tipo == "Pasantia")
                            {
                                return new Pasantia
                                {
                                    Id = (int)reader["Id"],
                                    EmpresaId = (int)reader["EmpresaId"],
                                    Puesto = reader["Puesto"].ToString(),
                                    Tipo = tipo,
                                    Descripcion = reader["Descripcion"].ToString(),
                                    Requisitos = reader["Requisitos"].ToString(),
                                    Creditos = reader["Creditos"] as int? ?? 0,
                                    Area = reader["Area"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}

