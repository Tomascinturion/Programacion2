using CDatos.Entidades;
using CDatos.Repositorios.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Models;

namespace CDatos.Repositorios
{
    public class DuenoAnimalRepository : Repository<DuenoAnimal>, IDuenoAnimalRepository
    {
        public DuenoAnimalRepository(VeterinariaContext context) : base(context) { }
    }
}
