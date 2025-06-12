using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CDatos.Entidades;
using TodoApi.Models;
using CLogica.Logica.Implementaciones;
using CEntidades.DTOs;

namespace ApiVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtencionsController : ControllerBase
    {
        private readonly IAtencionLogic _AtencionLogic;

        public AtencionsController(IAtencionLogic atencionLogic)
        {
            _AtencionLogic = atencionLogic;
        }

        //GET: api/Atencions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atencion>>> GetAtencion()
        {
            return await _AtencionLogic.ObtenerAtenciones();
        }

        // GET: api/Atencions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Atencion>> GetAtencion(int id)
        {
            var atencion = await _AtencionLogic.ObtenerAtencionPorId(id);

            if (atencion == null)
            {
                return NotFound();
            }

            return Ok(atencion);
        }

        // PUT: api/Atencions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtencion([FromBody] EditarAtencionDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var atencion = await _AtencionLogic.ModificarAtencion(dto);
            if (!atencion)
            {
                return NotFound("No se encontró la atención indicada.");
            }
            return Ok("Atencion modificada correctamente.");
        }

        // POST: api/Atencions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostAtencion([FromBody] CrearAtencionDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _AtencionLogic.CrearAtencion(dto);
                return Ok("Atención creada correctamente.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest("Error en los campos ingresados.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);

            }
        }
        // DELETE: api/Atencions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtencion(int id)
        {
            try
            {
                await _AtencionLogic.EliminarAtencion(id);
                return Ok("Atención eliminada correctamente.");
            }
            catch (ArgumentException ex)
            {
                return NotFound("No se encontro la atención a eliminar.");
            }
        }
    }
}
