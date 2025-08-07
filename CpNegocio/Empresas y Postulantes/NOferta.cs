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
                o.Tipo,       -- **AGREGADO: Columna de tipo de oferta**
                o.Descripcion, -- **AGREGADO: Columna de descripción**
                o.Creditos,    -- **AGREGADO: Columna de créditos (para pasantías)**
                e.Nombre AS NombreEmpresa
                FROM Oferta o
                INNER JOIN Empresa e ON o.EmpresaId = e.Id
                WHERE o.Ocupada = 0";

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
