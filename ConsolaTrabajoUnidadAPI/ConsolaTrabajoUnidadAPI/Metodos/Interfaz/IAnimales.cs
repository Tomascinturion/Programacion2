using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaTrabajoUnidadAPI.Metodos.Interfaz
{
    public interface IAnimales 
    {
        Task<Uri> CreateAnimalAsync();
        Task UpdateAnimalAsync();
        Task<HttpStatusCode> DeleteAnimalAsync();
        Task GetAnimalAsync();

    }
}
