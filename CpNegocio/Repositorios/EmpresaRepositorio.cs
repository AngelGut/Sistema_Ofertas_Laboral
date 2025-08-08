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
    //TODO: Clase que implementa la interfaz IEmpresaRepositorio para interactuar con la base de datos
    public class EmpresaRepositorio : IEmpresaRepositorio
    {
        //TODO: Método que obtiene una empresa por su ID
        public CnEmpresa ObtenerEmpresaPorId(int idEmpresa)
        {
            using (SqlConnection connection = OfertaDatos.ObtenerConexion())
            {
                connection.Open();
                string query = "SELECT Id, Nombre, Correo, Rnc, Telefono, Direccion FROM Empresa WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", idEmpresa);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CnEmpresa
                            {
                                Id = (int)reader["Id"],
                                Nombre = reader["Nombre"].ToString(),
                                Correo = reader["Correo"].ToString(),
                                Rnc = reader["Rnc"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Direccion = reader["Direccion"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        //TODO: Método que obtiene una empresa por su RNC
        public CnEmpresa ObtenerEmpresaPorRnc(string rnc)
        {
            using (SqlConnection connection = OfertaDatos.ObtenerConexion())
            {
                connection.Open();
                string query = "SELECT Id, Nombre, Correo, Rnc, Telefono, Direccion FROM Empresa WHERE Rnc = @Rnc";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Rnc", rnc);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CnEmpresa
                            {
                                Id = (int)reader["Id"],
                                Nombre = reader["Nombre"].ToString(),
                                Correo = reader["Correo"].ToString(),
                                Rnc = reader["Rnc"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Direccion = reader["Direccion"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
