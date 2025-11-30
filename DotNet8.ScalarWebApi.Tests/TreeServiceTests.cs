using DotNet8.WebApi.Data;
using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using DotNet8.WebApi.Services;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.ScalarWebApi.Tests;

public class TreeServiceTests
{
    private static AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task CreateTreeAsync_ReturnsNullWhenNumberExistsForUser()
    {
        await using var context = CreateContext();
        await context.Trees.AddAsync(new Tree { UserId = 5, Number = 10, Species = "Oak" });
        await context.SaveChangesAsync();

        var service = new TreeService(context);
        var request = new CreateTreeDto { Number = 10, Species = "Birch" };

        var result = await service.CreateTreeAsync(request, userId: 5);

        Assert.Null(result);
        Assert.Equal(1, await context.Trees.CountAsync());
    }

    [Fact]
    public async Task CreateTreeAsync_PersistsWhenUniquePerUser()
    {
        await using var context = CreateContext();
        var service = new TreeService(context);
        var request = new CreateTreeDto
        {
            Number = 1,
            Species = "Maple",
            GreenAreaId = 3,
            Latitude = 1.1,
            Longitude = 2.2,
            CrownDiameterMeters = 3.3,
            NumberOfTrunks = 2,
            TrunkDiameter1 = 12.5,
            TrunkDiameter2 = 10.2,
            TrunkDiameter3 = 0.0
        };

        var tree = await service.CreateTreeAsync(request, userId: 9);

        Assert.NotNull(tree);
        Assert.True(tree!.Id > 0);
        Assert.Equal(9, tree.UserId);
        Assert.Equal(3, tree.GreenAreaId);
        Assert.Equal("Maple", tree.Species);
        Assert.Equal(12.5, tree.TrunkDiameter1);
        Assert.Equal(10.2, tree.TrunkDiameter2);
        Assert.Equal(0.0, tree.TrunkDiameter3);
        Assert.Equal(1, await context.Trees.CountAsync());
    }

    [Fact]
    public async Task GetAllTreesAsync_ReturnsTreesForUser()
    {
        await using var context = CreateContext();
        await context.Trees.AddRangeAsync(
            new Tree { UserId = 1, Number = 1, Species = "A" },
            new Tree { UserId = 2, Number = 2, Species = "B" });
        await context.SaveChangesAsync();

        var service = new TreeService(context);

        var trees = await service.GetAllTreesAsync(userId: 1);

        Assert.Single(trees);
        Assert.Equal(1, trees[0].UserId);
    }

    [Fact]
    public async Task GetTreesByGreenAreaIdAsync_FiltersByAreaAndUser()
    {
        await using var context = CreateContext();
        await context.Trees.AddRangeAsync(
            new Tree { UserId = 1, GreenAreaId = 9, Number = 1, Species = "A" },
            new Tree { UserId = 1, GreenAreaId = 10, Number = 2, Species = "B" },
            new Tree { UserId = 2, GreenAreaId = 9, Number = 3, Species = "C" });
        await context.SaveChangesAsync();

        var service = new TreeService(context);

        var trees = await service.GetTreesByGreenAreaIdAsync(greenAreaId: 9, userId: 1);

        Assert.Single(trees);
        Assert.Equal(9, trees[0].GreenAreaId);
        Assert.Equal(1, trees[0].UserId);
    }
}
