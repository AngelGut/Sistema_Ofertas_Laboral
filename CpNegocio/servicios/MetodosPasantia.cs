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
    public class MetodosPasantia : MetodosBase
    {
        private Pasantia pasantia;

        // Constructor: recibe un objeto Pasantia
        public MetodosPasantia(Pasantia p)
        {
            pasantia = p;
        }

        public MetodosPasantia() { } // <--- Constructor sin parámetros

        // Método para registrar una pasantía en la base de datos
        public void Registrar(Pasantia pasantia)
        {
            try
            {
                using (SqlConnection conn = OfertaDatos.ObtenerConexion())
                {
                    conn.Open();

                    string query = @"
                    INSERT INTO Oferta (EmpresaId, Puesto, Tipo, Descripcion, Requisitos, Salario, Creditos)
                    VALUES (@EmpresaId, @Puesto, @Tipo, @Descripcion, @Requisitos, @Salario, @Creditos)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmpresaId", pasantia.EmpresaId);
                        cmd.Parameters.AddWithValue("@Puesto", pasantia.Puesto);
                        cmd.Parameters.AddWithValue("@Tipo", pasantia.Tipo);
                        cmd.Parameters.AddWithValue("@Descripcion", pasantia.Descripcion);
                        cmd.Parameters.AddWithValue("@Requisitos", pasantia.Requisitos);
                        cmd.Parameters.AddWithValue("@Salario", DBNull.Value); // <- NULO
                        cmd.Parameters.AddWithValue("@Creditos", pasantia.Creditos);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la pasantía: " + ex.Message);
            }
        }

        // Método para eliminar una pasantía por ID
        public override void Eliminar()
        {
            using (SqlConnection conn = OfertaDatos.ObtenerConexion())
            {
                conn.Open();

                string query = "DELETE FROM Oferta WHERE Id = @Id AND Tipo = 'Pasantia'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", pasantia.Id);

                    int filas = cmd.ExecuteNonQuery();

                    if (filas == 0)
                        throw new Exception("No se encontró ninguna pasantía con ese ID.");
                }
            }
        }

        // Método para obtener todas las pasantías registradas
        public override DataTable Buscar()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conn = OfertaDatos.ObtenerConexion())
            {
                conn.Open();

                string query = "SELECT * FROM Oferta WHERE Tipo = 'Pasantia'";

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
