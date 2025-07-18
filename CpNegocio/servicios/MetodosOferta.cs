﻿using Capa_Datos;
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
    }
}
