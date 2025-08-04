using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CpNegocio.Entidades;
using CpNegocio.Interfaces;
using CpNegocio.Repositorios;
using CpNegocio.Oferta;
using CpNegocio.Entidades;

//Creamos la clase AsignacionServicio, que actúa como el "cerebro" de la aplicación...
//Su función es centralizar el proceso de asignar a una persona a una oferta y enviar las notificaciones
namespace CpNegocio.servicio
{
    //TODO: Clase que se encarga de asignar una oferta a una persona y enviar correos electrónicos de notificación
    public class AsignacionServicio
    {
        //TODO: Declaración de los repositorios necesarios para acceder a los datos
        private readonly IPersonaRepositorio _personaRepositorio;
        private readonly IOfertaRepositorio _ofertaRepositorio;
        private readonly IAsignacionRepositorio _asignacionRepositorio;
        private readonly IEmpresaRepositorio _empresaRepositorio;
        private readonly IMensajeriaRepositorio _mensajeriaRepositorio; // Usando la interfaz

        //TODO: Constructor que inicializa los repositorios necesarios
        public AsignacionServicio()
        {
            _personaRepositorio = new PersonaRepositorio();
            _ofertaRepositorio = new OfertaRepositorio();
            _asignacionRepositorio = new AsignacionRepositorio();
            _empresaRepositorio = new EmpresaRepositorio();
            _mensajeriaRepositorio = new MensajeriaRepo(); // Inicializando con la implementación
        }

        //TODO: Método que asigna una oferta a una persona y envía correos electrónicos de notificación
        public void AsignarOfertaAPersona(int idPersona, int idOferta)
        {
            //TODO: Obtener los datos de la persona, oferta y empresa
            var persona = _personaRepositorio.ObtenerPersonaPorId(idPersona);
            var oferta = _ofertaRepositorio.ObtenerOfertaPorId(idOferta);
            var empresa = _empresaRepositorio.ObtenerEmpresaPorId(oferta.EmpresaId);

            //TODO: Validar que los datos existan
            if (persona == null || oferta == null || empresa == null)
            {
                throw new Exception("Persona, oferta o empresa no encontrada.");
            }

            //TODO: Persistir la asignación en la base de datos
            _asignacionRepositorio.AsignarPersonaAOferta(idPersona, idOferta);
            _personaRepositorio.ActualizarOfertaIdPersona(idPersona, idOferta);

            //TODO: enviar las notificaciones por correo
            try
            {
                //TODO: Lógica para determinar el detalle del salario o los créditos
                string detalleOferta = string.Empty;
                if (oferta is EmpleoFijo empleoFijo)
                {
                    detalleOferta = $"Salario: ${empleoFijo.Salario}";
                }
                else if (oferta is Pasantia pasantia)
                {
                    detalleOferta = $"Créditos: {pasantia.Creditos}";
                }

                //TODO: Cuerpo del mensaje para la persona
                string cuerpoPersona =
                    $"Estimado/a {persona.Nombre},\n\n" +
                    $"Nos complace informarte que has sido seleccionado/a y asignado/a a la siguiente oferta de trabajo publicada en EmpleaTech:\n\n" +
                    $"Puesto: {oferta.Puesto}\n" +
                    $"Área: {oferta.Area}\n" +
                    $"{detalleOferta}\n\n" +
                    $"Descripción del Puesto: \n\n" +
                    $"{oferta.Descripcion}\n\n" +
                    $"Empresa: {empresa.Nombre}\n\n" +
                    $"La Empresa {empresa.Nombre} pide que se cumplan los siguientes requisitos antes de empezar el proceso de selección :\n" +
                    $"{oferta.Requisitos}\n\n" +
                    $"Para continuar con el proceso de selección, es importante que te pongas en contacto con la empresa a través del siguiente correo electrónico:\n" +
                    $"{empresa.Correo}\n\n" +
                    $"Te recomendamos enviar un correo de presentación indicando tu interés y disponibilidad para coordinar los próximos pasos.\n\n" +
                    $"Desde EmpleaTech, te deseamos mucho éxito en este proceso.\n\n" +
                    $"Atentamente,\n" +
                    $"El equipo de EmpleaTech";

                //TODO: Usamos el repositorio de mensajería para enviar el correo
                _mensajeriaRepositorio.EnviarMensaje(
                    persona.Correo,
                    "Asignación a Oferta Laboral - EmpleaTech",
                    cuerpoPersona
                );


                //TODO: Cuerpo del mensaje para la empresa
                string cuerpoEmpresa =
                    $"Estimados/as de {empresa.Nombre},\n\n" +
                    $"Les informamos que un nuevo candidato ha sido asignado a la siguiente oferta laboral publicada en nuestra plataforma Postulate:\n\n" +
                    $"Oferta: {oferta.Puesto}\n\n" +
                    $"Detalles del candidato asignado:\n" +
                    $"- Nombre: {persona.Nombre}\n" +
                    $"- Cédula: {persona.Dni}\n" +
                    $"- Correo electrónico: {persona.Correo}\n" +
                    $"- Teléfono: {persona.Telefono}\n\n" +
                    $"Les recomendamos contactar al candidato a la brevedad para continuar con el proceso de selección y coordinar los próximos pasos.\n\n" +
                    $"Agradecemos su confianza en EmpleaTech para la gestión de su oferta laboral.\n\n" +
                    $"Atentamente,\n" +
                    $"El equipo de EmpleaTech";

                //TODO: Usamos el repositorio de mensajería para enviar el correo
                _mensajeriaRepositorio.EnviarMensaje(
                    empresa.Correo,
                    "Nueva Asignación en tu Oferta Laboral - EmpleaTech",
                    cuerpoEmpresa
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar los correos: {ex.Message}");
            }
        }
    }
}
