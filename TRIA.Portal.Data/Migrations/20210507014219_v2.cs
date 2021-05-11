using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TRIA.Portal.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "dt_alteracao",
                table: "Tbl_Cliente_Contato",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "nm_empresa",
                table: "Tbl_Cliente_Contato",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Tbl_Produto_Servico",
                keyColumn: "id_produto_servico",
                keyValue: 1,
                column: "dt_inclusao",
                value: new DateTime(2021, 5, 6, 22, 42, 18, 879, DateTimeKind.Local).AddTicks(5498));

            migrationBuilder.UpdateData(
                table: "Tbl_Produto_Servico",
                keyColumn: "id_produto_servico",
                keyValue: 2,
                column: "dt_inclusao",
                value: new DateTime(2021, 5, 6, 22, 42, 18, 881, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "Tbl_Produto_Servico",
                keyColumn: "id_produto_servico",
                keyValue: 3,
                column: "dt_inclusao",
                value: new DateTime(2021, 5, 6, 22, 42, 18, 881, DateTimeKind.Local).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "Tbl_Produto_Servico",
                keyColumn: "id_produto_servico",
                keyValue: 4,
                column: "dt_inclusao",
                value: new DateTime(2021, 5, 6, 22, 42, 18, 881, DateTimeKind.Local).AddTicks(2036));

            migrationBuilder.UpdateData(
                table: "Tbl_Produto_Servico",
                keyColumn: "id_produto_servico",
                keyValue: 5,
                column: "dt_inclusao",
                value: new DateTime(2021, 5, 6, 22, 42, 18, 881, DateTimeKind.Local).AddTicks(2038));

            migrationBuilder.UpdateData(
                table: "Tbl_Produto_Servico",
                keyColumn: "id_produto_servico",
                keyValue: 6,
                column: "dt_inclusao",
                value: new DateTime(2021, 5, 6, 22, 42, 18, 881, DateTimeKind.Local).AddTicks(2040));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nm_empresa",
                table: "Tbl_Cliente_Contato");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dt_alteracao",
                table: "Tbl_Cliente_Contato",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Tbl_Produto_Servico",
                keyColumn: "id_produto_servico",
                keyValue: 1,
                column: "dt_inclusao",
                value: new DateTime(2021, 5, 5, 22, 13, 43, 930, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "Tbl_Produto_Servico",
                keyColumn: "id_produto_servico",
                keyValue: 2,
                column: "dt_inclusao",
                value: new DateTime(2021, 5, 5, 22, 13, 43, 932, DateTimeKind.Local).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "Tbl_Produto_Servico",
                keyColumn: "id_produto_servico",
                keyValue: 3,
                column: "dt_inclusao",
                value: new DateTime(2021, 5, 5, 22, 13, 43, 932, DateTimeKind.Local).AddTicks(6713));

            migrationBuilder.UpdateData(
                table: "Tbl_Produto_Servico",
                keyColumn: "id_produto_servico",
                keyValue: 4,
                column: "dt_inclusao",
                value: new DateTime(2021, 5, 5, 22, 13, 43, 932, DateTimeKind.Local).AddTicks(6716));

            migrationBuilder.UpdateData(
                table: "Tbl_Produto_Servico",
                keyColumn: "id_produto_servico",
                keyValue: 5,
                column: "dt_inclusao",
                value: new DateTime(2021, 5, 5, 22, 13, 43, 932, DateTimeKind.Local).AddTicks(6718));

            migrationBuilder.UpdateData(
                table: "Tbl_Produto_Servico",
                keyColumn: "id_produto_servico",
                keyValue: 6,
                column: "dt_inclusao",
                value: new DateTime(2021, 5, 5, 22, 13, 43, 932, DateTimeKind.Local).AddTicks(6720));
        }
    }
}
