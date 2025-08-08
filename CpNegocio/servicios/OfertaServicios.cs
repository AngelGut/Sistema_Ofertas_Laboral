using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CpNegocio.Oferta;
using CpNegocio.Repositorios;

namespace CpNegocio.servicios
{
    //TODO: Clase de servicio para manejar la lógica de negocio relacionada con ofertas
    public class OfertaServicio
    {
        //TODO: Repositorio para acceder a los datos de ofertas
        private readonly OfertaRepositorio _repositorio;

        //TODO: Constructor que inicializa el repositorio
        public OfertaServicio()
        {
            _repositorio = new OfertaRepositorio();
        }

        //TODO: Método para obtener todas las ofertas disponibles
        public DataTable ObtenerOfertas()
        {
            //TODO: Llama al repositorio para obtener las ofertas disponibles
            var ofertas = _repositorio.ObtenerOfertasDisponibles();

            //TODO: Crea una tabla de datos para almacenar las ofertas
            DataTable tabla = new DataTable();
            tabla.Columns.Add("IdOferta", typeof(int));
            tabla.Columns.Add("Puesto", typeof(string));
            tabla.Columns.Add("Tipo", typeof(string));
            tabla.Columns.Add("Descripcion", typeof(string));
            tabla.Columns.Add("Requisitos", typeof(string));
            tabla.Columns.Add("Area", typeof(string));
            tabla.Columns.Add("Salario", typeof(int));
            tabla.Columns.Add("Creditos", typeof(int));

            //TODO: Recorre las ofertas y agrega los datos a la tabla
            foreach (var oferta in ofertas)
            {
                if (oferta is EmpleoFijo empleo)
                {
                    tabla.Rows.Add(empleo.Id, empleo.Puesto, empleo.Tipo, empleo.Descripcion, empleo.Requisitos, empleo.Area, empleo.Salario, 0);
                }
                else if (oferta is Pasantia pasantia)
                {
                    tabla.Rows.Add(pasantia.Id, pasantia.Puesto, pasantia.Tipo, pasantia.Descripcion, pasantia.Requisitos, pasantia.Area, 0, pasantia.Creditos);
                }
            }

            return tabla;
        }
    }
}
