using CDatos.Repositorios;
using CDatos.Repositorios.Implementaciones;
using CLogica.Logica;
using CLogica.Logica.Implementaciones;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VeterinariaContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAnimalAtendidoRepository, AnimalAtendidoRepository>();
builder.Services.AddScoped<IAtencionRepository, AtencionRepository>();
builder.Services.AddScoped<IDuenoAnimalRepository, DuenoAnimalRepository>();
builder.Services.AddScoped<IAnimalAtendidoLogic, AnimalAtendidoLogic>();
builder.Services.AddScoped<IAtencionLogic, AtencionLogic>();
builder.Services.AddScoped<IDuenoAnimalLogic, DuenoAnimalLogic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
