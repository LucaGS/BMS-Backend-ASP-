using System.Security.Claims;
using DotNet8.WebApi.Services;
using Microsoft.AspNetCore.Http;

namespace DotNet8.ScalarWebApi.Tests;

public class CurrentUserServiceTests
{
    [Fact]
    public void UserIdAndIsAuthenticated_AvailableWhenClaimsPresent()
    {
        var context = new DefaultHttpContext
        {
            User = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new[] { new Claim(ClaimTypes.NameIdentifier, "42") },
                    authenticationType: "Test"))
        };

        var service = new CurrentUserService(new HttpContextAccessor { HttpContext = context });

        Assert.Equal(42, service.UserId);
        Assert.True(service.TryGetUserId(out var userId));
        Assert.Equal(42, userId);
        Assert.True(service.IsAuthenticated);
    }

    [Fact]
    public void UserIdAndIsAuthenticated_UnavailableWhenNoUser()
    {
        var service = new CurrentUserService(new HttpContextAccessor());

        Assert.Null(service.UserId);
        Assert.False(service.TryGetUserId(out _));
        Assert.False(service.IsAuthenticated);
    }
}
