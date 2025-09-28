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
        [HttpPost("/create")]
        public ActionResult<int> CreateBaum(CreateBaumDto newBaum)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("Benutzer-ID nicht im Token gefunden.");
            }
            var createdBaumId  =  baumService.CreateBaumAsync(newBaum, userId);
            return Ok(createdBaumId);
        }
        [HttpGet("/GetAll")]
        public ActionResult<List<Baum>> GetAllBaeume()
        {
            if(!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("Benutzer-ID nicht im Token gefunden.");
            }
            return Ok(baumService.GetAllBaeumeAsync(userId));
        }
    }
}
