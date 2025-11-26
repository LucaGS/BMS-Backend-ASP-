using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet8.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddInspectionDetailFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BreakageSafety",
                table: "Inspections",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DamageLevel",
                table: "Inspections",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Inspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DevelopmentalStage",
                table: "Inspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NewInspectionIntervall",
                table: "Inspections",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StandStability",
                table: "Inspections",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitality",
                table: "Inspections",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakageSafety",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "DamageLevel",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "DevelopmentalStage",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "NewInspectionIntervall",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "StandStability",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "Vitality",
                table: "Inspections");
        }
    }
}
