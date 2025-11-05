using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.WebApi.Controllers
{
    [Authorize]
    public class KontrollenController(IKontrolleService kontrolleService, ICurrentUserService currentUserService) : Controller
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateKontrolle([FromBody] CreateKontrolleDto request)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("Benutzer-ID nicht im Token gefunden.");
            }
         return Ok(await kontrolleService.CreateKontrolleAsync(request, userId));
        }
        [HttpGet("ByBaumId/{baumId}")]
        public async Task<IActionResult> GetKontrollenByBaumId(int baumId)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("Benutzer-ID nicht im Token gefunden.");
            }
            var kontrollen = await kontrolleService.GetKontrollenByBaumIdAsync(baumId, userId);
            return Ok(kontrollen);
        }
    }
}
