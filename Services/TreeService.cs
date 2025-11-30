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
                NumberOfTrunks = request.NumberOfTrunks,
                TrunkDiameter1 = request.TrunkDiameter1,
                TrunkDiameter2 = request.TrunkDiameter2,
                TrunkDiameter3 = request.TrunkDiameter3

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
