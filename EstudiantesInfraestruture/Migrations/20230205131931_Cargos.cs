using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudiantesInfraestruture.Migrations
{
    public partial class Cargos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargo",
                schema: "GE",
                table: "Persona");

            migrationBuilder.AddColumn<int>(
                name: "CargoId",
                schema: "GE",
                table: "Persona",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Salario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persona_CargoId",
                schema: "GE",
                table: "Persona",
                column: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Cargos_CargoId",
                schema: "GE",
                table: "Persona",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Cargos_CargoId",
                schema: "GE",
                table: "Persona");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropIndex(
                name: "IX_Persona_CargoId",
                schema: "GE",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "CargoId",
                schema: "GE",
                table: "Persona");

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                schema: "GE",
                table: "Persona",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }
    }
}
