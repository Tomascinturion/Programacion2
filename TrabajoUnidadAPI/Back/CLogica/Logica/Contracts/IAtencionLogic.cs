using CDatos.Entidades;
using CEntidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica.Logica.Implementaciones
{
    public interface IAtencionLogic
    {
        public Task CrearAtencion(CrearAtencionDTO dto);
        public Task<bool> ModificarAtencion(EditarAtencionDTO dto);
        public Task EliminarAtencion(int id);
        public Task<List<Atencion>> ObtenerAtencionesPorAnimal(int idAnimal);
        public Task<Atencion> ObtenerAtencionPorId(int id);
        public Task<List<Atencion>> ObtenerAtenciones();
    }
}
