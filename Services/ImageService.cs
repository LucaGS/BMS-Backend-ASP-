using DotNet8.WebApi.Data;
using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.WebApi.Services
{
    public class ImageService(AppDbContext context) : IImageService
    {
        public async Task<Image> CreateImage(CreateImageDto request, int userId)
        {
            var treeOwnedByUser = await context.Trees
                .AnyAsync(tree => tree.Id == request.TreeId && tree.UserId == userId);
            if (!treeOwnedByUser)
            {
                throw new InvalidOperationException(
                    $"Tree with id {request.TreeId} not found for the current user.");
            }

            var image = new Image
            {
                TreeId = request.TreeId,
                FileName = request.FileName,
                ContentType = request.ContentType,
                Data = request.Data
            };

            context.Images.Add(image);
            await context.SaveChangesAsync();

            return image;
        }

        public async Task<Image?> GetLastImage(int treeId, int userId)
        {
            var treeOwnedByUser = await context.Trees
                .AnyAsync(tree => tree.Id == treeId && tree.UserId == userId);
            if (!treeOwnedByUser)
            {
                return null;
            }

            return await context.Images
                .Where(img => img.TreeId == treeId)
                .OrderByDescending(img => img.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Image>> GetImages(int treeId, int userId)
        {
            var treeOwnedByUser = await context.Trees
                .AnyAsync(tree => tree.Id == treeId && tree.UserId == userId);
            if (!treeOwnedByUser)
            {
                return new List<Image>();
            }

            return await context.Images
                .Where(img => img.TreeId == treeId)
                .ToListAsync();
        }

        public async Task<Image?> UpdateImageAsync(int imageId, UpdateImageDto request, int userId)
        {
            var image = await context.Images
                .Join(context.Trees, img => img.TreeId, tree => tree.Id, (img, tree) => new { img, tree })
                .Where(x => x.img.Id == imageId && x.tree.UserId == userId)
                .Select(x => x.img)
                .SingleOrDefaultAsync();

            if (image == null)
            {
                return null;
            }

            image.FileName = request.FileName;
            image.ContentType = request.ContentType;
            image.Data = request.Data;

            await context.SaveChangesAsync();
            return image;
        }

        public async Task<bool> DeleteImageAsync(int imageId, int userId)
        {
            var image = await context.Images
                .Join(context.Trees, img => img.TreeId, tree => tree.Id, (img, tree) => new { img, tree })
                .Where(x => x.img.Id == imageId && x.tree.UserId == userId)
                .Select(x => x.img)
                .SingleOrDefaultAsync();

            if (image == null)
            {
                return false;
            }

            context.Images.Remove(image);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
