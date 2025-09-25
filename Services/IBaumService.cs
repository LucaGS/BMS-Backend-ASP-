namespace DotNet8.WebApi.Services
{
    /// <summary>
    /// Defines operations for creating and updating tree records.
    /// </summary>
    public interface IBaumService
    {
        /// <summary>
        /// Persists a new tree with the supplied data and returns its identifier.
        /// </summary>
        /// <param name="nummer">The identifying number of the tree.</param>
        /// <param name="art">The species or type of the tree.</param>
        Task<int> CreateBaumAsync(int nummer, string art);

        /// <summary>
        /// Updates an existing tree with new details.
        /// </summary>
        /// <param name="id">The identifier of the tree to update.</param>
        /// <param name="nummer">The new identifying number.</param>
        /// <param name="art">The updated species or type.</param>
        Task<int> UpdateBaumAsync(int id, int nummer, string art);
    }
}
