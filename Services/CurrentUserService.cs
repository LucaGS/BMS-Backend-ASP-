using DotNet8.WebApi.Extensions;
using Microsoft.AspNetCore.Http;

namespace DotNet8.WebApi.Services
{
    /// <summary>
    /// Reads user identity information from the current HTTP context (supports multiple claim types).
    /// </summary>
    public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
     {  
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public int? UserId => _httpContextAccessor.HttpContext?.User.GetUserId();

        public bool TryGetUserId(out int userId)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            return user.TryGetUserId(out userId);
        }

        public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}
