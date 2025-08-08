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
        public override DataTable Buscar()
        {
            try
            {
                using var conn = OfertaDatos.ObtenerConexion();
                conn.Open();

                const string q = @"
                    SELECT
                        p.Id,
                        p.Nombre,
                        p.Dni,
                        p.Telefono,
                        p.Correo,
                        p.Direccion
                    FROM Persona p";
                using var cmd = new SqlCommand(q, conn);
                using var reader = cmd.ExecuteReader();
                var tabla = new DataTable();
                tabla.Load(reader);
                return tabla;
            }
            catch (Exception ex)
            {
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

                        query = "SELECT Id, Nombre, Rnc, Telefono, Direccion, Correo FROM Empresa WHERE Id = @ValorBusqueda";
                    }
                    else if (criterio == "Nombre")
                    {
                        query = "SELECT Id, Nombre, Rnc, Telefono, Direccion, Correo FROM Empresa WHERE Nombre LIKE @ValorBusqueda";
                    }
                    else if (criterio == "Rnc")
                    {
                        query = "SELECT Id, Nombre, Rnc, Telefono, Direccion, Correo FROM Empresa WHERE Rnc LIKE @ValorBusqueda";
                    }
                    else
                    {
                        throw new Exception("Criterio de búsqueda no válido.");
                    }

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        // En el caso de que se filtre por Nombre o Rnc, usamos LIKE para búsqueda parcial
                        if (criterio == "Id")
                        {
                            cmd.Parameters.AddWithValue("@ValorBusqueda", valorBusqueda);  // Pasar el valor como número entero
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ValorBusqueda", "%" + valorBusqueda + "%");  // Búsqueda parcial para Nombre y Rnc
                        }

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





        /// <summary>
        /// Comprueba en la base de datos, usando la conexión ya abierta,
        /// si ya existe una persona con ese DNI.
        /// </summary>
        private bool PersonaYaExiste(SqlConnection conn, string dni)
        {
            const string query = "SELECT COUNT(*) FROM Persona WHERE Dni = @Dni";

            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Dni", dni);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
