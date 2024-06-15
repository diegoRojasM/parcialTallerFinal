using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SPA.ServicesApp;
using Examen3.ServiceApp3;

namespace Examen3.ServiceApp3
{
    [ApiController]
    [Route("evento")]
    public class EventoController : ControllerBase
    {
        private readonly EventoService _service;

        public EventoController(EventoService eventoService)
        {
            _service = eventoService;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Evento> GetById(int id)
        {
            var evento = _service.GetById(id);

            if (evento == null)
                return NotFound();

            return evento;
        }

        [HttpPost("participantes")]
        public IActionResult CreateParaParticipantes(Evento evento)
        {
            var newEvento = _service.CreateParaParticipantes(evento);
            return CreatedAtAction(nameof(GetById), new { id = newEvento.Id }, newEvento);
        }

        [HttpPost("equipos")]
        public IActionResult CreateParaEquipos(Evento evento)
        {
            var newEvento = _service.CreateParaEquipos(evento);
            return CreatedAtAction(nameof(GetById), new { id = newEvento.Id }, newEvento);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Evento evento)
        {
            if (id != evento.Id)
                return BadRequest();

            var eventoToUpdate = _service.GetById(id);
            if (eventoToUpdate != null)
            {
                _service.Update(id, evento);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eventoToDelete = _service.GetById(id);
            if (eventoToDelete != null)
            {
                _service.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("{eventoId}/participantes")]
        public IActionResult AddParticipante(int eventoId, Participante participante)
        {
            var evento = _service.GetById(eventoId);
            if (evento == null || evento.Tipo != "Participantes")
                return BadRequest("Evento no encontrado o no es del tipo Participantes");

            _service.AddParticipante(eventoId, participante);
            return NoContent();
        }

        [HttpPost("{eventoId}/equipos")]
        public IActionResult AddEquipo(int eventoId, Equipo equipo)
        {
            var evento = _service.GetById(eventoId);
            if (evento == null || evento.Tipo != "Equipos")
                return BadRequest("Evento no encontrado o no es del tipo Equipos");

            _service.AddEquipo(eventoId, equipo);
            return NoContent();
        }
    }
}
