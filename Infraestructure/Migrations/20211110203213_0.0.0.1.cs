using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class _0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Librerias",
                columns: table => new
                {
                    IdLibreria = table.Column<int>(type: "int", nullable: false, comment: "Llave de la tabla libreria")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Librerias", x => x.IdLibreria);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroPaginas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibreriasLibros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    IdLibreria = table.Column<int>(type: "int", nullable: false),
                    IdBook = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibreriasLibros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibreriasLibros_Librerias_IdLibreria",
                        column: x => x.IdLibreria,
                        principalTable: "Librerias",
                        principalColumn: "IdLibreria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibreriasLibros_Libros_IdBook",
                        column: x => x.IdBook,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibreriasLibros_IdBook",
                table: "LibreriasLibros",
                column: "IdBook");

            migrationBuilder.CreateIndex(
                name: "IX_LibreriasLibros_IdLibreria",
                table: "LibreriasLibros",
                column: "IdLibreria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibreriasLibros");

            migrationBuilder.DropTable(
                name: "Librerias");

            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}
