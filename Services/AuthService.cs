using DotNet8.WebApi.Data;
using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotNet8.WebApi.Services
{
    public class AuthService(AppDbContext context , IConfiguration configuration) : IAuthService
    {
        public async Task<string?> LoginAsync(UserDto request)
        {
            var user = await context.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user == null)
            {
                return null;
            }
            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.HashedPassword, request.Password)
                == PasswordVerificationResult.Failed)
            {
                return null;
            }
             return CreateToken(user);
            
        }

        public async Task<User?> RegisterAsync(UserDto request)
        {   
            if(await context.Users.AnyAsync(u => u.Username == request.Username))
            {
                return null;
            }
            var user = new User
            {
                Username = request.Username,

            };
            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.Password);
            user.HashedPassword = hashedPassword;
            context.Users.Add(user);
          await  context.SaveChangesAsync();
            return user;
        }


        private String CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
