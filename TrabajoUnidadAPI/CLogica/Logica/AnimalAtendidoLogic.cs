using CLogica.Logica.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.Repositorios.Implementaciones;
using CEntidades.DTOs;
using Microsoft.EntityFrameworkCore;
using CDatos.Entidades;


namespace CLogica.Logica
{
    public class AnimalAtendidoLogic : IAnimalAtendidoLogic
    {
        private IAnimalAtendidoRepository _AnimalAtendidoRepository;
        private IDuenoAnimalRepository _DuenoAnimalRepository;

        public AnimalAtendidoLogic(IAnimalAtendidoRepository AnimalAtendidoRepository, IDuenoAnimalRepository DuenoAnimalRepository)
        {
            _AnimalAtendidoRepository = AnimalAtendidoRepository;
            _DuenoAnimalRepository = DuenoAnimalRepository;
        }

        public async Task AltaAnimalAsync(CrearAnimalAtendidoDTO dto, int idDueno)
        {
            if (dto.Edad < 0)
            {
                throw new ArgumentException("La edad no puede ser negativa.");
            }
            var animal = new AnimalAtendido
            {
                Nombre = dto.Nombre,
                IdTipoAnimal = dto.IdTipoAnimal,
                Raza = dto.Raza,
                Edad = dto.Edad,
                Sexo = dto.Sexo,
                DuenoAnimal = new DuenoAnimal { IdDuenoAnimal = idDueno }
            };
            
            _AnimalAtendidoRepository.Create(animal);
            await _AnimalAtendidoRepository.SaveAsync();
        }

        public async Task<bool> EditarAnimalAsync(EditarAnimalAtendidoDTO dto)
        {
            var animal = await _AnimalAtendidoRepository.GetById(dto.IdAnimalAtendido);
            if (animal == null)
            {
                return false;
            }

            if (dto.Edad < 0)
            {
                throw new ArgumentException("La edad no puede ser negativa.");
            }

            animal.Edad = dto.Edad;
            animal.Raza = dto.Raza;
            animal.Nombre = dto.Nombre;
            animal.Sexo = dto.Sexo;

            _AnimalAtendidoRepository.Update(animal);
            await _AnimalAtendidoRepository.SaveAsync();
            return true;
        }

        public async Task EliminarAnimal(int id)
        {
            AnimalAtendido? animal = await _AnimalAtendidoRepository.GetById(id);
            if (animal == null)
            {
                throw new ArgumentException("El animal buscado no existe");
            }
            _AnimalAtendidoRepository.Delete(animal);
            await _AnimalAtendidoRepository.SaveAsync();
        }
        
    }
}
