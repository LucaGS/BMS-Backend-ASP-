using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using DotNet8.WebApi.Services;

namespace DotNet8.ScalarWebApi.Tests;

public class ImageServiceTests
{
    [Fact]
    public async Task CreateImage_Throws_WhenTreeNotOwned()
    {
        await using var context = TestingHelpers.CreateContext();
        context.Trees.Add(new Tree { Id = 1, UserId = 2, Number = 1, GreenAreaId = 1, Species = "Oak" });
        await context.SaveChangesAsync();
        var service = new ImageService(context);

        await Assert.ThrowsAsync<InvalidOperationException>(() => service.CreateImage(new CreateImageDto
        {
            TreeId = 1,
            FileName = "a",
            ContentType = "image/png",
            Data = Array.Empty<byte>()
        }, userId: 1));
    }

    [Fact]
    public async Task UpdateImageAsync_Updates_WhenOwned()
    {
        await using var context = TestingHelpers.CreateContext();
        context.Trees.Add(new Tree { Id = 1, UserId = 1, Number = 1, GreenAreaId = 1, Species = "Oak" });
        context.Images.Add(new Image { Id = 5, TreeId = 1, FileName = "old", ContentType = "image/png", Data = new byte[] { 1 } });
        await context.SaveChangesAsync();
        var service = new ImageService(context);

        var updated = await service.UpdateImageAsync(5, new UpdateImageDto
        {
            FileName = "new",
            ContentType = "image/jpg",
            Data = new byte[] { 1, 2 }
        }, userId: 1);

        Assert.NotNull(updated);
        Assert.Equal("new", updated!.FileName);
        Assert.Equal("image/jpg", updated.ContentType);
        Assert.Equal(2, updated.Data.Length);
    }

    [Fact]
    public async Task DeleteImageAsync_ReturnsFalse_WhenNotOwned()
    {
        await using var context = TestingHelpers.CreateContext();
        context.Trees.Add(new Tree { Id = 1, UserId = 2, Number = 1, GreenAreaId = 1, Species = "Oak" });
        context.Images.Add(new Image { Id = 7, TreeId = 1, FileName = "old", ContentType = "image/png", Data = Array.Empty<byte>() });
        await context.SaveChangesAsync();
        var service = new ImageService(context);

        var deleted = await service.DeleteImageAsync(imageId: 7, userId: 1);

        Assert.False(deleted);
        Assert.Single(context.Images);
    }
}
