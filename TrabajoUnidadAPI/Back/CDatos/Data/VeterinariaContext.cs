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
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

        modelBuilder.Entity<DuenoAnimal>(entity =>
        {
            entity.HasKey(e => e.IdDuenoAnimal)
                .HasName("PK_ID_DUENOANIMAL");

            entity.HasMany(e => e.AnimalAtendido)
                .WithOne(e => e.DuenoAnimal)
                .HasForeignKey("IdDuenoAnimal")
                .IsRequired();
        }
        );
        modelBuilder.Entity<AnimalAtendido>(entity =>
        {
            entity.HasKey(e => e.IdAnimalatendido)
                .HasName("PK_ID_ANIMALATENDIDO");

            entity.HasMany(e => e.Atencion)
                .WithOne(e => e.AnimalAtendido)
                .HasForeignKey("IdAnimalAtendido")
                .IsRequired();
        }
        );
        modelBuilder.Entity<Atencion>(entity =>
        {
            entity.HasKey(e => e.IdAtencion)
                .HasName("PK_ID_ATENCION");

            entity.Property(e => e.FechaAtencion)
                .HasColumnType("datetime");

            entity.HasOne(e => e.AnimalAtendido)
                .WithMany(e => e.Atencion)
                .HasForeignKey("IdAnimalAtendido")
                .IsRequired();

        }
        );

    }
    public override int SaveChanges()
    {
        this.DoCustomEntityPreparations();
        return base.SaveChanges();
    }
    private void DoCustomEntityPreparations()
    {
        var modifiedEntitiesWithTrackDate = this
            .ChangeTracker.Entries()
            .Where(c => c.State == EntityState.Modified);
        foreach (var entityEntry in modifiedEntitiesWithTrackDate)
        {
            if (entityEntry.Properties.Any(c => c.Metadata.Name == "UpdatedDate"))
            {
                entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;
            }
        }
    }

}
