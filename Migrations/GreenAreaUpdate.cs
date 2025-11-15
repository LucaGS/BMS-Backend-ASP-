using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DotNet8.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class GreenAreaUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GreenAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GreenAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PerformedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsSafeForTraffic = table.Column<bool>(type: "boolean", nullable: false),
                    TreeId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreeImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageBase64 = table.Column<string>(type: "text", nullable: false),
                    TreeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    GreenAreaId = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Species = table.Column<string>(type: "text", nullable: false),
                    LastInspectionId = table.Column<int>(type: "integer", nullable: true),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    CrownDiameterMeters = table.Column<double>(type: "double precision", nullable: false),
                    CrownAttachmentHeightMeters = table.Column<double>(type: "double precision", nullable: false),
                    NumberOfTrunks = table.Column<int>(type: "integer", nullable: false),
                    TrunkInclination = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    HashedPassword = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trees_UserId_Number",
                table: "Trees",
                columns: new[] { "UserId", "Number" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GreenAreas");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "TreeImages");

            migrationBuilder.DropTable(
                name: "Trees");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
