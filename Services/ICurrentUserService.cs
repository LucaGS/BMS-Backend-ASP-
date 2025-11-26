namespace DotNet8.WebApi.Services
{
    /// <summary>
    /// Provides access to the current authenticated user identity extracted from the HTTP context.
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>
        /// Gets the user id if present on the principal; otherwise null.
        /// </summary>
        int? UserId { get; }

        /// <summary>
        /// Attempts to read the user id from the current principal.
        /// </summary>
        bool TryGetUserId(out int userId);

        /// <summary>
        /// Indicates whether the current principal is authenticated.
        /// </summary>
        bool IsAuthenticated { get; }
    }
}
