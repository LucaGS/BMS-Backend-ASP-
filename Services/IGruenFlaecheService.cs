using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;

namespace DotNet8.WebApi.Services
{
    public interface IGruenFlaecheService
    {
        Task<GruenFlaeche> CreateGruenFlaeche(CreateGruenFlaecheDto request);
        Task<GruenFlaeche[]> GetGruenFlaechen();
    }
}
