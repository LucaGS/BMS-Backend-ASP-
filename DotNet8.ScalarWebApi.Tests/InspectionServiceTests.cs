using DotNet8.WebApi.Data;
using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using DotNet8.WebApi.Services;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.ScalarWebApi.Tests;

public class InspectionServiceTests
{
    private static AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task CreateInspectionAsync_SetsPerformedAtAndUpdatesTree()
    {
        await using var context = CreateContext();
        var tree = new Tree { UserId = 1, Number = 1, GreenAreaId = 1, Species = "Oak" };
        await context.Trees.AddAsync(tree);
        await context.SaveChangesAsync();

        var service = new InspectionService(context);
        var request = new CreateInspectionDto
        {
            TreeId = tree.Id,
            IsSafeForTraffic = true,
            NewInspectionIntervall = 12,
            DevelopmentalStage = "Mature",
            Vitality = 5,
            Description = "No issues",
            CrownInspection = new CreateCrownInspectionDto { Notes = "Healthy crown", Description = "Crown detail", AbioticDisturbance = true, TorsionCrack = true },
            TrunkInspection = new CreateTrunkInspectionDto { Notes = "Minor trunk scratch", Description = "Trunk detail", AbioticDisturbance = true, Wobbles = true },
            StemBaseInspection = new CreateStemBaseInspectionDto { Notes = "Stable stem base", Description = "Stem base detail", Exudation = true, GirdlingRoot = true }
        };
        var before = DateTime.UtcNow;

        var inspection = await service.CreateInspectionAsync(request, userId: 1);
        var after = DateTime.UtcNow;

        Assert.NotNull(inspection);
        Assert.True(inspection.Id > 0);
        Assert.InRange(inspection.PerformedAt, before.AddSeconds(-1), after.AddSeconds(1));
        Assert.Equal(request.NewInspectionIntervall, inspection.NewInspectionIntervall);
        Assert.Equal(request.DevelopmentalStage, inspection.DevelopmentalStage);
        Assert.Equal(request.Vitality, inspection.Vitality);
        Assert.Equal(request.Description, inspection.Description);
        Assert.Equal(request.CrownInspection.Notes, inspection.CrownInspection.Notes);
        Assert.Equal(request.CrownInspection.Description, inspection.CrownInspection.Description);
        Assert.True(inspection.CrownInspection.AbioticDisturbance);
        Assert.True(inspection.CrownInspection.TorsionCrack);
        Assert.Equal(request.TrunkInspection.Notes, inspection.TrunkInspection.Notes);
        Assert.Equal(request.TrunkInspection.Description, inspection.TrunkInspection.Description);
        Assert.True(inspection.TrunkInspection.AbioticDisturbance);
        Assert.True(inspection.TrunkInspection.Wobbles);
        Assert.Equal(request.StemBaseInspection.Notes, inspection.StemBaseInspection.Notes);
        Assert.Equal(request.StemBaseInspection.Description, inspection.StemBaseInspection.Description);
        Assert.True(inspection.StemBaseInspection.Exudation);
        Assert.True(inspection.StemBaseInspection.GirdlingRoot);

        var updatedTree = await context.Trees.FindAsync(tree.Id);
        Assert.Equal(inspection.Id, updatedTree!.LastInspectionId);
    }

    [Fact]
    public async Task CreateInspectionAsync_ThrowsWhenTreeMissing()
    {
        await using var context = CreateContext();
        var service = new InspectionService(context);
        var request = new CreateInspectionDto { TreeId = 999, IsSafeForTraffic = false };

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            service.CreateInspectionAsync(request, userId: 1));
    }

    [Fact]
    public async Task GetInspectionsByTreeIdAsync_FiltersByTreeAndUser()
    {
        await using var context = CreateContext();
        await context.Inspections.AddRangeAsync(
            new Inspection { TreeId = 2, UserId = 1 },
            new Inspection { TreeId = 2, UserId = 2 },
            new Inspection { TreeId = 3, UserId = 1 });
        await context.SaveChangesAsync();

        var service = new InspectionService(context);

        var inspections = await service.GetInspectionsByTreeIdAsync(treeId: 2, userId: 1);

        Assert.Single(inspections);
        Assert.Equal(1, inspections[0].UserId);
        Assert.Equal(2, inspections[0].TreeId);
    }

    [Fact]
    public async Task UpdateInspectionAsync_UpdatesValuesAndTreeNextInspection()
    {
        await using var context = CreateContext();
        var tree = new Tree { UserId = 1, Number = 1, GreenAreaId = 1, Species = "Oak" };
        context.Trees.Add(tree);
        var measure = new ArboriculturalMeasure { UserId = 1, MeasureName = "A", Description = "B" };
        context.ArboriculturalMeasures.Add(measure);
        await context.SaveChangesAsync();
        var service = new InspectionService(context);

        var created = await service.CreateInspectionAsync(new CreateInspectionDto
        {
            TreeId = tree.Id,
            IsSafeForTraffic = true,
            NewInspectionIntervall = 12,
            DevelopmentalStage = "Initial",
            Vitality = 3,
            Description = "Init",
            CrownInspection = new CreateCrownInspectionDto { Notes = "c", Description = "c" },
            TrunkInspection = new CreateTrunkInspectionDto { Notes = "t", Description = "t" },
            StemBaseInspection = new CreateStemBaseInspectionDto { Notes = "s", Description = "s" }
        }, userId: 1);

        var now = DateTime.UtcNow;
        var updated = await service.UpdateInspectionAsync(created.Id, new UpdateInspectionDto
        {
            IsSafeForTraffic = false,
            NewInspectionIntervall = 6,
            DevelopmentalStage = "Updated",
            Vitality = 1,
            Description = "Changed",
            ArboriculturalMeasureIds = new List<int> { measure.Id },
            CrownInspection = new CreateCrownInspectionDto { Notes = "c2", Description = "c2", AbioticDisturbance = true },
            TrunkInspection = new CreateTrunkInspectionDto { Notes = "t2", Description = "t2", AbioticDisturbance = true },
            StemBaseInspection = new CreateStemBaseInspectionDto { Notes = "s2", Description = "s2", Exudation = true }
        }, userId: 1);

        var treeAfter = await context.Trees.SingleAsync(t => t.Id == tree.Id);
        Assert.NotNull(updated);
        Assert.Equal("Updated", updated!.DevelopmentalStage);
        Assert.False(updated.IsSafeForTraffic);
        Assert.Single(updated.ArboriculturalMeasures);
        Assert.Equal("c2", updated.CrownInspection.Notes);
        Assert.Equal("t2", updated.TrunkInspection.Notes);
        Assert.Equal("s2", updated.StemBaseInspection.Notes);
        Assert.InRange(treeAfter.NextInspection, now.AddMonths(6).AddMinutes(-1), now.AddMonths(6).AddMinutes(1));
    }

    [Fact]
    public async Task DeleteInspectionAsync_UpdatesTreeLastInspection()
    {
        await using var context = CreateContext();
        var tree = new Tree { UserId = 1, Number = 1, GreenAreaId = 1, Species = "Oak" };
        context.Trees.Add(tree);
        await context.SaveChangesAsync();
        var service = new InspectionService(context);

        var first = await service.CreateInspectionAsync(new CreateInspectionDto
        {
            TreeId = tree.Id,
            IsSafeForTraffic = true,
            NewInspectionIntervall = 12,
            CrownInspection = new CreateCrownInspectionDto { Notes = "c", Description = "c" },
            TrunkInspection = new CreateTrunkInspectionDto { Notes = "t", Description = "t" },
            StemBaseInspection = new CreateStemBaseInspectionDto { Notes = "s", Description = "s" }
        }, userId: 1);

        var second = await service.CreateInspectionAsync(new CreateInspectionDto
        {
            TreeId = tree.Id,
            IsSafeForTraffic = false,
            NewInspectionIntervall = 1,
            CrownInspection = new CreateCrownInspectionDto { Notes = "c2", Description = "c2" },
            TrunkInspection = new CreateTrunkInspectionDto { Notes = "t2", Description = "t2" },
            StemBaseInspection = new CreateStemBaseInspectionDto { Notes = "s2", Description = "s2" }
        }, userId: 1);

        var deleted = await service.DeleteInspectionAsync(second.Id, userId: 1);

        var treeAfter = await context.Trees.SingleAsync(t => t.Id == tree.Id);
        Assert.True(deleted);
        Assert.Equal(first.Id, treeAfter.LastInspectionId);
        Assert.True(treeAfter.NextInspection > DateTime.MinValue);
    }
}
