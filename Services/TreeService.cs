using DotNet8.WebApi.Data;
using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.WebApi.Services
{
    public class TreeService(AppDbContext context) : ITreeService
    {
        public async Task<Tree?> CreateTreeAsync(CreateTreeDto request, int userId)
        {
            if (await context.Trees.AnyAsync(tree => tree.UserId == userId && tree.Number == request.Number))
            {
                return null;
            }

            var tree = new Tree
            {
                UserId = userId,
                Number = request.Number,
                Species = request.Species,
                GreenAreaId = request.GreenAreaId,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                CrownDiameterMeters = request.CrownDiameterMeters,
                CrownAttachmentHeightMeters = request.CrownAttachmentHeightMeters,
                NumberOfTrunks = request.NumberOfTrunks,
                TrunkInclination = request.TrunkInclination

            };

            await context.Trees.AddAsync(tree);
            await context.SaveChangesAsync();

            return tree;
        }

        public async Task<List<Tree>> GetAllTreesAsync(int userId)
        {
            return await context.Trees
                .Where(tree => tree.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<Tree>> GetTreesByGreenAreaIdAsync(int greenAreaId, int userId)
        {
            return await context.Trees
                .Where(tree => tree.GreenAreaId == greenAreaId && tree.UserId == userId)
                .ToListAsync();
        }
    }
}
