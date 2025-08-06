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
        //TODO: Implementa la lógica SQL para obtener todas las ofertas sin una asignación
        public List<CnOferta> ObtenerOfertasDisponibles()
        {
            return new List<CnOferta>();
        }

        public CnOferta ObtenerOfertaPorId(int idOferta)
        {
            using (SqlConnection connection = OfertaDatos.ObtenerConexion())
            {
                connection.Open();
                string query = "SELECT Id, Puesto, Area, EmpresaId, Tipo, Salario, Creditos FROM Oferta WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", idOferta);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string tipoContrato = reader.GetString(4);

                            if (tipoContrato == "EmpleoFijo")
                            {
                                return new EmpleoFijo
                                {
                                    Id = reader.GetInt32(0),
                                    Puesto = reader.GetString(1),
                                    Area = reader.GetString(2),
                                    EmpresaId = reader.GetInt32(3),
                                    TipoContrato = tipoContrato,
                                    Salario = reader.GetInt32(5)
                                };
                            }
                            else if (tipoContrato == "Pasantia")
                            {
                                return new Pasantia
                                {
                                    Id = reader.GetInt32(0),
                                    Puesto = reader.GetString(1),
                                    Area = reader.GetString(2),
                                    EmpresaId = reader.GetInt32(3),
                                    TipoContrato = tipoContrato,
                                    Creditos = reader.GetInt32(6)
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

