namespace DotNet8.WebApi.Services
{
    using DotNet8.WebApi.Data;
    using DotNet8.WebApi.Dtos;
    using DotNet8.WebApi.Entities;
    public class GruenFlaecheService(AppDbContext context, IConfiguration configuration) : IGruenFlaecheService
    {
        public Task<GruenFlaeche> CreateGruenFlaeche(CreateGruenFlaecheDto request, int userId)
        {
            GruenFlaeche gruenFlaeche = new GruenFlaeche
            {
                Name = request.Name,
                userId = userId,

            };
            context.GruenFlaechen.Add(gruenFlaeche);
            context.SaveChanges();
            return Task.FromResult(gruenFlaeche);
        }
        public Task<List<GruenFlaeche>> GetGruenFlaechen(int userId)
        {
            var gruenFlaechen = context.GruenFlaechen.Where(g => g.userId == userId).ToList();
            return Task.FromResult(gruenFlaechen);
        }
    }
}
