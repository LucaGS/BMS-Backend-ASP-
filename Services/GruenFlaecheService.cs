namespace DotNet8.WebApi.Services
{
    using DotNet8.WebApi.Data;
    using DotNet8.WebApi.Dtos;
    using DotNet8.WebApi.Entities;
    using Microsoft.EntityFrameworkCore;

    public class GruenFlaecheService(AppDbContext context) : IGruenFlaecheService
    {
        public async Task<GruenFlaeche> CreateGruenFlaeche(CreateGruenFlaecheDto request, int userId)
        {
            var gruenFlaeche = new GruenFlaeche
            {
                Name = request.Name,
                userId = userId,
            };

            context.GruenFlaechen.Add(gruenFlaeche);
            await context.SaveChangesAsync();
            return gruenFlaeche;
        }

        public async Task<List<GruenFlaeche>> GetGruenFlaechen(int userId)
        {
            return await context.GruenFlaechen
                .Where(g => g.userId == userId)
                .ToListAsync();
        }
    }
}
