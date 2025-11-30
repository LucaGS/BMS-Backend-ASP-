using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;

namespace DotNet8.WebApi.Services
{
    /// <summary>
    /// Provides operations for managing green area entities per user.
    /// </summary>
    public interface IGreenAreaService
    {
        /// <summary>
        /// Creates a new green area for the specified user.
        /// </summary>
        /// <param name="request">The creation payload supplied by the client.</param>
        /// <param name="userId">The identifier of the owning user.</param>
        Task<GreenArea> CreateGreenArea(CreateGreenAreaDto request, int userId);

        /// <summary>
        /// Retrieves all green areas that belong to the given user.
        /// </summary>
        /// <param name="userId">The identifier of the owning user.</param>
        Task<List<GreenArea>> GetGreenAreas(int userId);

        /// <summary>
        /// Updates a green area owned by the specified user.
        /// </summary>
        /// <param name="greenAreaId">Identifier of the green area.</param>
        /// <param name="request">The update payload.</param>
        /// <param name="userId">The identifier of the owning user.</param>
        Task<GreenArea?> UpdateGreenAreaAsync(int greenAreaId, UpdateGreenAreaDto request, int userId);

        /// <summary>
        /// Deletes a green area owned by the specified user.
        /// </summary>
        /// <param name="greenAreaId">Identifier of the green area.</param>
        /// <param name="userId">The identifier of the owning user.</param>
        Task<bool> DeleteGreenAreaAsync(int greenAreaId, int userId);
    }
}
