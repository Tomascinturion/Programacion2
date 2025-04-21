using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CDatos.Entidades;
using TodoApi.Models;

namespace ApiVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtencionsController : ControllerBase
    {
        private readonly VeterinariaContext _context;

        public AtencionsController(VeterinariaContext context)
        {
            _context = context;
        }

        // GET: api/Atencions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atencion>>> GetAtencion()
        {
            return await _context.Atencion.ToListAsync();
        }

        // GET: api/Atencions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Atencion>> GetAtencion(int id)
        {
            var atencion = await _context.Atencion.FindAsync(id);

            if (atencion == null)
            {
                return NotFound();
            }

            return atencion;
        }

        // PUT: api/Atencions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtencion(int id, Atencion atencion)
        {
            if (id != atencion.IdAtencion)
            {
                return BadRequest();
            }

            _context.Entry(atencion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtencionExists(id))
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

        // POST: api/Atencions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Atencion>> PostAtencion(Atencion atencion)
        {
            _context.Atencion.Add(atencion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtencion", new { id = atencion.IdAtencion }, atencion);
        }

        // DELETE: api/Atencions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtencion(int id)
        {
            var atencion = await _context.Atencion.FindAsync(id);
            if (atencion == null)
            {
                return NotFound();
            }

            _context.Atencion.Remove(atencion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AtencionExists(int id)
        {
            return _context.Atencion.Any(e => e.IdAtencion == id);
        }
    }
}
