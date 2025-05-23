﻿using CDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.Repositorios.Implementaciones
{
    public interface IDuenoAnimalRepository : IRepository<DuenoAnimal>
    {
        Task<DuenoAnimal> ObtenerPorDniAsync(int dni);
    }
}
