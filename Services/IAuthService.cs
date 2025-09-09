using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;

namespace DotNet8.WebApi.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<string?> LoginAsync(UserDto request);
    }
}
