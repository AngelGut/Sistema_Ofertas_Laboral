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
    public class NOferta
    {
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
                o.EmpresaId, 
                e.Nombre AS NombreEmpresa,
                e.Rnc AS RNC
            FROM Oferta o
            INNER JOIN Empresa e ON o.EmpresaId = e.Id
            WHERE o.Ocupada = 0"; //filtrar las ofertas disponibles.

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

    }
}
