using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;

namespace DotNet8.WebApi.Services
{
    /// <summary>
    /// Defines operations for creating and updating tree records.
    /// </summary>
    public interface IBaumService
    {
        /// <summary>
        /// Persists a new tree with the supplied data and returns it.
        /// </summary>
        /// <param name="nummer">The identifying number of the tree.</param>
        /// <param name="art">The species or type of the tree.</param>
        Task<Baum> CreateBaumAsync(CreateBaumDto request, int userId);
        Task<List<Baum>> GetAllBaeumeAsync(int userId);
    }
}
