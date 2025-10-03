using DotNet8.WebApi.Data;
using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;

namespace DotNet8.WebApi.Services
{
    public class BaumService(AppDbContext context, IConfiguration configuration) : IBaumService
    {
        
        public Task<Baum> CreateBaumAsync(CreateBaumDto request, int userId)
        {
           Baum baum = new Baum            {
                UserId = userId,
                Nummer = request.Nummer,
                Art = request.Art,
                GruenFlächenId = request.GruenFlaechenId,
                Breitengrad = request.Breitengrad,
                Laengengrad = request.Laengengrad
           };
            context.Baeume.Add(baum);
            context.SaveChangesAsync();
            return Task.FromResult(baum);

        }
        public Task<List<Baum>> GetAllBaeumeAsync(int userId)
        {
            var baeume = context.Baeume.Where(b => b.UserId == userId).ToList();
            return Task.FromResult(baeume);
        }
        public object? GetBaeumeByGruenFlaechenIdAsync(int gruenFlaechenId, int userId)
        {
            var baeume = context.Baeume.Where(b => b.GruenFlächenId == gruenFlaechenId && b.UserId == userId).ToList();
            return baeume;
        }

    }
}
