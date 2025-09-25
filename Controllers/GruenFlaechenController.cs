using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GruenFlaechenController(IGruenFlaecheService gruenFlaecheService, ICurrentUserService currentUserService) : Controller
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateGruenFlaeche(CreateGruenFlaecheDto request)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("Benutzer-ID nicht im Token gefunden.");
            }

            var gruenFlaeche = await gruenFlaecheService.CreateGruenFlaeche(request, userId);
            return Ok(gruenFlaeche);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult>GetAllGruenFlaechen()
        {
            if(!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("Benutzer-Id nicht im Token gefunden");
                
            }
            var gruenFlaechen = await gruenFlaecheService.GetGruenFlaechen(userId);
            return Ok(gruenFlaechen);
        }
    }
}
