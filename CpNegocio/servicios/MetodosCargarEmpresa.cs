using Capa_Datos;
using CpNegocio.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio.servicios
{
    public class MetodosCargarEmpresa
    {
        // Método que obtiene la lista de empresas desde la base de datos
        public List<EmpresaComboItem> ObtenerEmpresas()
        {
            var empresas = new List<EmpresaComboItem>();

            using (SqlConnection conn = OfertaDatos.ObtenerConexion()) // Usa la clase de conexión de tu capa de datos
            {
                conn.Open();

                string query = "SELECT Id, Nombre FROM Empresa"; // Consulta SQL

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        empresas.Add(new EmpresaComboItem
                        {
                            Id = reader.GetInt32(0),         // Primer campo: Id
                            Nombre = reader.GetString(1)     // Segundo campo: Nombre
                        });
                    }
                }
            }

            return empresas; // Devuelve la lista lista de objetos para el ComboBox
        }
    }
}
