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
        /// <summary>
        /// Inserta en [dbo].[Asignacion] si no existe el par (PersonaId, OfertaId).
        /// NO cambia Oferta.Ocupada; eso se gestiona manualmente en otro form.
        /// </summary>
        public void AsignarPersonaAOferta(int idPersona, int idOferta)
        {
            using var cn = OfertaDatos.ObtenerConexion();
            cn.Open();
            using var tx = cn.BeginTransaction();

            try
            {
                const string insertSql = @"
                    IF NOT EXISTS (
                        SELECT 1 FROM [dbo].[Asignacion] WHERE PersonaId = @PersonaId AND OfertaId = @OfertaId
                    )
                    BEGIN
                        INSERT INTO [dbo].[Asignacion] (PersonaId, OfertaId, FechaAsignacion, AsignadorUsuarioId)
                        VALUES (@PersonaId, @OfertaId, GETDATE(), NULL);
                    END";

                using (var cmd = new SqlCommand(insertSql, cn, tx))
                {
                    cmd.Parameters.AddWithValue("@PersonaId", idPersona);
                    cmd.Parameters.AddWithValue("@OfertaId", idOferta);
                    cmd.ExecuteNonQuery();
                }

                // NO actualizar Oferta.Ocupada aquí

                tx.Commit();
            }
            catch (SqlException ex)
            {
                tx.Rollback();

                // 547 = violación de FK (Persona/Oferta inexistentes)
                if (ex.Number == 547)
                    throw new InvalidOperationException("PersonaId u OfertaId no existen (violación de clave foránea).", ex);

                // 2627/2601 no aparecerán por el IF NOT EXISTS, pero por si acaso:
                if (ex.Number == 2627 || ex.Number == 2601)
                    throw new InvalidOperationException("Esta persona ya está asignada a esa oferta.", ex);

                throw;
            }
        }
    }
}

