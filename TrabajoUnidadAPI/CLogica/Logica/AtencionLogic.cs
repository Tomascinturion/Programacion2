using CDatos.Entidades;
using CDatos.Repositorios.Implementaciones;
using CEntidades.DTOs;
using CLogica.Logica.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CLogica.Logica
{
    public class AtencionLogic : IAtencionLogic
    {
        private readonly IAtencionRepository _AtencionRepository;
        private readonly IAnimalAtendidoRepository _AnimalAtendidoRepository;

        public AtencionLogic(IAtencionRepository atencionRepository, IAnimalAtendidoRepository animalAtendidoRepository)
        {
            _AtencionRepository = atencionRepository;
            _AnimalAtendidoRepository = animalAtendidoRepository;
        }

        public async Task CrearAtencion(CrearAtencionDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Motivo) ||
                string.IsNullOrWhiteSpace(dto.Tratamiento) ||
                string.IsNullOrWhiteSpace(dto.Medicamentos))
            {
                throw new ArgumentException("Estos campos son obligatorios.");
            }

            var animal = await _AnimalAtendidoRepository.GetById(dto.IdAnimalAtendido);
            if (animal == null)
            {
                throw new ArgumentException("El animal buscado no existe.");
            }

            DateTime fechaatencion = dto.FechaAtencion?.Date ?? DateTime.Today;

            if (fechaatencion < DateTime.Today)
            {
                throw new ArgumentException("La fecha de atención no puede ser menor a la fecha de hoy.");
            }
            if (fechaatencion > (DateTime.Now.AddDays(30)))
            {
                throw new ArgumentException("No se puede registrar una atención con más de 30 días de anticipacion.");
            }

            var atencion = new Atencion
            {
                AnimalAtendido = animal,
                Motivo = dto.Motivo,
                Tratamiento = dto.Tratamiento,
                Medicamentos = dto.Medicamentos,
                FechaAtencion = fechaatencion
            };
            _AtencionRepository.Create(atencion);
            await _AtencionRepository.SaveAsync();
        }
        public async Task<bool> ModificarAtencion(EditarAtencionDTO dto)
        {
            var atencion = await _AtencionRepository.GetById(dto.IdAtencion);
            if (atencion == null)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(dto.Motivo) ||
                string.IsNullOrWhiteSpace(dto.Tratamiento) ||
                string.IsNullOrWhiteSpace(dto.Medicamentos))
            {
                throw new ArgumentException("Estos campos son obligatorios.");
            }
            if (dto.FechaAtencion != null)
            {
                DateTime fechaatencion = dto.FechaAtencion.Value.Date;
                if (fechaatencion < DateTime.Today)
                {
                    throw new ArgumentException("La fecha de atención no puede ser menor a la fecha de hoy.");
                }
                if (fechaatencion > (DateTime.Now.AddDays(30)))
                {
                    throw new ArgumentException("No se puede registrar una atención con más de 30 días de anticipación.");
                }
            }

            atencion.Motivo = dto.Motivo;
            atencion.Tratamiento = dto.Tratamiento;
            atencion.Medicamentos = dto.Medicamentos;
            atencion.FechaAtencion = dto.FechaAtencion ?? atencion.FechaAtencion;

            _AtencionRepository.Update(atencion);
            await _AtencionRepository.SaveAsync();
            return true;
        }
        public async Task EliminarAtencion(int id)
        {
            Atencion? atencion = await _AtencionRepository.GetById(id);
            if (atencion == null)
            {
                throw new ArgumentException("La atención buscada no existe");
            }
            _AtencionRepository.Delete(atencion);
            await _AtencionRepository.SaveAsync();
        }

        public async Task<List<Atencion>> ObtenerAtencionesPorAnimal(int idAnimal)
        {
            var atenciones = await _AtencionRepository.FindAllAsync();
            var atencionesPorAnimal = atenciones.Where(a => a.AnimalAtendido.IdAnimalatendido == idAnimal).ToList();
            return atencionesPorAnimal;
        }
        public async Task<Atencion> ObtenerAtencionPorId(int id)
        {
            var atencion = await _AtencionRepository.GetById(id);
            if (atencion == null)
            {
                throw new ArgumentException("La atención buscada no existe");
            }
            return atencion;
        }
        public async Task<List<Atencion>> ObtenerAtenciones()
        {
            var atenciones = await _AtencionRepository.FindAllAsync();
            return atenciones.ToList();
        }
    }
}
