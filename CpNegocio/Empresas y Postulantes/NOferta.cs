using Capa_Datos;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace CpNegocio.Empresas_y_Postulantes
{
    public class NOferta
    {
        //TODO: Método para obtener todas las ofertas sin filtros
        public DataTable ObtenerOfertas()
        {
            DataTable tabla = new DataTable();
            string query = @"
            SELECT 
                o.Id AS IdOferta, 
                o.Puesto AS NombrePuesto, 
                o.Area, 
                o.Salario, 
                o.Requisitos,
                o.Tipo,       -- **AGREGADO: Columna de tipo de oferta**
                o.Descripcion, -- **AGREGADO: Columna de descripción**
                o.Creditos,    -- **AGREGADO: Columna de créditos (para pasantías)**
                e.Nombre AS NombreEmpresa
            FROM Oferta o
            INNER JOIN Empresa e ON o.EmpresaId = e.Id
            WHERE o.Ocupada = 0"; // Ofertas no ocupadas

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

        //TODO: Método para obtener ofertas filtradas por Área y ID
        public DataTable ObtenerOfertasFiltradas(string area, string idOferta)
        {
            DataTable tabla = new DataTable();

            // Empieza la consulta básica
            string query = @"
            SELECT 
                o.Id AS IdOferta, 
                o.Puesto AS NombrePuesto, 
                o.Area, 
                o.Salario, 
                o.Requisitos,
                o.Tipo,
                o.Descripcion,
                o.Creditos,
                e.Nombre AS NombreEmpresa
            FROM Oferta o
            INNER JOIN Empresa e ON o.EmpresaId = e.Id
            WHERE o.Ocupada = 0"; // Solo ofertas no ocupadas

            // Añadir filtros dinámicamente según los parámetros proporcionados
            if (!string.IsNullOrEmpty(area) && area != "Todas")
            {
                query += " AND o.Area = @Area";
            }
            if (!string.IsNullOrEmpty(idOferta))
            {
                query += " AND o.Id = @IdOferta";
            }

            try
            {
                using (SqlConnection conn = OfertaDatos.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Añadir los parámetros a la consulta
                        if (!string.IsNullOrEmpty(area) && area != "Todas")
                        {
                            cmd.Parameters.AddWithValue("@Area", area);
                        }
                        if (!string.IsNullOrEmpty(idOferta))
                        {
                            cmd.Parameters.AddWithValue("@IdOferta", int.Parse(idOferta));
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(tabla); // Rellenar el DataTable con los resultados de la consulta
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al obtener las ofertas filtradas: " + ex.Message);
            }
            return tabla;
        }
    }
}
