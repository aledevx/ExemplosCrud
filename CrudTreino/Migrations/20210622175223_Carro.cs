using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudTreino.Migrations
{
    public partial class Carro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Pessoas_PessoaId",
                table: "Carros");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaId",
                table: "Carros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Pessoas_PessoaId",
                table: "Carros",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Pessoas_PessoaId",
                table: "Carros");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaId",
                table: "Carros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Pessoas_PessoaId",
                table: "Carros",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
