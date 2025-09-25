using DotNet8.WebApi.Extensions;
using Microsoft.AspNetCore.Http;

namespace DotNet8.WebApi.Services
{    // Handels extracting User id from token
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
