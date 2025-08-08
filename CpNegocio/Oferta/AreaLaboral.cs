using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpNegocio.Oferta
{
    public static class AreaLaboralProvider
    {
        /// <summary>
        /// Devuelve la lista de todas las áreas laborales disponibles.
        /// </summary>
        public static IReadOnlyList<string> GetAll()
        {
            return new[]
            {
                "Limpieza",
                "Mantenimiento y Reparaciones",
                "Atención al Cliente",
                "Recepción / Botones",
                "Seguridad y Vigilancia",

                "Cocina / Gastronomía",
                "Camarería / Sala",
                "Turismo y Agencias de Viaje",
                "Guía Turístico",
                "Gestión Hotelera",

                "Ventas / Comercio Minorista",
                "Telemarketing",
                "Comercio Electrónico",
                "Merchandising",

                "Administración",
                "Contabilidad y Finanzas",
                "Recursos Humanos",
                "Secretariado / Asistencia Ejecutiva",
                "Gestión de Proyectos",

                "Docencia / Educación Infantil",
                "Formación Profesional",
                "Universidad / Investigación Académica",
                "E-learning / Desarrollo de Contenidos",

                "Medicina / Enfermería",
                "Farmacia",
                "Fisioterapia",
                "Psicología",
                "Salud Pública",

                "Desarrollo de Software",
                "Administración de Sistemas",
                "Soporte Técnico",
                "Ciberseguridad",
                "Big Data / Ciencia de Datos",
                "Inteligencia Artificial",

                "Ingeniería Civil",
                "Ingeniería Mecánica",
                "Ingeniería Eléctrica",
                "Ingeniería Química",
                "Ingeniería Industrial",
                "Ingeniería Espacial / Aeroespacial",

                "Investigación Científica",
                "Investigación Química",
                "Biotecnología",
                "Investigación Médica",
                "Astronáutica",

                "Diseño Gráfico",
                "Marketing y Publicidad",
                "Periodismo",
                "Audiovisuales / Producción de Vídeo",
                "Comunicación Corporativa",

                "Banca y Seguros",
                "Asesoría Financiera",
                "Derecho / Asesoría Legal",
                "Compliance",

                "Transporte y Conducción",
                "Logística y Almacén",
                "Cadena de Suministro",

                "Gestión Ambiental",
                "Energías Renovables",
                "Minería",

                "Deportes y Fitness",
                "Agricultura y Agroindustria",
                "Investigación de Mercado",
                "Servicios Sociales",
                "Trabajo Social"
            };
        }
        //subir
    }
}
