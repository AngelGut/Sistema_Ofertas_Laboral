using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Microsoft.Data.SqlClient;

namespace CpNegocio.Empresas_y_Postulantes
{
    public class NEmpresa
    {
        // Mostrar todas las empresas
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conn = OfertaDatos.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM Empresa";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    tabla.Load(reader);
                }
            }
            return tabla;
        }

        // Buscar empresa por RNC
        public DataTable BuscarPorRNC(string rnc)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conn = OfertaDatos.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM Empresa WHERE Rnc = @rnc";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@rnc", rnc);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        tabla.Load(reader);
                    }
                }
            }
            return tabla;
        }

        // Buscar empresa por ID
        public DataTable BuscarPorID(string id)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conn = OfertaDatos.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM Empresa WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        tabla.Load(reader);
                    }
                }
            }
            return tabla;
        }
    }

}
