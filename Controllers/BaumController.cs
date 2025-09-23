using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaumController : ControllerBase    
    {
        [HttpPost("/create")]
        public async Task<ActionResult<int>> CreateBaum(CreateBaumDto newBaum)
        {
            // Benutzer-ID aus dem JWT-Token im Header extrahieren
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "sub" || c.Type == "userid" || c.Type == "id" || c.Type == "Id");
            if (userIdClaim == null)
            {
                return Unauthorized("Benutzer-ID nicht im Token gefunden.");
            }
            var userId = userIdClaim.Value;

            var baumId = 11;
            // Optional: userId weiterverwenden
            return Ok(baumId);
        }
       

    }
}
