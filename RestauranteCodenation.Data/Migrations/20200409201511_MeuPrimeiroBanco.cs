using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestauranteCodenation.Data.Migrations
{
    public partial class MeuPrimeiroBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInicio = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    DataFim = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cardapio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardapio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: true),
                    Validade = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPrato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPrato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgendaCardapio",
                columns: table => new
                {
                    IdCardapio = table.Column<int>(nullable: false),
                    IdAgenda = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaCardapio", x => new { x.IdAgenda, x.IdCardapio });
                    table.ForeignKey(
                        name: "FK_AgendaCardapio_Agenda_IdAgenda",
                        column: x => x.IdAgenda,
                        principalTable: "Agenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendaCardapio_Cardapio_IdCardapio",
                        column: x => x.IdCardapio,
                        principalTable: "Cardapio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdTipoPrato = table.Column<int>(nullable: false),
                    CardapioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prato_Cardapio_CardapioId",
                        column: x => x.CardapioId,
                        principalTable: "Cardapio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prato_TipoPrato_IdTipoPrato",
                        column: x => x.IdTipoPrato,
                        principalTable: "TipoPrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PratosIngredientes",
                columns: table => new
                {
                    IdPrato = table.Column<int>(nullable: false),
                    IdIngrediente = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PratosIngredientes", x => new { x.IdIngrediente, x.IdPrato });
                    table.ForeignKey(
                        name: "FK_PratosIngredientes_Ingrediente_IdIngrediente",
                        column: x => x.IdIngrediente,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PratosIngredientes_Prato_IdPrato",
                        column: x => x.IdPrato,
                        principalTable: "Prato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendaCardapio_IdCardapio",
                table: "AgendaCardapio",
                column: "IdCardapio");

            migrationBuilder.CreateIndex(
                name: "IX_Prato_CardapioId",
                table: "Prato",
                column: "CardapioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prato_IdTipoPrato",
                table: "Prato",
                column: "IdTipoPrato");

            migrationBuilder.CreateIndex(
                name: "IX_PratosIngredientes_IdPrato",
                table: "PratosIngredientes",
                column: "IdPrato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendaCardapio");

            migrationBuilder.DropTable(
                name: "PratosIngredientes");

            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "Prato");

            migrationBuilder.DropTable(
                name: "Cardapio");

            migrationBuilder.DropTable(
                name: "TipoPrato");
        }
    }
}
