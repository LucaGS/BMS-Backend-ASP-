using DotNet8.WebApi.Data;
using DotNet8.WebApi.Services;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.ScalarWebApi.Tests;

public static class TestingHelpers
{
    public static AppDbContext CreateContext(string? databaseName = null)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName ?? Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }
}

public class FakeCurrentUserService(int? userId, bool isAuthenticated = true) : ICurrentUserService
{
    public int? UserId => userId;

    public bool TryGetUserId(out int id)
    {
        if (userId.HasValue)
        {
            id = userId.Value;
            return true;
        }

        id = 0;
        return false;
    }

    public bool IsAuthenticated => isAuthenticated;
}
