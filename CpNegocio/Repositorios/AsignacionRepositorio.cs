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
        // TODO: Implementa la lógica SQL para insertar una nueva fila en la tabla Asignacion
        public void AsignarPersonaAOferta(int idPersona, int idOferta)
        {
            using (SqlConnection connection = OfertaDatos.ObtenerConexion())
            {
                connection.Open();
                string query = "INSERT INTO Asignacion (IdPersona, IdOferta, FechaAsignacion) VALUES (@IdPersona, @IdOferta, GETDATE())";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdPersona", idPersona);
                    command.Parameters.AddWithValue("@IdOferta", idOferta);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
