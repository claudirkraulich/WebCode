using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCode.Migrations
{
    public partial class OutrasEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demanda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    OrigemId = table.Column<int>(nullable: true),
                    TipoDemanda = table.Column<int>(nullable: false),
                    ProcessoOrigem = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    NumeroProa = table.Column<string>(nullable: true),
                    DataInicial = table.Column<DateTime>(nullable: false),
                    Prazo = table.Column<int>(nullable: false),
                    DataFinal = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demanda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demanda_Origem_OrigemId",
                        column: x => x.OrigemId,
                        principalTable: "Origem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Atividade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Acao = table.Column<string>(nullable: true),
                    NumeroProa = table.Column<string>(nullable: true),
                    Setor = table.Column<string>(nullable: true),
                    Responsavel = table.Column<string>(nullable: true),
                    DataInicial = table.Column<DateTime>(nullable: false),
                    Prazo = table.Column<int>(nullable: false),
                    TipoPrazo = table.Column<string>(nullable: true),
                    DataFinal = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DemandaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atividade_Demanda_DemandaId",
                        column: x => x.DemandaId,
                        principalTable: "Demanda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atividade_DemandaId",
                table: "Atividade",
                column: "DemandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Demanda_OrigemId",
                table: "Demanda",
                column: "OrigemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atividade");

            migrationBuilder.DropTable(
                name: "Demanda");
        }
    }
}
