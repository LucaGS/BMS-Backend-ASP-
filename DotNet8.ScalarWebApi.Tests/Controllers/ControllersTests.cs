using DotNet8.WebApi.Controllers;
using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using DotNet8.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.ScalarWebApi.Tests;

public class ControllersTests
{
    [Fact]
    public async Task TreesController_CreateTree_ReturnsUnauthorized_WhenUserMissing()
    {
        await using var context = TestingHelpers.CreateContext();
        var controller = new TreesController(new FakeCurrentUserService(null, false), new TreeService(context));

        var result = await controller.CreateTree(new CreateTreeDto { Number = 1, GreenAreaId = 1, Species = "Oak" });

        Assert.IsType<UnauthorizedObjectResult>(result);
    }

    [Fact]
    public async Task TreesController_DeleteTree_ReturnsNoContent_WhenOwned()
    {
        await using var context = TestingHelpers.CreateContext();
        var service = new TreeService(context);
        var tree = await service.CreateTreeAsync(new CreateTreeDto { Number = 1, GreenAreaId = 1, Species = "Oak" }, userId: 1);
        var controller = new TreesController(new FakeCurrentUserService(1), service);

        var result = await controller.DeleteTree(tree!.Id);

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task GreenAreasController_Update_ReturnsNotFound_WhenNotOwned()
    {
        await using var context = TestingHelpers.CreateContext();
        var service = new GreenAreaService(context);
        var controller = new GreenAreasController(service, new FakeCurrentUserService(1));

        var response = await controller.UpdateGreenArea(99, new UpdateGreenAreaDto { Name = "x", Latitude = 0, Longitude = 0 });

        Assert.IsType<NotFoundResult>(response);
    }

    [Fact]
    public async Task ArboriculturalMeasuresController_Delete_ReturnsNoContent_WhenOwned()
    {
        await using var context = TestingHelpers.CreateContext();
        var service = new ArboriculturalMeasuresService(context);
        var measure = await service.CreateArboriculturalMeasureAsync(new CreateArboriculturalMeasuresDto
        {
            MeasureName = "M",
            Description = "D"
        }, UserId: 1);
        var controller = new ArboriculturalMeasuresController(new FakeCurrentUserService(1), service);

        var result = await controller.DeleteArboriculturalMeasure(measure.Id);

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task ImagesController_Update_ReturnsNotFound_WhenImageMissing()
    {
        await using var context = TestingHelpers.CreateContext();
        var controller = new ImagesController(new FakeCurrentUserService(1), new ImageService(context));

        var result = await controller.UpdateImage(123, new UpdateImageDto { FileName = "x", ContentType = "image/png", Data = Array.Empty<byte>() });

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task InspectionsController_GetAll_ReturnsUserScopedResults()
    {
        await using var context = TestingHelpers.CreateContext();
        var tree = new Tree { UserId = 1, Number = 1, GreenAreaId = 1, Species = "Oak" };
        context.Trees.Add(tree);
        context.Inspections.Add(new Inspection { TreeId = tree.Id, UserId = 1 });
        context.Inspections.Add(new Inspection { TreeId = tree.Id, UserId = 2 });
        await context.SaveChangesAsync();
        var service = new InspectionService(context);
        var controller = new InspectionsController(service, new FakeCurrentUserService(1));

        var result = await controller.GetAllInspections();

        var ok = Assert.IsType<OkObjectResult>(result);
        var list = Assert.IsAssignableFrom<IEnumerable<Inspection>>(ok.Value);
        Assert.Single(list);
        Assert.All(list, i => Assert.Equal(1, i.UserId));
    }
}
