using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CDatos.Entidades;
using TodoApi.Models;
using CEntidades.DTOs;
using CLogica.Logica.Implementaciones;
using CLogica.Logica;

namespace ApiVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuenoAnimalsController : ControllerBase
    {
        private readonly IDuenoAnimalLogic _duenoAnimalLogic;

        public DuenoAnimalsController(IDuenoAnimalLogic duenoAnimalLogic)
        {
            _duenoAnimalLogic = duenoAnimalLogic;
        }

        //// GET: api/DuenoAnimals
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<DuenoAnimal>>> GetDuenoAnimal()
        //{
        //    return await _context.DuenoAnimal.ToListAsync();
        //}

        //// GET: api/DuenoAnimals/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<DuenoAnimal>> GetDuenoAnimal(int id)
        //{
        //    var duenoAnimal = await _context.DuenoAnimal.FindAsync(id);

        //    if (duenoAnimal == null)
        //    {
        //        return NotFound();
        //    }

        //    return duenoAnimal;
        //}

        // PUT: api/DuenoAnimals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDuenoAnimal([FromBody] EditarDuenoDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var duenoAnimal = await _duenoAnimalLogic.ModificarDueno(dto);
            if(!duenoAnimal)
            {
                return NotFound("No se encontró el dueño del animal indicado.");
            }
            return Ok("Dueño modificado correctamente.");
        }

        // POST: api/DuenoAnimals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> DuenoAnimal([FromBody] CrearDuenoDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _duenoAnimalLogic.CrearDueno(dto);
            return Ok("Dueño creado correctamente.");

        }  

        // DELETE: api/DuenoAnimals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDuenoAnimal(int id)
        {
            try
            {
                await _duenoAnimalLogic.EliminarDueno(id);
                return Ok("Dueño eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return NotFound("No se encontró el dueño del animal indicado.");
            }
        }

        //private bool DuenoAnimalExists(int id)
        //{
        //    return _context.DuenoAnimal.Any(e => e.IdDuenoAnimal == id);
        //}
    }
}
