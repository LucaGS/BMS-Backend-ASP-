using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet8.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCrownAttachmentHeightFromTrees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrownAttachmentHeightMeters",
                table: "Trees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CrownAttachmentHeightMeters",
                table: "Trees",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
