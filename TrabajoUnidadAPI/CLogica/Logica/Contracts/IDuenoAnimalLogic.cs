using CEntidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica.Logica.Implementaciones
{
    public interface IDuenoAnimalLogic
    {
        public Task CrearDueno(CrearDuenoDTO dto);
        public Task<bool> ModificarDueno(EditarDuenoDTO dto);
        public Task EliminarDueno(int id);
    }
}
