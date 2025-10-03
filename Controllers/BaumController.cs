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
    public class BaumController(ICurrentUserService currentUserService, IBaumService baumService ): ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateBaum(CreateBaumDto newBaum)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("Benutzer-ID nicht im Token gefunden.");
            }
              return Ok(baumService.CreateBaumAsync(newBaum, userId));
        }
        //Todo: Fix why this returns Baum Entities with small a in art 
        [HttpGet("GetAll")]
        public ActionResult<List<Baum>> GetAllBaeume()
        {
            if(!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("Benutzer-ID nicht im Token gefunden.");
            }
            return Ok(baumService.GetAllBaeumeAsync(userId));
        }

        [HttpGet("GetByGruenFlaechenId/{gruenFlaechenId}")]
        public ActionResult<List<Baum>> GetBaeumeByGruenFlaechenId(int gruenFlaechenId)
        {
            if(!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("Benutzer-ID nicht im Token gefunden.");
            }
            return Ok(baumService.GetBaeumeByGruenFlaechenIdAsync(gruenFlaechenId, userId));
        }
    }
}
