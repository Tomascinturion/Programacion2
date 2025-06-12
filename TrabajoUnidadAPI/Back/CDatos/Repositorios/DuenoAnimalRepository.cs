using CDatos.Entidades;
using CDatos.Repositorios.Implementaciones;
using Microsoft.EntityFrameworkCore;
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
        private readonly VeterinariaContext _context;
        public DuenoAnimalRepository(VeterinariaContext context) : base(context) 
        {
            _context = context;
        }


        public async Task<DuenoAnimal> ObtenerPorDniAsync(int dni)
        {
            return await _context.DuenoAnimal.FirstOrDefaultAsync(d => d.Dni == dni);
        }
    }
}
