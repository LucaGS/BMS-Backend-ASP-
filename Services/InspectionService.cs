namespace DotNet8.WebApi.Services
{
    using DotNet8.WebApi.Data;
    using DotNet8.WebApi.Dtos;
    using DotNet8.WebApi.Entities;
    using Microsoft.EntityFrameworkCore;

    public class InspectionService(AppDbContext context) : IInspectionService
    {
        public async Task<Inspection> CreateInspectionAsync(CreateInspectionDto request, int userId)
        {
            var inspection = new Inspection
            {
                TreeId = request.TreeId,
                PerformedAt = DateTime.UtcNow,
                IsSafeForTraffic = request.IsSafeForTraffic,
                UserId = userId
            };

            context.Inspections.Add(inspection);
            await context.SaveChangesAsync();
            return inspection;
        }

        public Task<bool> DeleteInspectionAsync(int inspectionId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Inspection>> GetAllInspectionsAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Inspection> GetInspectionByIdAsync(int inspectionId, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Inspection>> GetInspectionsByTreeIdAsync(int treeId, int userId)
        {
            return await context.Inspections
                .Where(inspection => inspection.TreeId == treeId && inspection.UserId == userId)
                .ToListAsync();
        }
    }
}
