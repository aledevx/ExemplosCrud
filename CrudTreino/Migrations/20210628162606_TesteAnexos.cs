using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudTreino.Migrations
{
    public partial class TesteAnexos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Anexo_AnexoId",
                table: "Pessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Anexo",
                table: "Anexo");

            migrationBuilder.RenameTable(
                name: "Anexo",
                newName: "Anexos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Anexos",
                table: "Anexos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Anexos_AnexoId",
                table: "Pessoas",
                column: "AnexoId",
                principalTable: "Anexos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Anexos_AnexoId",
                table: "Pessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Anexos",
                table: "Anexos");

            migrationBuilder.RenameTable(
                name: "Anexos",
                newName: "Anexo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Anexo",
                table: "Anexo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Anexo_AnexoId",
                table: "Pessoas",
                column: "AnexoId",
                principalTable: "Anexo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
