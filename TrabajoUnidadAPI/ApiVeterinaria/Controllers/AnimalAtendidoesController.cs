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
    public class AnimalAtendidoesController : ControllerBase
    {
        private readonly VeterinariaContext _context;

        public AnimalAtendidoesController(VeterinariaContext context)
        {
            _context = context;
        }

        // GET: api/AnimalAtendidoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalAtendido>>> GetAnimalAtendido()
        {
            return await _context.AnimalAtendido.ToListAsync();
        }

        // GET: api/AnimalAtendidoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalAtendido>> GetAnimalAtendido(int id)
        {
            var animalAtendido = await _context.AnimalAtendido.FindAsync(id);

            if (animalAtendido == null)
            {
                return NotFound();
            }

            return animalAtendido;
        }

        // PUT: api/AnimalAtendidoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalAtendido(int id, AnimalAtendido animalAtendido)
        {
            if (id != animalAtendido.IdAnimalatendido)
            {
                return BadRequest();
            }

            _context.Entry(animalAtendido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalAtendidoExists(id))
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

        // POST: api/AnimalAtendidoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimalAtendido>> PostAnimalAtendido(AnimalAtendido animalAtendido)
        {
            _context.AnimalAtendido.Add(animalAtendido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimalAtendido", new { id = animalAtendido.IdAnimalatendido }, animalAtendido);
        }

        // DELETE: api/AnimalAtendidoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalAtendido(int id)
        {
            var animalAtendido = await _context.AnimalAtendido.FindAsync(id);
            if (animalAtendido == null)
            {
                return NotFound();
            }

            _context.AnimalAtendido.Remove(animalAtendido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalAtendidoExists(int id)
        {
            return _context.AnimalAtendido.Any(e => e.IdAnimalatendido == id);
        }
    }
}
