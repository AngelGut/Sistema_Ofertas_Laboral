using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using CpNegocio.Interfaces;
using Microsoft.Data.SqlClient;

namespace CpNegocio.Repositorios
{
    public class AsignacionRepositorio : IAsignacionRepositorio
    {
        // *** Implementación requerida por la interfaz (2 parámetros) ***
        public void AsignarPersonaAOferta(int idPersona, int idOferta)
        {
            // Llama a la sobrecarga con usuario null
            InsertarAsignacion(idPersona, idOferta, null);
        }

        // *** Sobrecarga opcional (si quieres registrar el usuario asignador) ***
        public void AsignarPersonaAOferta(int idPersona, int idOferta, int? asignadorUsuarioId)
        {
            InsertarAsignacion(idPersona, idOferta, asignadorUsuarioId);
        }

        // *** Lógica común ***
        private void InsertarAsignacion(int personaId, int ofertaId, int? asignadorUsuarioId)
        {
            using (SqlConnection connection = OfertaDatos.ObtenerConexion())
            {
                connection.Open();

                string query = @"
                INSERT INTO Asignacion (PersonaId, OfertaId, FechaAsignacion, AsignadorUsuarioId)
                VALUES (@PersonaId, @OfertaId, GETDATE(), @AsignadorUsuarioId);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonaId", personaId);
                    command.Parameters.AddWithValue("@OfertaId", ofertaId);
                    command.Parameters.AddWithValue("@AsignadorUsuarioId",
                        (object?)asignadorUsuarioId ?? DBNull.Value);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        // 2627/2601: UNIQUE (par PersonaId-OfertaId duplicado)
                        if (ex.Number == 2627 || ex.Number == 2601)
                            throw new InvalidOperationException("Esta persona ya está asignada a esa oferta.", ex);

                        // 547: FK (PersonaId u OfertaId no existen)
                        if (ex.Number == 547)
                            throw new InvalidOperationException("PersonaId u OfertaId no existen (violación de FK).", ex);

                        throw;
                    }
                }
            }
        }
    }
}
