namespace DotNet8.WebApi.Services
{
    using DotNet8.WebApi.Data;
    using DotNet8.WebApi.Dtos;
    using DotNet8.WebApi.Entities;
    using Microsoft.EntityFrameworkCore;

    public class InspectionService(AppDbContext context) : IInspectionService
    {
        /// <summary>
        /// Creates a new inspection for a tree including child inspection entities, sets last inspection on the tree and next inspection date
        /// (crown, trunk, and stem base) and optional arboricultural measures.
        /// </summary>
        public async Task<Inspection> CreateInspectionAsync(CreateInspectionDto request, int userId)
        {
            // Create the Inspection entity from the request DTO
            var inspection = new Inspection
            {
                TreeId = request.TreeId,
                PerformedAt = DateTime.UtcNow,
                IsSafeForTraffic = request.IsSafeForTraffic,
                UserId = userId,
                NewInspectionIntervall = request.NewInspectionIntervall,
                DevelopmentalStage = request.DevelopmentalStage ?? string.Empty,
                Vitality = request.Vitality,
                Description = request.Description ?? string.Empty
            };

            // Verify that the referenced tree exists and belongs to the current user
            var tree = await context.Trees
                .SingleOrDefaultAsync(t => t.Id == request.TreeId && t.UserId == userId);
            if (tree == null)
            {
                throw new InvalidOperationException(
                    $"Tree with id {request.TreeId} not found for the current user.");
            }

            // If arboricultural measures were specified, validate and load them
            if (request.ArboriculturalMeasureIds.Any())
            {
                // Remove duplicate ids
                var measureIds = request.ArboriculturalMeasureIds.Distinct().ToList();

                // Load measures that belong to the current user
                var measures = await context.ArboriculturalMeasures
                    .Where(m => measureIds.Contains(m.Id) && m.UserId == userId)
                    .ToListAsync();

                // Determine if any requested ids were not found
                var missingIds = measureIds.Except(measures.Select(m => m.Id)).ToList();
                if (missingIds.Any())
                {
                    throw new InvalidOperationException(
                        $"Arboricultural measures not found for the current user: {string.Join(", ", missingIds)}");
                }

                // Assign measures to this inspection
                inspection.ArboriculturalMeasures = measures;
            }

            // Begin a transaction only if the database provider supports it
            await using var transaction = context.Database.IsRelational()
                ? await context.Database.BeginTransactionAsync()
                : null;

            // Save the inspection first, so we get a database-generated ID
            context.Inspections.Add(inspection);
            await context.SaveChangesAsync();

            // Map crown, trunk, and stem base inspection details from the DTO
            CrownInspection crownInspection = MapCreateInspectionDtoToCrownInspectionEntity(request, inspection);
            TrunkInspection trunkInspection = MapCreateInspectionDtoToTrunkInspectionEntity(request, inspection);
            StemBaseInspection stemBaseInspection = MapCreateInspectionDtoToStemBaseInspectionEnity(request, inspection);

            // Add child inspection entities to the context
            context.CrownInspections.Add(crownInspection);
            context.TrunkInspections.Add(trunkInspection);
            context.StemBaseInspections.Add(stemBaseInspection);

            // Set navigation properties
            inspection.CrownInspection = crownInspection;
            inspection.TrunkInspection = trunkInspection;
            inspection.StemBaseInspection = stemBaseInspection;

            // Update the tree with information about the inspection
            tree.LastInspectionId = inspection.Id;
            tree.NextInspection = DateTime.UtcNow.AddMonths(inspection.NewInspectionIntervall);

            // Persist all changes
            await context.SaveChangesAsync();

            // Commit the transaction if one was opened
            if (transaction != null)
            {
                await transaction.CommitAsync();
            }

            // Reload the inspection with all navigation properties,
            // ensuring the returned object contains the persisted state
            return await context.Inspections
                .Include(i => i.CrownInspection)
                .Include(i => i.TrunkInspection)
                .Include(i => i.StemBaseInspection)
                .SingleAsync(i => i.Id == inspection.Id && i.UserId == userId);
        }


    

        public Task<bool> DeleteInspectionAsync(int inspectionId, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Inspection>> GetInspectionsByTreeIdAsync(int treeId, int userId)
        {
            return await context.Inspections
                .Include(inspection => inspection.CrownInspection)
                .Include(inspection => inspection.TrunkInspection)
                .Include(inspection => inspection.StemBaseInspection)
                .Include(inspection => inspection.ArboriculturalMeasures)
                .Where(inspection => inspection.TreeId == treeId && inspection.UserId == userId)
                .ToListAsync();
        }

        public Task<List<Inspection>> GetAllInspectionsAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Inspection?> GetInspectionByIdAsync(int inspectionId, int userId)
        {
            return context.Inspections
                .Include(inspection => inspection.CrownInspection)
                .Include(inspection => inspection.TrunkInspection)
                .Include(inspection => inspection.StemBaseInspection)
                .Include(inspection => inspection.ArboriculturalMeasures)
                .SingleOrDefaultAsync(inspection =>
                    inspection.Id == inspectionId && inspection.UserId == userId);
        }
        /// <summary>
        /// Creates a StemBaseInspection entity from the CreateInspectionDto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="inspection"></param>
        /// <returns></returns>
        private static StemBaseInspection MapCreateInspectionDtoToStemBaseInspectionEnity(CreateInspectionDto request, Inspection inspection)
        {
            return new StemBaseInspection
            {
                InspectionId = inspection.Id,
                Notes = request.StemBaseInspection?.Notes ?? string.Empty,
                Description = request.StemBaseInspection?.Description ?? string.Empty,
                Excavation = request.StemBaseInspection?.Excavation ?? false,
                ExcavationDescription = request.StemBaseInspection?.ExcavationDescription ?? string.Empty,
                AdventitiousRootFormation = request.StemBaseInspection?.AdventitiousRootFormation ?? false,
                AdventitiousRootFormationDescription = request.StemBaseInspection?.AdventitiousRootFormationDescription ?? string.Empty,
                Exudation = request.StemBaseInspection?.Exudation ?? false,
                ExudationDescription = request.StemBaseInspection?.ExudationDescription ?? string.Empty,
                StructuresAtStemBase = request.StemBaseInspection?.StructuresAtStemBase ?? false,
                StructuresAtStemBaseDescription = request.StemBaseInspection?.StructuresAtStemBaseDescription ?? string.Empty,
                StructuresNearTree = request.StemBaseInspection?.StructuresNearTree ?? false,
                StructuresNearTreeDescription = request.StemBaseInspection?.StructuresNearTreeDescription ?? string.Empty,
                BulgeOrSwelling = request.StemBaseInspection?.BulgeOrSwelling ?? false,
                BulgeOrSwellingDescription = request.StemBaseInspection?.BulgeOrSwellingDescription ?? string.Empty,
                ForeignVegetation = request.StemBaseInspection?.ForeignVegetation ?? false,
                ForeignVegetationDescription = request.StemBaseInspection?.ForeignVegetationDescription ?? string.Empty,
                BoreDust = request.StemBaseInspection?.BoreDust ?? false,
                BoreDustDescription = request.StemBaseInspection?.BoreDustDescription ?? string.Empty,
                Bottleneck = request.StemBaseInspection?.Bottleneck ?? false,
                BottleneckDescription = request.StemBaseInspection?.BottleneckDescription ?? string.Empty,
                ForeignObject = request.StemBaseInspection?.ForeignObject ?? false,
                ForeignObjectDescription = request.StemBaseInspection?.ForeignObjectDescription ?? string.Empty,
                HabitatStructures = request.StemBaseInspection?.HabitatStructures ?? false,
                HabitatStructuresDescription = request.StemBaseInspection?.HabitatStructuresDescription ?? string.Empty,
                TreeOnSlope = request.StemBaseInspection?.TreeOnSlope ?? false,
                TreeOnSlopeDescription = request.StemBaseInspection?.TreeOnSlopeDescription ?? string.Empty,
                ResinFlow = request.StemBaseInspection?.ResinFlow ?? false,
                ResinFlowDescription = request.StemBaseInspection?.ResinFlowDescription ?? string.Empty,
                Cavity = request.StemBaseInspection?.Cavity ?? false,
                CavityDescription = request.StemBaseInspection?.CavityDescription ?? string.Empty,
                Canker = request.StemBaseInspection?.Canker ?? false,
                CankerDescription = request.StemBaseInspection?.CankerDescription ?? string.Empty,
                OpenDecay = request.StemBaseInspection?.OpenDecay ?? false,
                OpenDecayDescription = request.StemBaseInspection?.OpenDecayDescription ?? string.Empty,
                FungalFruitingBody = request.StemBaseInspection?.FungalFruitingBody ?? false,
                FungalFruitingBodyDescription = request.StemBaseInspection?.FungalFruitingBodyDescription ?? string.Empty,
                SlimeFlux = request.StemBaseInspection?.SlimeFlux ?? false,
                SlimeFluxDescription = request.StemBaseInspection?.SlimeFluxDescription ?? string.Empty,
                StemBaseThickened = request.StemBaseInspection?.StemBaseThickened ?? false,
                StemBaseThickenedDescription = request.StemBaseInspection?.StemBaseThickenedDescription ?? string.Empty,
                CompressionDamage = request.StemBaseInspection?.CompressionDamage ?? false,
                CompressionDamageDescription = request.StemBaseInspection?.CompressionDamageDescription ?? string.Empty,
                Overfilled = request.StemBaseInspection?.Overfilled ?? false,
                OverfilledDescription = request.StemBaseInspection?.OverfilledDescription ?? string.Empty,
                GraftPoint = request.StemBaseInspection?.GraftPoint ?? false,
                GraftPointDescription = request.StemBaseInspection?.GraftPointDescription ?? string.Empty,
                GirdlingRoot = request.StemBaseInspection?.GirdlingRoot ?? false,
                GirdlingRootDescription = request.StemBaseInspection?.GirdlingRootDescription ?? string.Empty,
                RootDamage = request.StemBaseInspection?.RootDamage ?? false,
                RootDamageDescription = request.StemBaseInspection?.RootDamageDescription ?? string.Empty
            };
        }
        /// <summary>
        /// Creates a TrunkInspection entity from the CreateInspectionDto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="inspection"></param>
        /// <returns></returns>
        private static TrunkInspection MapCreateInspectionDtoToTrunkInspectionEntity(CreateInspectionDto request, Inspection inspection)
        {
            return new TrunkInspection
            {
                InspectionId = inspection.Id,
                Notes = request.TrunkInspection?.Notes ?? string.Empty,
                Description = request.TrunkInspection?.Description ?? string.Empty,
                AbioticDisturbance = request.TrunkInspection?.AbioticDisturbance ?? false,
                AbioticDisturbanceDescription = request.TrunkInspection?.AbioticDisturbanceDescription ?? string.Empty,
                BranchBreakWound = request.TrunkInspection?.BranchBreakWound ?? false,
                BranchBreakWoundDescription = request.TrunkInspection?.BranchBreakWoundDescription ?? string.Empty,
                PruningWound = request.TrunkInspection?.PruningWound ?? false,
                PruningWoundDescription = request.TrunkInspection?.PruningWoundDescription ?? string.Empty,
                Exudation = request.TrunkInspection?.Exudation ?? false,
                ExudationDescription = request.TrunkInspection?.ExudationDescription ?? string.Empty,
                TreeRemoved = request.TrunkInspection?.TreeRemoved ?? false,
                TreeRemovedDescription = request.TrunkInspection?.TreeRemovedDescription ?? string.Empty,
                BulgeOrSwelling = request.TrunkInspection?.BulgeOrSwelling ?? false,
                BulgeOrSwellingDescription = request.TrunkInspection?.BulgeOrSwellingDescription ?? string.Empty,
                ForeignVegetation = request.TrunkInspection?.ForeignVegetation ?? false,
                ForeignVegetationDescription = request.TrunkInspection?.ForeignVegetationDescription ?? string.Empty,
                BioticDisturbance = request.TrunkInspection?.BioticDisturbance ?? false,
                BioticDisturbanceDescription = request.TrunkInspection?.BioticDisturbanceDescription ?? string.Empty,
                LightningDamage = request.TrunkInspection?.LightningDamage ?? false,
                LightningDamageDescription = request.TrunkInspection?.LightningDamageDescription ?? string.Empty,
                LeavesBrokenOff = request.TrunkInspection?.LeavesBrokenOff ?? false,
                LeavesBrokenOffDescription = request.TrunkInspection?.LeavesBrokenOffDescription ?? string.Empty,
                Deformed = request.TrunkInspection?.Deformed ?? false,
                DeformedDescription = request.TrunkInspection?.DeformedDescription ?? string.Empty,
                SpiralGrain = request.TrunkInspection?.SpiralGrain ?? false,
                SpiralGrainDescription = request.TrunkInspection?.SpiralGrainDescription ?? string.Empty,
                CompressionFork = request.TrunkInspection?.CompressionFork ?? false,
                CompressionForkDescription = request.TrunkInspection?.CompressionForkDescription ?? string.Empty,
                IncludedBark = request.TrunkInspection?.IncludedBark ?? false,
                IncludedBarkDescription = request.TrunkInspection?.IncludedBarkDescription ?? string.Empty,
                ForeignObject = request.TrunkInspection?.ForeignObject ?? false,
                ForeignObjectDescription = request.TrunkInspection?.ForeignObjectDescription ?? string.Empty,
                Topped = request.TrunkInspection?.Topped ?? false,
                ToppedDescription = request.TrunkInspection?.ToppedDescription ?? string.Empty,
                HabitatStructures = request.TrunkInspection?.HabitatStructures ?? false,
                HabitatStructuresDescription = request.TrunkInspection?.HabitatStructuresDescription ?? string.Empty,
                ResinFlow = request.TrunkInspection?.ResinFlow ?? false,
                ResinFlowDescription = request.TrunkInspection?.ResinFlowDescription ?? string.Empty,
                Cavity = request.TrunkInspection?.Cavity ?? false,
                CavityDescription = request.TrunkInspection?.CavityDescription ?? string.Empty,
                Canker = request.TrunkInspection?.Canker ?? false,
                CankerDescription = request.TrunkInspection?.CankerDescription ?? string.Empty,
                LongitudinalCrack = request.TrunkInspection?.LongitudinalCrack ?? false,
                LongitudinalCrackDescription = request.TrunkInspection?.LongitudinalCrackDescription ?? string.Empty,
                MowingDamage = request.TrunkInspection?.MowingDamage ?? false,
                MowingDamageDescription = request.TrunkInspection?.MowingDamageDescription ?? string.Empty,
                Burl = request.TrunkInspection?.Burl ?? false,
                BurlDescription = request.TrunkInspection?.BurlDescription ?? string.Empty,
                OpenDecay = request.TrunkInspection?.OpenDecay ?? false,
                OpenDecayDescription = request.TrunkInspection?.OpenDecayDescription ?? string.Empty,
                FungalFruitingBody = request.TrunkInspection?.FungalFruitingBody ?? false,
                FungalFruitingBodyDescription = request.TrunkInspection?.FungalFruitingBodyDescription ?? string.Empty,
                Leaning = request.TrunkInspection?.Leaning ?? false,
                LeaningDescription = request.TrunkInspection?.LeaningDescription ?? string.Empty,
                SlimeFlux = request.TrunkInspection?.SlimeFlux ?? false,
                SlimeFluxDescription = request.TrunkInspection?.SlimeFluxDescription ?? string.Empty,
                SecondaryRadialGrowthMissing = request.TrunkInspection?.SecondaryRadialGrowthMissing ?? false,
                SecondaryRadialGrowthMissingDescription = request.TrunkInspection?.SecondaryRadialGrowthMissingDescription ?? string.Empty,
                WoodpeckerHole = request.TrunkInspection?.WoodpeckerHole ?? false,
                WoodpeckerHoleDescription = request.TrunkInspection?.WoodpeckerHoleDescription ?? string.Empty,
                CompressionDamage = request.TrunkInspection?.CompressionDamage ?? false,
                CompressionDamageDescription = request.TrunkInspection?.CompressionDamageDescription ?? string.Empty,
                TorsionCrack = request.TrunkInspection?.TorsionCrack ?? false,
                TorsionCrackDescription = request.TrunkInspection?.TorsionCrackDescription ?? string.Empty,
                Deadwood = request.TrunkInspection?.Deadwood ?? false,
                DeadwoodDescription = request.TrunkInspection?.DeadwoodDescription ?? string.Empty,
                WidowmakerBranch = request.TrunkInspection?.WidowmakerBranch ?? false,
                WidowmakerBranchDescription = request.TrunkInspection?.WidowmakerBranchDescription ?? string.Empty,
                GraftPoint = request.TrunkInspection?.GraftPoint ?? false,
                GraftPointDescription = request.TrunkInspection?.GraftPointDescription ?? string.Empty,
                SupplyShadow = request.TrunkInspection?.SupplyShadow ?? false,
                SupplyShadowDescription = request.TrunkInspection?.SupplyShadowDescription ?? string.Empty,
                Wobbles = request.TrunkInspection?.Wobbles ?? false,
                WobblesDescription = request.TrunkInspection?.WobblesDescription ?? string.Empty,
                Wound = request.TrunkInspection?.Wound ?? false,
                WoundDescription = request.TrunkInspection?.WoundDescription ?? string.Empty,
                WoundCallusRidge = request.TrunkInspection?.WoundCallusRidge ?? false,
                WoundCallusRidgeDescription = request.TrunkInspection?.WoundCallusRidgeDescription ?? string.Empty,
                WoundCallusClosed = request.TrunkInspection?.WoundCallusClosed ?? false,
                WoundCallusClosedDescription = request.TrunkInspection?.WoundCallusClosedDescription ?? string.Empty,
                TensionFork = request.TrunkInspection?.TensionFork ?? false,
                TensionForkDescription = request.TrunkInspection?.TensionForkDescription ?? string.Empty,
                ForkedTrunk = request.TrunkInspection?.ForkedTrunk ?? false,
                ForkedTrunkDescription = request.TrunkInspection?.ForkedTrunkDescription ?? string.Empty,
                ForkCrack = request.TrunkInspection?.ForkCrack ?? false,
                ForkCrackDescription = request.TrunkInspection?.ForkCrackDescription ?? string.Empty
            };
        }
        /// <summary>
        /// Creates a CrownInspection entity from the CreateInspectionDto.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="inspection"></param>
        /// <returns></returns>
        private static CrownInspection MapCreateInspectionDtoToCrownInspectionEntity(CreateInspectionDto request, Inspection inspection)
        {
            return new CrownInspection
            {
                InspectionId = inspection.Id,
                Notes = request.CrownInspection?.Notes ?? string.Empty,
                Description = request.CrownInspection?.Description ?? string.Empty,
                AbioticDisturbance = request.CrownInspection?.AbioticDisturbance ?? false,
                AbioticDisturbanceDescription = request.CrownInspection?.AbioticDisturbanceDescription ?? string.Empty,
                Dying = request.CrownInspection?.Dying ?? false,
                DyingDescription = request.CrownInspection?.DyingDescription ?? string.Empty,
                OverloadedBranchOrCrown = request.CrownInspection?.OverloadedBranchOrCrown ?? false,
                OverloadedBranchOrCrownDescription = request.CrownInspection?.OverloadedBranchOrCrownDescription ?? string.Empty,
                BranchBreak = request.CrownInspection?.BranchBreak ?? false,
                BranchBreakDescription = request.CrownInspection?.BranchBreakDescription ?? string.Empty,
                BranchBreakWound = request.CrownInspection?.BranchBreakWound ?? false,
                BranchBreakWoundDescription = request.CrownInspection?.BranchBreakWoundDescription ?? string.Empty,
                PruningWound = request.CrownInspection?.PruningWound ?? false,
                PruningWoundDescription = request.CrownInspection?.PruningWoundDescription ?? string.Empty,
                Exudation = request.CrownInspection?.Exudation ?? false,
                ExudationDescription = request.CrownInspection?.ExudationDescription ?? string.Empty,
                TreeInGroup = request.CrownInspection?.TreeInGroup ?? false,
                TreeInGroupDescription = request.CrownInspection?.TreeInGroupDescription ?? string.Empty,
                TreeIsDead = request.CrownInspection?.TreeIsDead ?? false,
                TreeIsDeadDescription = request.CrownInspection?.TreeIsDeadDescription ?? string.Empty,
                ForeignVegetation = request.CrownInspection?.ForeignVegetation ?? false,
                ForeignVegetationDescription = request.CrownInspection?.ForeignVegetationDescription ?? string.Empty,
                BioticDisturbance = request.CrownInspection?.BioticDisturbance ?? false,
                BioticDisturbanceDescription = request.CrownInspection?.BioticDisturbanceDescription ?? string.Empty,
                LightningDamage = request.CrownInspection?.LightningDamage ?? false,
                LightningDamageDescription = request.CrownInspection?.LightningDamageDescription ?? string.Empty,
                Deformed = request.CrownInspection?.Deformed ?? false,
                DeformedDescription = request.CrownInspection?.DeformedDescription ?? string.Empty,
                CompressionFork = request.CrownInspection?.CompressionFork ?? false,
                CompressionForkDescription = request.CrownInspection?.CompressionForkDescription ?? string.Empty,
                DryBranches = request.CrownInspection?.DryBranches ?? false,
                DryBranchesDescription = request.CrownInspection?.DryBranchesDescription ?? string.Empty,
                IncludedBark = request.CrownInspection?.IncludedBark ?? false,
                IncludedBarkDescription = request.CrownInspection?.IncludedBarkDescription ?? string.Empty,
                OneSidedCrown = request.CrownInspection?.OneSidedCrown ?? false,
                OneSidedCrownDescription = request.CrownInspection?.OneSidedCrownDescription ?? string.Empty,
                ForeignObject = request.CrownInspection?.ForeignObject ?? false,
                ForeignObjectDescription = request.CrownInspection?.ForeignObjectDescription ?? string.Empty,
                Topped = request.CrownInspection?.Topped ?? false,
                ToppedDescription = request.CrownInspection?.ToppedDescription ?? string.Empty,
                HabitatStructure = request.CrownInspection?.HabitatStructure ?? false,
                HabitatStructureDescription = request.CrownInspection?.HabitatStructureDescription ?? string.Empty,
                ResinFlow = request.CrownInspection?.ResinFlow ?? false,
                ResinFlowDescription = request.CrownInspection?.ResinFlowDescription ?? string.Empty,
                Cavity = request.CrownInspection?.Cavity ?? false,
                CavityDescription = request.CrownInspection?.CavityDescription ?? string.Empty,
                CompetingBranch = request.CrownInspection?.CompetingBranch ?? false,
                CompetingBranchDescription = request.CrownInspection?.CompetingBranchDescription ?? string.Empty,
                CompetingTree = request.CrownInspection?.CompetingTree ?? false,
                CompetingTreeDescription = request.CrownInspection?.CompetingTreeDescription ?? string.Empty,
                Canker = request.CrownInspection?.Canker ?? false,
                CankerDescription = request.CrownInspection?.CankerDescription ?? string.Empty,
                CrownSecured = request.CrownInspection?.CrownSecured ?? false,
                CrownSecuredDescription = request.CrownInspection?.CrownSecuredDescription ?? string.Empty,
                LongitudinalCrack = request.CrownInspection?.LongitudinalCrack ?? false,
                LongitudinalCrackDescription = request.CrownInspection?.LongitudinalCrackDescription ?? string.Empty,
                ClearanceProfile2_50m = request.CrownInspection?.ClearanceProfile2_50m ?? false,
                ClearanceProfile2_50mDescription = request.CrownInspection?.ClearanceProfile2_50mDescription ?? string.Empty,
                ClearanceProfile4_50m = request.CrownInspection?.ClearanceProfile4_50m ?? false,
                ClearanceProfile4_50mDescription = request.CrownInspection?.ClearanceProfile4_50mDescription ?? string.Empty,
                Burl = request.CrownInspection?.Burl ?? false,
                BurlDescription = request.CrownInspection?.BurlDescription ?? string.Empty,
                OpenDecay = request.CrownInspection?.OpenDecay ?? false,
                OpenDecayDescription = request.CrownInspection?.OpenDecayDescription ?? string.Empty,
                WithoutLeaderShoot = request.CrownInspection?.WithoutLeaderShoot ?? false,
                WithoutLeaderShootDescription = request.CrownInspection?.WithoutLeaderShootDescription ?? string.Empty,
                FungalFruitingBody = request.CrownInspection?.FungalFruitingBody ?? false,
                FungalFruitingBodyDescription = request.CrownInspection?.FungalFruitingBodyDescription ?? string.Empty,
                RubbingBranches = request.CrownInspection?.RubbingBranches ?? false,
                RubbingBranchesDescription = request.CrownInspection?.RubbingBranchesDescription ?? string.Empty,
                SlimeFlux = request.CrownInspection?.SlimeFlux ?? false,
                SlimeFluxDescription = request.CrownInspection?.SlimeFluxDescription ?? string.Empty,
                SecondaryCrowns = request.CrownInspection?.SecondaryCrowns ?? false,
                SecondaryCrownsDescription = request.CrownInspection?.SecondaryCrownsDescription ?? string.Empty,
                WoodpeckerHole = request.CrownInspection?.WoodpeckerHole ?? false,
                WoodpeckerHoleDescription = request.CrownInspection?.WoodpeckerHoleDescription ?? string.Empty,
                CompressionDamage = request.CrownInspection?.CompressionDamage ?? false,
                CompressionDamageDescription = request.CrownInspection?.CompressionDamageDescription ?? string.Empty,
                TorsionCrack = request.CrownInspection?.TorsionCrack ?? false,
                TorsionCrackDescription = request.CrownInspection?.TorsionCrackDescription ?? string.Empty,
                Deadwood = request.CrownInspection?.Deadwood ?? false,
                DeadwoodDescription = request.CrownInspection?.DeadwoodDescription ?? string.Empty,
                WidowmakerBranch = request.CrownInspection?.WidowmakerBranch ?? false,
                WidowmakerBranchDescription = request.CrownInspection?.WidowmakerBranchDescription ?? string.Empty,
                UnfavorableCrownDevelopment = request.CrownInspection?.UnfavorableCrownDevelopment ?? false,
                UnfavorableCrownDevelopmentDescription = request.CrownInspection?.UnfavorableCrownDevelopmentDescription ?? string.Empty,
                GraftPoint = request.CrownInspection?.GraftPoint ?? false,
                GraftPointDescription = request.CrownInspection?.GraftPointDescription ?? string.Empty,
                UtilityLineConflict = request.CrownInspection?.UtilityLineConflict ?? false,
                UtilityLineConflictDescription = request.CrownInspection?.UtilityLineConflictDescription ?? string.Empty,
                TopDieback = request.CrownInspection?.TopDieback ?? false,
                TopDiebackDescription = request.CrownInspection?.TopDiebackDescription ?? string.Empty,
                Wound = request.CrownInspection?.Wound ?? false,
                WoundDescription = request.CrownInspection?.WoundDescription ?? string.Empty,
                WoundWithCallusRidge = request.CrownInspection?.WoundWithCallusRidge ?? false,
                WoundWithCallusRidgeDescription = request.CrownInspection?.WoundWithCallusRidgeDescription ?? string.Empty,
                WoundCallusClosed = request.CrownInspection?.WoundCallusClosed ?? false,
                WoundCallusClosedDescription = request.CrownInspection?.WoundCallusClosedDescription ?? string.Empty,
                TensionFork = request.CrownInspection?.TensionFork ?? false,
                TensionForkDescription = request.CrownInspection?.TensionForkDescription ?? string.Empty,
                ForkedCrown = request.CrownInspection?.ForkedCrown ?? false,
                ForkedCrownDescription = request.CrownInspection?.ForkedCrownDescription ?? string.Empty,
                ForkCrack = request.CrownInspection?.ForkCrack ?? false,
                ForkCrackDescription = request.CrownInspection?.ForkCrackDescription ?? string.Empty
            };
        }
    }
}
