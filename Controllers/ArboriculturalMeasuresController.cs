using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArboriculturalMeasuresController(ICurrentUserService currentUserService, IArboriculturalMeasuresService measuresService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllArboriculturalMeasures()
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }
            var measures = await measuresService.GetArboriculturalMeasuresAsync(userId);
            return Ok(measures);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateArboriculturalMeasure(CreateArboriculturalMeasuresDto request)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }
            var measure = await measuresService.CreateArboriculturalMeasureAsync(request, userId);
            return Ok(measure);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArboriculturalMeasure(int id, UpdateArboriculturalMeasuresDto request)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var updated = await measuresService.UpdateArboriculturalMeasureAsync(id, request, userId);
            if (updated == null)
            {
                return NotFound();
            }

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArboriculturalMeasure(int id)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var deleted = await measuresService.DeleteArboriculturalMeasureAsync(id, userId);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
