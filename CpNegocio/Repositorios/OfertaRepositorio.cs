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
    //TODO: Clase que implementa la interfaz IOfertaRepositorio para interactuar con la base de datos
    public class OfertaRepositorio : IOfertaRepositorio
    {
        //TODO: Método que obtiene una lista de ofertas disponibles
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
                    //Recorre los resultados de la consulta y crea objetos CnOferta
                    while (reader.Read())
                    {
                        string tipoRaw = (reader["Tipo"]?.ToString() ?? "").Trim();
                        string tipo = NormalizarTipo(tipoRaw);
                        // Verifica el tipo de oferta y crea la instancia correspondiente
                        int id = (int)reader["Id"];
                        int empresaId = (int)reader["EmpresaId"];
                        string puesto = reader["Puesto"]?.ToString() ?? "";
                        string desc = reader["Descripcion"]?.ToString() ?? "";
                        string req = reader["Requisitos"]?.ToString() ?? "";
                        string area = reader["Area"]?.ToString() ?? "";
                        int salario = reader["Salario"] is DBNull ? 0 : (int)reader["Salario"];
                        int creditos = reader["Creditos"] is DBNull ? 0 : (int)reader["Creditos"];

                        //Crea la oferta según el tipo
                        if (tipo == "empleofijo" || tipo == "fijo")
                        {
                            //Crea una instancia de EmpleoFijo
                            ofertas.Add(new EmpleoFijo
                            {
                                Id = id,
                                EmpresaId = empresaId,
                                Puesto = puesto,
                                Tipo = tipoRaw, //Normalizado para mantener el tipo original
                                Descripcion = desc,
                                Requisitos = req, 
                                Salario = salario,
                                Area = area
                            });
                        }
                        else 
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

        //TODO: Método que obtiene una oferta por su ID
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
                        //Verifica el tipo de oferta y crea la instancia correspondiente
                        int id = (int)reader["Id"];
                        int empresaId = (int)reader["EmpresaId"];
                        string puesto = reader["Puesto"]?.ToString() ?? "";
                        string desc = reader["Descripcion"]?.ToString() ?? "";
                        string req = reader["Requisitos"]?.ToString() ?? "";
                        string area = reader["Area"]?.ToString() ?? "";
                        int salario = reader["Salario"] is DBNull ? 0 : (int)reader["Salario"];
                        int creditos = reader["Creditos"] is DBNull ? 0 : (int)reader["Creditos"];

                        //Crea la oferta según el tipo
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
                        else 
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

        //TODO: Método que realiza una serie de transformaciones sobre la cadena de entrada (tipoRaw) para normalizarla
        private static string NormalizarTipo(string tipoRaw)
        {
            
            string t = tipoRaw
                .Replace("á", "a").Replace("é", "e").Replace("í", "i")
                .Replace("ó", "o").Replace("ú", "u")
                .Replace(" ", "")
                .ToLowerInvariant();

            
            if (t == "empleofijo" || t == "empleo" || t == "fijo") return "empleofijo";
            if (t == "pasantia" || t == "pasantia") return "pasantia";

            return t; 
        }
    }
}

