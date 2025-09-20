using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet8.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Baeume",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "Kontrollen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NeuesKotnrollIntervall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Verkehrssicher = table.Column<bool>(type: "bit", nullable: false),
                    BaumId = table.Column<int>(type: "int", nullable: false)
                },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Kontrollen", x => x.Id);
                   table.ForeignKey(
                       name: "FK_Kontrollen_Baeume_BaumId",
                       column: x => x.BaumId,
                       principalTable: "Baeume",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Restrict); // <-- statt Cascade
               }
);

            migrationBuilder.CreateIndex(
                name: "IX_Baeume_LetzteKontrolleID",
                table: "Baeume",
                column: "LetzteKontrolleID");

            migrationBuilder.CreateIndex(
                name: "IX_Kontrollen_BaumId",
                table: "Kontrollen",
                column: "BaumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baeume_Kontrollen_LetzteKontrolleID",
                table: "Baeume",
                column: "LetzteKontrolleID",
                principalTable: "Kontrollen",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baeume_Kontrollen_LetzteKontrolleID",
                table: "Baeume");

            migrationBuilder.DropTable(
                name: "Kontrollen");

            migrationBuilder.DropTable(
                name: "Baeume");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");
        }
    }
}
