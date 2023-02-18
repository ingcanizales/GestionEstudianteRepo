using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudiantesInfraestruture.Migrations
{
    public partial class CorrepcionTramite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tramites",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "Funcionarios",
                schema: "GE");

            migrationBuilder.CreateTable(
                name: "EstadoTramite",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoTramite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 200, nullable: true),
                    Apellido = table.Column<string>(maxLength: 200, nullable: true),
                    Documento = table.Column<string>(maxLength: 20, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<string>(maxLength: 1, nullable: true),
                    Direccion = table.Column<string>(maxLength: 500, nullable: true),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FechaIngreso = table.Column<DateTime>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    FechaRetiro = table.Column<DateTime>(nullable: false),
                    TipoDocumentoId = table.Column<int>(nullable: true),
                    Cargo = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_TipoDocumento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalSchema: "GE",
                        principalTable: "TipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tramitacion",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreTramite = table.Column<string>(maxLength: 200, nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    valor = table.Column<decimal>(nullable: true),
                    EstudianteId = table.Column<int>(nullable: true),
                    PersonaId = table.Column<int>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tramitacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tramitacion_Estudiante_EstudianteId",
                        column: x => x.EstudianteId,
                        principalSchema: "GE",
                        principalTable: "Estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tramitacion_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalSchema: "GE",
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persona_TipoDocumentoId",
                schema: "GE",
                table: "Persona",
                column: "TipoDocumentoId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstadoTramite",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "Tramitacion",
                schema: "GE");

            migrationBuilder.DropTable(
                name: "Persona",
                schema: "GE");

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellido = table.Column<string>(maxLength: 200, nullable: true),
                    Cargo = table.Column<string>(maxLength: 500, nullable: false),
                    Direccion = table.Column<string>(maxLength: 500, nullable: true),
                    Documento = table.Column<string>(maxLength: 20, nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FechaIngreso = table.Column<DateTime>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    FechaRetiro = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: true),
                    Sexo = table.Column<string>(maxLength: 1, nullable: true),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    TipoDocumentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_TipoDocumento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalSchema: "GE",
                        principalTable: "TipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tramites",
                schema: "GE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descuento = table.Column<decimal>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    EstudianteId = table.Column<int>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    NombreTramite = table.Column<string>(maxLength: 200, nullable: false),
                    funcionarioId = table.Column<int>(nullable: true),
                    valor = table.Column<decimal>(nullable: false)
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
    }
}
