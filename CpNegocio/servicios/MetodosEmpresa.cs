using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos; // Aquí está la clase OfertaDatos con la conexión
using CpNegocio.Entidades; // Aquí está la clase Persona
using Microsoft.Data.SqlClient; // Usamos SqlConnection y SqlCommand para manejar la base de datos

namespace CpNegocio.servicios
{
    public class CnMetodosEmpresa : MetodosBase
    {
        // Empresa que se va a gestionar (registrar, eliminar, buscar)
        private CnEmpresa empresa;

        // Constructor que recibe una empresa al momento de instanciar la clase
        public CnMetodosEmpresa(CnEmpresa emp)
        {
            empresa = emp;
        }

        // Método que verifica si una empresa ya existe en la base de datos por su RNC
        public static bool EmpresaYaExiste(string rnc)
        {
            using (SqlConnection conn = OfertaDatos.ObtenerConexion())
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM Empresa WHERE Rnc = @Rnc";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Rnc", rnc);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }


        // Método que registra una nueva empresa en la base de datos
        //TODO: Implementacion del metodo virtual
        public override void Registrar()
        {
            try
            {
                // Se abre la conexión
                using (SqlConnection conn = OfertaDatos.ObtenerConexion())
                {
                    conn.Open();

                    // Validamos si la empresa ya existe por su RNC
                    if (EmpresaYaExiste(empresa.Rnc))
                    {
                        throw new Exception("Esta empresa ya está registrada.");
                    }

                    // Consulta SQL para insertar una nueva empresa
                    string query = @"INSERT INTO Empresa (Nombre, Telefono, Correo, Direccion, Rnc)
                                     VALUES (@Nombre, @Telefono, @Correo, @Direccion, @Rnc)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Asignamos los parámetros desde el objeto empresa
                        cmd.Parameters.AddWithValue("@Nombre", empresa.Nombre);
                        cmd.Parameters.AddWithValue("@Telefono", empresa.Telefono);
                        cmd.Parameters.AddWithValue("@Correo", empresa.Correo);
                        cmd.Parameters.AddWithValue("@Direccion", empresa.Direccion);
                        cmd.Parameters.AddWithValue("@Rnc", empresa.Rnc);

                        // Ejecutamos la consulta
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Relanzamos el error con contexto para mostrarlo en la capa de presentación
                throw new Exception("No se pudo registrar la empresa: " + ex.Message);
            }
        }

        // Método que elimina una empresa de la base de datos según su RNC
        //TODO: Implementacion del metodo abstracto
        public override void Eliminar()
        {
            try
            {
                using (SqlConnection conn = OfertaDatos.ObtenerConexion())
                {
                    conn.Open();

                    // Consulta SQL para eliminar por RNC
                    string query = "DELETE FROM Empresa WHERE Rnc = @Rnc";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Rnc", empresa.Rnc);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se encontró ninguna empresa con ese RNC.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la empresa: " + ex.Message);
            }
        }

        // Método que retorna un DataTable con todas las empresas registradas
        public override DataTable Buscar()
        {
            try
            {
                using (SqlConnection conn = OfertaDatos.ObtenerConexion())
                {
                    conn.Open();

                    // Consulta SQL para seleccionar todas las empresas
                    string query = "SELECT * FROM Empresa";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable tabla = new DataTable();
                            tabla.Load(reader);
                            return tabla;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar empresas: " + ex.Message);
            }
        }
    }
}
