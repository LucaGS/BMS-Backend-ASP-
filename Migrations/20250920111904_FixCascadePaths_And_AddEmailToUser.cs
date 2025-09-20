using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet8.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadePaths_And_AddEmailToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kontrollen_Baeume_BaumId",
                table: "Kontrollen");

            migrationBuilder.RenameColumn(
                name: "NeuesKotnrollIntervall",
                table: "Kontrollen",
                newName: "NeuesKontrollIntervall");

            migrationBuilder.AddForeignKey(
                name: "FK_Kontrollen_Baeume_BaumId",
                table: "Kontrollen",
                column: "BaumId",
                principalTable: "Baeume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kontrollen_Baeume_BaumId",
                table: "Kontrollen");

            migrationBuilder.RenameColumn(
                name: "NeuesKontrollIntervall",
                table: "Kontrollen",
                newName: "NeuesKotnrollIntervall");

            migrationBuilder.AddForeignKey(
                name: "FK_Kontrollen_Baeume_BaumId",
                table: "Kontrollen",
                column: "BaumId",
                principalTable: "Baeume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
