using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;

namespace DotNet8.WebApi.Services
{
    /// <summary>
    /// Defines operations for creating and retrieving tree records.
    /// </summary>
    public interface ITreeService
    {
        /// <summary>
        /// Persists a new tree with the supplied data and returns it.
        /// </summary>
        /// <param name="request">Tree creation payload.</param>
        /// <param name="userId">Identifier of the owner.</param>
        Task<Tree?> CreateTreeAsync(CreateTreeDto request, int userId);

        /// <summary>
        /// Retrieves all trees owned by the given user.
        /// </summary>
        /// <param name="userId">Identifier of the owner.</param>
        Task<List<Tree>> GetAllTreesAsync(int userId);

        /// <summary>
        /// Retrieves all trees associated with the provided green area for the given user.
        /// </summary>
        /// <param name="greenAreaId">Identifier of the green area.</param>
        /// <param name="userId">Identifier of the owner.</param>
        Task<List<Tree>> GetTreesByGreenAreaIdAsync(int greenAreaId, int userId);

        /// <summary>
        /// Updates an existing tree that belongs to the specified user.
        /// </summary>
        /// <param name="treeId">Identifier of the tree to update.</param>
        /// <param name="request">Updated tree data.</param>
        /// <param name="userId">Identifier of the owner.</param>
        Task<Tree?> UpdateTreeAsync(int treeId, UpdateTreeDto request, int userId);

        /// <summary>
        /// Deletes the specified tree if it belongs to the user.
        /// </summary>
        /// <param name="treeId">Identifier of the tree to delete.</param>
        /// <param name="userId">Identifier of the owner.</param>
        Task<bool> DeleteTreeAsync(int treeId, int userId);
    }
}
