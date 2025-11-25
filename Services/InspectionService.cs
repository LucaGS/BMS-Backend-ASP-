namespace DotNet8.WebApi.Services
{
    using DotNet8.WebApi.Data;
    using DotNet8.WebApi.Dtos;
    using DotNet8.WebApi.Entities;
    using Microsoft.EntityFrameworkCore;

    public class InspectionService(AppDbContext context) : IInspectionService
    {
        public async Task<Inspection> CreateInspectionAsync(CreateInspectionDto request, int userId)
        {
            var inspection = new Inspection
            {
                TreeId = request.TreeId,
                PerformedAt = DateTime.UtcNow,
                IsSafeForTraffic = request.IsSafeForTraffic,
                UserId = userId,
                NewInspectionIntervall = request.NewInspectionIntervall,
                DevelopmentalStage = request.DevelopmentalStage ?? string.Empty,
                DamageLevel = request.DamageLevel,
                StandStability = request.StandStability,
                BreakageSafety = request.BreakageSafety,
                Vitality = request.Vitality,
                Description = request.Description ?? string.Empty
            };

            var tree = await context.Trees.FindAsync(request.TreeId);
            if (tree == null)
            {
                throw new InvalidOperationException($"Tree with id {request.TreeId} not found.");
            }

            context.Inspections.Add(inspection);

            // Persist inspection first to obtain its database-generated id, then wire it to the tree.
            await context.SaveChangesAsync();

            var crownInspection = new CrownInspection
            {
                InspectionId = inspection.Id,
                Notes = request.CrownInspection?.Notes ?? string.Empty,
                AbioticDisturbance = request.CrownInspection?.AbioticDisturbance ?? false,
                Dying = request.CrownInspection?.Dying ?? false,
                OverloadedBranchOrCrown = request.CrownInspection?.OverloadedBranchOrCrown ?? false,
                BranchBreak = request.CrownInspection?.BranchBreak ?? false,
                BranchBreakWound = request.CrownInspection?.BranchBreakWound ?? false,
                PruningWound = request.CrownInspection?.PruningWound ?? false,
                Exudation = request.CrownInspection?.Exudation ?? false,
                TreeInGroup = request.CrownInspection?.TreeInGroup ?? false,
                TreeIsDead = request.CrownInspection?.TreeIsDead ?? false,
                ForeignVegetation = request.CrownInspection?.ForeignVegetation ?? false,
                BioticDisturbance = request.CrownInspection?.BioticDisturbance ?? false,
                LightningDamage = request.CrownInspection?.LightningDamage ?? false,
                Deformed = request.CrownInspection?.Deformed ?? false,
                CompressionFork = request.CrownInspection?.CompressionFork ?? false,
                DryBranches = request.CrownInspection?.DryBranches ?? false,
                IncludedBark = request.CrownInspection?.IncludedBark ?? false,
                OneSidedCrown = request.CrownInspection?.OneSidedCrown ?? false,
                ForeignObject = request.CrownInspection?.ForeignObject ?? false,
                Topped = request.CrownInspection?.Topped ?? false,
                HabitatStructure = request.CrownInspection?.HabitatStructure ?? false,
                ResinFlow = request.CrownInspection?.ResinFlow ?? false,
                Cavity = request.CrownInspection?.Cavity ?? false,
                CompetingBranch = request.CrownInspection?.CompetingBranch ?? false,
                CompetingTree = request.CrownInspection?.CompetingTree ?? false,
                Canker = request.CrownInspection?.Canker ?? false,
                CrownSecured = request.CrownInspection?.CrownSecured ?? false,
                LongitudinalCrack = request.CrownInspection?.LongitudinalCrack ?? false,
                ClearanceProfile2_50m = request.CrownInspection?.ClearanceProfile2_50m ?? false,
                ClearanceProfile4_50m = request.CrownInspection?.ClearanceProfile4_50m ?? false,
                Burl = request.CrownInspection?.Burl ?? false,
                OpenDecay = request.CrownInspection?.OpenDecay ?? false,
                WithoutLeaderShoot = request.CrownInspection?.WithoutLeaderShoot ?? false,
                FungalFruitingBody = request.CrownInspection?.FungalFruitingBody ?? false,
                RubbingBranches = request.CrownInspection?.RubbingBranches ?? false,
                SlimeFlux = request.CrownInspection?.SlimeFlux ?? false,
                SecondaryCrowns = request.CrownInspection?.SecondaryCrowns ?? false,
                WoodpeckerHole = request.CrownInspection?.WoodpeckerHole ?? false,
                CompressionDamage = request.CrownInspection?.CompressionDamage ?? false,
                TorsionCrack = request.CrownInspection?.TorsionCrack ?? false,
                Deadwood = request.CrownInspection?.Deadwood ?? false,
                WidowmakerBranch = request.CrownInspection?.WidowmakerBranch ?? false,
                UnfavorableCrownDevelopment = request.CrownInspection?.UnfavorableCrownDevelopment ?? false,
                GraftPoint = request.CrownInspection?.GraftPoint ?? false,
                UtilityLineConflict = request.CrownInspection?.UtilityLineConflict ?? false,
                TopDieback = request.CrownInspection?.TopDieback ?? false,
                Wound = request.CrownInspection?.Wound ?? false,
                WoundWithCallusRidge = request.CrownInspection?.WoundWithCallusRidge ?? false,
                WoundCallusClosed = request.CrownInspection?.WoundCallusClosed ?? false,
                TensionFork = request.CrownInspection?.TensionFork ?? false,
                ForkedCrown = request.CrownInspection?.ForkedCrown ?? false,
                ForkCrack = request.CrownInspection?.ForkCrack ?? false
            };

            var trunkInspection = new TrunkInspection
            {
                InspectionId = inspection.Id,
                Notes = request.TrunkInspection?.Notes ?? string.Empty,
                AbioticDisturbance = request.TrunkInspection?.AbioticDisturbance ?? false,
                BranchBreakWound = request.TrunkInspection?.BranchBreakWound ?? false,
                PruningWound = request.TrunkInspection?.PruningWound ?? false,
                Exudation = request.TrunkInspection?.Exudation ?? false,
                TreeRemoved = request.TrunkInspection?.TreeRemoved ?? false,
                BulgeOrSwelling = request.TrunkInspection?.BulgeOrSwelling ?? false,
                ForeignVegetation = request.TrunkInspection?.ForeignVegetation ?? false,
                BioticDisturbance = request.TrunkInspection?.BioticDisturbance ?? false,
                LightningDamage = request.TrunkInspection?.LightningDamage ?? false,
                LeavesBrokenOff = request.TrunkInspection?.LeavesBrokenOff ?? false,
                Deformed = request.TrunkInspection?.Deformed ?? false,
                SpiralGrain = request.TrunkInspection?.SpiralGrain ?? false,
                CompressionFork = request.TrunkInspection?.CompressionFork ?? false,
                IncludedBark = request.TrunkInspection?.IncludedBark ?? false,
                ForeignObject = request.TrunkInspection?.ForeignObject ?? false,
                Topped = request.TrunkInspection?.Topped ?? false,
                HabitatStructures = request.TrunkInspection?.HabitatStructures ?? false,
                ResinFlow = request.TrunkInspection?.ResinFlow ?? false,
                Cavity = request.TrunkInspection?.Cavity ?? false,
                Canker = request.TrunkInspection?.Canker ?? false,
                LongitudinalCrack = request.TrunkInspection?.LongitudinalCrack ?? false,
                MowingDamage = request.TrunkInspection?.MowingDamage ?? false,
                Burl = request.TrunkInspection?.Burl ?? false,
                OpenDecay = request.TrunkInspection?.OpenDecay ?? false,
                FungalFruitingBody = request.TrunkInspection?.FungalFruitingBody ?? false,
                Leaning = request.TrunkInspection?.Leaning ?? false,
                SlimeFlux = request.TrunkInspection?.SlimeFlux ?? false,
                SecondaryRadialGrowthMissing = request.TrunkInspection?.SecondaryRadialGrowthMissing ?? false,
                WoodpeckerHole = request.TrunkInspection?.WoodpeckerHole ?? false,
                CompressionDamage = request.TrunkInspection?.CompressionDamage ?? false,
                TorsionCrack = request.TrunkInspection?.TorsionCrack ?? false,
                Deadwood = request.TrunkInspection?.Deadwood ?? false,
                WidowmakerBranch = request.TrunkInspection?.WidowmakerBranch ?? false,
                GraftPoint = request.TrunkInspection?.GraftPoint ?? false,
                SupplyShadow = request.TrunkInspection?.SupplyShadow ?? false,
                Wobbles = request.TrunkInspection?.Wobbles ?? false,
                Wound = request.TrunkInspection?.Wound ?? false,
                WoundCallusRidge = request.TrunkInspection?.WoundCallusRidge ?? false,
                WoundCallusClosed = request.TrunkInspection?.WoundCallusClosed ?? false,
                TensionFork = request.TrunkInspection?.TensionFork ?? false,
                ForkedTrunk = request.TrunkInspection?.ForkedTrunk ?? false,
                ForkCrack = request.TrunkInspection?.ForkCrack ?? false
            };

            var stemBaseInspection = new StemBaseInspection
            {
                InspectionId = inspection.Id,
                Notes = request.StemBaseInspection?.Notes ?? string.Empty,
                Excavation = request.StemBaseInspection?.Excavation ?? false,
                AdventitiousRootFormation = request.StemBaseInspection?.AdventitiousRootFormation ?? false,
                Exudation = request.StemBaseInspection?.Exudation ?? false,
                StructuresAtStemBase = request.StemBaseInspection?.StructuresAtStemBase ?? false,
                StructuresNearTree = request.StemBaseInspection?.StructuresNearTree ?? false,
                BulgeOrSwelling = request.StemBaseInspection?.BulgeOrSwelling ?? false,
                ForeignVegetation = request.StemBaseInspection?.ForeignVegetation ?? false,
                BoreDust = request.StemBaseInspection?.BoreDust ?? false,
                Bottleneck = request.StemBaseInspection?.Bottleneck ?? false,
                ForeignObject = request.StemBaseInspection?.ForeignObject ?? false,
                HabitatStructures = request.StemBaseInspection?.HabitatStructures ?? false,
                TreeOnSlope = request.StemBaseInspection?.TreeOnSlope ?? false,
                ResinFlow = request.StemBaseInspection?.ResinFlow ?? false,
                Cavity = request.StemBaseInspection?.Cavity ?? false,
                Canker = request.StemBaseInspection?.Canker ?? false,
                OpenDecay = request.StemBaseInspection?.OpenDecay ?? false,
                FungalFruitingBody = request.StemBaseInspection?.FungalFruitingBody ?? false,
                SlimeFlux = request.StemBaseInspection?.SlimeFlux ?? false,
                StemBaseThickened = request.StemBaseInspection?.StemBaseThickened ?? false,
                CompressionDamage = request.StemBaseInspection?.CompressionDamage ?? false,
                Overfilled = request.StemBaseInspection?.Overfilled ?? false,
                GraftPoint = request.StemBaseInspection?.GraftPoint ?? false,
                GirdlingRoot = request.StemBaseInspection?.GirdlingRoot ?? false,
                RootDamage = request.StemBaseInspection?.RootDamage ?? false
            };

            context.CrownInspections.Add(crownInspection);
            context.TrunkInspections.Add(trunkInspection);
            context.StemBaseInspections.Add(stemBaseInspection);

            inspection.CrownInspection = crownInspection;
            inspection.TrunkInspection = trunkInspection;
            inspection.StemBaseInspection = stemBaseInspection;

            tree.LastInspectionId = inspection.Id;

            await context.SaveChangesAsync();

            return inspection;
        }


        public Task<bool> DeleteInspectionAsync(int inspectionId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Inspection>> GetAllInspectionsAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Inspection> GetInspectionByIdAsync(int inspectionId, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Inspection>> GetInspectionsByTreeIdAsync(int treeId, int userId)
        {
            return await context.Inspections
                .Include(inspection => inspection.CrownInspection)
                .Include(inspection => inspection.TrunkInspection)
                .Include(inspection => inspection.StemBaseInspection)
                .Where(inspection => inspection.TreeId == treeId && inspection.UserId == userId)
                .ToListAsync();
        }
    }
}
