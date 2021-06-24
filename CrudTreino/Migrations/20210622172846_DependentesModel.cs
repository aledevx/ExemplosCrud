using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudTreino.Migrations
{
    public partial class DependentesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Pessoas_PessoaId",
                table: "Pessoas");

            migrationBuilder.RenameColumn(
                name: "PessoaId",
                table: "Pessoas",
                newName: "ResponsavelId");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoas_PessoaId",
                table: "Pessoas",
                newName: "IX_Pessoas_ResponsavelId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Pessoas",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Pessoas_ResponsavelId",
                table: "Pessoas",
                column: "ResponsavelId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Pessoas_ResponsavelId",
                table: "Pessoas");

            migrationBuilder.RenameColumn(
                name: "ResponsavelId",
                table: "Pessoas",
                newName: "PessoaId");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoas_ResponsavelId",
                table: "Pessoas",
                newName: "IX_Pessoas_PessoaId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Pessoas_PessoaId",
                table: "Pessoas",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
