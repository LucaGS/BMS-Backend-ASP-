using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DotNet8.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GruenFlaechenController(IGruenFlaecheService gruenFlaecheService) : Controller
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateGruenFlaeche(CreateGruenFlaecheDto request)
        {
            var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdValue))
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "sub" || c.Type == "userid" || c.Type == "Id");
                if (userIdClaim == null)
                {
                    return Unauthorized("Benutzer-ID nicht im Token gefunden.");
                }

                userIdValue = userIdClaim.Value;
            }

            if (!int.TryParse(userIdValue, out var userId))
            {
                return Unauthorized("Benutzer-ID nicht im Token gefunden.");
            }

            var gruenFlaeche = await gruenFlaecheService.CreateGruenFlaeche(request, userId);
            return Ok(gruenFlaeche);
        }
    }
}
