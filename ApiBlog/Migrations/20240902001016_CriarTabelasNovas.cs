using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBlog.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelasNovas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CONFIGGERAL",
                columns: table => new
                {
                    IDCONFIGGERAL = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NOMESITE = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IMAGEMSITE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NOME = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FONE = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ENDERECO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    INSTAGRAM = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FACEBOOK = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONFIGGERAL", x => x.IDCONFIGGERAL);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            // Inserir config padrão
            migrationBuilder.InsertData(
                table: "CONFIGGERAL",
                columns: new[] { "IDCONFIGGERAL", "NOMESITE", "IMAGEMSITE", "NOME", "FONE", "EMAIL", "ENDERECO", "INSTAGRAM", "FACEBOOK" },
                values: new object[]
                {
                Guid.NewGuid(),    // Gerar um novo GUID para o IDUSUARIO
                "Nome Site",       // NOMESITE
                "",                // IMAGEMSITE
                "Site",            // NOME
                "(48)00000-0000",  // FONE
                "teste@teste.com", // EMAIL
                "",                // ENDERECO
                "",                // INSTAGRAM
                ""                 // FACEBOOK
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONFIGGERAL");
        }
    }
}
