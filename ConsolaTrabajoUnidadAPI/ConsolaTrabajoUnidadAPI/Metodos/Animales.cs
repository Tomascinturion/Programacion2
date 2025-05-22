using ConsolaTrabajoUnidadAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaTrabajoUnidadAPI.Metodos
{
    public class Animales
    {

        static HttpClient client = new HttpClient();
        Console.Writeline("Ingrese el nombre del animal:");
        string nombre = Console.ReadLine();
        Console.Writeline("Ingrese el tipo de animal:");
        string tipoAnimal = Console.ReadLine();
        static async Task<Uri> CreateAnimalAsync(CrearAnimalAtendidoDTO)
        {

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/AnimalAtendidoes", animal);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }
    }
}
