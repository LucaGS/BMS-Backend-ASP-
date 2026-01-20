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
                CrownShape = request.CrownShape,
                TrafficSafetyExpectation = request.TrafficSafetyExpectation,
                TreeSizeMeters = request.TreeSizeMeters,
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

        public async Task<Tree?> UpdateTreeAsync(int treeId, UpdateTreeDto request, int userId)
        {
            var tree = await context.Trees.SingleOrDefaultAsync(t => t.Id == treeId && t.UserId == userId);
            if (tree == null)
            {
                return null;
            }

            var numberInUse = await context.Trees
                .AnyAsync(t => t.UserId == userId && t.Number == request.Number && t.Id != treeId);
            if (numberInUse)
            {
                throw new InvalidOperationException("A tree with this number already exists.");
            }

            tree.GreenAreaId = request.GreenAreaId;
            tree.Number = request.Number;
            tree.Species = request.Species;
            tree.Latitude = request.Latitude;
            tree.Longitude = request.Longitude;
            tree.CrownDiameterMeters = request.CrownDiameterMeters;
            tree.CrownShape = request.CrownShape;
            tree.TrafficSafetyExpectation = request.TrafficSafetyExpectation;
            tree.TreeSizeMeters = request.TreeSizeMeters;
            tree.NumberOfTrunks = request.NumberOfTrunks;
            tree.TrunkDiameter1 = request.TrunkDiameter1;
            tree.TrunkDiameter2 = request.TrunkDiameter2;
            tree.TrunkDiameter3 = request.TrunkDiameter3;

            await context.SaveChangesAsync();
            return tree;
        }

        public async Task<bool> DeleteTreeAsync(int treeId, int userId)
        {
            var tree = await context.Trees.SingleOrDefaultAsync(t => t.Id == treeId && t.UserId == userId);
            if (tree == null)
            {
                return false;
            }

            context.Trees.Remove(tree);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Tree?> GetLastCreatedTree(int userId)
        {   
            //Find Last Created Trre of the User
            var tree = await context.Trees
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.Id)
                .FirstOrDefaultAsync();
            
            return tree;


        }
    }
}
