using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using DotNet8.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaumController(ICurrentUserService currentUserService, IBaumService baumService) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateBaum(CreateBaumDto newBaum)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("Benutzer-ID nicht im Token gefunden.");
            }

            var createdBaum = await baumService.CreateBaumAsync(newBaum, userId);
            if(createdBaum == null)
            {
                return BadRequest("Ein Baum mit dieser Nummer existiert bereits.");
            }
            return Ok(createdBaum);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Baum>>> GetAllBaeume()
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("Benutzer-ID nicht im Token gefunden.");
            }

            var baeume = await baumService.GetAllBaeumeAsync(userId);
            return Ok(baeume);
        }

        [HttpGet("GetByGruenFlaechenId/{gruenFlaechenId}")]
        public async Task<ActionResult<List<Baum>>> GetBaeumeByGruenFlaechenId(int gruenFlaechenId)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("Benutzer-ID nicht im Token gefunden.");
            }

            var baeume = await baumService.GetBaeumeByGruenFlaechenIdAsync(gruenFlaechenId, userId);
            return Ok(baeume);
        }
    }
}
