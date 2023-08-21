using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudiantesInfraestruture.Migrations
{
    public partial class TipoDocumentoPretramite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoDocumentoId",
                table: "Pretramite",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pretramite_TipoDocumentoId",
                table: "Pretramite",
                column: "TipoDocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pretramite_TipoDocumento_TipoDocumentoId",
                table: "Pretramite",
                column: "TipoDocumentoId",
                principalSchema: "GE",
                principalTable: "TipoDocumento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pretramite_TipoDocumento_TipoDocumentoId",
                table: "Pretramite");

            migrationBuilder.DropIndex(
                name: "IX_Pretramite_TipoDocumentoId",
                table: "Pretramite");

            migrationBuilder.DropColumn(
                name: "TipoDocumentoId",
                table: "Pretramite");
        }
    }
}
