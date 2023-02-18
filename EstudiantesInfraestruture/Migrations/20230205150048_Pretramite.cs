using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudiantesInfraestruture.Migrations
{
    public partial class Pretramite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tramitacion_Estudiante_EstudianteId",
                schema: "GE",
                table: "Tramitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Tramitacion_Persona_PersonaId",
                schema: "GE",
                table: "Tramitacion");

            migrationBuilder.DropIndex(
                name: "IX_Tramitacion_EstudianteId",
                schema: "GE",
                table: "Tramitacion");

            migrationBuilder.DropIndex(
                name: "IX_Tramitacion_PersonaId",
                schema: "GE",
                table: "Tramitacion");

            migrationBuilder.DropColumn(
                name: "EstudianteId",
                schema: "GE",
                table: "Tramitacion");

            migrationBuilder.DropColumn(
                name: "Fecha",
                schema: "GE",
                table: "Tramitacion");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                schema: "GE",
                table: "Tramitacion");

            migrationBuilder.CreateTable(
                name: "Pretramite",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Documento = table.Column<string>(maxLength: 20, nullable: true),
                    NombreTramite = table.Column<string>(nullable: true),
                    PersonaId = table.Column<int>(nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pretramite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pretramite_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalSchema: "GE",
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoTramite",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    Activo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTramite", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pretramite_PersonaId",
                table: "Pretramite",
                column: "PersonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pretramite");

            migrationBuilder.DropTable(
                name: "TipoTramite");

            migrationBuilder.AddColumn<int>(
                name: "EstudianteId",
                schema: "GE",
                table: "Tramitacion",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                schema: "GE",
                table: "Tramitacion",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                schema: "GE",
                table: "Tramitacion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tramitacion_EstudianteId",
                schema: "GE",
                table: "Tramitacion",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tramitacion_PersonaId",
                schema: "GE",
                table: "Tramitacion",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tramitacion_Estudiante_EstudianteId",
                schema: "GE",
                table: "Tramitacion",
                column: "EstudianteId",
                principalSchema: "GE",
                principalTable: "Estudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tramitacion_Persona_PersonaId",
                schema: "GE",
                table: "Tramitacion",
                column: "PersonaId",
                principalSchema: "GE",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
