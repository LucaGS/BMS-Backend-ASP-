using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using DotNet8.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.WebApi.Controllers
{
    //Handels all request regarding Authentication
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user = await authService.RegisterAsync(request);
            if (user == null)
            {
                return BadRequest("User already exists");
            }
            var token = await authService.LoginAsync(request);
            return Ok(new { token });
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>>Login(UserDto request)
        {
            var token = await authService.LoginAsync(request);
            if(token == null)
            {
                return BadRequest("Wrong credentials");
            }
            return Ok(new {token});
        }

       


    }
}
