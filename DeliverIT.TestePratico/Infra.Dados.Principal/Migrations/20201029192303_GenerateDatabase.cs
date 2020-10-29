using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Dados.Principal.Migrations
{
    public partial class GenerateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContasPagar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false, maxLength: 60),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    DataPagamento = table.Column<DateTime>(nullable: false),
                    ValorOriginal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasPagar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContasPagarBaixas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContasPagarId = table.Column<int>(nullable: false),
                    QtdeDiasAtraso = table.Column<int>(nullable: false),
                    PercentualJurosDia = table.Column<decimal>(nullable: false),
                    PercentualMulta = table.Column<decimal>(nullable: false),
                    ValorPago = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasPagarBaixas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasPagarBaixas_ContasPagar_ContasPagarId",
                        column: x => x.ContasPagarId,
                        principalTable: "ContasPagar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContasPagarBaixas_ContasPagarId",
                table: "ContasPagarBaixas",
                column: "ContasPagarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasPagarBaixas");

            migrationBuilder.DropTable(
                name: "ContasPagar");
        }
    }
}
