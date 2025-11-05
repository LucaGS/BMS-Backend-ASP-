using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet8.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class MakeNummerUniquePerUser1234 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Baeume_Nummer",
                table: "Baeume");

            migrationBuilder.CreateIndex(
                name: "IX_Baeume_UserId_Nummer",
                table: "Baeume",
                columns: new[] { "UserId", "Nummer" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Baeume_UserId_Nummer",
                table: "Baeume");

            migrationBuilder.CreateIndex(
                name: "IX_Baeume_Nummer",
                table: "Baeume",
                column: "Nummer",
                unique: true);
        }
    }
}
