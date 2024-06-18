using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen3.ServiceApp;

namespace Examen3.Controllers
{
    [ApiController]
    [Route("eventos")]
    public class EventosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Eventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
        {
            return await _context.Eventos.ToListAsync();
        }

        // GET: api/Eventos/5
[HttpGet("{id}")]
public async Task<IActionResult> GetEvento(int id, bool incluirParticipantes = false)
{
    if (id <= 0)
    {
        return BadRequest(new { message = "ID de evento no válido" });
    }

    Evento evento;

    if (incluirParticipantes)
    {
        evento = await _context.Eventos
                               .Include(x => x.Participantes)
                               .FirstOrDefaultAsync(x => x.Id == id);
    }
    else
    {
        evento = await _context.Eventos.FindAsync(id);
    }

    if (evento == null)
    {
        return NotFound(new { message = "Evento no encontrado" });
    }

    return Ok(evento);
}


        private async Task CrearOEditarParticipantes(List<Participante> participantes)
        {
            // Separa las participantes en dos listas: las que necesitan ser creadas y las que necesitan ser editadas
            List<Participante> participantesACrear = participantes.Where(x => x.Id == 0).ToList();
            List<Participante> participantesAEditar = participantes.Where(x => x.Id != 0).ToList();

            if (participantesACrear.Any())
            {
                await _context.AddRangeAsync(participantesACrear);
            }
            if (participantesAEditar.Any())
            {
                _context.UpdateRange(participantesAEditar);
            }
        }




        // PUT: api/Eventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, Evento evento)
        {
            if (id != evento.Id)
            {
                return BadRequest();
            }

            _context.Entry(evento).State = EntityState.Modified;

            try
            {
                await CrearOEditarParticipantes(evento.Participantes);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Eventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvento", new { id = evento.Id }, evento);
        }

        // DELETE: api/Eventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}
