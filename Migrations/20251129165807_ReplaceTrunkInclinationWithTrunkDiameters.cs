using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet8.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceTrunkInclinationWithTrunkDiameters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrunkInclination",
                table: "Trees");

            migrationBuilder.AddColumn<double>(
                name: "TrunkDiameter1",
                table: "Trees",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TrunkDiameter2",
                table: "Trees",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TrunkDiameter3",
                table: "Trees",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrunkDiameter1",
                table: "Trees");

            migrationBuilder.DropColumn(
                name: "TrunkDiameter2",
                table: "Trees");

            migrationBuilder.DropColumn(
                name: "TrunkDiameter3",
                table: "Trees");

            migrationBuilder.AddColumn<double>(
                name: "TrunkInclination",
                table: "Trees",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
