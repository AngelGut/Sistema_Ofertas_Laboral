using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn_abs_Base.Base
{
    public abstract class BaseUser
    {
        //campos para la clase Registro
        private string _nombre;
        private string _id;
        private string _telefono;
        private string _correo;


        //propiedades para los campos
        public abstract string Nombre { get; set; }
        public abstract string Id { get; set; }
        public abstract string Telefono { get; set; }
        public abstract string Correo { get; set; }

        public abstract void GuardarRegistro();

    }

}
