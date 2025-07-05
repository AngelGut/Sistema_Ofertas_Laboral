using cn_abs_Base.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;


namespace CpNegocio.Entidades
{
    public class Persona : BaseUser
    {
        //Campos privados para la clase Person
        private string _nombre;
        private string _telefono;
        private string _correo;
        private string _direccion;
        private string _dni;

        public override string Nombre 
        {
            get { return _nombre; }
            set { _nombre = value; } 
        }
        public override string Telefono 
        {
            get { return _telefono; } 
            set { _telefono = value; } 
        }
        public override string Correo 
        { 
            get { return _correo; }
            set { _correo = value; }
        }
        public override string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        public string Dni
        {
            get { return _dni; }
            set { _dni = value; }
        }

        public override void ValidarDisponibilidad()
        {

        }

        //constructor
        public Persona(string nombre, string telefono, string correo, string direccion, string dni)
        {
            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
            Dni = dni;
        }

    }
}
