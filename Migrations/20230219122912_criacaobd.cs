using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudProdutos.Migrations
{
    public partial class criacaobd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cnpj = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    RazaoSocial = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    Fantasia = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    Cep = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    numero = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Complemento = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    IdEquipamento = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tag = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Operando = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    NumeroContrato = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    clienteIdCliente = table.Column<int>(type: "INTEGER", nullable: true),
                    InicioLocacao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FimLocacao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Obs = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.IdEquipamento);
                    table.ForeignKey(
                        name: "FK_Equipamentos_Clientes_clienteIdCliente",
                        column: x => x.clienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movimentos",
                columns: table => new
                {
                    IdMovimento = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataMovimento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TipoMovimento = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    NumeroContrato = table.Column<string>(type: "TEXT", nullable: true),
                    clienteIdCliente = table.Column<int>(type: "INTEGER", nullable: true),
                    InicioLocacao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FimLocacao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Obs = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentos", x => x.IdMovimento);
                    table.ForeignKey(
                        name: "FK_Movimentos_Clientes_clienteIdCliente",
                        column: x => x.clienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipamentoModelMovimentoModel",
                columns: table => new
                {
                    EquipamentosModelIdEquipamento = table.Column<int>(type: "INTEGER", nullable: false),
                    MovimentosModelIdMovimento = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentoModelMovimentoModel", x => new { x.EquipamentosModelIdEquipamento, x.MovimentosModelIdMovimento });
                    table.ForeignKey(
                        name: "FK_EquipamentoModelMovimentoModel_Equipamentos_EquipamentosModelIdEquipamento",
                        column: x => x.EquipamentosModelIdEquipamento,
                        principalTable: "Equipamentos",
                        principalColumn: "IdEquipamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipamentoModelMovimentoModel_Movimentos_MovimentosModelIdMovimento",
                        column: x => x.MovimentosModelIdMovimento,
                        principalTable: "Movimentos",
                        principalColumn: "IdMovimento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentoModelMovimentoModel_MovimentosModelIdMovimento",
                table: "EquipamentoModelMovimentoModel",
                column: "MovimentosModelIdMovimento");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_clienteIdCliente",
                table: "Equipamentos",
                column: "clienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentos_clienteIdCliente",
                table: "Movimentos",
                column: "clienteIdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipamentoModelMovimentoModel");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Movimentos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
