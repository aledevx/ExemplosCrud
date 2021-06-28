using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudTreino.Migrations
{
    public partial class Anexos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnexoId",
                table: "Pessoas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Anexo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalizadorDoAnexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bytes = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anexo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_AnexoId",
                table: "Pessoas",
                column: "AnexoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Anexo_AnexoId",
                table: "Pessoas",
                column: "AnexoId",
                principalTable: "Anexo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Anexo_AnexoId",
                table: "Pessoas");

            migrationBuilder.DropTable(
                name: "Anexo");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_AnexoId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "AnexoId",
                table: "Pessoas");
        }
    }
}
