using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudiantesInfraestruture.Migrations
{
    public partial class Tramites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    Apellido = table.Column<string>(maxLength: 200, nullable: false),
                    Documento = table.Column<string>(maxLength: 20, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<string>(maxLength: 1, nullable: false),
                    Direccion = table.Column<string>(maxLength: 500, nullable: false),
                    Telefono = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    FechaIngreso = table.Column<DateTime>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    FechaEgreso = table.Column<DateTime>(nullable: false),
                    FechaRetiro = table.Column<DateTime>(nullable: false),
                    TipoDocumentoId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false),
                    Cargo = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_EstadoEstudiante_EstadoId",
                        column: x => x.EstadoId,
                        principalSchema: "GE",
                        principalTable: "EstadoEstudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_TipoDocumento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalSchema: "GE",
                        principalTable: "TipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tramites",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreTramite = table.Column<string>(maxLength: 200, nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    valor = table.Column<decimal>(nullable: false),
                    Descuento = table.Column<decimal>(nullable: false),
                    EstudianteId = table.Column<int>(nullable: true),
                    funcionarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tramites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tramites_Estudiante_EstudianteId",
                        column: x => x.EstudianteId,
                        principalSchema: "GE",
                        principalTable: "Estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tramites_Funcionarios_funcionarioId",
                        column: x => x.funcionarioId,
                        principalSchema: "GE",
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EstadoId",
                schema: "GE",
                table: "Funcionarios",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_TipoDocumentoId",
                schema: "GE",
                table: "Funcionarios",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tramites_EstudianteId",
                schema: "GE",
                table: "Tramites",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tramites_funcionarioId",
                schema: "GE",
                table: "Tramites",
                column: "funcionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tramites",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "Funcionarios",
                schema: "GE");
        }
    }
}
