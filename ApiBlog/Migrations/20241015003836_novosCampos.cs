using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBlog.Migrations
{
    /// <inheritdoc />
    public partial class novosCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubTitulo",
                table: "NOTICIA",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubTitulo",
                table: "NOTICIA");
        }
    }
}
