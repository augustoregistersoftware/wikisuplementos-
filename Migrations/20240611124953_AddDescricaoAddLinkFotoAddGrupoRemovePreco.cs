using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wikisuplementos.Migrations
{
    /// <inheritdoc />
    public partial class AddDescricaoAddLinkFotoAddGrupoRemovePreco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Suplementos");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Suplementos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Grupo",
                table: "Suplementos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkFoto",
                table: "Suplementos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Suplementos");

            migrationBuilder.DropColumn(
                name: "Grupo",
                table: "Suplementos");

            migrationBuilder.DropColumn(
                name: "LinkFoto",
                table: "Suplementos");

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Suplementos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
