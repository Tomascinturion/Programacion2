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
        private const string path = "http://localhost:5239/api/AnimalAtendidoes";

        public enum TipoAnimal
        {
            Perro = 0,
            Gato = 1,
            Ave = 2,
            Hamster = 3,

        }

        public async Task CreateAnimalAsync()
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
                nombre = nombre,
                idtipoanimal = tipoAnimal,
                raza = raza,
                edad = int.Parse(edad),
                sexo = sexo,
                dniduenoanimal = int.Parse(dniDueno)
            };
            try
            {
                var json = JsonSerializer.Serialize(crearAnimalAtendidoDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(path, content);
                response.EnsureSuccessStatusCode();

                Console.WriteLine("Animal creado exitosamente!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public async Task<HttpStatusCode> DeleteAnimalAsync()
        {
            try
            {
                Console.WriteLine("Ingrese el id del animal a eliminar:");
                string id = Console.ReadLine();
                HttpResponseMessage response = await client.DeleteAsync(
                   path + $"/{id}");
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return HttpStatusCode.InternalServerError;
            }

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
                idanimalatendido = id,
                nombre = nombre,
                raza = raza,
                edad = edad,
                sexo = sexo
            };

            try
            {
                var json = JsonSerializer.Serialize(editarAnimalAtendidoDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(path + $"/{id}", content);
                response.EnsureSuccessStatusCode();

                Console.WriteLine("Animal modificado exitosamente!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
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
                    Console.WriteLine($"Id: {animal.idAnimalatendido}:" +
                        $"\n   Nombre: {animal.nombre}" +
                        $"\n   Tipo:{animal.tipoAnimal}" +
                        $"\n   Raza: {animal.raza}" +
                        $"\n   Edad: {animal.edad}" +
                        $"\n   Sexo: {animal.sexo}" +
                        $"\n   ID Dueño: {animal.idDueno}" +
                        $"\n   Nombre Dueño: {animal.nombreDueno}"); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


        }
    }
}
