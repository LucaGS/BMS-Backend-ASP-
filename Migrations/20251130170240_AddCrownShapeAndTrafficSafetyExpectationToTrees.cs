using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet8.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCrownShapeAndTrafficSafetyExpectationToTrees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CrownShape",
                table: "Trees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TrafficSafetyExpectation",
                table: "Trees",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrownShape",
                table: "Trees");

            migrationBuilder.DropColumn(
                name: "TrafficSafetyExpectation",
                table: "Trees");
        }
    }
}
