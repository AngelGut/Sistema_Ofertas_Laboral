using Capa_Datos;
using CpNegocio.Oferta;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio.servicios
{
    public class MetodosEmpleoFijo : MetodosBase
    {
        private EmpleoFijo empleo;

        // Constructor que recibe una instancia de EmpleoFijo
        public MetodosEmpleoFijo(EmpleoFijo e)
        {
            empleo = e;
        }

        // Método para registrar un empleo fijo en la tabla Oferta
        public override void Registrar()
        {
            using (SqlConnection conn = OfertaDatos.ObtenerConexion())
            {
                conn.Open();

                // INSERT con campo Creditos en NULL
                string query = @"INSERT INTO Oferta 
                                (EmpresaId, Puesto, Tipo, Descripcion, Requisitos, Salario, Creditos)
                                 VALUES 
                                (@EmpresaId, @Puesto, @Tipo, @Descripcion, @Requisitos, @Salario, NULL)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmpresaId", empleo.EmpresaId);
                    cmd.Parameters.AddWithValue("@Puesto", empleo.Puesto ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tipo", empleo.Tipo);
                    cmd.Parameters.AddWithValue("@Descripcion", empleo.Descripcion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Requisitos", empleo.Requisitos ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Salario", empleo.Salario ?? (object)DBNull.Value); // null si no lo llena

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para eliminar un empleo fijo por ID
        public override void Eliminar()
        {
            using (SqlConnection conn = OfertaDatos.ObtenerConexion())
            {
                conn.Open();

                string query = "DELETE FROM Oferta WHERE Id = @Id AND Tipo = 'EmpleoFijo'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", empleo.Id);

                    int filas = cmd.ExecuteNonQuery();

                    if (filas == 0)
                        throw new Exception("No se encontró ningún empleo fijo con ese ID.");
                }
            }
        }

        // Método para listar todas las ofertas de tipo EmpleoFijo
        public override DataTable Buscar()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = OfertaDatos.ObtenerConexion())
            {
                conn.Open();

                string query = "SELECT * FROM Oferta WHERE Tipo = 'EmpleoFijo'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    tabla.Load(reader);
                }
            }

            return tabla;
        }
    }
}

