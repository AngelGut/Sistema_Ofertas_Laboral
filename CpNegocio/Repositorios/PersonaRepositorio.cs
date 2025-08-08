using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using CpNegocio.Entidades;
using CpNegocio.Interfaces;
using Microsoft.Data.SqlClient;


namespace CpNegocio.Repositorios
{
    //TODO: Implementación de la interfaz IPersonaRepositorio para interactuar con la base de datos espeficicamente de la tabla persona
    public class PersonaRepositorio : IPersonaRepositorio
    {
        //TODO: Clase que implementa los métodos definidos en la interfaz IPersonaRepositorio
        public Persona ObtenerPersonaPorCedula(string cedula)
        {
            //TODO: Usamos un bloque "using" para asegurar que la conexión se cierre correctamente
            using (SqlConnection connection = OfertaDatos.ObtenerConexion())
            {
                //TODO: aqui abrimos nuestra conexion
                connection.Open();

                //TODO: Implementamos nuestra logica del Select para obtener una persona por su cédula/Dni
                string query = "SELECT Id, Nombre, Dni, Correo, Telefono, Direccion FROM Persona WHERE Dni = @Dni";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Dni", cedula); //Aqui Cedula ya que es metodo creado es con este Nombre en vez de Dni

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //TODO: Creamos una nueva instancia de Persona y asignamos los valores obtenidos del lector
                            return new Persona
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Dni = reader.GetString(2),
                                Correo = reader.GetString(3),
                                Telefono = reader.GetString(4),
                                Direccion = reader.GetString(5)

                            };
                        }
                    }
                }
            } 

            return null; //TODO: Se retorna null si no se encuentra la persona
        }

        public List<Persona> ObtenerPersonasPorArea(string area)
        {
            //TODO: Logica similar usando OfertaDatos.ObtenerConexion()
            return new List<Persona>();
        }

        public void ActualizarOfertaIdPersona(int idPersona, int idOferta)
        {
            
        }
    }
}
