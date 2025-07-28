using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn_abs_Base.Entidades
{
    //TODO: clase abstracta que define la estructura básica de un usuario
    public abstract class BaseUser
    {

        //TODO: campos para la clase Registro
        private string _nombre;
        private string _telefono;
        private string _correo;
        private string _direccion;


        //TODO: propiedades para los campos
        public abstract string Nombre { get; set; }
        public abstract string Telefono { get; set; }
        public abstract string Correo { get; set; }
        public abstract string Direccion { get; set; }

    }

}
