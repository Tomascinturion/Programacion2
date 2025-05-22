using System;
using System.Net;
using System.Net.Http.Headers;

class Program
{
    public async Task MenuPrincipal()
    {
        while (true)
        {
            Console.WriteLine("Menu Principal");
            Console.WriteLine("1. Menu Dueño");
            Console.WriteLine("2. Menu Animal");
            Console.WriteLine("3. Menu Atencion");
            Console.WriteLine("4. Salir");
            var opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    // Llamar al menu de dueño
                    break;
                case "2":
                    // Llamar al menu de animal
                    break;
                case "3":
                    // Llamar al menu de atencion
                    break;
                case "4":
                    Console.WriteLine("Saliendo...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }


    }
    public async Task MenuAnimal()
    {
        while (true)
        {
            Console.WriteLine("Menu Animal");
            Console.WriteLine("1. Crear Animal");
            Console.WriteLine("2. Editar Animal");
            Console.WriteLine("3. Eliminar Animal");
            Console.WriteLine("4. Listar Animales");
            Console.WriteLine("5. Volver al Menu Principal");
            var opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    // Llamar al metodo para crear animal
                    break;
                case "2":
                    // Llamar al metodo para editar animal
                    break;
                case "3":
                    // Llamar al metodo para eliminar animal
                    break;
                case "4":
                    // Llamar al metodo para listar animales
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }
    public async Task MenuDueno()
    {
        while (true)
        {
            Console.WriteLine("Menu Dueño");
            Console.WriteLine("1. Crear Dueño");
            Console.WriteLine("2. Voler al Menu Principal");
            var opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    // Llamar al metodo para crear dueño
                    break;
                case "2":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }

    public async Task MenuAtencion()
    {
        while (true)
        {
            Console.WriteLine("Menu Atencion");
            Console.WriteLine("1. Crear Atencion");
            Console.WriteLine("2. Volver al Menu Principal");
            var opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    // Llamar al metodo para crear atencion
                    break;
                case "2":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }

    static HttpClient client = new HttpClient();
    static void ShowAnimal(AnimalAtendido animal)
    {
        Console.WriteLine($"Nombre: {animal.Nombre}\tEspecie: " +
            $"{animal.IdTipoAnimal}\tRaza: {animal.Raza}\tEdad {animal.Edad}\tSexo {animal.Sexo}");
    }
    static async Task<Uri> CreateDuenoAsync(DuenoAnimal dueno)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync(
            "api/DuenoAnimals", dueno);
        response.EnsureSuccessStatusCode();

        // return URI of the created resource.
        return response.Headers.Location;
    }
    static async Task<Uri> CreateAnimalAsync(AnimalAtendido animal)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync(
            "api/AnimalAtendidoes", animal);
        response.EnsureSuccessStatusCode();

        // return URI of the created resource.
        return response.Headers.Location;
    }
    static async Task<AnimalAtendido> GetAnimalAsync(string path)
    {
        AnimalAtendido animal = null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            animal = await response.Content.ReadAsAsync<AnimalAtendido>();
        }
        return animal;
    }

    //static async Task<AnimalAtendido> UpdateAnimalAsync(AnimalAtendido animal)
    //{
    //    HttpResponseMessage response = await client.PutAsJsonAsync(
    //        $"api/products/{product.Id}", product);
    //    response.EnsureSuccessStatusCode();

    //    // Deserialize the updated product from the response body.
    //    product = await response.Content.ReadAsAsync<Product>();
    //    return product;
    //}

    static async Task<HttpStatusCode> DeleteAnimalAsync(string id)
    {
        HttpResponseMessage response = await client.DeleteAsync(
            $"api/products/{id}");
        return response.StatusCode;
    }
    static void Main()
    {
        RunAsync().GetAwaiter().GetResult();
    }

    static async Task RunAsync()
    {
        // Update port # in the following line.
        client.BaseAddress = new Uri("http://localhost:5239/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        try
        {
            //DuenoAnimal dueno = new DuenoAnimal
            //{
            //    Dni = 12345678,
            //    Nombre = "Juan",
            //    Apellido = "Pérez"
            //};
            //var url = await CreateDuenoAsync(dueno);
            //Console.WriteLine($"Created at {url}");

            //AnimalAtendido animal = new AnimalAtendido
            //{
            //    Nombre = "Firulais",
            //    IdTipoAnimal = 0,
            //    Raza = "Labrador",
            //    Edad = 5,
            //    Sexo = "Macho",
            //    DuenoAnimal = dueno,
            //};
            //var urlAnimal = await CreateAnimalAsync(animal);
            // Get the product
            var animal = await GetAnimalAsync("url.api/AnimalAtendidoes");
            if (animal != null)
                ShowAnimal(animal);
            else
                Console.WriteLine("Animal not found.");
            //animal = await GetAnimalAsync("url.api/AnimalAtendidoes");
            //ShowProduct(product)
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.ReadLine();
    }
}



   