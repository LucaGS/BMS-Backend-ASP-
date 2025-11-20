using DotNet8.WebApi.Data;
using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using DotNet8.WebApi.Services;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.ScalarWebApi.Tests;

public class ImageServiceTests
{
    private static AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task CreateImage_PersistsAndReturnsImage()
    {
        await using var context = CreateContext();
        var service = new ImageService(context);
        var request = new CreateImageDto
        {
            TreeId = 4,
            FileName = "tree.jpg",
            ContentType = "image/jpeg",
            Data = [1, 2, 3]
        };

        var image = await service.CreateImage(request, userId: 1);

        Assert.NotNull(image);
        Assert.True(image.Id > 0);
        Assert.Equal("tree.jpg", image.FileName);
        Assert.Equal(1, await context.Images.CountAsync());
    }

    [Fact]
    public async Task GetLastImage_ReturnsMostRecentForTree()
    {
        await using var context = CreateContext();
        await context.Images.AddRangeAsync(
            new Image { TreeId = 5, FileName = "first.jpg" },
            new Image { TreeId = 5, FileName = "second.jpg" },
            new Image { TreeId = 6, FileName = "other.jpg" });
        await context.SaveChangesAsync();

        var service = new ImageService(context);

        var last = await service.GetLastImage(treeId: 5, userId: 1);

        Assert.NotNull(last);
        Assert.Equal("second.jpg", last!.FileName);
    }

    [Fact]
    public async Task GetImages_ReturnsImagesForTree()
    {
        await using var context = CreateContext();
        await context.Images.AddRangeAsync(
            new Image { TreeId = 2, FileName = "a.jpg" },
            new Image { TreeId = 3, FileName = "b.jpg" },
            new Image { TreeId = 2, FileName = "c.jpg" });
        await context.SaveChangesAsync();

        var service = new ImageService(context);

        var images = await service.GetImages(treeId: 2, userId: 1);

        Assert.Equal(2, images.Count);
        Assert.All(images, img => Assert.Equal(2, img.TreeId));
    }
}
