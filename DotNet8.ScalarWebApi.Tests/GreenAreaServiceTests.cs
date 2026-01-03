using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Services;

namespace DotNet8.ScalarWebApi.Tests;

public class GreenAreaServiceTests
{
    [Fact]
    public async Task UpdateGreenAreaAsync_ReturnsNull_WhenNotOwned()
    {
        await using var context = TestingHelpers.CreateContext();
        var service = new GreenAreaService(context);
        var created = await service.CreateGreenArea(new CreateGreenAreaDto { Name = "Park", Latitude = 1, Longitude = 1 }, userId: 1);

        var result = await service.UpdateGreenAreaAsync(created.Id, new UpdateGreenAreaDto { Name = "New", Latitude = 2, Longitude = 3 }, userId: 2);

        Assert.Null(result);
    }

    [Fact]
    public async Task DeleteGreenAreaAsync_RemovesOwnedArea()
    {
        await using var context = TestingHelpers.CreateContext();
        var service = new GreenAreaService(context);
        var created = await service.CreateGreenArea(new CreateGreenAreaDto { Name = "Park", Latitude = 1, Longitude = 1 }, userId: 1);

        var deleted = await service.DeleteGreenAreaAsync(created.Id, userId: 1);

        Assert.True(deleted);
        Assert.Empty(context.GreenAreas);
    }
}
