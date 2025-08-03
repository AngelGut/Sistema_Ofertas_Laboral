using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CpNegocio.Entidades;
using CpNegocio.Interfaces;
using CpNegocio.Repositorios;
using CpNegocio.Gmail;
using CpNegocio.Oferta;
using CpNegocio.Entidades;

//Creamos la clase AsignacionServicio, que actúa como el "cerebro" de la aplicación...
//Su función es centralizar el proceso de asignar a una persona a una oferta y enviar las notificaciones
namespace CpNegocio.servicio
{
    //TODO: Clase que se encarga de asignar una oferta a una persona y enviar correos electrónicos de notificación
    public class AsignacionServicio
    {
        private readonly IPersonaRepositorio _personaRepositorio;
        private readonly IOfertaRepositorio _ofertaRepositorio;
        private readonly IAsignacionRepositorio _asignacionRepositorio;
        private readonly IEmpresaRepositorio _empresaRepositorio;

        //TODO: Constructor que inicializa los repositorios necesarios
        public AsignacionServicio()
        {
            _personaRepositorio = new PersonaRepositorio();
            _ofertaRepositorio = new OfertaRepositorio();
            _asignacionRepositorio = new AsignacionRepositorio();
            _empresaRepositorio = new EmpresaRepositorio();
        }

        //TDO: Método que asigna una oferta a una persona y envía correos electrónicos de notificación
        public void AsignarOfertaAPersona(int idPersona, int idOferta)
        {
            //Obtener los datos de la persona, oferta y empresa
            var persona = _personaRepositorio.ObtenerPersonaPorId(idPersona);
            var oferta = _ofertaRepositorio.ObtenerOfertaPorId(idOferta);
            var empresa = _empresaRepositorio.ObtenerEmpresaPorId(oferta.EmpresaId);

            //Validar que los datos existan
            if (persona == null || oferta == null || empresa == null)
            {
                throw new Exception("Persona, oferta o empresa no encontrada.");
            }

            //Persistir la asignación en la base de datos
            _asignacionRepositorio.AsignarPersonaAOferta(idPersona, idOferta);
            _personaRepositorio.ActualizarOfertaIdPersona(idPersona, idOferta);

            //nviar las notificaciones por correo (de forma asíncrona)
            try
            {
                //Enviar correo a la PERSONA
                var gmailPersona = new GmailService();
                gmailPersona.Destinatario = persona.Correo;
                gmailPersona.Asunto = "¡Felicidades! Has sido asignado a una oferta de trabajo.";
                gmailPersona.CuerpoMensaje = $"Hola {persona.Nombre},\n\n" +
                                             $"Nos complace informarte que has sido asignado a la oferta de trabajo '{oferta.Puesto}'.\n" +
                                             $"Para contactar con la empresa, escribe al siguiente correo: {empresa.Correo}.\n\n" +
                                             $"¡Mucha suerte!\n\n" +
                                             "Atentamente,\nEl equipo de GoatComm";

                if (gmailPersona.Validar())
                {
                    Task.Run(() => gmailPersona.Enviar());
                }

                //Enviar correo a la EMPRESA
                var gmailEmpresa = new GmailService();
                gmailEmpresa.Destinatario = empresa.Correo;
                gmailEmpresa.Asunto = "Nueva asignación para tu oferta de trabajo";
                gmailEmpresa.CuerpoMensaje = $"Hola equipo de {empresa.Nombre},\n\n" +
                                             $"Se ha asignado una persona a tu oferta de '{oferta.Puesto}'.\n\n" +
                                             $"Detalles de la persona asignada:\n" +
                                             $"- Nombre: {persona.Nombre}\n" +
                                             $"- Cédula: {persona.Dni}\n" +
                                             $"- Correo: {persona.Correo}\n" +
                                             $"- Teléfono: {persona.Telefono}\n\n" +
                                             $"Por favor, contacta a esta persona para continuar con el proceso.\n\n" +
                                             "Atentamente,\nEl equipo de GoatComm";

                if (gmailEmpresa.Validar())
                {
                    Task.Run(() => gmailEmpresa.Enviar());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar los correos: {ex.Message}");
            }
        }
    }
}
