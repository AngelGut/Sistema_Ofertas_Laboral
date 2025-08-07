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
                // La consulta ahora sigue el orden exacto de las columnas de tu tabla
                string query = @"SELECT Id, EmpresaId, Puesto, Tipo, Descripcion, Requisitos, Salario, Creditos, Area 
                                 FROM Oferta 
                                 WHERE Ocupada = 0";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Los índices numéricos coinciden con el orden de la consulta
                            string tipoContrato = reader.GetString(3); // 'Tipo' es la cuarta columna (índice 3)
                            if (tipoContrato == "EmpleoFijo")
                            {
                                ofertas.Add(new EmpleoFijo
                                {
                                    Id = reader.GetInt32(0),
                                    EmpresaId = reader.GetInt32(1),
                                    Puesto = reader.GetString(2),
                                    Tipo = tipoContrato,
                                    Descripcion = reader.GetString(4),
                                    Requisitos = reader.GetString(5),
                                    Salario = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                                    Area = reader.GetString(8) // 'Area' es la novena columna (índice 8)
                                });
                            }
                            else if (tipoContrato == "Pasantia")
                            {
                                ofertas.Add(new Pasantia
                                {
                                    Id = reader.GetInt32(0),
                                    EmpresaId = reader.GetInt32(1),
                                    Puesto = reader.GetString(2),
                                    Tipo = tipoContrato,
                                    Descripcion = reader.GetString(4),
                                    Requisitos = reader.GetString(5),
                                    Creditos = reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                                    Area = reader.GetString(8) // 'Area' es la novena columna (índice 8)
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
                // La consulta también se ha ajustado para coincidir con tu tabla
                string query = "SELECT Id, EmpresaId, Puesto, Tipo, Descripcion, Requisitos, Salario, Creditos, Area FROM Oferta WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", idOferta);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Los índices numéricos coinciden con el orden de la consulta
                            string tipo = reader.GetString(3); // 'Tipo' es la cuarta columna (índice 3)

                            if (tipo == "EmpleoFijo")
                            {
                                return new EmpleoFijo
                                {
                                    Id = reader.GetInt32(0),
                                    EmpresaId = reader.GetInt32(1),
                                    Puesto = reader.GetString(2),
                                    Tipo = tipo,
                                    Descripcion = reader.GetString(4),
                                    Requisitos = reader.GetString(5),
                                    Salario = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                                    Area = reader.GetString(8)
                                };
                            }
                            else if (tipo == "Pasantia")
                            {
                                return new Pasantia
                                {
                                    Id = reader.GetInt32(0),
                                    EmpresaId = reader.GetInt32(1),
                                    Puesto = reader.GetString(2),
                                    Tipo = tipo,
                                    Descripcion = reader.GetString(4),
                                    Requisitos = reader.GetString(5),
                                    Creditos = reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                                    Area = reader.GetString(8)
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

