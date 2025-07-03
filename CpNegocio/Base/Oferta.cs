using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnOferta.Base
{
    public class Oferta
    {
        //Campos privados para la clase Oferta
        private string _nombreCompania;
        private string _puesto;
        private string _descripcion;
        private string _requisitos;
        private string _tipo;

        //Propiedades públicas para acceder a los campos privados
        public string NombreCompania
        {
            get { return _nombreCompania; }
            set {_nombreCompania = value; }
        }
        public string Puesto 
        { 
            get { return _puesto; }
            set { _puesto = value; }
        }
        public string Descripcion 
        {
            get { return _descripcion; } 
            set { _descripcion = value; }
        }
        public string Requisitos 
        { 
            get { return _requisitos; }
            set { _requisitos = value; } 
        }
        public string Tipo
        { 
            get { return _tipo; }
            set { _tipo = value; }
        }

        //Constructor con parámetros para la clase Oferta
        public Oferta(string nombreCompania, string puesto, string descripcion, string requisitos, string tipo)
        {
            NombreCompania = nombreCompania;
            Puesto = puesto;
            Descripcion = descripcion;
            Requisitos = requisitos;
            Tipo = tipo;
        }
    }
}
