using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCode.Migrations
{
    public partial class Chave_Estrangeira_Demanda_Atividade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividade_Demanda_DemandaId",
                table: "Atividade");

            migrationBuilder.AlterColumn<int>(
                name: "DemandaId",
                table: "Atividade",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Atividade_Demanda_DemandaId",
                table: "Atividade",
                column: "DemandaId",
                principalTable: "Demanda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividade_Demanda_DemandaId",
                table: "Atividade");

            migrationBuilder.AlterColumn<int>(
                name: "DemandaId",
                table: "Atividade",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Atividade_Demanda_DemandaId",
                table: "Atividade",
                column: "DemandaId",
                principalTable: "Demanda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
