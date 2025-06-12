using CDatos.Entidades;
using CDatos.Repositorios.Implementaciones;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace CDatos.Repositorios
{
    public class AnimalAtendidoRepository : Repository<AnimalAtendido>, IAnimalAtendidoRepository
    {
        public AnimalAtendidoRepository(VeterinariaContext context) : base(context) { }

        public async Task<List<AnimalAtendido>> ObtenerAnimalesConDuenoAsync()
        {
            return await _context.AnimalAtendido
                .Include(a => a.DuenoAnimal)
                .ToListAsync();
        }

    }
}
