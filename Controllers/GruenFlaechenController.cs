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
            GruenFlaeche gruenFlaeche = await gruenFlaecheService.CreateGruenFlaeche(request);
            return Ok(gruenFlaeche);

        }
    }
}
