using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecenzjeFilmowe.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "varchar(100)", nullable: false),
                    Premiera = table.Column<string>(type: "varchar(30)", nullable: false),
                    Czas = table.Column<int>(type: "int", nullable: false),
                    Rezyseria = table.Column<string>(type: "varchar(100)", nullable: false),
                    Zdjecie = table.Column<string>(type: "varchar(200)", nullable: false),
                    Link = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recenzje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Autor = table.Column<string>(type: "varchar(100)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ocena = table.Column<int>(type: "int", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recenzje_Filmy_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Filmy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recenzje_FilmId",
                table: "Recenzje",
                column: "FilmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recenzje");

            migrationBuilder.DropTable(
                name: "Filmy");
        }
    }
}
