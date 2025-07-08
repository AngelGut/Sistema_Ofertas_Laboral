using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//esta clase sirve como una estructura simple para representar una empresa dentro de un ComboBox en la interfaz gráfica.
namespace CpNegocio.Entidades
{
    public class EmpresaComboItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        // Sobrescribir ToString para mostrar el nombre en el ComboBox
        public override string ToString() => Nombre;
    }
}
