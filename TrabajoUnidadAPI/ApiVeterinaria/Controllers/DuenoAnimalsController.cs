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
    public class DuenoAnimalsController : ControllerBase
    {
        private readonly VeterinariaContext _context;

        public DuenoAnimalsController(VeterinariaContext context)
        {
            _context = context;
        }

        // GET: api/DuenoAnimals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DuenoAnimal>>> GetDuenoAnimal()
        {
            return await _context.DuenoAnimal.ToListAsync();
        }

        // GET: api/DuenoAnimals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DuenoAnimal>> GetDuenoAnimal(int id)
        {
            var duenoAnimal = await _context.DuenoAnimal.FindAsync(id);

            if (duenoAnimal == null)
            {
                return NotFound();
            }

            return duenoAnimal;
        }

        // PUT: api/DuenoAnimals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDuenoAnimal(int id, DuenoAnimal duenoAnimal)
        {
            if (id != duenoAnimal.IdDuenoAnimal)
            {
                return BadRequest();
            }

            _context.Entry(duenoAnimal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DuenoAnimalExists(id))
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

        // POST: api/DuenoAnimals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DuenoAnimal>> PostDuenoAnimal(DuenoAnimal duenoAnimal)
        {
            _context.DuenoAnimal.Add(duenoAnimal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDuenoAnimal", new { id = duenoAnimal.IdDuenoAnimal }, duenoAnimal);
        }

        // DELETE: api/DuenoAnimals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDuenoAnimal(int id)
        {
            var duenoAnimal = await _context.DuenoAnimal.FindAsync(id);
            if (duenoAnimal == null)
            {
                return NotFound();
            }

            _context.DuenoAnimal.Remove(duenoAnimal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DuenoAnimalExists(int id)
        {
            return _context.DuenoAnimal.Any(e => e.IdDuenoAnimal == id);
        }
    }
}
