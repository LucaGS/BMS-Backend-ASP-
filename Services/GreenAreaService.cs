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
    }
}
