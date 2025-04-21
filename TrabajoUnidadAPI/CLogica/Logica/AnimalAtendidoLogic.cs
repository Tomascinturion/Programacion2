using CLogica.Logica.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.Repositorios.Implementaciones;
using CEntidades.DTOs;
using Microsoft.EntityFrameworkCore;


namespace CLogica.Logica
{
    public class AnimalAtendidoLogic : IAnimalAtendidoLogic
    {
        private IAnimalAtendidoRepository _AnimalAtendidoRepository;

        public AnimalAtendidoLogic(IAnimalAtendidoRepository AnimalAtendidoRepository)
        {
            _AnimalAtendidoRepository = AnimalAtendidoRepository;
        }

        public async Task AltaAnimalAtendido(string nombre, int tipoanimal, string raza, int edad, string sexo, int dnidueno)
        {
       //     var dueno = await _context.DuenoAnimales
       //.FirstOrDefaultAsync(d => d.Dni == dniDueno);

       //     if (dueno == null)
       //     {
       //         throw new Exception("No se encontró un dueño con ese DNI.");
       //     }
            CrearAnimalAtendidoDTO animalagregar = new CrearAnimalAtendidoDTO()
            {
                Nombre = nombre,
                IdTipoAnimal = (CDatos.Entidades.TipoAnimal)tipoanimal,
                Raza = raza,
                Edad = edad,
                Sexo = sexo,
                DniDuenoAnimal = dnidueno
            };
        }
    }
}
