using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DotNet8.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaumController : ControllerBase
    {
        [HttpPost("/create")]
        public Task<ActionResult<int>> CreateBaum(CreateBaumDto newBaum)
        {
            var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdValue))
            {
                // Benutzer-ID aus dem JWT-Token im Header extrahieren
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "sub" || c.Type == "userid" || c.Type == "Id");
                if (userIdClaim == null)
                {
                    return Task.FromResult<ActionResult<int>>(Unauthorized("Benutzer-ID nicht im Token gefunden."));
                }

                userIdValue = userIdClaim.Value;
            }

            if (!int.TryParse(userIdValue, out var userId))
            {
                return Task.FromResult<ActionResult<int>>(Unauthorized("Benutzer-ID nicht im Token gefunden."));
            }

            // Optional: userId weiterverwenden
            return Task.FromResult<ActionResult<int>>(Ok(userId));
        }
    }
}
