using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudiantesInfraestruture.Migrations
{
    public partial class TablaNotas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notas",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nota1 = table.Column<decimal>(nullable: false),
                    Nota2 = table.Column<decimal>(nullable: false),
                    Nota3 = table.Column<decimal>(nullable: false),
                    MateriaId = table.Column<int>(nullable: true),
                    EstudianteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notas_Estudiante_EstudianteId",
                        column: x => x.EstudianteId,
                        principalSchema: "GE",
                        principalTable: "Estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notas_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalSchema: "GE",
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notas_EstudianteId",
                schema: "GE",
                table: "Notas",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_MateriaId",
                schema: "GE",
                table: "Notas",
                column: "MateriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notas",
                schema: "GE");
        }
    }
}
