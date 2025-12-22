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
    public class TreesController(ICurrentUserService currentUserService, ITreeService treeService) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateTree(CreateTreeDto newTree)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var createdTree = await treeService.CreateTreeAsync(newTree, userId);
            if (createdTree == null)
            {
                return BadRequest("A tree with this number already exists.");
            }

            return Ok(createdTree);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Tree>>> GetAllTrees()
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var trees = await treeService.GetAllTreesAsync(userId);
            return Ok(trees);
        }

        [HttpGet("GetByGreenAreaId/{greenAreaId}")]
        public async Task<ActionResult<List<Tree>>> GetTreesByGreenAreaId(int greenAreaId)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var trees = await treeService.GetTreesByGreenAreaIdAsync(greenAreaId, userId);
            return Ok(trees);
        }

        [HttpPut("{treeId}")]
        public async Task<IActionResult> UpdateTree(int treeId, UpdateTreeDto request)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            try
            {
                var updatedTree = await treeService.UpdateTreeAsync(treeId, request, userId);
                if (updatedTree == null)
                {
                    return NotFound();
                }

                return Ok(updatedTree);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{treeId}")]
        public async Task<IActionResult> DeleteTree(int treeId)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var deleted = await treeService.DeleteTreeAsync(treeId, userId);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
