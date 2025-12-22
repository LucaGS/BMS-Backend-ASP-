using DotNet8.WebApi.Data;
using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;

namespace DotNet8.WebApi.Services
{
    public class ImageService(AppDbContext context) : IImageService
    {
        public Task<Image> CreateImage(CreateImageDto request, int userId)
        {
            Image image = new Image
            {
                TreeId = request.TreeId,
                FileName = request.FileName,
                ContentType = request.ContentType,
                Data = request.Data
            };
            context.Images.Add(image);
            context.SaveChanges();

           return Task.FromResult(image);
        }

        public Task<Image> GetLastImage(int treeId, int userId)
        {
            var image = context.Images
                .Where(img => img.TreeId == treeId)
                .OrderByDescending(img => img.Id)
                .FirstOrDefault();
            return Task.FromResult(image);
        }
        public Task<List<Image>> GetImages(int treeId, int userId)
        {
            var images = context.Images
                .Where(img => img.TreeId == treeId)
                .ToList();
            return Task.FromResult(images);
        }
    }
}
