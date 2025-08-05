using Capa_Datos;
using CpNegocio.Empresas_y_Postulantes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CpNegocio.Oferta;

namespace CpNegocio.servicios
{
    public class MetodosOferta
    {
        //TODO: lista de ofertas para el listado de ofertas
        public List<OfertaListadoDto> ObtenerOfertas()
        {
            var lista = new List<OfertaListadoDto>();

            using (SqlConnection conn = OfertaDatos.ObtenerConexion())
            {
                conn.Open();
                string query = @"
            SELECT o.Id, e.Nombre AS Empresa, o.Puesto, o.Tipo, o.Descripcion,
                o.Requisitos, o.Salario, o.Creditos,
                CASE WHEN o.Ocupada = 1 THEN 'Ocupada' ELSE 'Disponible' END AS Estado
                FROM Oferta o
                INNER JOIN Empresa e ON o.EmpresaId = e.Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new OfertaListadoDto
                        {
                            Id = reader.GetInt32(0),
                            Empresa = reader.GetString(1),
                            Puesto = reader.GetString(2),
                            Tipo = reader.GetString(3),
                            Descripcion = reader.GetString(4),
                            Requisitos = reader.GetString(5),
                            Salario = reader.IsDBNull(6) ? null : reader.GetInt32(6),
                            Creditos = reader.IsDBNull(7) ? null : reader.GetInt32(7),
                            Estado = reader.GetString(8)
                        });
                    }
                }
            }

            return lista;
        }

        public List<OfertaComboItem> ObtenerTodas()
        {
            var lista = new List<OfertaComboItem>();

            using (SqlConnection conn = OfertaDatos.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT Id, Puesto FROM Oferta";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new OfertaComboItem
                        {
                            Id = reader.GetInt32(0),
                            Puesto = reader.GetString(1)
                        });
                    }
                }
            }

            return lista;
        }

        public void RegistrarOferta(int empresaId, string puesto, string tipo, string descripcion, string requisitos,
                            int salario, int creditos, string area, bool ocupada)
        {
            try
            {
                using (SqlConnection conn = OfertaDatos.ObtenerConexion())
                {
                    conn.Open();

                    string query = @"
                INSERT INTO Oferta (EmpresaId, Puesto, Tipo, Descripcion, Requisitos, Salario, Creditos, Area, Ocupada)
                VALUES (@EmpresaId, @Puesto, @Tipo, @Descripcion, @Requisitos, @Salario, @Creditos, @Area, @Ocupada)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmpresaId", empresaId);
                        cmd.Parameters.AddWithValue("@Puesto", puesto);
                        cmd.Parameters.AddWithValue("@Tipo", tipo);
                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@Requisitos", requisitos);
                        cmd.Parameters.AddWithValue("@Salario", salario);
                        cmd.Parameters.AddWithValue("@Creditos", creditos);
                        cmd.Parameters.AddWithValue("@Area", area);
                        cmd.Parameters.AddWithValue("@Ocupada", ocupada);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo registrar la oferta: " + ex.Message);
            }
        }

    }
}
