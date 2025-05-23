using ConsolaTrabajoUnidadAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsolaTrabajoUnidadAPI.Metodos
{
    public class Duenos
    {
        static HttpClient client = new HttpClient();
        private const string path = "http://localhost:5239/api/DuenoAnimals";
        public async Task CreateDuenoAsync()
        {
            Console.WriteLine("Ingrese el dni del dueño:");
            string dni = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del dueño:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido del dueño:");
            string apellido = Console.ReadLine();
            CrearDuenoDTO crearDuenoDTO = new CrearDuenoDTO()
            {
                dni = int.Parse(dni),
                nombre = nombre,
                apellido = apellido
            };
            try
            {
                var json = JsonSerializer.Serialize(crearDuenoDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(path, content);
                response.EnsureSuccessStatusCode();

                Console.WriteLine("Dueño creado exitosamente!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
