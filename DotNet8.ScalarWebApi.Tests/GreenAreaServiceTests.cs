using DotNet8.WebApi.Data;
using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using DotNet8.WebApi.Services;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.ScalarWebApi.Tests;

public class GreenAreaServiceTests
{
    private static AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task CreateGreenArea_PersistsEntityWithUser()
    {
        await using var context = CreateContext();
        var service = new GreenAreaService(context);
        var request = new CreateGreenAreaDto
        {
            Name = "Central Park",
            Latitude = 10.5,
            Longitude = 20.5
        };

        var result = await service.CreateGreenArea(request, userId: 7);

        Assert.NotNull(result);
        Assert.True(result.Id > 0);
        Assert.Equal("Central Park", result.Name);
        Assert.Equal(7, result.UserId);
        Assert.Equal(1, await context.GreenAreas.CountAsync());
    }

    [Fact]
    public async Task GetGreenAreas_FiltersByUser()
    {
        await using var context = CreateContext();
        await context.GreenAreas.AddRangeAsync(
            new GreenArea { Name = "A", UserId = 1 },
            new GreenArea { Name = "B", UserId = 2 },
            new GreenArea { Name = "C", UserId = 1 });
        await context.SaveChangesAsync();

        var service = new GreenAreaService(context);

        var areas = await service.GetGreenAreas(userId: 1);

        Assert.Equal(2, areas.Count);
        Assert.All(areas, a => Assert.Equal(1, a.UserId));
    }
}
