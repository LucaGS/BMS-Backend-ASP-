using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DotNet8.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionsAndMeasures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"TrunkInspections\" DROP COLUMN IF EXISTS \"TopDieback\";");

            migrationBuilder.DropColumn(
                name: "BreakageSafety",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "DamageLevel",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "StandStability",
                table: "Inspections");

            migrationBuilder.AddColumn<string>(
                name: "AbioticDisturbanceDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BioticDisturbanceDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BranchBreakWoundDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BulgeOrSwellingDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BurlDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CankerDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CavityDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompressionDamageDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompressionForkDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeadwoodDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeformedDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExudationDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ForeignObjectDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ForeignVegetationDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ForkCrackDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ForkedTrunkDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FungalFruitingBodyDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GraftPointDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HabitatStructuresDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IncludedBarkDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LeaningDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LeavesBrokenOffDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LightningDamageDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LongitudinalCrackDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MowingDamageDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OpenDecayDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PruningWoundDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResinFlowDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryRadialGrowthMissingDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SlimeFluxDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpiralGrainDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupplyShadowDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TensionForkDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ToppedDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TorsionCrackDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TreeRemovedDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WidowmakerBranchDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WobblesDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WoodpeckerHoleDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WoundCallusClosedDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WoundCallusRidgeDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WoundDescription",
                table: "TrunkInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdventitiousRootFormationDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BoreDustDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BottleneckDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BulgeOrSwellingDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CankerDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CavityDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompressionDamageDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExcavationDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExudationDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ForeignObjectDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ForeignVegetationDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FungalFruitingBodyDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GirdlingRootDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GraftPointDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HabitatStructuresDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OpenDecayDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OverfilledDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResinFlowDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RootDamageDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SlimeFluxDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StemBaseThickenedDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StructuresAtStemBaseDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StructuresNearTreeDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TreeOnSlopeDescription",
                table: "StemBaseInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AbioticDisturbanceDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BioticDisturbanceDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BranchBreakDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BranchBreakWoundDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BurlDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CankerDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CavityDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClearanceProfile2_50mDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClearanceProfile4_50mDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompetingBranchDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompetingTreeDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompressionDamageDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompressionForkDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CrownSecuredDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeadwoodDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeformedDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DryBranchesDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DyingDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExudationDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ForeignObjectDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ForeignVegetationDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ForkCrackDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ForkedCrownDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FungalFruitingBodyDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GraftPointDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HabitatStructureDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IncludedBarkDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LightningDamageDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LongitudinalCrackDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OneSidedCrownDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OpenDecayDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OverloadedBranchOrCrownDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PruningWoundDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResinFlowDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RubbingBranchesDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryCrownsDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SlimeFluxDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TensionForkDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TopDiebackDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ToppedDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TorsionCrackDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TreeInGroupDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TreeIsDeadDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnfavorableCrownDevelopmentDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UtilityLineConflictDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WidowmakerBranchDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WithoutLeaderShootDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WoodpeckerHoleDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WoundCallusClosedDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WoundDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WoundWithCallusRidgeDescription",
                table: "CrownInspections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ArboriculturalMeasures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    MeasureName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArboriculturalMeasures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArboriculturalMeasureInspection",
                columns: table => new
                {
                    ArboriculturalMeasuresId = table.Column<int>(type: "integer", nullable: false),
                    InspectionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArboriculturalMeasureInspection", x => new { x.ArboriculturalMeasuresId, x.InspectionsId });
                    table.ForeignKey(
                        name: "FK_ArboriculturalMeasureInspection_ArboriculturalMeasures_Arbo~",
                        column: x => x.ArboriculturalMeasuresId,
                        principalTable: "ArboriculturalMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArboriculturalMeasureInspection_Inspections_InspectionsId",
                        column: x => x.InspectionsId,
                        principalTable: "Inspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArboriculturalMeasureInspection_InspectionsId",
                table: "ArboriculturalMeasureInspection",
                column: "InspectionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArboriculturalMeasureInspection");

            migrationBuilder.DropTable(
                name: "ArboriculturalMeasures");

            migrationBuilder.DropColumn(
                name: "AbioticDisturbanceDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "BioticDisturbanceDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "BranchBreakWoundDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "BulgeOrSwellingDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "BurlDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "CankerDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "CavityDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "CompressionDamageDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "CompressionForkDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "DeadwoodDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "DeformedDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "ExudationDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "ForeignObjectDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "ForeignVegetationDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "ForkCrackDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "ForkedTrunkDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "FungalFruitingBodyDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "GraftPointDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "HabitatStructuresDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "IncludedBarkDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "LeaningDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "LeavesBrokenOffDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "LightningDamageDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "LongitudinalCrackDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "MowingDamageDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "OpenDecayDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "PruningWoundDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "ResinFlowDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "SecondaryRadialGrowthMissingDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "SlimeFluxDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "SpiralGrainDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "SupplyShadowDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "TensionForkDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "ToppedDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "TorsionCrackDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "TreeRemovedDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "WidowmakerBranchDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "WobblesDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "WoodpeckerHoleDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "WoundCallusClosedDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "WoundCallusRidgeDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "WoundDescription",
                table: "TrunkInspections");

            migrationBuilder.DropColumn(
                name: "AdventitiousRootFormationDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "BoreDustDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "BottleneckDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "BulgeOrSwellingDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "CankerDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "CavityDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "CompressionDamageDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "ExcavationDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "ExudationDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "ForeignObjectDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "ForeignVegetationDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "FungalFruitingBodyDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "GirdlingRootDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "GraftPointDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "HabitatStructuresDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "OpenDecayDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "OverfilledDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "ResinFlowDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "RootDamageDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "SlimeFluxDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "StemBaseThickenedDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "StructuresAtStemBaseDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "StructuresNearTreeDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "TreeOnSlopeDescription",
                table: "StemBaseInspections");

            migrationBuilder.DropColumn(
                name: "AbioticDisturbanceDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "BioticDisturbanceDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "BranchBreakDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "BranchBreakWoundDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "BurlDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "CankerDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "CavityDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "ClearanceProfile2_50mDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "ClearanceProfile4_50mDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "CompetingBranchDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "CompetingTreeDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "CompressionDamageDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "CompressionForkDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "CrownSecuredDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "DeadwoodDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "DeformedDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "DryBranchesDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "DyingDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "ExudationDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "ForeignObjectDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "ForeignVegetationDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "ForkCrackDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "ForkedCrownDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "FungalFruitingBodyDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "GraftPointDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "HabitatStructureDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "IncludedBarkDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "LightningDamageDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "LongitudinalCrackDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "OneSidedCrownDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "OpenDecayDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "OverloadedBranchOrCrownDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "PruningWoundDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "ResinFlowDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "RubbingBranchesDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "SecondaryCrownsDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "SlimeFluxDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "TensionForkDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "TopDiebackDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "ToppedDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "TorsionCrackDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "TreeInGroupDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "TreeIsDeadDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "UnfavorableCrownDevelopmentDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "UtilityLineConflictDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "WidowmakerBranchDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "WithoutLeaderShootDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "WoodpeckerHoleDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "WoundCallusClosedDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "WoundDescription",
                table: "CrownInspections");

            migrationBuilder.DropColumn(
                name: "WoundWithCallusRidgeDescription",
                table: "CrownInspections");

            migrationBuilder.AddColumn<bool>(
                name: "TopDieback",
                table: "TrunkInspections",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddColumn<int>(
                name: "StandStability",
                table: "Inspections",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
