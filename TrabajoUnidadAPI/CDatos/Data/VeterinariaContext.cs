using CDatos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class VeterinariaContext : DbContext
{
    public VeterinariaContext(DbContextOptions<VeterinariaContext> options)
        : base(options)
    {
    }

    public DbSet<AnimalAtendido> AnimalAtendido { get; set; } = null!;
    public DbSet<Atencion> Atencion { get; set;} = null!;
    public DbSet<DuenoAnimal> DuenoAnimal { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=VeterinariaProg;Integrated Security=True;TrustServerCertificate=true;");
    }


}
