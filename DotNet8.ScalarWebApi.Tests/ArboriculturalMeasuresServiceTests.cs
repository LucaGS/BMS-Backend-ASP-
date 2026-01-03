using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using DotNet8.WebApi.Services;

namespace DotNet8.ScalarWebApi.Tests;

public class ArboriculturalMeasuresServiceTests
{
    [Fact]
    public async Task UpdateArboriculturalMeasureAsync_UpdatesFields()
    {
        await using var context = TestingHelpers.CreateContext();
        var service = new ArboriculturalMeasuresService(context);
        var created = await service.CreateArboriculturalMeasureAsync(new CreateArboriculturalMeasuresDto
        {
            MeasureName = "Old",
            Description = "Desc"
        }, UserId: 1);

        var updated = await service.UpdateArboriculturalMeasureAsync(created.Id, new UpdateArboriculturalMeasuresDto
        {
            MeasureName = "New",
            Description = "Updated"
        }, userId: 1);

        Assert.NotNull(updated);
        Assert.Equal("New", updated!.MeasureName);
        Assert.Equal("Updated", updated.Description);
    }

    [Fact]
    public async Task DeleteArboriculturalMeasureAsync_ReturnsFalse_WhenNotOwned()
    {
        await using var context = TestingHelpers.CreateContext();
        var service = new ArboriculturalMeasuresService(context);
        await context.ArboriculturalMeasures.AddAsync(new ArboriculturalMeasure { MeasureName = "A", Description = "B", UserId = 2 });
        await context.SaveChangesAsync();

        var deleted = await service.DeleteArboriculturalMeasureAsync(id: 1, userId: 1);

        Assert.False(deleted);
        Assert.Single(context.ArboriculturalMeasures);
    }
}
