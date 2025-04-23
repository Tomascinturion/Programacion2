using CDatos.Entidades;
using CDatos.Repositorios;
using CDatos.Repositorios.Implementaciones;
using CEntidades.DTOs;
using CLogica.Logica.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica.Logica
{
    public class DuenoAnimalLogic : IDuenoAnimalLogic
    {
        private IDuenoAnimalRepository _DuenoAnimalRepository;
        public DuenoAnimalLogic(IDuenoAnimalRepository DuenoAnimalRepository)
        {
            _DuenoAnimalRepository = DuenoAnimalRepository;
        }
        public async Task CrearDueno(CrearDuenoDTO dto)
        {
            var dueno = new DuenoAnimal
            {
                Dni = dto.dni,
                Nombre = dto.nombre,
                Apellido = dto.apellido
            };

            _DuenoAnimalRepository.Create(dueno);
            await _DuenoAnimalRepository.SaveAsync();
        }

        public async Task<bool> ModificarDueno(EditarDuenoDTO dto)
        {
            var dueno = await _DuenoAnimalRepository.GetById(dto.IdDuenoAnimal);
            if (dueno == null)
            {
                return false;
            }

            dueno.Nombre = dto.Nombre;
            dueno.Apellido = dto.Apellido;

            _DuenoAnimalRepository.Update(dueno);
            await _DuenoAnimalRepository.SaveAsync();
            return true;
        }

        public async Task EliminarDueno(int id)
        {
            var dueno = await _DuenoAnimalRepository.GetById(id);
            if (dueno == null)
            {
                return;
            }

            _DuenoAnimalRepository.Delete(dueno);
            await _DuenoAnimalRepository.SaveAsync();
        }
        public async Task<DuenoAnimal> ObtenerDuenoPorId(int id)
        {
            var atencion = await _DuenoAnimalRepository.GetById(id);
            if (atencion == null)
            {
                throw new ArgumentException("La persona buscada no existe");
            }
            return atencion;
        }
        public async Task<List<DuenoAnimal>> ObtenerDuenos()
        {
            var atenciones = await _DuenoAnimalRepository.FindAllAsync();
            return atenciones.ToList();
        }
    }
}
