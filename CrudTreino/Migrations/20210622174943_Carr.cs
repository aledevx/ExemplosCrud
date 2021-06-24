using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudTreino.Migrations
{
    public partial class Carr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Pessoas_ResponsavelId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_ResponsavelId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "ResponsavelId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "dependenteId",
                table: "Pessoas");

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PessoaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carros_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_PessoaId",
                table: "Carros",
                column: "PessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ResponsavelId",
                table: "Pessoas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "dependenteId",
                table: "Pessoas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_ResponsavelId",
                table: "Pessoas",
                column: "ResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Pessoas_ResponsavelId",
                table: "Pessoas",
                column: "ResponsavelId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
