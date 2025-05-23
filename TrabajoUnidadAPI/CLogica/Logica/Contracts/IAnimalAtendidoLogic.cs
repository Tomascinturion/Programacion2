using CDatos.Entidades;
using CEntidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica.Logica.Implementaciones
{
    public interface IAnimalAtendidoLogic
    {
        public Task AltaAnimalAsync(CrearAnimalAtendidoDTO dto, DuenoAnimal idDueno);

        public Task<bool> EditarAnimalAsync(EditarAnimalAtendidoDTO dto);
        public Task EliminarAnimal(int id);
        public Task<AnimalAtendido> ObtenerAnimalPorId(int id);
        Task<List<LeerAnimalAtendidoDTO>> ObtenerAnimalesDTO();
    }
}
