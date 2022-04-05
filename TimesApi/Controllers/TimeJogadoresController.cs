using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimesApi.Models;

namespace TimesApi.Controllers
{
    [Authorize(Roles = "Capitao")]
    [Route("api/[controller]")]
    [ApiController]
    public class TimeJogadoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TimeJogadoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TimeJogadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeJogadores>>> GetTimeJogadores()
        {
            return await _context.TimeJogadores.ToListAsync();
        }

        // GET: api/TimeJogadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeJogadores>> GetTimeJogadores(Guid id)
        {
            var timeJogadores = await _context.TimeJogadores.FindAsync(id);

            if (timeJogadores == null)
            {
                return NotFound();
            }

            return timeJogadores;
        }

        // PUT: api/TimeJogadores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeJogadores(Guid id, TimeJogadores timeJogadores)
        {
            if (id != timeJogadores.Id)
            {
                return BadRequest();
            }

            _context.Entry(timeJogadores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeJogadoresExists(id))
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

        // POST: api/TimeJogadores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TimeJogadores>> PostTimeJogadores(TimeJogadores timeJogadores)
        {
            _context.TimeJogadores.Add(timeJogadores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeJogadores", new { id = timeJogadores.Id }, timeJogadores);
        }

        // DELETE: api/TimeJogadores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeJogadores(Guid id)
        {
            var timeJogadores = await _context.TimeJogadores.FindAsync(id);
            if (timeJogadores == null)
            {
                return NotFound();
            }

            _context.TimeJogadores.Remove(timeJogadores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimeJogadoresExists(Guid id)
        {
            return _context.TimeJogadores.Any(e => e.Id == id);
        }
    }
}
