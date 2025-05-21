using System.Net.Http.Headers;

public class DuenoAnimal
{
    public int IdDuenoAnimal { get; set; }
    public int Dni { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public ICollection<AnimalAtendido> AnimalAtendido { get; set; }
}
public class AnimalAtendido
{
    public int IdAnimalatendido { get; set; }
    public string Nombre { get; set; }
    public TipoAnimal IdTipoAnimal { get; set; }
    public string Raza { get; set; }
    public int Edad { get; set; }
    public string Sexo { get; set; }
    public DuenoAnimal DuenoAnimal { get; set; }
    public ICollection<Atencion> Atencion { get; set; }

}
public class Atencion
{
    public int IdAtencion { get; set; }
    public AnimalAtendido AnimalAtendido { get; set; }
    public string Motivo { get; set; }
    public string Tratamiento { get; set; }
    public string Medicamentos { get; set; }
    public DateTime? FechaAtencion { get; set; }
}
public enum TipoAnimal
{
    Perro = 0,
    Gato = 1,
    Ave = 2,
    Hamster = 3,

}

class Program
{
    static HttpClient client = new HttpClient();
    static void ShowDueno(DuenoAnimal dueno)
    {
        Console.WriteLine($"Dni: {dueno.Dni}\tNombre: " +
            $"{dueno.Nombre}\tApellido: {dueno.Apellido}");
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
            DuenoAnimal dueno = new DuenoAnimal
            {
                Dni = 12345678,
                Nombre = "Juan",
                Apellido = "Pérez"
            };
            //var url = await CreateDuenoAsync(dueno);
            //Console.WriteLine($"Created at {url}");

            AnimalAtendido animal = new AnimalAtendido
            {
                Nombre = "Firulais",
                IdTipoAnimal = 0,
                Raza = "Labrador",
                Edad = 5,
                Sexo = "Macho",
                DuenoAnimal = dueno,
            };
            var urlAnimal = await CreateAnimalAsync(animal);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.ReadLine();
    }
}




   