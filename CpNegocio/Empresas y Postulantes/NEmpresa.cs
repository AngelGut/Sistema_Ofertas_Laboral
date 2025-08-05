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

        private DataTable EjecutarConsulta(string query)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conn = OfertaDatos.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    tabla.Load(reader);
                }
            }
            return tabla;
        }


        // (El resto del código de NEmpresa.cs permanece igual)

        public DataTable ObtenerEmpresasConArea()
        {
            DataTable tabla = new DataTable();
            // Se usa un LEFT JOIN para asegurar que se muestren las empresas aunque no tengan una oferta asociada todavía
            string query = @"
        SELECT 
            E.Id,
            E.Nombre,
            E.RNC,
            E.Telefono,
            E.Direccion,
            E.Correo,
            O.Area
        FROM 
            Empresa E
        LEFT JOIN 
            Oferta O ON E.Id = O.EmpresaId
        ";

            using (SqlConnection conn = OfertaDatos.ObtenerConexion())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(tabla);
                }
            }
            return tabla;
        }

        // (Remueve el método MostrarConAreas() si existía, ya que lo reemplazaremos)



    }

}
