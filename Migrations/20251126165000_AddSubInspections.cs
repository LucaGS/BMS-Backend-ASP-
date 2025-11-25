using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DotNet8.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSubInspections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrownInspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InspectionId = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    AbioticDisturbance = table.Column<bool>(type: "boolean", nullable: false),
                    Dying = table.Column<bool>(type: "boolean", nullable: false),
                    OverloadedBranchOrCrown = table.Column<bool>(type: "boolean", nullable: false),
                    BranchBreak = table.Column<bool>(type: "boolean", nullable: false),
                    BranchBreakWound = table.Column<bool>(type: "boolean", nullable: false),
                    PruningWound = table.Column<bool>(type: "boolean", nullable: false),
                    Exudation = table.Column<bool>(type: "boolean", nullable: false),
                    TreeInGroup = table.Column<bool>(type: "boolean", nullable: false),
                    TreeIsDead = table.Column<bool>(type: "boolean", nullable: false),
                    ForeignVegetation = table.Column<bool>(type: "boolean", nullable: false),
                    BioticDisturbance = table.Column<bool>(type: "boolean", nullable: false),
                    LightningDamage = table.Column<bool>(type: "boolean", nullable: false),
                    Deformed = table.Column<bool>(type: "boolean", nullable: false),
                    CompressionFork = table.Column<bool>(type: "boolean", nullable: false),
                    DryBranches = table.Column<bool>(type: "boolean", nullable: false),
                    IncludedBark = table.Column<bool>(type: "boolean", nullable: false),
                    OneSidedCrown = table.Column<bool>(type: "boolean", nullable: false),
                    ForeignObject = table.Column<bool>(type: "boolean", nullable: false),
                    Topped = table.Column<bool>(type: "boolean", nullable: false),
                    HabitatStructure = table.Column<bool>(type: "boolean", nullable: false),
                    ResinFlow = table.Column<bool>(type: "boolean", nullable: false),
                    Cavity = table.Column<bool>(type: "boolean", nullable: false),
                    CompetingBranch = table.Column<bool>(type: "boolean", nullable: false),
                    CompetingTree = table.Column<bool>(type: "boolean", nullable: false),
                    Canker = table.Column<bool>(type: "boolean", nullable: false),
                    CrownSecured = table.Column<bool>(type: "boolean", nullable: false),
                    LongitudinalCrack = table.Column<bool>(type: "boolean", nullable: false),
                    ClearanceProfile2_50m = table.Column<bool>(type: "boolean", nullable: false),
                    ClearanceProfile4_50m = table.Column<bool>(type: "boolean", nullable: false),
                    Burl = table.Column<bool>(type: "boolean", nullable: false),
                    OpenDecay = table.Column<bool>(type: "boolean", nullable: false),
                    WithoutLeaderShoot = table.Column<bool>(type: "boolean", nullable: false),
                    FungalFruitingBody = table.Column<bool>(type: "boolean", nullable: false),
                    RubbingBranches = table.Column<bool>(type: "boolean", nullable: false),
                    SlimeFlux = table.Column<bool>(type: "boolean", nullable: false),
                    SecondaryCrowns = table.Column<bool>(type: "boolean", nullable: false),
                    WoodpeckerHole = table.Column<bool>(type: "boolean", nullable: false),
                    CompressionDamage = table.Column<bool>(type: "boolean", nullable: false),
                    TorsionCrack = table.Column<bool>(type: "boolean", nullable: false),
                    Deadwood = table.Column<bool>(type: "boolean", nullable: false),
                    WidowmakerBranch = table.Column<bool>(type: "boolean", nullable: false),
                    UnfavorableCrownDevelopment = table.Column<bool>(type: "boolean", nullable: false),
                    GraftPoint = table.Column<bool>(type: "boolean", nullable: false),
                    UtilityLineConflict = table.Column<bool>(type: "boolean", nullable: false),
                    TopDieback = table.Column<bool>(type: "boolean", nullable: false),
                    Wound = table.Column<bool>(type: "boolean", nullable: false),
                    WoundWithCallusRidge = table.Column<bool>(type: "boolean", nullable: false),
                    WoundCallusClosed = table.Column<bool>(type: "boolean", nullable: false),
                    TensionFork = table.Column<bool>(type: "boolean", nullable: false),
                    ForkedCrown = table.Column<bool>(type: "boolean", nullable: false),
                    ForkCrack = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrownInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrownInspections_Inspections_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "Inspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StemBaseInspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InspectionId = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    Excavation = table.Column<bool>(type: "boolean", nullable: false),
                    AdventitiousRootFormation = table.Column<bool>(type: "boolean", nullable: false),
                    Exudation = table.Column<bool>(type: "boolean", nullable: false),
                    StructuresAtStemBase = table.Column<bool>(type: "boolean", nullable: false),
                    StructuresNearTree = table.Column<bool>(type: "boolean", nullable: false),
                    BulgeOrSwelling = table.Column<bool>(type: "boolean", nullable: false),
                    ForeignVegetation = table.Column<bool>(type: "boolean", nullable: false),
                    BoreDust = table.Column<bool>(type: "boolean", nullable: false),
                    Bottleneck = table.Column<bool>(type: "boolean", nullable: false),
                    ForeignObject = table.Column<bool>(type: "boolean", nullable: false),
                    HabitatStructures = table.Column<bool>(type: "boolean", nullable: false),
                    TreeOnSlope = table.Column<bool>(type: "boolean", nullable: false),
                    ResinFlow = table.Column<bool>(type: "boolean", nullable: false),
                    Cavity = table.Column<bool>(type: "boolean", nullable: false),
                    Canker = table.Column<bool>(type: "boolean", nullable: false),
                    OpenDecay = table.Column<bool>(type: "boolean", nullable: false),
                    FungalFruitingBody = table.Column<bool>(type: "boolean", nullable: false),
                    SlimeFlux = table.Column<bool>(type: "boolean", nullable: false),
                    StemBaseThickened = table.Column<bool>(type: "boolean", nullable: false),
                    CompressionDamage = table.Column<bool>(type: "boolean", nullable: false),
                    Overfilled = table.Column<bool>(type: "boolean", nullable: false),
                    GraftPoint = table.Column<bool>(type: "boolean", nullable: false),
                    GirdlingRoot = table.Column<bool>(type: "boolean", nullable: false),
                    RootDamage = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StemBaseInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StemBaseInspections_Inspections_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "Inspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrunkInspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InspectionId = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    AbioticDisturbance = table.Column<bool>(type: "boolean", nullable: false),
                    BranchBreakWound = table.Column<bool>(type: "boolean", nullable: false),
                    PruningWound = table.Column<bool>(type: "boolean", nullable: false),
                    Exudation = table.Column<bool>(type: "boolean", nullable: false),
                    TreeRemoved = table.Column<bool>(type: "boolean", nullable: false),
                    BulgeOrSwelling = table.Column<bool>(type: "boolean", nullable: false),
                    ForeignVegetation = table.Column<bool>(type: "boolean", nullable: false),
                    BioticDisturbance = table.Column<bool>(type: "boolean", nullable: false),
                    LightningDamage = table.Column<bool>(type: "boolean", nullable: false),
                    LeavesBrokenOff = table.Column<bool>(type: "boolean", nullable: false),
                    Deformed = table.Column<bool>(type: "boolean", nullable: false),
                    SpiralGrain = table.Column<bool>(type: "boolean", nullable: false),
                    CompressionFork = table.Column<bool>(type: "boolean", nullable: false),
                    IncludedBark = table.Column<bool>(type: "boolean", nullable: false),
                    ForeignObject = table.Column<bool>(type: "boolean", nullable: false),
                    Topped = table.Column<bool>(type: "boolean", nullable: false),
                    HabitatStructures = table.Column<bool>(type: "boolean", nullable: false),
                    ResinFlow = table.Column<bool>(type: "boolean", nullable: false),
                    Cavity = table.Column<bool>(type: "boolean", nullable: false),
                    Canker = table.Column<bool>(type: "boolean", nullable: false),
                    LongitudinalCrack = table.Column<bool>(type: "boolean", nullable: false),
                    MowingDamage = table.Column<bool>(type: "boolean", nullable: false),
                    Burl = table.Column<bool>(type: "boolean", nullable: false),
                    OpenDecay = table.Column<bool>(type: "boolean", nullable: false),
                    FungalFruitingBody = table.Column<bool>(type: "boolean", nullable: false),
                    Leaning = table.Column<bool>(type: "boolean", nullable: false),
                    SlimeFlux = table.Column<bool>(type: "boolean", nullable: false),
                    SecondaryRadialGrowthMissing = table.Column<bool>(type: "boolean", nullable: false),
                    WoodpeckerHole = table.Column<bool>(type: "boolean", nullable: false),
                    CompressionDamage = table.Column<bool>(type: "boolean", nullable: false),
                    TorsionCrack = table.Column<bool>(type: "boolean", nullable: false),
                    Deadwood = table.Column<bool>(type: "boolean", nullable: false),
                    WidowmakerBranch = table.Column<bool>(type: "boolean", nullable: false),
                    GraftPoint = table.Column<bool>(type: "boolean", nullable: false),
                    SupplyShadow = table.Column<bool>(type: "boolean", nullable: false),
                    Wobbles = table.Column<bool>(type: "boolean", nullable: false),
                    Wound = table.Column<bool>(type: "boolean", nullable: false),
                    WoundCallusRidge = table.Column<bool>(type: "boolean", nullable: false),
                    WoundCallusClosed = table.Column<bool>(type: "boolean", nullable: false),
                    TensionFork = table.Column<bool>(type: "boolean", nullable: false),
                    ForkedTrunk = table.Column<bool>(type: "boolean", nullable: false),
                    ForkCrack = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrunkInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrunkInspections_Inspections_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "Inspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrownInspections_InspectionId",
                table: "CrownInspections",
                column: "InspectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StemBaseInspections_InspectionId",
                table: "StemBaseInspections",
                column: "InspectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrunkInspections_InspectionId",
                table: "TrunkInspections",
                column: "InspectionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrownInspections");

            migrationBuilder.DropTable(
                name: "StemBaseInspections");

            migrationBuilder.DropTable(
                name: "TrunkInspections");
        }
    }
}
