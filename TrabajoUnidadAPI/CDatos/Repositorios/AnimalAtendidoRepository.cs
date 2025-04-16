using CDatos.Entidades;
using CDatos.Repositorios.Implementaciones;
using TodoApi.Models;

namespace CDatos.Repositorios
{
    public class AnimalAtendidoRepository : Repository<AnimalAtendido>, IAnimalAtendidoRepository
    {
        public AnimalAtendidoRepository(VeterinariaContext context) : base(context) { }
    }
}
