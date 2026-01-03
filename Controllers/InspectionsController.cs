using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class InspectionsController(IInspectionService inspectionService, ICurrentUserService currentUserService) : Controller
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateInspection([FromBody] CreateInspectionDto request)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var inspection = await inspectionService.CreateInspectionAsync(request, userId);
            return Ok(inspection);
        }

        [HttpGet("ByTreeId/{treeId}")]
        public async Task<IActionResult> GetInspectionsByTreeId(int treeId)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var inspections = await inspectionService.GetInspectionsByTreeIdAsync(treeId, userId);
            return Ok(inspections);
        }
        [HttpGet("{inspectionId}")]
        public async Task<IActionResult> GetInspectionById(int inspectionId)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }
            var inspection = await inspectionService.GetInspectionByIdAsync(inspectionId, userId);
            if (inspection == null)
            {
                return NotFound();
            }

            return Ok(inspection);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllInspections()
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var inspections = await inspectionService.GetAllInspectionsAsync(userId);
            return Ok(inspections);
        }

        [HttpPut("{inspectionId}")]
        public async Task<IActionResult> UpdateInspection(int inspectionId, UpdateInspectionDto request)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            try
            {
                var updated = await inspectionService.UpdateInspectionAsync(inspectionId, request, userId);
                if (updated == null)
                {
                    return NotFound();
                }

                return Ok(updated);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{inspectionId}")]
        public async Task<IActionResult> DeleteInspection(int inspectionId)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var deleted = await inspectionService.DeleteInspectionAsync(inspectionId, userId);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
