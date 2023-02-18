using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudiantesInfraestruture.Migrations
{
    public partial class funcionarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_EstadoEstudiante_EstadoId",
                schema: "GE",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_TipoDocumento_TipoDocumentoId",
                schema: "GE",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_EstadoId",
                schema: "GE",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                schema: "GE",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "FechaEgreso",
                schema: "GE",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDocumentoId",
                schema: "GE",
                table: "Funcionarios",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                schema: "GE",
                table: "Funcionarios",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                schema: "GE",
                table: "Funcionarios",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                schema: "GE",
                table: "Funcionarios",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "GE",
                table: "Funcionarios",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Documento",
                schema: "GE",
                table: "Funcionarios",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                schema: "GE",
                table: "Funcionarios",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                schema: "GE",
                table: "Funcionarios",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_TipoDocumento_TipoDocumentoId",
                schema: "GE",
                table: "Funcionarios",
                column: "TipoDocumentoId",
                principalSchema: "GE",
                principalTable: "TipoDocumento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_TipoDocumento_TipoDocumentoId",
                schema: "GE",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<int>(
                name: "TipoDocumentoId",
                schema: "GE",
                table: "Funcionarios",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                schema: "GE",
                table: "Funcionarios",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                schema: "GE",
                table: "Funcionarios",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                schema: "GE",
                table: "Funcionarios",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "GE",
                table: "Funcionarios",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Documento",
                schema: "GE",
                table: "Funcionarios",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                schema: "GE",
                table: "Funcionarios",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                schema: "GE",
                table: "Funcionarios",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                schema: "GE",
                table: "Funcionarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEgreso",
                schema: "GE",
                table: "Funcionarios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EstadoId",
                schema: "GE",
                table: "Funcionarios",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_EstadoEstudiante_EstadoId",
                schema: "GE",
                table: "Funcionarios",
                column: "EstadoId",
                principalSchema: "GE",
                principalTable: "EstadoEstudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_TipoDocumento_TipoDocumentoId",
                schema: "GE",
                table: "Funcionarios",
                column: "TipoDocumentoId",
                principalSchema: "GE",
                principalTable: "TipoDocumento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
