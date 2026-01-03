using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GreenAreasController(IGreenAreaService greenAreaService, ICurrentUserService currentUserService) : Controller
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateGreenArea(CreateGreenAreaDto request)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var greenArea = await greenAreaService.CreateGreenArea(request, userId);
            return Ok(greenArea);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllGreenAreas()
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var greenAreas = await greenAreaService.GetGreenAreas(userId);
            return Ok(greenAreas);
        }

        [HttpPut("{greenAreaId}")]
        public async Task<IActionResult> UpdateGreenArea(int greenAreaId, UpdateGreenAreaDto request)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var updatedGreenArea = await greenAreaService.UpdateGreenAreaAsync(greenAreaId, request, userId);
            if (updatedGreenArea == null)
            {
                return NotFound();
            }

            return Ok(updatedGreenArea);
        }

        [HttpDelete("{greenAreaId}")]
        public async Task<IActionResult> DeleteGreenArea(int greenAreaId)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var deleted = await greenAreaService.DeleteGreenAreaAsync(greenAreaId, userId);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
