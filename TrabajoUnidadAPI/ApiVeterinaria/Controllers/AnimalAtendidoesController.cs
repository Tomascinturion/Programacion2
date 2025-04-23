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
using CDatos.Repositorios.Implementaciones;
using CLogica.Logica.Implementaciones;
using CLogica.Logica;

namespace ApiVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalAtendidoesController : ControllerBase
    {
        private readonly IDuenoAnimalRepository _DuenoAnimalRepository;
        private readonly IAnimalAtendidoRepository _AnimalAtendidoRepository;
        private readonly IAnimalAtendidoLogic _AnimalAtendidoLogic;

        public AnimalAtendidoesController(IAnimalAtendidoRepository animalAtendidoRepository, IDuenoAnimalRepository duenoAnimalRepository, IAnimalAtendidoLogic animalAtendidoLogic)
        {
            _AnimalAtendidoRepository = animalAtendidoRepository;
            _DuenoAnimalRepository = duenoAnimalRepository;
            _AnimalAtendidoLogic = animalAtendidoLogic;
        }

        // GET: api/AnimalAtendidoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalAtendido>>> GetAnimalAtendido()
        {
            return await _AnimalAtendidoLogic.ObtenerAnimales();
        }

        // GET: api/AnimalAtendidoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalAtendido>> GetAnimalAtendido(int id)
        {
            var animalAtendido = await _AnimalAtendidoLogic.ObtenerAnimalPorId(id);

            if (animalAtendido == null)
            {
                return NotFound();
            }

            return animalAtendido;
        }

        // PUT: api/AnimalAtendidoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalAtendido([FromBody] EditarAnimalAtendidoDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _AnimalAtendidoLogic.EditarAnimalAsync(dto);

            if (!resultado)
            {
                return NotFound("No se encotro el animal buscado.");
            }
            return Ok("animal modificado correctamente");
        }

        // POST: api/AnimalAtendidoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AltaAnimal([FromBody] CrearAnimalAtendidoDTO dto)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            
            var dueno = await _DuenoAnimalRepository.ObtenerPorDniAsync(dto.DniDuenoAnimal);
            if (dueno == null)
                return NotFound("No se encontró un dueño con ese DNI.");

            
            await _AnimalAtendidoLogic.AltaAnimalAsync(dto, dueno.IdDuenoAnimal);

            
            return Ok("Animal registrado correctamente.");
        }

        // DELETE: api/AnimalAtendidoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalAtendido(int id)
        {
            try
            {
                await _AnimalAtendidoLogic.EliminarAnimal(id);
                return Ok("Animal eliminado correctamente.");
            }
            catch (ArgumentException ex)
            {
                return NotFound("No se encontro el animal indicado.");
            }
        }

    }
}
