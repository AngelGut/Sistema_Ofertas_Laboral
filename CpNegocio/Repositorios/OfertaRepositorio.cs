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
            var ofertas = new List<CnOferta>();

            using (SqlConnection connection = OfertaDatos.ObtenerConexion())
            {
                connection.Open();

                string query = @"
                SELECT Id, EmpresaId, Puesto, Tipo, Descripcion, Requisitos, Salario, Creditos, Area
                FROM [dbo].[Oferta]
                WHERE Ocupada = 0;";

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Normalizar el tipo
                        string tipoRaw = (reader["Tipo"]?.ToString() ?? "").Trim();
                        string tipo = NormalizarTipo(tipoRaw);

                        int id = (int)reader["Id"];
                        int empresaId = (int)reader["EmpresaId"];
                        string puesto = reader["Puesto"]?.ToString() ?? "";
                        string desc = reader["Descripcion"]?.ToString() ?? "";
                        string req = reader["Requisitos"]?.ToString() ?? "";
                        string area = reader["Area"]?.ToString() ?? "";
                        int salario = reader["Salario"] is DBNull ? 0 : (int)reader["Salario"];
                        int creditos = reader["Creditos"] is DBNull ? 0 : (int)reader["Creditos"];

                        if (tipo == "empleofijo" || tipo == "fijo")
                        {
                            ofertas.Add(new EmpleoFijo
                            {
                                Id = id,
                                EmpresaId = empresaId,
                                Puesto = puesto,
                                Tipo = tipoRaw, // conserva original
                                Descripcion = desc,
                                Requisitos = req,
                                Salario = salario,
                                Area = area
                            });
                        }
                        else // pasantía u otro → tratamos como pasantía por defecto
                        {
                            ofertas.Add(new Pasantia
                            {
                                Id = id,
                                EmpresaId = empresaId,
                                Puesto = puesto,
                                Tipo = tipoRaw,
                                Descripcion = desc,
                                Requisitos = req,
                                Creditos = creditos,
                                Area = area
                            });
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

                string query = @"
SELECT Id, EmpresaId, Puesto, Tipo, Descripcion, Requisitos, Salario, Creditos, Area
FROM [dbo].[Oferta]
WHERE Id = @Id;";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", idOferta);

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        string tipoRaw = (reader["Tipo"]?.ToString() ?? "").Trim();
                        string tipo = NormalizarTipo(tipoRaw);

                        int id = (int)reader["Id"];
                        int empresaId = (int)reader["EmpresaId"];
                        string puesto = reader["Puesto"]?.ToString() ?? "";
                        string desc = reader["Descripcion"]?.ToString() ?? "";
                        string req = reader["Requisitos"]?.ToString() ?? "";
                        string area = reader["Area"]?.ToString() ?? "";
                        int salario = reader["Salario"] is DBNull ? 0 : (int)reader["Salario"];
                        int creditos = reader["Creditos"] is DBNull ? 0 : (int)reader["Creditos"];

                        if (tipo == "empleofijo" || tipo == "fijo")
                        {
                            return new EmpleoFijo
                            {
                                Id = id,
                                EmpresaId = empresaId,
                                Puesto = puesto,
                                Tipo = tipoRaw,
                                Descripcion = desc,
                                Requisitos = req,
                                Salario = salario,
                                Area = area
                            };
                        }
                        else // pasantía u otro → devolver Pasantia
                        {
                            return new Pasantia
                            {
                                Id = id,
                                EmpresaId = empresaId,
                                Puesto = puesto,
                                Tipo = tipoRaw,
                                Descripcion = desc,
                                Requisitos = req,
                                Creditos = creditos,
                                Area = area
                            };
                        }
                    }
                }
            }
        }

        // --- helpers ---
        private static string NormalizarTipo(string tipoRaw)
        {
            // quita espacios y baja a minúsculas; reemplaza tildes comunes
            string t = tipoRaw
                .Replace("á", "a").Replace("é", "e").Replace("í", "i")
                .Replace("ó", "o").Replace("ú", "u")
                .Replace(" ", "")
                .ToLowerInvariant();

            // mapea variantes comunes
            if (t == "empleofijo" || t == "empleo" || t == "fijo") return "empleofijo";
            if (t == "pasantia" || t == "pasantia") return "pasantia";

            return t; // deja lo que venga (y tratamos default como pasantía arriba)
        }
    }
}

