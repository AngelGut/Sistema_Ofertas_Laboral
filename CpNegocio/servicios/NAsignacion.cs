using System.Data;
using System.Threading.Tasks;
using CpDatos;  // Asegúrate de tener la referencia a la capa de datos

namespace CpNegocio
{
    public class NAsignacion
    {
        // Instancia de la capa de acceso a datos
        private readonly AsignacionDA _asignacionDA;

        // Constructor que inicializa la capa de acceso a datos
        public NAsignacion()
        {
            _asignacionDA = new AsignacionDA();  // Instancia de la clase de acceso a datos
        }

        // Método asíncrono que llama al método de la capa de datos para obtener el historial
        public async Task<DataTable> ObtenerHistorialConDetalleAsync()
        {
            // Llama a la capa de datos y devuelve los resultados a la capa de negocio
            return await _asignacionDA.ObtenerHistorialConDetalleAsync();
        }
    }
}

