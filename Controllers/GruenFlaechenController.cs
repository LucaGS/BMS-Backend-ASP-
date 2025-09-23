using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Services;
using DotNet8.WebApi.Entities;
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
            // Benutzer-ID aus dem JWT-Token im Header extrahieren
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "sub" || c.Type == "userid" || c.Type == "id");
            if (userIdClaim == null)
            {
                return Unauthorized("Benutzer-ID nicht im Token gefunden.");
            }
            var userId = userIdClaim.Value;
            GruenFlaeche gruenFlaeche = await gruenFlaecheService.CreateGruenFlaeche(request, int.Parse(userId));
            return Ok(gruenFlaeche);

        }
    }
}
