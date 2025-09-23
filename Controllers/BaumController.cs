using DotNet8.WebApi.Dtos;
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
        public async Task<ActionResult<int>> CreateBaum(CreateBaumDto newBaum)
        {

            var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdValue))

            // Benutzer-ID aus dem JWT-Token im Header extrahieren
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "sub" || c.Type == "userid" || c.Type == "Id");
            if (userIdClaim == null)

            {
                return Unauthorized("Benutzer-ID nicht im Token gefunden.");
            }

            if (!int.TryParse(userIdValue, out var userId))
            {
                return Unauthorized("Benutzer-ID nicht im Token gefunden.");
            }

            _ = userId;

            var baumId = 11;
            // Optional: userId weiterverwenden
            return Ok(baumId);
        }
    }
}
