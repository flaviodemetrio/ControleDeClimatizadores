using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudProdutos.Migrations
{
    public partial class CriacaoBd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    EquipamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tag = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Operando = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Obs = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.EquipamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Movimentos",
                columns: table => new
                {
                    MovimentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataMovimento = table.Column<string>(type: "TEXT", nullable: true),
                    TipoMovimento = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    NumeroContrato = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    InicioLocacao = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    FimLocacao = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Obs = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentos", x => x.MovimentoId);
                    table.ForeignKey(
                        name: "FK_Movimentos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipamentoModelMovimentoModel",
                columns: table => new
                {
                    EquipamentosModelEquipamentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    MovimentosModelMovimentoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentoModelMovimentoModel", x => new { x.EquipamentosModelEquipamentoId, x.MovimentosModelMovimentoId });
                    table.ForeignKey(
                        name: "FK_EquipamentoModelMovimentoModel_Equipamentos_EquipamentosModelEquipamentoId",
                        column: x => x.EquipamentosModelEquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "EquipamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipamentoModelMovimentoModel_Movimentos_MovimentosModelMovimentoId",
                        column: x => x.MovimentosModelMovimentoId,
                        principalTable: "Movimentos",
                        principalColumn: "MovimentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentoModelMovimentoModel_MovimentosModelMovimentoId",
                table: "EquipamentoModelMovimentoModel",
                column: "MovimentosModelMovimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentos_ClienteId",
                table: "Movimentos",
                column: "ClienteId");
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
