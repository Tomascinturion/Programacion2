using ConsolaTrabajoUnidadAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsolaTrabajoUnidadAPI.Metodos
{
    public class Atenciones
    {
        static HttpClient client = new HttpClient();
        private const string path = "http://localhost:5239/api/Atencions";

        public async Task CrearAtencion()
        {
            Console.WriteLine("Ingrese el id del animal:");
            string idAnimal = Console.ReadLine();
            Console.WriteLine("Ingrese el motivo de la atención:");
            string motivo = Console.ReadLine();
            Console.WriteLine("Ingrese el tratamiento:");
            string tratamiento = Console.ReadLine();
            Console.WriteLine("Ingrese los medicamentos:");
            string medicamentos = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de atención (opcional, presione Enter para omitir):");
            string fechaInput = Console.ReadLine();
            DateTime? fechaAtencion = null;
            if (!string.IsNullOrEmpty(fechaInput))
            {
                if (DateTime.TryParse(fechaInput, out DateTime fecha))
                {
                    fechaAtencion = fecha;
                }
                else
                {
                    Console.WriteLine("Fecha inválida. Se omitirá.");
                }
            }
            CrearAtencionDTO crearAtencionDTO = new CrearAtencionDTO()
            {
                idanimalatendido = int.Parse(idAnimal),
                motivo = motivo,
                tratamiento = tratamiento,
                medicamentos = medicamentos,
                fechaatencion = fechaAtencion
            };
            try
            {
                var json = JsonSerializer.Serialize(crearAtencionDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(path, content);
                response.EnsureSuccessStatusCode();

                Console.WriteLine("Atención creada exitosamente!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
