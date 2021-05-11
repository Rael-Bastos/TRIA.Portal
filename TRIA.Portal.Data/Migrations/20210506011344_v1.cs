using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TRIA.Portal.Data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Produto_Servico",
                columns: table => new
                {
                    id_produto_servico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nm_produto_servico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dt_inclusao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Produto_Servico", x => x.id_produto_servico);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nome_completo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dt_inclusao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Usuarios", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Cliente_Contato",
                columns: table => new
                {
                    id_cliente_contato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nm_cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone_contato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email_contato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    texto_livre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dt_inclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dt_alteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hr_atendimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_produto_servico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Cliente_Contato", x => x.id_cliente_contato);
                    table.ForeignKey(
                        name: "FK_Tbl_Cliente_Contato_Tbl_Produto_Servico_id_produto_servico",
                        column: x => x.id_produto_servico,
                        principalTable: "Tbl_Produto_Servico",
                        principalColumn: "id_produto_servico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tbl_Produto_Servico",
                columns: new[] { "id_produto_servico", "dt_inclusao", "nm_produto_servico" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 5, 22, 13, 43, 930, DateTimeKind.Local).AddTicks(9146), "Desenvolvimento de App" },
                    { 2, new DateTime(2021, 5, 5, 22, 13, 43, 932, DateTimeKind.Local).AddTicks(6657), "Desenvolvimento Web" },
                    { 3, new DateTime(2021, 5, 5, 22, 13, 43, 932, DateTimeKind.Local).AddTicks(6713), "Integração com SAP" },
                    { 4, new DateTime(2021, 5, 5, 22, 13, 43, 932, DateTimeKind.Local).AddTicks(6716), "Integração com Mastersaf" },
                    { 5, new DateTime(2021, 5, 5, 22, 13, 43, 932, DateTimeKind.Local).AddTicks(6718), "Suporte Nível Especialista" },
                    { 6, new DateTime(2021, 5, 5, 22, 13, 43, 932, DateTimeKind.Local).AddTicks(6720), "Solução Tributária" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Cliente_Contato_id_produto_servico",
                table: "Tbl_Cliente_Contato",
                column: "id_produto_servico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Cliente_Contato");

            migrationBuilder.DropTable(
                name: "Tbl_Usuarios");

            migrationBuilder.DropTable(
                name: "Tbl_Produto_Servico");
        }
    }
}
