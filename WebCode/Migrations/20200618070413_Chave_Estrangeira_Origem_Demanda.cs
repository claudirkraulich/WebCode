using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCode.Migrations
{
    public partial class Chave_Estrangeira_Origem_Demanda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demanda_Origem_OrigemId",
                table: "Demanda");

            migrationBuilder.AlterColumn<int>(
                name: "OrigemId",
                table: "Demanda",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Demanda_Origem_OrigemId",
                table: "Demanda",
                column: "OrigemId",
                principalTable: "Origem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demanda_Origem_OrigemId",
                table: "Demanda");

            migrationBuilder.AlterColumn<int>(
                name: "OrigemId",
                table: "Demanda",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Demanda_Origem_OrigemId",
                table: "Demanda",
                column: "OrigemId",
                principalTable: "Origem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
