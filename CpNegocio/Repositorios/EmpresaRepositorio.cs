using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using CpNegocio.Empresas_y_Postulantes;
using CpNegocio.Entidades;
using CpNegocio.Interfaces;
using Microsoft.Data.SqlClient;


namespace CpNegocio.Repositorios
{
    public class EmpresaRepositorio : IEmpresaRepositorio
    {
        //TODO: Implementa la lógica SQL para obtener una empresa por su ID
        public CnEmpresa ObtenerEmpresaPorId(int idEmpresa)
        {
            using (SqlConnection connection = OfertaDatos.ObtenerConexion())
            {
                connection.Open();
                string query = "SELECT Id, Nombre, Correo, Rnc FROM Empresa WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", idEmpresa);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CnEmpresa
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Correo = reader.GetString(2),
                                Rnc = reader.GetString(3)
                            };
                        }
                    }
                }
            }
            return null;
        }

        //TODO: Implementa la lógica SQL para obtener una empresa por su RNC
        public CnEmpresa ObtenerEmpresaPorRnc(string rnc)
        {
            using (SqlConnection connection = OfertaDatos.ObtenerConexion())
            {
                connection.Open();
                string query = "SELECT Id, Nombre, Correo, Rnc FROM Empresa WHERE Rnc = @Rnc";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Rnc", rnc);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CnEmpresa
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Correo = reader.GetString(2),
                                Rnc = reader.GetString(3)
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
