using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks; //para metodos asincronos
using Capa_Datos; // Aquí está la clase OfertaDatos con la conexión
using CpNegocio.Entidades; // Aquí está la clase Persona
using Microsoft.Data.SqlClient; // Usamos SqlConnection y SqlCommand para manejar la base de datos

namespace CpNegocio.servicios
{
    //TODO: Herencia de MetodosBase para implementar los métodos de registrar, eliminar y buscar
    public class MetodosPersona : MetodosBase
    {
        // Variable privada que contiene la persona actual que se va a manejar
        private Persona persona;

        // Constructor que recibe una persona y la guarda en la variable privada
        public MetodosPersona(Persona p)
        {
            persona = p;
        }

        // Verifica existencia usando la columna Dni
        public static bool PersonaYaExiste(string dni)
        {
            try
            {
                using var conn = OfertaDatos.ObtenerConexion();
                conn.Open();
                const string q = "SELECT COUNT(*) FROM Persona WHERE Dni = @Dni";
                using var cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@Dni", dni);
                return (int)cmd.ExecuteScalar() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar existencia de persona.", ex);
            }
        }


        // Método que guarda una nueva persona en la tabla Persona
        public override void Registrar()
        {
            try
            {
                using var conn = OfertaDatos.ObtenerConexion();
                conn.Open();

                if (PersonaYaExiste(persona.Dni))
                    throw new Exception("Esta persona ya está registrada.");

                const string q = @"
                    INSERT INTO Persona
                        (Nombre, Telefono, Correo, Direccion, Dni)
                    VALUES
                        (@Nombre, @Telefono, @Correo, @Direccion, @Dni)";
                using var cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", persona.Telefono);
                cmd.Parameters.AddWithValue("@Correo", persona.Correo);
                cmd.Parameters.AddWithValue("@Direccion", persona.Direccion);
                cmd.Parameters.AddWithValue("@Dni", persona.Dni);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la persona en la base de datos.", ex);
            }
        }

        // Método que elimina una persona de la base de datos según su cédula
        public override void Eliminar()
        {
            try
            {
                using var conn = OfertaDatos.ObtenerConexion();
                conn.Open();

                const string q = "DELETE FROM Persona WHERE Dni = @Dni";
                using var cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@Dni", persona.Dni);
                int filas = cmd.ExecuteNonQuery();

                if (filas == 0)
                    throw new Exception("No se encontró ninguna persona con ese DNI.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la persona de la base de datos.", ex);
            }
        }

        // Método que retorna todas las personas registradas en un DataTable
        // Método que retorna todas las personas registradas en un DataTable
        public override DataTable Buscar()
        {
            try
            {
                // Conexión con la base de datos
                using var conn = OfertaDatos.ObtenerConexion();
                conn.Open();

                // Consulta SQL para obtener los datos de las personas, incluyendo la columna 'Id'
                const string q = @"
            SELECT
                p.Id,           -- Selección de la columna 'Id'
                p.Nombre,       -- Selección de la columna 'Nombre'
                p.Dni,          -- Selección de la columna 'Dni'
                p.Telefono,     -- Selección de la columna 'Telefono'
                p.Correo,       -- Selección de la columna 'Correo'
                p.Direccion     -- Selección de la columna 'Direccion'
            FROM Persona p";   // Tabla de personas

                // Ejecutar la consulta
                using var cmd = new SqlCommand(q, conn);
                using var reader = cmd.ExecuteReader();

                // Crear un DataTable y cargar los datos de la consulta
                var tabla = new DataTable();
                tabla.Load(reader);  // Carga los resultados en el DataTable

                return tabla;  // Devuelve el DataTable con los resultados
            }
            catch (Exception ex)
            {
                // Si ocurre un error, lo lanzamos como una excepción personalizada
                throw new Exception("Error al mostrar los datos de personas.", ex);
            }
        }

        public DataTable BuscarConFiltro(string criterio, string valorBusqueda)
        {
            try
            {
                using (var conn = OfertaDatos.ObtenerConexion())
                {
                    conn.Open();

                    string query = "";

                    // Dependiendo del criterio, ajustamos la consulta
                    if (criterio == "Id")
                    {
                        // Validamos si el valor de búsqueda para Id es un número entero
                        if (!int.TryParse(valorBusqueda, out int idValor))
                        {
                            throw new Exception("El valor para el filtro 'Id' debe ser un número entero.");
                        }

                        query = "SELECT Id, Nombre, Dni, Telefono, Correo, Direccion FROM Persona WHERE Id = @ValorBusqueda";
                    }
                    else if (criterio == "Nombre")
                    {
                        query = "SELECT Id, Nombre, Dni, Telefono, Correo, Direccion FROM Persona WHERE Nombre LIKE @ValorBusqueda";
                    }
                    else if (criterio == "Dni")
                    {
                        query = "SELECT Id, Nombre, Dni, Telefono, Correo, Direccion FROM Persona WHERE Dni LIKE @ValorBusqueda";
                    }
                    else
                    {
                        throw new Exception("Criterio de búsqueda no válido.");
                    }

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        // Agregar el parámetro de búsqueda
                        if (criterio == "Id")
                        {
                            // Para 'Id', pasamos el valor como entero (int)
                            cmd.Parameters.AddWithValue("@ValorBusqueda", int.Parse(valorBusqueda));
                        }
                        else
                        {
                            // Para 'Nombre' y 'Dni', utilizamos LIKE con búsqueda parcial
                            cmd.Parameters.AddWithValue("@ValorBusqueda", "%" + valorBusqueda + "%");
                        }

                        // Ejecutar la consulta
                        using (var reader = cmd.ExecuteReader())
                        {
                            var tabla = new DataTable();
                            tabla.Load(reader);
                            return tabla;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al aplicar el filtro: " + ex.Message, ex);
            }
        }



    }
}
