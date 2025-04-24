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
using CDatos.Repositorios;


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

        public async Task AltaAnimalAsync(CrearAnimalAtendidoDTO dto, DuenoAnimal idDueno)
        {
            try
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
                DuenoAnimal = idDueno
            };
            
            _AnimalAtendidoRepository.Create(animal);
            await _AnimalAtendidoRepository.SaveAsync();

            }
            catch(Exception ex)
            {
                throw new ArgumentException("Error al crear el animal: " + ex.Message);
            }
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
        public async Task<AnimalAtendido> ObtenerAnimalPorId(int id)
        {
            var animal = await _AnimalAtendidoRepository.GetById(id);
            if (animal == null)
            {
                throw new ArgumentException("El animal buscado no existe");
            }
            return animal;
        }
        public async Task<List<AnimalAtendido>> ObtenerAnimales()
        {
            var animales = await _AnimalAtendidoRepository.FindAllAsync();
            return animales.ToList();
        }

    }
}
