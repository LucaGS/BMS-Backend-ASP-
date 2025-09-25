using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DotNet8.WebApi.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        private static readonly string[] ClaimTypesPreferred = new[]
        {
            ClaimTypes.NameIdentifier,
            JwtRegisteredClaimNames.Sub,
            "userid",
            "Id"
        };

        public static bool TryGetUserId(this ClaimsPrincipal? principal, out int userId)
        {
            userId = default;
            if (principal == null)
            {
                return false;
            }

            foreach (var claimType in ClaimTypesPreferred)
            {
                var value = principal.FindFirstValue(claimType);
                if (!string.IsNullOrWhiteSpace(value) && int.TryParse(value, out userId))
                {
                    return true;
                }
            }

            return false;
        }

        public static int? GetUserId(this ClaimsPrincipal? principal)
        {
            return principal.TryGetUserId(out var userId) ? userId : null;
        }
    }
}
