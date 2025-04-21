using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDatos.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuenoAnimal",
                columns: table => new
                {
                    IdDuenoAnimal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_DUENOANIMAL", x => x.IdDuenoAnimal);
                });

            migrationBuilder.CreateTable(
                name: "AnimalAtendido",
                columns: table => new
                {
                    IdAnimalatendido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoAnimal = table.Column<int>(type: "int", nullable: false),
                    Raza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDuenoAnimal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_ANIMALATENDIDO", x => x.IdAnimalatendido);
                    table.ForeignKey(
                        name: "FK_AnimalAtendido_DuenoAnimal_IdDuenoAnimal",
                        column: x => x.IdDuenoAnimal,
                        principalTable: "DuenoAnimal",
                        principalColumn: "IdDuenoAnimal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atencion",
                columns: table => new
                {
                    IdAtencion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAnimalAtendido = table.Column<int>(type: "int", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tratamiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medicamentos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAtencion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_ATENCION", x => x.IdAtencion);
                    table.ForeignKey(
                        name: "FK_Atencion_AnimalAtendido_IdAnimalAtendido",
                        column: x => x.IdAnimalAtendido,
                        principalTable: "AnimalAtendido",
                        principalColumn: "IdAnimalatendido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalAtendido_IdDuenoAnimal",
                table: "AnimalAtendido",
                column: "IdDuenoAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_Atencion_IdAnimalAtendido",
                table: "Atencion",
                column: "IdAnimalAtendido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atencion");

            migrationBuilder.DropTable(
                name: "AnimalAtendido");

            migrationBuilder.DropTable(
                name: "DuenoAnimal");
        }
    }
}
