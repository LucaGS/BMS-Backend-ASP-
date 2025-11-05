using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet8.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToKontrollen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeuesKontrollIntervall",
                table: "Kontrollen");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Kontrollen",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Kontrollen");

            migrationBuilder.AddColumn<string>(
                name: "NeuesKontrollIntervall",
                table: "Kontrollen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
