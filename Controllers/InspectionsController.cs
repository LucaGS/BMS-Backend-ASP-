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
            var inspection = await InspectionService.GetInspectionById(inspectionId);
            return Ok(inspection);
        }
    }
}
