using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DotNet8.WebApi.Data;
using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using DotNet8.WebApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DotNet8.ScalarWebApi.Tests
{
    public class AuthServiceTests
    {
        [Fact]
        public async Task LoginAsync_ShouldIncludeUserIdClaim()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            await using var context = new AppDbContext(options);

            var user = new User
            {
                Username = "testuser",
                Email = "test@example.com"
            };

            user.HashedPassword = new PasswordHasher<User>()
                .HashPassword(user, "P@ssw0rd!");

            context.Users.Add(user);
            await context.SaveChangesAsync();

            var inMemorySettings = new Dictionary<string, string?>
            {
                {"AppSettings:Token", "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef"},
                {"AppSettings:Issuer", "TestIssuer"},
                {"AppSettings:Audience", "TestAudience"}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var authService = new AuthService(context, configuration);
            var loginRequest = new UserDto
            {
                Username = user.Username,
                Password = "P@ssw0rd!"
            };

            var token = await authService.LoginAsync(loginRequest);

            Assert.NotNull(token);

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            var idClaim = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            Assert.NotNull(idClaim);
            Assert.Equal(user.Id.ToString(), idClaim!.Value);
        }
    }
}
