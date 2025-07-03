using cn_abs_Base.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CpNegocio.Base
{
    public class Persona : BaseUser
    {
        //Campos privados para la clase Person
        private string _nombre;
        private string _id;
        private string _telefono;
        private string _correo;

        public string Nombre 
        {
            get { return _nombre; }
            set { _nombre = value; } 
        }
        public string Id 
        { 
            get { return _id; }
            set { _id = value; }
        }
        public string Telefono { get; set; }
        public string Correo { get; set; }

    }
}
