using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBlog.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    IDCATEGORIA = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DATAULTIMAALTERACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA", x => x.IDCATEGORIA);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    IDUSUARIO = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NOME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SOBRENOME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SENHA = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FOTOPERFIL = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADMIN = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.IDUSUARIO);
                })
                .Annotation("MySql:CharSet", "utf8mb4");


            // Inserir um usuário padrão
            migrationBuilder.InsertData(
                table: "USUARIO",
                columns: new[] { "IDUSUARIO", "ATIVO", "NOME", "SOBRENOME", "EMAIL", "SENHA", "FOTOPERFIL", "ADMIN", "DATACRIACAO" },
                values: new object[]
                {
                Guid.NewGuid(), // Gerar um novo GUID para o IDUSUARIO
                true,          // ATIVO
                "Boot",         // NOME
                "User",         // SOBRENOME
                "Boot",         // EMAIL
                "$2a$10$U7b8xqO8n7M7SXj9VUgoCecaZJzAH0q.GSAwD0HEY/v2c3ZQKkPIS", // SENHA
                "",            // FOTOPERFIL (ou um valor padrão se aplicável)
                true,          // ADMIN
                DateTime.UtcNow // DATACRIACAO
                });

            migrationBuilder.CreateTable(
                name: "NOTICIA",
                columns: table => new
                {
                    IDNOTICIA = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TITULO = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CONTEUDO = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IMAGEM = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PRIORIDADE = table.Column<int>(type: "int", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IDAUTOR = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IDCATEGORIA = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTICIA", x => x.IDNOTICIA);
                    table.ForeignKey(
                        name: "FK_NOTICIA_CATEGORIA_IDCATEGORIA",
                        column: x => x.IDCATEGORIA,
                        principalTable: "CATEGORIA",
                        principalColumn: "IDCATEGORIA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NOTICIA_USUARIO_IDAUTOR",
                        column: x => x.IDAUTOR,
                        principalTable: "USUARIO",
                        principalColumn: "IDUSUARIO",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_NOTICIA_IDAUTOR",
                table: "NOTICIA",
                column: "IDAUTOR");

            migrationBuilder.CreateIndex(
                name: "IX_NOTICIA_IDCATEGORIA",
                table: "NOTICIA",
                column: "IDCATEGORIA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NOTICIA");

            migrationBuilder.DropTable(
                name: "CATEGORIA");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
