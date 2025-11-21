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
            DamageLevel = 2,
            StandStability = 3,
            BreakageSafety = 4,
            Vitality = 5,
            Description = "No issues"
        };
        var before = DateTime.UtcNow;

        var inspection = await service.CreateInspectionAsync(request, userId: 1);
        var after = DateTime.UtcNow;

        Assert.NotNull(inspection);
        Assert.True(inspection.Id > 0);
        Assert.InRange(inspection.PerformedAt, before.AddSeconds(-1), after.AddSeconds(1));
        Assert.Equal(request.NewInspectionIntervall, inspection.NewInspectionIntervall);
        Assert.Equal(request.DevelopmentalStage, inspection.DevelopmentalStage);
        Assert.Equal(request.DamageLevel, inspection.DamageLevel);
        Assert.Equal(request.StandStability, inspection.StandStability);
        Assert.Equal(request.BreakageSafety, inspection.BreakageSafety);
        Assert.Equal(request.Vitality, inspection.Vitality);
        Assert.Equal(request.Description, inspection.Description);

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
}
