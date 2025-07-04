using cn_abs_Base.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio.Base
{
    public class Empresa : BaseUser
    {
        //Campos privados para la clase Empresa
        private string _nombre;
        private string _telefono;
        private string _correo;
        private string _direccion;
        private int _rnc;
 

        // propiedades públicas para acceder a los campos privados
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
        public int Rnc
        {
            get { return _rnc; }
            set { _rnc = value; }
        }
        public override void ValidarDisponibilidad()
        {
            // Implementación específica para validar disponibilidad de la empresa
        }
    }
}
