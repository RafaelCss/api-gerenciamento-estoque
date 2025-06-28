using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class Mudando_Classe_Produto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "QuantidadeEstoque",
                table: "Produtos");

            migrationBuilder.AddColumn<string>(
                name: "CodigoBarras",
                table: "Produtos",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoBarras",
                table: "Produtos");

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Produtos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeEstoque",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
