using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImagesController(ICurrentUserService currentUserService , IImageService imageService) : Controller
    {

        [HttpGet("GetImages/{treeId}")]
        public async Task<IActionResult> GetImages(int treeId)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }
            var images = await imageService.GetImages(treeId, userId);
            return Ok(images);
        }
        [HttpPost("CreateImage")]
        public async Task<IActionResult> CreateImage(CreateImageDto request)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }
            var image = await imageService.CreateImage(request, userId);
            return Ok(image);
        }

        [HttpPut("{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, UpdateImageDto request)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var updated = await imageService.UpdateImageAsync(imageId, request, userId);
            if (updated == null)
            {
                return NotFound();
            }

            return Ok(updated);
        }

        [HttpDelete("{imageId}")]
        public async Task<IActionResult> DeleteImage(int imageId)
        {
            if (!currentUserService.TryGetUserId(out var userId))
            {
                return Unauthorized("User ID not found in token.");
            }

            var deleted = await imageService.DeleteImageAsync(imageId, userId);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
