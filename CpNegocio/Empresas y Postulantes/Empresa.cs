using Capa_Datos;
using cn_abs_Base.Entidades;
using CpNegocio.servicios;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio.Entidades
{
    //TODO: Clase Empresa que hereda de BaseUser
    public class CnEmpresa : BaseUser
    {
        //TODO: Campos privados para la clase Empresa
        private string _nombre;
        private string _telefono;
        private string _correo;
        private string _direccion;
        private string _rnc;
 

        //TODO: propiedades públicas para acceder a los campos privados
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
        public string Rnc
        {
            get { return _rnc; }
            set { _rnc = value; }
        }
        public int Id { get; set; }       //TODO: Solo propiedad, sin campo privado

        //TODO: constructor 
        public CnEmpresa(string nombre, string telefono, string correo, string direccion, string rnc)
        {
            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
            Rnc = rnc;
        }

        //TODO: C# permite sobrecarga de constructores (varios constructores con distinta firma).
        //Esto no rompe nada en otras partes, porque donde necesitas pasar parámetros puedes seguir usando el constructor original.
        //El nuevo constructor vacío te sirve solo para métodos como Buscar(), que no necesitan una empresa específica.
        public CnEmpresa()
        {
            //TODO: Este se usa solo cuando no necesitas inicializar valores (como en Buscar)
        }

    }
}
