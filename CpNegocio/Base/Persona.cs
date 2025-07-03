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
        private string _direccion;

        public override string Nombre 
        {
            get { return _nombre; }
            set { _nombre = value; } 
        }
        public override string Id 
        { 
            get { return _id; }
            set { _id = value; }
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

        public override void GuardarRegistro()
        {

        }
    }
}
