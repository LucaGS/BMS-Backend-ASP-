namespace DotNet8.WebApi.Services
{
    public interface ICurrentUserService
    {
        int? UserId { get; }
        bool TryGetUserId(out int userId);
        bool IsAuthenticated { get; }
    }
}
