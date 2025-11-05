using DotNet8.WebApi.Data;
using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.WebApi.Services
{
    public class BaumService(AppDbContext context) : IBaumService
    {
        public async Task<Baum> CreateBaumAsync(CreateBaumDto request, int userId)
        {
            var baum = new Baum
            {
                UserId = userId,
                Nummer = request.Nummer,
                Art = request.Art,
                GruenFlaechenId = request.GruenFlaechenId,
                Breitengrad = request.Breitengrad,
                Laengengrad = request.Laengengrad
            };
            //test if nummer is already taken for this user
            if(context.Baeume.Any(b => b.UserId == userId && b.Nummer == request.Nummer))
            {
                return null;
            }
            await context.Baeume.AddAsync(baum);
            await context.SaveChangesAsync();

            return baum;
        }

        public async Task<List<Baum>> GetAllBaeumeAsync(int userId)
        {
            return await context.Baeume
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<Baum>> GetBaeumeByGruenFlaechenIdAsync(int gruenFlaechenId, int userId)
        {
            return await context.Baeume
                .Where(b => b.GruenFlaechenId == gruenFlaechenId && b.UserId == userId)
                .ToListAsync();
        }
    }
}
