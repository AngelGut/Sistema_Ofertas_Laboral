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
    public class NPostulante
    {
        // Mostrar todos los postulantes (Personas)
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conn = OfertaDatos.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT Id, Nombre, Dni, Correo, Telefono, Direccion FROM Persona";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    tabla.Load(reader);
                }
            }
            return tabla;
        }

        // Buscar por ID
        public DataTable BuscarPorID(string id)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conn = OfertaDatos.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM Persona WHERE Id = @id";
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

        // Buscar por DNI o Cédula
        public DataTable BuscarPorDNI(string dni)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conn = OfertaDatos.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM Persona WHERE Dni = @dni";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dni", dni);
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
