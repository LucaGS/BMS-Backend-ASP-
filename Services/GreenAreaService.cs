namespace DotNet8.WebApi.Services
{
    using DotNet8.WebApi.Data;
    using DotNet8.WebApi.Dtos;
    using DotNet8.WebApi.Entities;
    using Microsoft.EntityFrameworkCore;

    public class GreenAreaService(AppDbContext context) : IGreenAreaService
    {
        public async Task<GreenArea> CreateGreenArea(CreateGreenAreaDto request, int userId)
        {
            var greenArea = new GreenArea
            {
                Name = request.Name,
                UserId = userId,
                Longitude = request.Longitude,
                Latitude = request.Latitude

            };

            context.GreenAreas.Add(greenArea);
            await context.SaveChangesAsync();
            return greenArea;
        }

        public async Task<List<GreenArea>> GetGreenAreas(int userId)
        {
            return await context.GreenAreas
                .Where(area => area.UserId == userId)
                .ToListAsync();
        }

        public async Task<GreenArea?> UpdateGreenAreaAsync(int greenAreaId, UpdateGreenAreaDto request, int userId)
        {
            var greenArea = await context.GreenAreas.SingleOrDefaultAsync(area =>
                area.Id == greenAreaId && area.UserId == userId);
            if (greenArea == null)
            {
                return null;
            }

            greenArea.Name = request.Name;
            greenArea.Longitude = request.Longitude;
            greenArea.Latitude = request.Latitude;

            await context.SaveChangesAsync();
            return greenArea;
        }

        public async Task<bool> DeleteGreenAreaAsync(int greenAreaId, int userId)
        {
            var greenArea = await context.GreenAreas.SingleOrDefaultAsync(area =>
                area.Id == greenAreaId && area.UserId == userId);
            if (greenArea == null)
            {
                return false;
            }

            context.GreenAreas.Remove(greenArea);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
