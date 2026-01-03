using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using DotNet8.WebApi.Services;

namespace DotNet8.ScalarWebApi.Tests;

public class TreeServiceTests
{
    [Fact]
    public async Task CreateTreeAsync_ReturnsNull_WhenNumberExistsForUser()
    {
        await using var context = TestingHelpers.CreateContext();
        var service = new TreeService(context);
        await service.CreateTreeAsync(new CreateTreeDto { Number = 1, GreenAreaId = 1, Species = "Oak" }, userId: 1);

        var duplicate = await service.CreateTreeAsync(new CreateTreeDto { Number = 1, GreenAreaId = 2, Species = "Pine" }, userId: 1);

        Assert.Null(duplicate);
    }

    [Fact]
    public async Task UpdateTreeAsync_UpdatesFields_WhenOwnedByUser()
    {
        await using var context = TestingHelpers.CreateContext();
        var service = new TreeService(context);
        var created = await service.CreateTreeAsync(new CreateTreeDto
        {
            Number = 1,
            GreenAreaId = 1,
            Species = "Oak",
            Latitude = 1,
            Longitude = 1,
            CrownDiameterMeters = 2,
            CrownShape = "Rounded",
            TrafficSafetyExpectation = "Standard",
            TreeSizeMeters = 3,
            NumberOfTrunks = 1,
            TrunkDiameter1 = 10,
            TrunkDiameter2 = 0,
            TrunkDiameter3 = 0
        }, userId: 1);

        var updated = await service.UpdateTreeAsync(created!.Id, new UpdateTreeDto
        {
            Number = 2,
            GreenAreaId = 3,
            Species = "Maple",
            Latitude = 5,
            Longitude = 6,
            CrownDiameterMeters = 7,
            CrownShape = "Vase",
            TrafficSafetyExpectation = "High",
            TreeSizeMeters = 8,
            NumberOfTrunks = 2,
            TrunkDiameter1 = 11,
            TrunkDiameter2 = 12,
            TrunkDiameter3 = 13
        }, userId: 1);

        Assert.NotNull(updated);
        Assert.Equal(3, updated!.GreenAreaId);
        Assert.Equal("Maple", updated.Species);
        Assert.Equal(2, updated.Number);
        Assert.Equal(7, updated.CrownDiameterMeters);
        Assert.Equal(8, updated.TreeSizeMeters);
        Assert.Equal(12, updated.TrunkDiameter2);
        Assert.Equal("Vase", updated.CrownShape);
        Assert.Equal("High", updated.TrafficSafetyExpectation);
    }

    [Fact]
    public async Task UpdateTreeAsync_Throws_WhenNumberConflict()
    {
        await using var context = TestingHelpers.CreateContext();
        var service = new TreeService(context);
        var tree1 = await service.CreateTreeAsync(new CreateTreeDto { Number = 1, GreenAreaId = 1, Species = "Oak" }, 1);
        await service.CreateTreeAsync(new CreateTreeDto { Number = 2, GreenAreaId = 1, Species = "Pine" }, 1);

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            service.UpdateTreeAsync(tree1!.Id, new UpdateTreeDto { Number = 2, GreenAreaId = 1, Species = "Ash" }, 1));
    }

    [Fact]
    public async Task DeleteTreeAsync_ReturnsFalse_WhenNotOwned()
    {
        await using var context = TestingHelpers.CreateContext();
        var service = new TreeService(context);
        var tree = await service.CreateTreeAsync(new CreateTreeDto { Number = 1, GreenAreaId = 1, Species = "Oak" }, 1);

        var deleted = await service.DeleteTreeAsync(tree!.Id, userId: 2);

        Assert.False(deleted);
        Assert.Equal(1, context.Trees.Count());
    }
}
