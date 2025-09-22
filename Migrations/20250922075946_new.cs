using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet8.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baeume",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GruenFlächenId = table.Column<int>(type: "int", nullable: false),
                    Nummer = table.Column<int>(type: "int", nullable: false),
                    Art = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetzteKontrolleID = table.Column<int>(type: "int", nullable: true),
                    Laengengrad = table.Column<double>(type: "float", nullable: false),
                    Breitengrad = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baeume", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bilder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgAsText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Baumid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GruenFlaechen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgAsText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruenFlaechen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kontrollen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NeuesKontrollIntervall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Verkehrssicher = table.Column<bool>(type: "bit", nullable: false),
                    BaumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontrollen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baeume");

            migrationBuilder.DropTable(
                name: "Bilder");

            migrationBuilder.DropTable(
                name: "GruenFlaechen");

            migrationBuilder.DropTable(
                name: "Kontrollen");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
