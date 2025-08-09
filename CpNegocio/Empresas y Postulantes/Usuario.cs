using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio.Empresas_y_Postulantes
{
    public class Usuario
    {
        // TODO: Revisar la clase 'Usuario' y agregar comentarios explicativos para cada propiedad y el propósito de la clase.
        // La clase 'Usuario' representa la información básica de un usuario en el sistema.
       
        public string UsuarioNombre { get; set; }
        // Propiedad: Clave
        public string Clave { get; set; }
        // Propiedad: Correo
        public string Correo { get; set; }
        // Propiedad: Rol
        public string Rol { get; set; }

    }

}
