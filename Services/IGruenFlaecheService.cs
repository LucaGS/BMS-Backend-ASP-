using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;

namespace DotNet8.WebApi.Services
{
    /// <summary>
    /// Provides operations for managing green area entities per user.
    /// </summary>
    public interface IGruenFlaecheService
    {
        /// <summary>
        /// Creates a new green area for the specified user.
        /// </summary>
        /// <param name="request">The creation payload supplied by the client.</param>
        /// <param name="userId">The identifier of the owning user.</param>
        Task<GruenFlaeche> CreateGruenFlaeche(CreateGruenFlaecheDto request, int userId);

        /// <summary>
        /// Retrieves all green areas that belong to the given user.
        /// </summary>
        /// <param name="userId">The identifier of the owning user.</param>
        Task<List<GruenFlaeche>> GetGruenFlaechen(int userId);
    }
}
