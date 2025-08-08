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

           
            var persona = _personaRepositorio.ObtenerPersonaPorId(idPersona);
            var oferta = _ofertaRepositorio.ObtenerOfertaPorId(idOferta);


            if (persona == null)
                throw new Exception($"Persona no encontrada (Id={idPersona}).");

            if (oferta == null)
                throw new Exception($"Oferta no encontrada (Id={idOferta}).");

            
            var empresa = _empresaRepositorio.ObtenerEmpresaPorId(oferta.EmpresaId);
            if (empresa == null)
                throw new Exception($"Empresa no encontrada para la oferta (EmpresaId={oferta.EmpresaId}).");

            
            _asignacionRepositorio.AsignarPersonaAOferta(idPersona, idOferta);

            //TODO: enviar las notificaciones por correo
            // Enviar correos en HTML
            try
            {
                string detalleOferta = string.Empty;
                if (oferta is EmpleoFijo empleoFijo)
                    detalleOferta = $"<li><strong>Salario:</strong> ${empleoFijo.Salario}</li>";
                else if (oferta is Pasantia pasantia)
                    detalleOferta = $"<li><strong>Créditos:</strong> {pasantia.Creditos}</li>";

                // ====== CORREO A LA PERSONA (HTML) ======
                var subjectPersona = $"Asignación confirmada: {oferta.Puesto} en {empresa.Nombre}";
                var cuerpoPersonaHtml = $@"
                 <html>
                 <body style='font-family:Arial,Helvetica,sans-serif;color:#222;background:#f6f8fb;padding:0;margin:0;'>
                 <div style='max-width:640px;margin:24px auto;background:#fff;border-radius:12px;box-shadow:0 1px 4px rgba(0,0,0,.08);overflow:hidden;'>
                 <div style='background:#0ea5e9;color:#fff;padding:16px 20px;font-size:18px;font-weight:700;'>
                 EmpleaTech • Asignación de Oferta
                 </div>
                 <div style='padding:22px 22px 8px 22px;font-size:15px;line-height:1.5;'>
                 <p style='margin:0 0 12px 0;'>Hola <strong>{persona.Nombre}</strong>,</p>
                 <p style='margin:0 0 16px 0;'>¡Enhorabuena! Has sido asignado/a a la oferta <strong>{oferta.Puesto}</strong> en <strong>{empresa.Nombre}</strong>.</p>
                 </div>

                 <div style='padding:0 22px 12px 22px;'>
                 <div style='border:1px solid #e5e7eb;border-radius:10px;overflow:hidden;'>
                 <div style='background:#f8fafc;padding:12px 14px;font-weight:700;'>Resumen de la oferta</div>
                 <div style='padding:10px 14px;border-top:1px solid #f1f5f9;'><strong>Puesto:</strong> {oferta.Puesto}</div>
                 <div style='padding:10px 14px;border-top:1px solid #f1f5f9;'><strong>Área:</strong> {oferta.Area}</div>
                 <div style='padding:10px 14px;border-top:1px solid #f1f5f9;'><strong>Empresa:</strong> {empresa.Nombre}</div>
                 {(string.IsNullOrEmpty(detalleOferta) ? "" : $"<div style='padding:10px 14px;border-top:1px solid #f1f5f9;'><ul style=\"margin:0;padding-left:18px;\">{detalleOferta}</ul></div>")}
                 </div>
                 </div>

                 <div style='padding:6px 22px 8px 22px;font-size:15px;line-height:1.5;'>
                 <p style='margin:0 0 6px 0;'><strong>Descripción:</strong></p>
                 <p style='margin:0 0 12px 0;white-space:pre-line;'>{oferta.Descripcion}</p>
                 <p style='margin:0 0 6px 0;'><strong>Requisitos:</strong></p>
                 <p style='margin:0 0 12px 0;white-space:pre-line;'>{oferta.Requisitos}</p>
                 </div>

                 <div style='padding:0 22px 22px 22px;'>
                 <p style='margin:0 0 12px 0;'>Para continuar, contacta a la empresa:</p>
                 <a href='mailto:{empresa.Correo}?subject=Interés%20en%20{oferta.Puesto.Replace(" ", "%20")}'
                 style='background:#0ea5e9;color:#fff;text-decoration:none;padding:12px 18px;border-radius:8px;display:inline-block;font-weight:600;'>
                 Escribir a {empresa.Correo}
                 </a>
                 <p style='margin:12px 0 0 0;color:#475569;font-size:12px;'>
                 Consejo: envía un correo breve de presentación indicando tu disponibilidad y adjunta tu CV.
                 </p>
                 </div>

                 <div style='background:#f8fafc;padding:14px 22px;color:#475569;font-size:12px;'>
                 — Equipo EmpleaTech
                 </div>
                 </div>
                 <p style='text-align:center;color:#94a3b8;font-size:11px;margin:8px 0 0 0;'>
                 Recibiste este correo por una asignación realizada en EmpleaTech.
                 </p>
                 </body>
                 </html>";

                _mensajeriaRepositorio.EnviarMensaje(
                    persona.Correo,
                    subjectPersona,
                    cuerpoPersonaHtml
                );

                // ====== CORREO A LA EMPRESA (HTML) ======
                var subjectEmpresa = $"Nuevo candidato asignado: {persona.Nombre} para {oferta.Puesto}";
                var cuerpoEmpresaHtml = $@"
                 <html>
                 <body style='font-family:Arial,Helvetica,sans-serif;color:#222;background:#f6f8fb;padding:0;margin:0;'>
                 <div style='max-width:640px;margin:24px auto;background:#fff;border-radius:12px;box-shadow:0 1px 4px rgba(0,0,0,.08);overflow:hidden;'>
                 <div style='background:#0ea5e9;color:#fff;padding:16px 20px;font-size:18px;font-weight:700;'>
                 EmpleaTech • Nuevo Candidato Asignado
                 </div>
                 <div style='padding:22px 22px 8px 22px;font-size:15px;line-height:1.5;'>
                 <p style='margin:0 0 12px 0;'>Hola <strong>{empresa.Nombre}</strong>,</p>
                 <p style='margin:0 0 16px 0;'>Se ha asignado un candidato a su oferta <strong>{oferta.Puesto}</strong>.</p>
                 </div>

                 <div style='padding:0 22px 12px 22px;'>
                 <div style='border:1px solid #e5e7eb;border-radius:10px;overflow:hidden;'>
                 <div style='background:#f8fafc;padding:12px 14px;font-weight:700;'>Datos del candidato</div>
                 <div style='padding:10px 14px;border-top:1px solid #f1f5f9;'><strong>Nombre:</strong> {persona.Nombre}</div>
                 <div style='padding:10px 14px;border-top:1px solid #f1f5f9;'><strong>Cédula:</strong> {persona.Dni}</div>
                 <div style='padding:10px 14px;border-top:1px solid #f1f5f9;'><strong>Correo:</strong> {persona.Correo}</div>
                 <div style='padding:10px 14px;border-top:1px solid #f1f5f9;'><strong>Teléfono:</strong> {persona.Telefono}</div>
                 </div>
                 </div>

                 <div style='padding:0 22px 22px 22px;'>
                 <a href='mailto:{persona.Correo}?subject=Proceso%20{oferta.Puesto.Replace(" ", "%20")}'
                 style='background:#0ea5e9;color:#fff;text-decoration:none;padding:12px 18px;border-radius:8px;display:inline-block;font-weight:600;'>
                 Contactar a {persona.Nombre}
                 </a>
                 <p style='margin:12px 0 0 0;color:#475569;font-size:12px;'>
                 Sugerencia: coordinen una entrevista y soliciten documentación adicional si aplica.
                 </p>
                 </div>

                 <div style='background:#f8fafc;padding:14px 22px;color:#475569;font-size:12px;'>
                 — Equipo EmpleaTech
                 </div>
                 </div>
                 </body>
                 </html>";

                _mensajeriaRepositorio.EnviarMensaje(
                    empresa.Correo,
                    subjectEmpresa,
                    cuerpoEmpresaHtml
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar los correos: {ex.Message}");
            }
        }
    }
}
