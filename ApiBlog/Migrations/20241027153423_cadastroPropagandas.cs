using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBlog.Migrations
{
    /// <inheritdoc />
    public partial class cadastroPropagandas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PROPAGANDA",
                columns: table => new
                {
                    IDPROPAGANDA = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TITULO = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IMAGEM = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LINK = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PRIORIDADE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROPAGANDA", x => x.IDPROPAGANDA);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PROPAGANDA");
        }
    }
}
