using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;

namespace DotNet8.WebApi.Services
{
    public interface IImageService
    {
        /// <summary>
        /// Creates a new green area for the specified user.
        /// </summary>
        /// <param name="request">The creation payload supplied by the client.</param>
        /// <param name="userId">The identifier of the owning user.</param>
        Task<Image> CreateImage(CreateImageDto request, int userId);
        /// <summary>
        /// Creates a new green area for the specified user.
        /// </summary>
        /// <param name="treeId">The Id of the Tree, supplied by the client</param>
        /// <param name="userId">The identifier of the owning user.</param>
        /// returns>All for the specified tree.</returns>
        Task<List<Image>> GetImages(int treeId,  int userId);
        /// </summary>
        /// <param name="treeId">The Id of the Tree, supplied by the client</param>
        /// <param name="userId">The identifier of the owning user.</param>
        /// returns>Return the Last Image of the Tree.</returns>
        Task<Image?> GetLastImage(int treeId, int userId);

        /// <summary>
        /// Updates an image if the related tree belongs to the user.
        /// </summary>
        /// <param name="imageId">The Id of the image to update</param>
        /// <param name="request">The updated image payload</param>
        /// <param name="userId">The identifier of the owning user.</param>
        Task<Image?> UpdateImageAsync(int imageId, UpdateImageDto request, int userId);

        /// <summary>
        /// Deletes an image if the related tree belongs to the user.
        /// </summary>
        /// <param name="imageId">The Id of the image to delete</param>
        /// <param name="userId">The identifier of the owning user.</param>
        Task<bool> DeleteImageAsync(int imageId, int userId);
    }
}
