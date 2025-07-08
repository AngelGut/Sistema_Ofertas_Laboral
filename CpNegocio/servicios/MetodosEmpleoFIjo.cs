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

        public MetodosEmpleoFijo() { } // <--- Constructor sin parámetros

        // Método para registrar un empleo fijo en la tabla Oferta
        public void Registrar(EmpleoFijo empleo)
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
                        cmd.Parameters.AddWithValue("@EmpresaId", empleo.EmpresaId);
                        cmd.Parameters.AddWithValue("@Puesto", empleo.Puesto);
                        cmd.Parameters.AddWithValue("@Tipo", empleo.Tipo);
                        cmd.Parameters.AddWithValue("@Descripcion", empleo.Descripcion);
                        cmd.Parameters.AddWithValue("@Requisitos", empleo.Requisitos);
                        cmd.Parameters.AddWithValue("@Salario", empleo.Salario);
                        cmd.Parameters.AddWithValue("@Creditos", DBNull.Value); // <- NULO

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar el empleo fijo: " + ex.Message);
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

