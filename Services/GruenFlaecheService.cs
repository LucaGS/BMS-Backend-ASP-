namespace DotNet8.WebApi.Services
{
    using DotNet8.WebApi.Data;
    using DotNet8.WebApi.Dtos;
    using DotNet8.WebApi.Entities;
    public class GruenFlaecheService(AppDbContext context, IConfiguration configuration) : IGruenFlaecheService
    {
        public Task<GruenFlaeche> CreateGruenFlaeche(CreateGruenFlaecheDto request)
        {
            GruenFlaeche gruenFlaeche = new GruenFlaeche
            {
                Name = request.Name,

            };
            context.GruenFlaechen.Add(gruenFlaeche);
            context.SaveChanges();
            return Task.FromResult(gruenFlaeche);
        }
        public Task<GruenFlaeche[]> GetGruenFlaechen()
        {
            throw new NotImplementedException();
        }
    }
}
