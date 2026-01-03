using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet8.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTreeSizeAndNextInspectionToTrees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NextInspection",
                table: "Trees",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "TreeSizeMeters",
                table: "Trees",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextInspection",
                table: "Trees");

            migrationBuilder.DropColumn(
                name: "TreeSizeMeters",
                table: "Trees");
        }
    }
}
