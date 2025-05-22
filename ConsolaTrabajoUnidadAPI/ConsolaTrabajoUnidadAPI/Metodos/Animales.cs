using ConsolaTrabajoUnidadAPI.DTOs;
using ConsolaTrabajoUnidadAPI.Metodos.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsolaTrabajoUnidadAPI.Metodos
{
    public class Animales : IAnimales
    {

        static HttpClient client = new HttpClient();
        private const string path = "https://localhost:5239/api/AnimalAtendidoes";

        public enum TipoAnimal
        {
            Perro = 0,
            Gato = 1,
            Ave = 2,
            Hamster = 3,

        }

        public async Task<Uri> CreateAnimalAsync()
        {
            Console.WriteLine("Ingrese el nombre del animal:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la especie del animal, 0 = Perro, 1 = Gato, 2 = Ave, 3 = Hamster:");
            var especie = Console.ReadLine();
            int tipoAnimalInt = int.Parse(especie);
            TipoAnimal tipoAnimal = (TipoAnimal)tipoAnimalInt;
            Console.WriteLine("Ingrese la raza del animal:");
            string raza = Console.ReadLine();
            Console.WriteLine("Ingrese la edad del animal:");
            string edad = Console.ReadLine();
            Console.WriteLine("Ingrese el sexo del animal:");
            string sexo = Console.ReadLine();
            Console.WriteLine("Ingrese el dni del dueño del animal:");
            string dniDueno = Console.ReadLine();
            CrearAnimalAtendidoDTO crearAnimalAtendidoDTO = new CrearAnimalAtendidoDTO()
            {
                Nombre = nombre,
                IdTipoAnimal = tipoAnimal,
                Raza = raza,
                Edad = int.Parse(edad),
                Sexo = sexo,
                DniDuenoAnimal = int.Parse(dniDueno)
            };
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/AnimalAtendidoes", crearAnimalAtendidoDTO);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }
        public async Task<HttpStatusCode> DeleteAnimalAsync()
        {
            Console.WriteLine("Ingrese el id del animal a eliminar:");
            string id = Console.ReadLine();
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/AnimalAtendidoes/{id}");
            return response.StatusCode;
        }
        public async Task UpdateAnimalAsync()
        {
            Console.WriteLine("Ingrese el id del animal a modificar:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre del animal:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la raza del animal:");
            string raza = Console.ReadLine();
            Console.WriteLine("ingrese la edad del animal:");
            int edad = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el sexo del animal:");
            string sexo = Console.ReadLine();
            EditarAnimalAtendidoDTO editarAnimalAtendidoDTO = new EditarAnimalAtendidoDTO()
            {
                IdAnimalAtendido = id,
                Nombre = nombre,
                Raza = raza,
                Edad = edad,
                Sexo = sexo
            };

            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/AnimalAtendidoes/{id}", editarAnimalAtendidoDTO);
            response.EnsureSuccessStatusCode();

            //// Deserialize the updated product from the response body.
            //editarAnimalAtendidoDTO = await response.Content.ReadAsAsync<EditarAnimalAtendidoDTO>();
            //return editarAnimalAtendidoDTO;
        }
        public async Task GetAnimalAsync()
        {

            try
            {
                var response = await client.GetAsync(path);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var animales = JsonSerializer.Deserialize<LecturaAnimalDTO[]>(content);

                foreach (var animal in animales)
                {
                    Console.WriteLine($"Id: {animal.IdAnimalatendido}:" +
                        $"\n   Nombre: {animal.Nombre}" +
                        $"\n   Tipo:{animal.IdTipoAnimal}" +
                        $"\n   Raza: {animal.Raza}" +
                        $"\n   Edad: {animal.Edad}" +
                        $"\n   Sexo: {animal.Sexo}" +
                        $"\n   Dueño: {animal.DniDuenoAnimal}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


        }
    }
}
